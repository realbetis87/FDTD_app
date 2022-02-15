using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.IO;


using CSparse.Complex;
using CSparse.Complex.Solver;
using CSparse.Storage;
using Complex = System.Numerics.Complex;

namespace FDTD_app
{
    class ModalSolverModule
    {

        private static double e0 = 8.85418781762e-12;
        private static double m0 = 4 * Math.PI * 1e-7;

        private static double c0 = 1 / Math.Sqrt(m0 * e0);

        private double freq, k0;
        private int c2l;

        private double d;
        public int M, N;

        private int[,] idm;

        private SparseMatrix erx, ery, erz, erzx, erxz, ierz;
        private SparseMatrix A;

        public double InitializeDomain(CoreForm.domain dm1)
        {
            this.freq = dm1.freq;
            this.c2l = dm1.c2l;

            var l0 = c0 / this.freq;
            k0 = 2 * Math.PI * freq / c0;

            d = l0 / this.c2l;


            M = (int)Math.Round(dm1.limits[0] / d);
            N = (int)Math.Round(dm1.limits[1] / d);

            return d;
        }

        public void MakeMedium(Materials.material[] mat, int[,] voxel_matrix)
        {

            var voxel_final = CoreForm.resizePixels(voxel_matrix, N, M);

            idm = new int[N, M];

            for (int i = 0; i < N; i++)
            {
                for (int j = 0; j < M; j++)
                {
                    idm[i, j] = i + N * j;
                }
            }

            erx = speye(new SparseMatrix(N * M, N * M, N * M));
            ery = speye(new SparseMatrix(N * M, N * M, N * M));
            erz = speye(new SparseMatrix(N * M, N * M, N * M));
            ierz = speye(new SparseMatrix(N * M, N * M, N * M));

            erxz = spdiag(new SparseMatrix(N * M, N * M, N * M));
            erzx = spdiag(new SparseMatrix(N * M, N * M, N * M));

            for (int i = 0; i < N; i++)
            {
                for (int j = 0; j < M; j++)
                {
                    erx.Values[idm[i, j]] = mat[voxel_final[i, j] - 1].er;
                    ery.Values[idm[i, j]] = mat[voxel_final[i, j] - 1].er;
                    erz.Values[idm[i, j]] = mat[voxel_final[i, j] - 1].er;
                }
            }

        }

        public void GrapheneDefinition(GrapheneForm.grapheneProperties[] grapheneLayers, double[,] limits)
        {

            if (grapheneLayers != null)
            {
                int gr_cells;

                for (int i = 0; i < grapheneLayers.Length; i++)
                {


                    if (grapheneLayers[i].orientation == "x")
                    {
                        gr_cells = (int)Math.Round(grapheneLayers[i].length * 1e-6 / d);
                        var constant_point = (int)Math.Round((grapheneLayers[i].startPos[0] - limits[0, 0]) / (limits[0, 1] - limits[0, 0]) * (M - 1));
                        var starting_point = (int)Math.Round((grapheneLayers[i].startPos[1] - limits[1, 0]) / (limits[1, 1] - limits[1, 0]) * (N - 1));
                        (Complex sd, Complex so) = GrapheneConductivity.anisotropic_conductivity(grapheneLayers[i].temperature, grapheneLayers[i].gamma * 1e-3, grapheneLayers[i].mc, grapheneLayers[i].b0, freq);

                        for (int k = starting_point; k < starting_point + gr_cells; k++)
                        {
                            int j = constant_point;

                            erx.Values[idm[k, j]] -= new Complex(0, 1) * (sd / 2 / Math.PI / freq / e0) / d;
                            erz.Values[idm[k, j]] -= new Complex(0, 1) * (sd / 2 / Math.PI / freq / e0) / d;

                            erxz.Values[idm[k, j]] -= new Complex(0, 1) * (so / 2 / Math.PI / freq / e0) / d;
                            erzx.Values[idm[k, j]] += new Complex(0, 1) * (so / 2 / Math.PI / freq / e0) / d;
                        }

                        erz.Values[idm[starting_point + gr_cells, constant_point]] -= new Complex(0, 1) * (sd / 2 / Math.PI / freq / e0) / d;
                        erzx.Values[idm[starting_point + gr_cells, constant_point]] = new Complex(0, 1) * (so / 2 / Math.PI / freq / e0) / d;

                    }
                    else
                    {

                    }

                }

            }


            ierz = erz;
            for (int i = 0; i < ierz.Values.Length; i++)
            {
                ierz.Values[i] = 1 / ierz.Values[i];
            }


        }


