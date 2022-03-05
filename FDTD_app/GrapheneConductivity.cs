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

using Complex = System.Numerics.Complex;

using MathNet.Numerics.LinearAlgebra;
using MathNet.Numerics;

namespace FDTD_app
{
    public partial class GrapheneConductivity
    {
        

        private static double kb=1.3806503e-23;
        private static double qe =1.60217646e-19;
        private static double h =6.626068e-34;
        private static double rh =h/2/Math.PI;
        
        private static double uf =9.71e5;

        private static double Hz2eV =4.135667516e-15;

        private static double e0 =8.85418781762e-12;
        private static double m0 =4*Math.PI*1e-7;

        public static double h0 = Math.Sqrt(m0/e0);

        static public (Complex[], double , double ) intraband_conductivity(double T, double G, double mc, double [] freq)
        {
            var l = freq.Length;

            var cond = new Complex[l];

            G = G / Hz2eV * 2 * Math.PI;
            mc *= qe;

            var A = qe * qe * kb * T * (mc / (kb * T) + 2 * Math.Log(Math.Exp(-mc / (kb * T)) + 1)) / (Math.PI * rh * rh);


            for (int i = 0; i < l; i++)
            {
                cond[i] = new Complex(2 * G, 2 * Math.PI * freq[i]);
                cond[i] = A / cond[i];
            }

            File.WriteAllLines("C:\\Users\\OFADC\\Desktop\\test.txt", cond.Select(f1 => f1.ToString()));
            return (cond, A, G);
        }

        static public (double, double) intraband_conductivity(double T, double G, double mc)
        {

            G = G / Hz2eV * 2 * Math.PI;
            mc *= qe;

            var A = qe * qe * kb * T * (mc / (kb * T) + 2 * Math.Log(Math.Exp(-mc / (kb * T)) + 1)) / (Math.PI * rh * rh);

            return (A, G);
        }

        static public (double, double, double) anisotropic_conductivity(double T, double G, double mc, double B0)
        {

            G = G / Hz2eV * 2 * Math.PI;
            mc *= qe;

            var A = 2 * qe * qe * kb * T * Math.Log(2 * Math.Cosh(mc / 2 / kb / T)) / (Math.PI * rh * rh);

            var wc = qe * B0 * uf * uf / Math.Abs(mc);

            return (A, wc, G);
        }

        static public (Complex, Complex) anisotropic_conductivity(double T, double G, double mc, double B0, double f)
        {
            G = G / Hz2eV * 2 * Math.PI;
            mc *= qe;

            Complex sd = new Complex(0, 0);
            Complex so = new Complex(0, 0);

            for (int n = 0; n < 10000001; n++)
            {


                var st1 = sd; var st2 = so;
                var Mn = Math.Sqrt(2 * n * uf * uf * Math.Abs(qe * B0) * rh);
                var Mn1 = Math.Sqrt(2 * (n + 1) * uf * uf * Math.Abs(qe * B0) * rh);
                var fdp = 1 / (Math.Exp((Mn - mc) / kb / T) + 1);
                var fdm = 1 / (Math.Exp((-Mn - mc) / kb / T) + 1);
                var fdp1 = 1 / (Math.Exp((Mn1 - mc) / kb / T) + 1);
                var fdm1 = 1 / (Math.Exp((-Mn1 - mc) / kb / T) + 1);


                Complex omega_term = new Complex(2 * Math.PI * f, -2 * G);
                Complex div_term = new Complex(0, Math.PI);

                sd = sd - qe * qe * uf * uf * Math.Abs(qe * B0) * omega_term * rh / div_term * ((fdp - fdp1 + fdm1 - fdm) / ((Mn1 - Mn) * (Mn1 - Mn) - omega_term * omega_term * rh * rh) / (Mn1 - Mn) + (fdm - fdp1 + fdm1 - fdp) / ((Mn1 + Mn) * (Mn1 + Mn) - omega_term * omega_term * rh * rh) / (Mn1 + Mn));
                so = so + qe * qe * uf * uf * qe * B0 / Math.PI * (fdp - fdp1 - fdm1 + fdm) * (1 / ((Mn1 - Mn) * (Mn1 - Mn) - omega_term * omega_term * rh * rh) + 1 / ((Mn1 + Mn) * (Mn1 + Mn) - omega_term * omega_term * rh * rh));

                if (Math.Abs(st1.Real - sd.Real) / sd.Real < 1e-9 && Math.Abs(st1.Imaginary - sd.Imaginary) / sd.Imaginary < 1e-9 && Math.Abs(st2.Real - so.Real) / so.Real < 1e-9 && Math.Abs(st2.Imaginary - so.Imaginary) / so.Imaginary < 1e-9)
                {
                    break;
                }
            }


            return (sd, so);
        }



