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
    public partial class GrapheneProperties
    {
        

        private static double kb=1.3806503e-23;
        private static double qe =1.60217646e-19;
        private static double h =6.626068e-34;
        private static double rh =h/2/Math.PI;
        private static double h0 =377;
        private static double uf =9.5e5;

        private static double Hz2eV =4.135667516e-15;

        private static double e0 =8.85418781762e-12;
        private static double m0 =4*Math.PI*1e-7;

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
    }
}