        public void ConstructMatrix()
        {
            var Ux = new SparseMatrix(N * M, N * M, 2 * N * M);

            Ux.ColumnPointers[0] = 0;

            int jj = 0;

            for (int i = 0; i < N * M; i++)
            {
                if ((i % N) != 0)
                {
                    Ux.Values[jj] = 1 / d;
                    Ux.RowIndices[jj++] = i - 1;

                    Ux.Values[jj] = -1 / d;
                    Ux.RowIndices[jj++] = i;
                }
                Ux.ColumnPointers[i + 1] = jj;
            }

            var Vx = new SparseMatrix(N * M, N * M, 2 * N * M);
            Ux.Transpose(Vx);

            for (int i = 0; i < Vx.Values.Length; i++)
            {
                Vx.Values[i] = -Vx.Values[i];
            }


            var Uy = new SparseMatrix(N * M, N * M, 2 * N * M);

            Uy.ColumnPointers[0] = 0;

            jj = 0;

            for (int i = 0; i < N * M; i++)
            {
                if (i >= N)
                {
                    Uy.Values[jj] = 1 / d;
                    Uy.RowIndices[jj++] = i - N;

                    Uy.Values[jj] = -1 / d;
                    Uy.RowIndices[jj++] = i;
                }
                Uy.ColumnPointers[i + 1] = jj;
            }

            var Vy = new SparseMatrix(N * M, N * M, 2 * N * M);
            Uy.Transpose(Vy);

            for (int i = 0; i < Vy.Values.Length; i++)
            {
                Vy.Values[i] = -Vy.Values[i];
            }

            var Ain = new SparseMatrix(N * M, N * M, 3 * N * M);

            Ain.Clear();
            var A11 = new SparseMatrix(N * M, N * M, 3 * N * M); Ux.Multiply(ierz, Ain); Ain.Multiply(erzx, A11); A11 = MultiplyConstant(A11, new Complex(0, -1));
            var A12 = spdiag(new SparseMatrix(N * M, N * M, N * M));
            Ain.Clear();
            var A13 = new SparseMatrix(N * M, N * M, 3 * N * M); Ux.Multiply(ierz, Ain); Ain.Multiply(Vy, A13); A13 = MultiplyConstant(A13, new Complex(-1 / k0, 0));
            Ain.Clear();
            var A14 = new SparseMatrix(N * M, N * M, 3 * N * M); Ux.Multiply(ierz, Ain); Ain.Multiply(Vx, A14); A14.Add(new Complex(1 / k0, 0), new Complex(k0, 0), speye(new SparseMatrix(N * M, N * M, N * M)), A14);

            Ain.Clear();
            var A21 = new SparseMatrix(N * M, N * M, 3 * N * M); Uy.Multiply(ierz, Ain); Ain.Multiply(erzx, A21); A21 = MultiplyConstant(A21, new Complex(0, -1));
            var A22 = spdiag(new SparseMatrix(N * M, N * M, N * M));
            Ain.Clear();
            var A23 = new SparseMatrix(N * M, N * M, 3 * N * M); Uy.Multiply(ierz, Ain); Ain.Multiply(Vy, A23); A23.Add(new Complex(-1 / k0, 0), new Complex(-k0, 0), speye(new SparseMatrix(N * M, N * M, N * M)), A23);
            Ain.Clear();
            var A24 = new SparseMatrix(N * M, N * M, 3 * N * M); Uy.Multiply(ierz, Ain); Ain.Multiply(Vx, A24); A24 = MultiplyConstant(A24, new Complex(1 / k0, 0));

            var A31 = new SparseMatrix(N * M, N * M, 3 * N * M); Vx.Multiply(Uy, A31); A31 = MultiplyConstant(A31, new Complex(1 / k0, 0));
            Ain.Clear();
            var A32 = new SparseMatrix(N * M, N * M, 3 * N * M); Vx.Multiply(Ux, Ain); Ain.Add(new Complex(-1 / k0, 0), new Complex(-k0, 0), ery, A32);
            var A33 = spdiag(new SparseMatrix(N * M, N * M, N * M));
            var A34 = spdiag(new SparseMatrix(N * M, N * M, N * M));

            Ain.Clear();
            var A41 = new SparseMatrix(N * M, N * M, 3 * N * M); Vy.Multiply(Uy, Ain); Ain.Add(new Complex(1 / k0, 0), new Complex(k0, 0), erx, A41);
            Ain.Clear(); erxz.Multiply(ierz, Ain); Ain.Multiply(erzx, Ain); A41.Add(new Complex(1, 0), new Complex(-k0, 0), Ain, A41);
            var A42 = new SparseMatrix(N * M, N * M, 3 * N * M); Vy.Multiply(Ux, A42); A42 = MultiplyConstant(A42, new Complex(-1 / k0, 0));
            Ain.Clear();
            var A43 = new SparseMatrix(N * M, N * M, 3 * N * M); erxz.Multiply(ierz, Ain); Ain.Multiply(Vy, A43); A43 = MultiplyConstant(A43, new Complex(0, 1));
            Ain.Clear();
            var A44 = new SparseMatrix(N * M, N * M, 3 * N * M); erxz.Multiply(ierz, Ain); Ain.Multiply(Vx, A44); A44 = MultiplyConstant(A44, new Complex(0, -1));

            A = hstack(hstack(vstack(vstack(A11, A21), vstack(A31, A41)), vstack(vstack(A12, A22), vstack(A32, A42))), hstack(vstack(vstack(A13, A23), vstack(A33, A43)), vstack(vstack(A14, A24), vstack(A34, A44))));
            A = MultiplyConstant(A, new Complex(1 / k0, 0));

            A.DropZeros();


            Console.WriteLine("Matrix completed!");
        }