        static public Vector<Complex> VectorFitting(double[] freq, Vector<Complex> c0, Complex[] poles)
        {

            var s = new Complex[21];

            for (int i = 0; i < 21; i++)
            {
                s[i] = new Complex(0, freq[i]);
            }

            var LAMBD = Matrix<Complex>.Build.Diagonal(poles);
            int Ns = freq.Length; int N = poles.Length; int Nc = 1;

            var B = Vector<Complex>.Build.Dense(N, 1);
            var I = Matrix<double>.Build.Diagonal(N, 21);


            int offs = 1;


            var cindex = Vector<double>.Build.Dense(N, 0);

            for (int m = 0; m < N; m++)
            {
                if (LAMBD[m, m].Imaginary != 0)
                {
                    if (m == 1)
                    {
                        cindex[m] = 1;
                    }
                    else
                    {
                        if (cindex[m - 1] == 0 | cindex[m - 1] == 2)
                        {
                            cindex[m] = 1; cindex[m + 1] = 2;
                        }
                        else
                        {
                            cindex[m] = 2;
                        }
                    }

                }

            }


            var Dk = Matrix<Complex>.Build.Dense(Ns, N + 1, 1);

            for (int m = 0; m < N; m++)
            {
                if (cindex[m] == 0)
                {
                    for (int jj = 0; jj < Ns; jj++)
                    {
                        Dk[jj, m] = 1 / (s[jj] - LAMBD[m, m]);
                    }
                }
                else if (cindex[m] == 1)
                {
                    for (int jj = 0; jj < Ns; jj++)
                    {
                        Dk[jj, m] = 1 / (s[jj] - LAMBD[m, m]) + 1 / (s[jj] - Complex.Conjugate(LAMBD[m, m]));
                        Dk[jj, m + 1] = (1 / (s[jj] - LAMBD[m, m]) - 1 / (s[jj] - Complex.Conjugate(LAMBD[m, m]))) * (new Complex(0, 1));
                    }
                }
            }

            double scale = 0;

            for (int m = 0; m < Nc; m++)
            {
                scale = scale + c0.Norm(2) / Ns;
            }


            var AA = Matrix<Complex>.Build.Dense(Nc * (N + 1), N + 1, 0);
            var bb = Vector<Complex>.Build.Dense(Nc * (N + 1), 0);
            var Escale = Vector<double>.Build.Dense(N + 1, 0);

            for (int n = 0; n < Nc; n++)
            {
                var A1 = Matrix<Complex>.Build.Dense(Ns, (N + offs) + N + 1, 0);

                for (int m = 0; m < N + offs; m++)
                {
                    for (int jj = 0; jj < Ns; jj++)
                    {
                        A1[jj, m] = Dk[jj, m];
                    }
                }
                int inda = N + offs;
                for (int m = 0; m < N + 1; m++)
                {
                    for (int jj = 0; jj < Ns; jj++)
                    {
                        A1[jj, inda + m] = -Dk[jj, m] * c0[jj]; // c0 is a Vector
                    }
                }




                var A = Matrix<double>.Build.Dense(2 * Ns + 1, (N + offs) + N + 1, 0);

                for (int i = 0; i < Ns; i++)
                {
                    for (int j = 0; j < N + offs + N + 1; j++)
                    {
                        A[i, j] = A1[i, j].Real;
                        A[i + Ns, j] = A1[i, j].Imaginary;

                    }
                }


                var offset = N + offs;

                if (n == Nc - 1)
                {
                    for (int mm = 0; mm < N + 1; mm++)
                    {
                        var sm = new Complex(0, 0);
                        for (int i = 0; i < Ns; i++)
                        {
                            sm = sm + Dk[i, mm] * scale;
                        }

                        A[2 * Ns, offset + mm] = sm.Real;
                    }
                }


                var qr = A.QR();

                int ind1 = N + offs;
                int ind2 = N + offs + N + 1;

                for (int i = 0; i < ind2 - ind1; i++)
                {
                    for (int j = 0; j < ind2 - ind1; j++)
                    {
                        AA[i + n * (N + 1), j] = qr.R[i + ind1, j + ind1];
                    }
                }

                if (n == Nc - 1)
                {
                    for (int i = 0; i < ind2 - ind1; i++)
                    {
                        bb[i + n * (N + 1)] = qr.Q[qr.Q.RowCount - 1, N + offs + i] * Ns * scale;
                    }
                }


            }

            for (int i = 0; i < AA.ColumnCount; i++)
            {
                Escale[i] = 1 / AA.ColumnNorms(2)[i];
                for (int j = 0; j < AA.RowCount; j++)
                {
                    AA[j, i] = Escale[i] * AA[j, i];
                }
            }


            var x = AA.Solve(bb);

            for (int i = 0; i < x.Count; i++)
            {
                x[i] = x[i] * Escale[i];
            }

            // Missing part: D extreme values


            var C = Vector<Complex>.Build.Dense(x.Count - 1);
            for (int i = 0; i < C.Count; i++)
            {
                C[i] = x[i];
            }
            var D = x[x.Count - 1];

            for (int m = 0; m < N; m++)
            {
                if (cindex[m] == 1)
                {
                    var r1 = C[m]; var r2 = C[m + 1];
                    C[m] = r1 + new Complex(0, 1) * r2;
                    C[m + 1] = r1 - new Complex(0, 1) * r2;
                }
            }


            var m1 = 0;

            for (int n = 0; n < N; n++)
            {
                if (m1 < N)
                {
                    if (LAMBD[m1, m1].Magnitude > Math.Abs(LAMBD[m1, m1].Real))
                    {
                        LAMBD[m1 + 1, m1] = -LAMBD[m1, m1].Imaginary;
                        LAMBD[m1, m1 + 1] = LAMBD[m1, m1].Imaginary;
                        LAMBD[m1, m1] = LAMBD[m1, m1].Real;
                        LAMBD[m1 + 1, m1 + 1] = LAMBD[m1, m1];
                        B[m1] = 2; B[m1 + 1] = 0;
                        var koko = C[m1]; C[m1] = koko.Real; C[m1 + 1] = koko.Imaginary;
                        m1 = m1 + 1;
                    }
                }
            }

            var ZER = LAMBD - B.OuterProduct(C) / D;

            var roetter = ZER.Evd().EigenValues;




            for (int i = 0; i < roetter.Count; i++)
            {
                if (roetter[i].Real > 0) // Check pole stability
                {
                    roetter[i] = roetter[i] - 2 * roetter[i].Real; //Forcing unstable poles to be stable...
                }

                if (Math.Abs(roetter[i].Real / roetter[i].Imaginary) > 1e10)
                {
                    roetter[i] = roetter[i].Real;
                }
            }


            for (int i = 1; i < roetter.Count; i++)
            {
                var val = roetter[i];
                int flag = 0;
                for (int j = i - 1; j >= 0 && flag != 1;)
                {
                    if (val.Magnitude < roetter[j].Magnitude)
                    {
                        roetter[j + 1] = roetter[j];
                        j--;
                        roetter[j + 1] = val;
                    }
                    else flag = 1;
                }
            }



            for (int m = 0; m < N; m++)
            {
                LAMBD[m, m] = roetter[m];

                if (LAMBD[m, m].Imaginary != 0)
                {
                    if (m == 0)
                    {
                        cindex[m] = 1;
                    }
                    else
                    {
                        if (cindex[m - 1] == 0 | cindex[m - 1] == 2)
                        {
                            cindex[m] = 1; cindex[m + 1] = 2;
                        }
                        else
                        {
                            cindex[m] = 2;
                        }
                    }

                }

            }

            for (int m = 0; m < N; m++)
            {
                if (cindex[m] == 0)
                {
                    for (int jj = 0; jj < Ns; jj++)
                    {
                        Dk[jj, m] = 1 / (s[jj] - LAMBD[m, m]);
                    }
                }
                else if (cindex[m] == 1)
                {
                    for (int jj = 0; jj < Ns; jj++)
                    {
                        Dk[jj, m] = 1 / (s[jj] - LAMBD[m, m]) + 1 / (s[jj] - Complex.Conjugate(LAMBD[m, m]));
                        Dk[jj, m + 1] = (1 / (s[jj] - LAMBD[m, m]) - 1 / (s[jj] - Complex.Conjugate(LAMBD[m, m]))) * (new Complex(0, 1));
                    }
                }
            }


            for (int n = 0; n < Nc; n++)
            {
                var A = Matrix<double>.Build.Dense(2 * Ns, N + 1, 0);
                var BB = Vector<double>.Build.Dense(2 * Ns, 0);

                for (int i = 0; i < Ns; i++)
                {
                    for (int j = 0; j < N; j++)
                    {
                        A[i, j] = Dk[i, j].Real;
                        A[i + Ns, j] = Dk[i, j].Imaginary;
                    }
                    A[i, N] = 1; A[i + Ns, N] = 0;


                    BB[i] = c0[i].Real;
                    BB[i + Ns] = c0[i].Imaginary;
                }

                for (int i = 0; i < A.ColumnCount; i++)
                {
                    Escale[i] = 1 / A.ColumnNorms(2)[i];
                    for (int j = 0; j < A.RowCount; j++)
                    {
                        A[j, i] = Escale[i] * A[j, i];
                    }
                }

                var x1 = A.Solve(BB);

                for (int i = 0; i < x1.Count; i++)
                {
                    x1[i] = x1[i] * Escale[i];
                }

                for (int i = 0; i < C.Count; i++)
                {
                    C[i] = x1[i];
                }

                D = x1[x1.Count - 1];

                for (int m = 0; m < N; m++)
                {
                    if (cindex[m] == 1)
                    {
                        var r1 = C[m]; var r2 = C[m + 1];
                        C[m] = r1 + new Complex(0, 1) * r2;
                        C[m + 1] = r1 - new Complex(0, 1) * r2;
                    }
                }

            }

            var Dc = Matrix<Complex>.Build.Dense(Ns, N, 1);

            for (int m = 0; m < N; m++)
            {

                for (int jj = 0; jj < Ns; jj++)
                {
                    Dc[jj, m] = 1 / (s[jj] - LAMBD[m, m]);
                }

            }

            var fit = Dc.Multiply(C);

            fit = fit + D;

            return fit;
        }

    }
}
