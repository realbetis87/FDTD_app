using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Complex = System.Numerics.Complex;

using MathNet.Numerics.Integration;



namespace FDTD_app
{
    class PolynomialChaos
    {
        //double iBegin;
        //double iEnd;
        int PolynomialOrder;
        //int QuadratureOrder;

        double d, wf, of;

        int N;

        double[,] p0;
        public double[] pq;

        public double[] Weights;
        public double[] Abscissas;

        public PolynomialChaos(double iBegin, double iEnd, int PolynomialOrder, int QuadratureOrder)
        {
            //this.iBegin = iBegin;
            //this.iEnd = iEnd;
            this.PolynomialOrder = PolynomialOrder;
            //this.QuadratureOrder = QuadratureOrder;

            d = 1 / (iEnd - iBegin);
            wf = 2 * d;
            of = (iEnd + iBegin) / 2;

            GaussLegendreRule rule = new GaussLegendreRule(iBegin, iEnd, QuadratureOrder);
            Weights = rule.Weights;
            Abscissas = rule.Abscissas;

            N = Abscissas.Length;

            p0 = new double[PolynomialOrder, N];
            pq = new double[PolynomialOrder];

            for (int k = 0; k < PolynomialOrder; k++)
            {
                pq[k] = 0;
                for (int i = 0; i < N; i++)
                {
                    p0[k, i] = alglib.legendrecalculate(k, (Abscissas[i] - of) * wf);
                    pq[k] += p0[k, i] * p0[k, i] * Weights[i] * d;
                }
            }
        }

        public (Complex, Complex) Statistics(Complex[] EvalData)
        {

            var coeffs = new Complex[PolynomialOrder];


            for (int k = 0; k < PolynomialOrder; k++)
            {
                coeffs[k] = 0;
                for (int i = 0; i < N; i++)
                {
                    coeffs[k] += EvalData[i] * p0[k, i] * Weights[i] * d / pq[k];
                }
                
            }

            var meanValue = coeffs[0];

            var stdValue = new Complex(0, 0);

            for (int k = 1; k < PolynomialOrder; k++)
            {
                stdValue += coeffs[k] * coeffs[k] * pq[k];
            }

            stdValue = Complex.Sqrt(stdValue);

            return (meanValue, stdValue);
        }

    }
}