        public (Complex[], CSparse.Matrix<Complex>) ModeSolver(int modeNo, double eff)
        {
            Console.WriteLine(A.RowCount);
            var dprob = new Arpack(A) { ComputeEigenVectors = true };

            // Finding eigenvalues and eigenvectors.
            var result = dprob.SolveStandard(modeNo, new Complex(eff, 0.0));


            using (TextWriter tw = new StreamWriter("C:\\Users\\OFADC\\Desktop\\test1.txt"))
            {
                for (int i = 0; i < result.EigenVectors.RowCount; i++)
                {
                    for (int k = 0; k < result.EigenVectors.ColumnCount; k++)
                    {
                        if (result.EigenVectors.At(i, k).Imaginary >= 0)
                        {
                            tw.Write(result.EigenVectors.At(i, k).Real + "+" + result.EigenVectors.At(i, k).Imaginary + "i ");
                        }
                        else
                        {
                            tw.Write(result.EigenVectors.At(i, k).Real + "" + result.EigenVectors.At(i, k).Imaginary + "i ");
                        }

                    }
                    tw.WriteLine();
                }
            }

            return (result.EigenValues, result.EigenVectors);

        }

        public static SparseMatrix vstack(CompressedColumnStorage<System.Numerics.Complex> uMatrix, CompressedColumnStorage<System.Numerics.Complex> bMatrix)
        {
            if (uMatrix.ColumnCount == bMatrix.ColumnCount)
            {
                var m1 = uMatrix.RowCount;
                var m2 = bMatrix.RowCount;

                var nz1 = uMatrix.NonZerosCount;
                var nz2 = bMatrix.NonZerosCount;

                SparseMatrix fMatrix = new SparseMatrix(m1 + m2, uMatrix.ColumnCount, nz1 + nz2);

                var uv = uMatrix.Values;
                var ur = uMatrix.RowIndices;
                var up = uMatrix.ColumnPointers;

                var bv = bMatrix.Values;
                var br = bMatrix.RowIndices;
                var bp = bMatrix.ColumnPointers;

                var fv = fMatrix.Values;
                var fr = fMatrix.RowIndices;
                var fp = fMatrix.ColumnPointers;

                fp[0] = 0;

                int j = 0;

                for (int i = 0; i != uMatrix.ColumnCount; i++)
                {
                    for (int k = up[i]; k < up[i + 1]; k++)
                    {
                        fv[j] = uv[k];
                        fr[j] = ur[k];
                        j++;
                    }

                    for (int k = bp[i]; k < bp[i + 1]; k++)
                    {
                        fv[j] = bv[k];
                        fr[j] = br[k] + m1;
                        j++;
                    }

                    fp[i + 1] = j;
                }

                return fMatrix;

            }
            else
            {
                throw new InvalidOperationException("Matrix columns are not equal.");
            }

        }


