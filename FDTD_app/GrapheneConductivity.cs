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


    }
}
