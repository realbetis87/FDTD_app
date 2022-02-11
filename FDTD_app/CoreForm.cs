using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;


using CSparse.Complex;
using CSparse.Complex.Solver;
using CSparse.Solvers;
using CSparse.Storage;
using CSparse.Interop.Spectra;

using MathNet.Numerics.Integration;

using Complex = System.Numerics.Complex;

namespace FDTD_app
{
    public partial class CoreForm : Form
    {

        private double[,] m;
        private double[,] array = new double[1, 4];

        Materials.material[] mat;
        Source.sources[] source;
        GrapheneForm.grapheneProperties[] grapheneLayers;
        Monitors.monitors monitor;

        private int matNo;

        private int[,] voxel_matrix;

        private TEmode2D fd;

        private bool oks;

        private string folderSave;


        public struct domain { public double freq; public double bw; public int c2l; public int noPulses;  public double[] limits; };
        

        public CoreForm()
        {
            InitializeComponent();

            //Complex[] t1 = new Complex[6];
            //var t2 = new int[6];
            //var t3 = new int[4];


            //t1[0] = new Complex(1,1); t1[1] = 2; t1[2] = 3; t1[3] = 4; t1[4] = 5; t1[5] = new Complex (6,2); 
            //t2[0] = 0; t2[1] = 2; t2[2] = 2; t2[3] = 0; t2[4] = 1; t2[5] = 2;
            //t3[0] = 0; t3[1] = 2; t3[2] = 3; t3[3] = 6;


            int n = 100; // Dimension of the problem.

            Complex rho = new Complex (10.0,2.0);

            Complex dd, dl, du, s, h, h2;
            
            h = 1.0 / (n + 1);
            h2 = h * h;
            s = rho / 2.0;
            dd = 2.0 / h2;
            dl = -(1.0 / h2) - s / h;
            du = -(1.0 / h2) + s / h;

            // Defining the number of nonzero matrix elements.

            int nnz = 3 * n - 2;

            // Creating output vectors.


            var matrix = new SparseMatrix(n, n, nnz);
            //var A = new SparseMatrix(n, n, nnz);
            var A = SparseMatrix.CreateIdentity(n);

            var ax = matrix.Values;
            var ai = matrix.RowIndices;
            var ap = matrix.ColumnPointers;


            // Filling A, ai and ap.

            ap[0] = 0;

            int j = 0;

            for (int i = 0; i != n; i++)
            {
                if (i != 0)
                {
                    ai[j] = i - 1;
                    ax[j++] = du;
                }

                ai[j] = i;
                ax[j++] = dd;

                if (i != (n - 1))
                {
                    ai[j] = i + 1;
                    ax[j++] = dl;
                }

                ap[i + 1] = j;
            }


            matrix.Multiply(matrix,A);

            var A3 = hstack(vstack(matrix,A), vstack(A,matrix));

            //File.WriteAllLines("C:\\Users\\OFADC\\Desktop\\test1.txt", A3.RowIndices.Select(f1 => f1.ToString()));

            /*
            using (TextWriter tw = new StreamWriter("C:\\Users\\OFADC\\Desktop\\test1.txt"))
            {
                for (int i = 0; i < A.RowCount; i++)
                {
                    for (int k = 0; k < A.ColumnCount; k++)
                    {
                        tw.Write(matrix.At(i,k).Imaginary + " ");
                    }
                    tw.WriteLine();
                }
            }
            */

            var a1 = new int[2]; a1[0] = 0; a1[1] = 1;

                        
            int m = A.RowCount;
            //int n = A.ColumnCount;

            // Create test data.
            var x = Vector.Create(n, 1.0);
            var b = new double[m];

            // Compute right hand side vector b.
            //A.Multiply(1.0, x, 0.0, b);
            //textBox1.Text = A.At(2,2).ToString();

            var dprob = new Arpack(matrix) { ComputeEigenVectors = true };

            // Finding eigenvalues and eigenvectors.
            var result = dprob.SolveStandard(4, new Complex(100.0, 0.0));

            //var x3 = new double[4];

            //x3[0] = alglib.legendrecalculate(3, 3.3);

            //GaussLegendreRule rule = new GaussLegendreRule(0.0, 10.0, 5);

            var xx1 = new PolynomialChaos(0.0, 0.5, 8, 101);

            var x3 = xx1.Abscissas;


            textBox1.Text = result.EigenValues[3].ToString();

            var f = linspace(1e10,1e12,101);

            //var (c, A0, G0) = GrapheneProperties.intraband_conductivity(300, 0.33e-3, 0.1, f);

            var cond = new Complex[x3.Length];


            for (int i = 0; i < x3.Length; i++)
            {
                var (c, A0, G0) = GrapheneConductivity.intraband_conductivity(300, 0.11e-3, x3[i], f);
                cond[i] = c[100];
            }

            var (x4,x5) = xx1.Statistics(cond);

            Console.WriteLine(x4);
            Console.WriteLine(x5);




            


        }