        public static SparseMatrix hstack(CompressedColumnStorage<System.Numerics.Complex> lMatrix, CompressedColumnStorage<System.Numerics.Complex> rMatrix)
        {
            if (lMatrix.RowCount == rMatrix.RowCount)
            {
                var n1 = lMatrix.ColumnCount;
                var n2 = rMatrix.ColumnCount;

                var nz1 = lMatrix.NonZerosCount;
                var nz2 = rMatrix.NonZerosCount;

                SparseMatrix fMatrix = new SparseMatrix(lMatrix.RowCount, n1 + n2, nz1 + nz2);

                var lv = lMatrix.Values;
                var lr = lMatrix.RowIndices;
                var lp = lMatrix.ColumnPointers;

                var rv = rMatrix.Values;
                var rr = rMatrix.RowIndices;
                var rp = rMatrix.ColumnPointers;

                var fv = fMatrix.Values;
                var fr = fMatrix.RowIndices;
                var fp = fMatrix.ColumnPointers;

                fp[0] = 0;

                int j = 0;

                for (int i = 0; i != lMatrix.ColumnCount; i++)
                {
                    for (int k = lp[i]; k < lp[i + 1]; k++)
                    {
                        fv[j] = lv[k];
                        fr[j] = lr[k];
                        j++;
                    }

                    fp[i + 1] = j;
                }

                for (int i = 0; i != rMatrix.ColumnCount; i++)
                {
                    for (int k = rp[i]; k < rp[i + 1]; k++)
                    {
                        fv[j] = rv[k];
                        fr[j] = rr[k];
                        j++;
                    }

                    fp[i + lMatrix.ColumnCount + 1] = j;
                }


                return fMatrix;

            }
            else
            {
                throw new InvalidOperationException("Matrix rows are not equal.");
            }

        }


        private SparseMatrix speye(SparseMatrix A)
        {
            var N = A.RowCount;

            var ax = A.Values;
            var ai = A.RowIndices;
            var ap = A.ColumnPointers;

            ap[0] = 0;

            for (int i = 0; i < N; i++)
            {
                ax[i] = 1;
                ai[i] = i;
                ap[i + 1] = i + 1;
            }

            return A;
        }

        private SparseMatrix spdiag(SparseMatrix A)
        {
            var N = A.RowCount;

            var ax = A.Values;
            var ai = A.RowIndices;
            var ap = A.ColumnPointers;

            ap[0] = 0;

            for (int i = 0; i < N; i++)
            {
                ax[i] = 0;
                ai[i] = i;
                ap[i + 1] = i + 1;
            }

            return A;
        }

        private SparseMatrix spdiag(SparseMatrix A, double value)
        {
            var N = A.RowCount;

            var ax = A.Values;
            var ai = A.RowIndices;
            var ap = A.ColumnPointers;

            ap[0] = 0;

            for (int i = 0; i < N; i++)
            {
                ax[i] = value;
                ai[i] = i;
                ap[i + 1] = i + 1;
            }

            return A;
        }

        private SparseMatrix spdiag(SparseMatrix A, Complex value)
        {
            var N = A.RowCount;

            var ax = A.Values;
            var ai = A.RowIndices;
            var ap = A.ColumnPointers;

            ap[0] = 0;

            for (int i = 0; i < N; i++)
            {
                ax[i] = value;
                ai[i] = i;
                ap[i + 1] = i + 1;
            }

            return A;
        }

        private SparseMatrix MultiplyConstant(SparseMatrix A, Complex value)
        {
            for (int i = 0; i < A.Values.Length; i++)
            {
                A.Values[i] = A.Values[i] * value;
            }

            return A;
        }


    }
}