        static public int[,] resizePixels(int[,] mat1, int w2, int h2)
        {
            int[] pixels = new int[mat1.GetLength(0) * mat1.GetLength(1)];
            int w1 = mat1.GetLength(0);
            int h1 = mat1.GetLength(1);

            for (int i = 0; i < w1; i++)
            {
                for (int k = 0; k < h1; k++)
                {
                    pixels[i * w1 + k] = mat1[i, k];
                }
            }

            int[,] temp = new int[w2, h2];
            double x_ratio = w1 / (double)w2;
            double y_ratio = h1 / (double)h2;

            double px, py;
            for (int i = 0; i < w2; i++)
            {
                for (int j = 0; j < h2; j++)
                {
                    px = Math.Floor(i * x_ratio);
                    py = Math.Floor(j * y_ratio);
                    temp[i , j] = pixels[(int)((px * h1) + py)];
                }
            }

            return temp;
        }


        public static double[] linspace(double startval, double endval, int steps)
        {
            double interval = (endval / Math.Abs(endval)) * Math.Abs(endval - startval) / (steps - 1);
            return (from val in Enumerable.Range(0, steps)
                    select startval + (val * interval)).ToArray();
        }


        public static SparseMatrix vstack(CompressedColumnStorage<System.Numerics.Complex> uMatrix, CompressedColumnStorage<System.Numerics.Complex> bMatrix)
        {
            if (uMatrix.ColumnCount == bMatrix.ColumnCount)
            {
                var m1 = uMatrix.RowCount;
                var m2 = bMatrix.RowCount;

                var nz1 = uMatrix.NonZerosCount;
                var nz2 = bMatrix.NonZerosCount;
                
                SparseMatrix fMatrix = new SparseMatrix(m1+m2, uMatrix.ColumnCount, nz1+nz2);

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

                SparseMatrix fMatrix = new SparseMatrix(lMatrix.RowCount, n1+n2, nz1 + nz2);

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


        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void button1_click(object sender, EventArgs e)
        {

            double Lx = 0, Ly = 0;

            var f1  = new OpenFileDialog();
            f1.Filter = "Txt files|*.txt";

            if (f1.ShowDialog() == DialogResult.OK)
            {
                var fileContent = string.Empty;
                string sFileName = f1.FileName;

                folderSave = System.IO.Path.GetDirectoryName(f1.FileName);

                int[][] list = File.ReadAllLines(sFileName).Select(l => l.Split(',').Select(i => int.Parse(i)).ToArray()).ToArray();

                int rows = list.Length;
                int cols = list.Max(subArray => subArray.Length);
                voxel_matrix = new int[rows, cols];
                for (int i = 0; i < rows; i++)
                {
                    cols = list[i].Length;
                    for (int jj = 0; jj < cols; jj++)
                    {
                        voxel_matrix[i, jj] = list[i][jj];
                    }
                }

                //var list3 = resizePixels(list2, 250, 600);


                //Console.WriteLine(String.Join(" ", list2.Cast<int>()));
                //Console.WriteLine(String.Join(" ", list3.Cast<int>()));

                /*
                using (TextWriter tw = new StreamWriter("C:\\Users\\OFADC\\Desktop\\fd\\f.txt"))
                {
                    for (int i = 0; i < list3.GetLength(0); i++)
                    {
                        for (int k = 0; k < list3.GetLength(1); k++)
                        {
                            tw.Write(list3[i, k] + ",");
                        }
                            tw.WriteLine();
                        
                    }
                }
                */

                matNo = voxel_matrix.Cast<int>().Max();

                NText.Text = voxel_matrix.GetLength(0).ToString();
                MText.Text = voxel_matrix.GetLength(1).ToString();

            }

            m = new double[2, 2];

            m[0, 0] = Lx; m[0, 1] = Ly; m[1, 0] = 1; m[1, 1] = 1;

            Console.WriteLine(Ly);

            //string[] lines = System.IO.File.ReadAllLines(@"C:\Users\Public\TestFolder\WriteLines2.txt");
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click_1(object sender, EventArgs e)
        {

        }

        private void frequency_TextChanged(object sender, EventArgs e)
        {
            
        }

        public void button2_Click(object sender, EventArgs e)
        {
            //GC.Collect();


            domain dm1 = new domain();

            dm1.freq = double.Parse(frequencyText.Text) * 1e12;
            dm1.bw = double.Parse(bandwidthText.Text) * 1e12;
            dm1.c2l = int.Parse(c2lText.Text);
            dm1.noPulses = int.Parse(noPulsesText.Text);

            dm1.limits = new double[2];

            dm1.limits[0] = 1e-6*(double.Parse(xmaxText.Text) - double.Parse(xminText.Text));
            dm1.limits[1] = 1e-6*(double.Parse(ymaxText.Text) - double.Parse(yminText.Text));

            double[,] limits = new double[2, 2];
            limits[0, 0] = double.Parse(xminText.Text);
            limits[0, 1] = double.Parse(xmaxText.Text);
            limits[1, 0] = double.Parse(yminText.Text);
            limits[1, 1] = double.Parse(ymaxText.Text);


            fd = new TEmode2D();

            var dt = fd.InitializeDomain(dm1);

            NText.Text = fd.N.ToString();
            MText.Text = fd.M.ToString();
            TText.Text = fd.simLength.ToString();
            dxText.Text = (fd.dx * 1e6).ToString("0.0000");
            dyText.Text = (fd.dy * 1e6).ToString("0.0000");
            dtText.Text = (fd.dt * 1e15).ToString("0.0000");


            fd.MakeMedium(mat, voxel_matrix);
            fd.InitializeComponents();
            fd.SourceDefinition(source, limits);

            fd.GrapheneDefinition(grapheneLayers, limits);

            fd.MonitorDefinition(monitor, limits);

            oks = true;

            if (oks)
            {
                simButton.Enabled = true;
            }

        }

        private void sourceButton_Click(object sender, EventArgs e)
        {

            var s1 = new Source(source);
            s1.ShowDialog();

            source = s1.source;

            /*
            array = ResizeArray(array, s1.su.GetLength(0), 4);

            for (int i=0;i< s1.su.GetLength(0); i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    array[i, j] = s1.su[i, j];
                }
              
            }

            */

        }


        T[,] ResizeArray<T>(T[,] original, int rows, int cols)
        {
            var newArray = new T[rows, cols];
            int minRows = Math.Min(rows, original.GetLength(0));
            int minCols = Math.Min(cols, original.GetLength(1));
            for (int i = 0; i < minRows; i++)
                for (int j = 0; j < minCols; j++)
                    newArray[i, j] = original[i, j];
            return newArray;
        }

        T[,] TrimArray<T>(int rowToRemove, T[,] originalArray)
        {
            var result = new T[originalArray.GetLength(0) - 1, originalArray.GetLength(1)];

            for (int i = 0, j = 0; i < originalArray.GetLength(0); i++)
            {
                if (i == rowToRemove)
                    continue;

                for (int k = 0; k < originalArray.GetLength(1); k++)
                {
                    result[j, k] = originalArray[i, k];
                }
                j++;
            }

            return result;
        }

        private void simButton_Click(object sender, EventArgs e)
        {

            fd.Simulation();

            if (!(monitor.frequencies == null))
            {
                for (int k = 0; k < monitor.frequencies.Length; k++)
                {
                    using (TextWriter tw = new StreamWriter(folderSave + "\\Ex_f=[" + (monitor.frequencies[k]).ToString() + "].txt"))
                    {
                        for (int i = 0; i < fd.N; i++)
                        {
                            for (int j = 0; j < fd.M; j++)
                            {
                                if (fd.efxImag[i, j, k] >= 0)
                                {
                                    tw.Write(fd.efxReal[i, j, k] + "+" + fd.efxImag[i, j, k] + "i ");
                                }
                                else
                                {
                                    tw.Write(fd.efxReal[i, j, k] + "" + fd.efxImag[i, j, k] + "i ");
                                }

                            }

                            tw.WriteLine();
                        }
                    }

                    using (TextWriter tw = new StreamWriter(folderSave + "\\Ey_f=[" + (monitor.frequencies[k]).ToString() + "].txt"))
                    {
                        for (int i = 0; i < fd.N; i++)
                        {
                            for (int j = 0; j < fd.M; j++)
                            {
                                if (fd.efyImag[i, j, k] >= 0)
                                {
                                    tw.Write(fd.efyReal[i, j, k] + "+" + fd.efyImag[i, j, k] + "i ");
                                }
                                else
                                {
                                    tw.Write(fd.efyReal[i, j, k] + "" + fd.efyImag[i, j, k] + "i ");
                                }

                            }

                            tw.WriteLine();
                        }
                    }
                }
            }

            if (!(monitor.trLocation == null))
            {
                using (TextWriter tw = new StreamWriter(folderSave + "\\Ex_transient.txt"))
                {
                    for (int i = 0; i < fd.exTimeMonitors.GetLength(0); i++)
                    {
                        for (int j = 0; j < fd.exTimeMonitors.GetLength(1); j++)
                        {
                            tw.Write(fd.exTimeMonitors[i, j] + " ");
                        }
                        tw.WriteLine();
                    }
                }

                using (TextWriter tw = new StreamWriter(folderSave + "\\Ey_transient.txt"))
                {
                    for (int i = 0; i < fd.eyTimeMonitors.GetLength(0); i++)
                    {
                        for (int j = 0; j < fd.eyTimeMonitors.GetLength(1); j++)
                        {
                            tw.Write(fd.eyTimeMonitors[i, j] + " ");
                        }
                        tw.WriteLine();
                    }
                }

            }

            MessageBox.Show("The simulation has been completed successfully!", "Simulation completed", MessageBoxButtons.OK, MessageBoxIcon.Information);

            simButton.Enabled = false;

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            
            
            var s1 = new Materials(matNo, mat);
            
            s1.ShowDialog();

            mat = s1.mat;
            
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

        private void grapheneButton_Click(object sender, EventArgs e)
        {
            var f = 2e12;

            var e0 = 8.85418781762e-12;
            var m0 = 4 * Math.PI * 1e-7;
            var c0 = 1 / Math.Sqrt(e0 * m0);

            var l0 = c0 / f;

            var k0 = 2 * Math.PI * f / c0;

            var d = l0 / 6;

            var Lx = 200e-6;
            var Ly = 150e-6;

            int N = (int)Math.Round(Lx / d);
            int M = (int)Math.Round(Ly / d);

            d = Lx / N;

            int[,] idm = new int[N, M];

            for (int i = 0; i < N; i++)
            {
                for (int j = 0; j < M; j++)
                {
                    idm[i, j] = i + N * j;
                }
            }

            var erx = speye(new SparseMatrix(N * M, N * M, N * M));
            var ery = speye(new SparseMatrix(N * M, N * M, N * M));
            var erz = speye(new SparseMatrix(N * M, N * M, N * M));
            var ierz = speye(new SparseMatrix(N * M, N * M, N * M));

            var erxz = spdiag(new SparseMatrix(N * M, N * M, N * M));
            var erzx = spdiag(new SparseMatrix(N * M, N * M, N * M));

            (Complex sd, Complex so) = GrapheneConductivity.anisotropic_conductivity(300, 0.11 * 1e-3, 0.2, 1, f);

            var gr_w = 40e-6;
            int gr_1 = (int)Math.Round((double)N / 2 - gr_w / d / 2) -1;
            int gr_2 = (int)Math.Round((double)N / 2 + gr_w / d / 2) -1;

            Console.WriteLine(gr_1 + " " + gr_2);

            for (int i = gr_1; i < gr_2; i++)
            {
                int j = (int)Math.Round((double)M / 2) -1;

                erx.Values[idm[i, j]] -= new Complex(0, 1) * (sd / 2 / Math.PI / f / e0) / d;
                erz.Values[idm[i, j]] -= new Complex(0, 1) * (sd / 2 / Math.PI / f / e0) / d;

                erxz.Values[idm[i, j]] -= new Complex(0, 1) * (so / 2 / Math.PI / f / e0) / d;
                erzx.Values[idm[i, j]] += new Complex(0, 1) * (so / 2 / Math.PI / f / e0) / d;
            }

            erz.Values[idm[gr_2, (int)Math.Round((double)M / 2) - 1]] -= new Complex(0, 1) * (sd / 2 / Math.PI / f / e0) / d;
            erzx.Values[idm[gr_2, (int)Math.Round((double)M / 2) - 1]] = new Complex(0, 1) * (so / 2 / Math.PI / f / e0) / d;

            ierz = erz;

            for (int i = 0; i < ierz.Values.Length; i++)
            {
                ierz.Values[i] = 1 / ierz.Values[i];
            }


            var Ux = new SparseMatrix(N * M, N * M, 2 * N * M);
            
            Ux.ColumnPointers[0] = 0;

            int jj = 0;

            for (int i=0; i < N * M; i++)
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

            var A11 = new SparseMatrix(N * M, N * M, 2 * N * M); Ux.Multiply(ierz, A11); A11.Multiply(erzx,A11); A11 = MultiplyConstant(A11, new Complex(0, -1));
            
            //for (int i = 0; i < A11.Values.Length; i++)
            //{
            //    A11.Values[i] = A11.Values[i] * (new Complex(0, -1));
            //}

            var A = new SparseMatrix(20, 20, 20);

            var ax = A.Values;
            var ai = A.RowIndices;
            var ap = A.ColumnPointers;

            ap[0] = 0;

            for (int i = 0; i < 20; i++)
            {
                ax[i] = 1;
                ai[i] = i;
                ap[i + 1] = i+1;
            }

            ax[14] = new Complex(3,2);

            
            using (TextWriter tw = new StreamWriter("C:\\Users\\OFADC\\Desktop\\test1.txt"))
            {
                for (int i = 0; i < Ux.RowCount; i++)
                {
                    for (int k = 0; k < Ux.ColumnCount; k++)
                    {
                        tw.Write(A11.At(i, k).Imaginary + " ");
                    }
                    tw.WriteLine();
                }
            }
            

            var dprob = new Arpack(A11) { ComputeEigenVectors = true };

            // Finding eigenvalues and eigenvectors.
            var result = dprob.SolveStandard(2, new Complex(10, 0.0));

            Console.WriteLine(result.EigenValues[0]);



            var s1 = new GrapheneForm(grapheneLayers);

            s1.ShowDialog();

            grapheneLayers = s1.grapheneLayers;



            //(Complex sd, Complex so) = GrapheneConductivity.anisotropic_conductivity(grapheneLayers[0].temperature, grapheneLayers[0].gamma * 1e-3, grapheneLayers[0].mc, grapheneLayers[0].b0, double.Parse(frequencyText.Text) * 1e12);


            //Console.WriteLine(sd);
            //Console.WriteLine(so);



        }

        private void aboutButton_Click(object sender, EventArgs e)
        {
            var s1 = new AboutBox();

            s1.ShowDialog();
        }

        private void monitorButton_Click(object sender, EventArgs e)
        {
            var s1 = new Monitors(monitor);

            s1.ShowDialog();

            monitor = s1.monitor;
        }
    }
}
