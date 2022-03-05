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
using System.Text.RegularExpressions;
using System.Globalization;

using System.Windows.Forms.DataVisualization.Charting;

using CSparse.Complex;
using CSparse.Complex.Solver;
using CSparse.Solvers;
using CSparse.Storage;
using CSparse.Interop.Spectra;

using MathNet.Numerics.LinearAlgebra;
using MathNet.Numerics;


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
        private ModalSolverModule m1; private Complex[] effectiveIndex; private CSparse.Matrix<Complex> eigenVectors;

        private PolynomialChaos xx1;
        private OpenFileDialog filesPC;
        private bool chk = true;


        private bool oks;

        private string folderSave;


        public struct domain { public double freq; public double bw; public int c2l; public int noPulses;  public double[] limits; };
        

        public CoreForm()
        {
            InitializeComponent();


            Vector<Complex> c0 = Vector<Complex>.Build.Dense(21);

            c0[0] = new Complex(0.0026, 0.0132) * 1e-4;
            c0[1] = new Complex(0.0125, 0.0667) * 1e-4;
            c0[2] = new Complex(0.0242, 0.1161) * 1e-4;
            c0[3] = new Complex(0.0390, 0.1648) * 1e-4;
            c0[4] = new Complex(0.0586, 0.2137) * 1e-4;
            c0[5] = new Complex(0.0846, 0.2622) * 1e-4;
            c0[6] = new Complex(0.1186, 0.3089) * 1e-4;
            c0[7] = new Complex(0.1614, 0.3513) * 1e-4;
            c0[8] = new Complex(0.2126, 0.3861) * 1e-4;
            c0[9] = new Complex(0.2701, 0.4100) * 1e-4;
            c0[10] = new Complex(0.3301, 0.4209) * 1e-4;
            c0[11] = new Complex(0.3881, 0.4189) * 1e-4;
            c0[12] = new Complex(0.4401, 0.4058) * 1e-4;
            c0[13] = new Complex(0.4838, 0.3850) * 1e-4;
            c0[14] = new Complex(0.5185, 0.3600) * 1e-4;
            c0[15] = new Complex(0.5448, 0.3336) * 1e-4;
            c0[16] = new Complex(0.5641, 0.3078) * 1e-4;
            c0[17] = new Complex(0.5778, 0.2839) * 1e-4;
            c0[18] = new Complex(0.5875, 0.2623) * 1e-4;
            c0[19] = new Complex(0.5942, 0.2431) * 1e-4;
            c0[20] = new Complex(0.5988, 0.2262) * 1e-4;

            var f0 = linspace(1e12, 1e14, 21);

            //chart1.ChartAreas[0].AxisX.Minimum = f0[0];
            //chart1.ChartAreas[0].AxisX.Maximum = f0[20];

            //chart1.ChartAreas[0].AxisX.IsMarginVisible = false;





            //chart1.ChartAreas[0].AxisX.ScaleView.Zoomable = true;
            //chart1.ChartAreas[0].AxisY.ScaleView.Zoomable = true;

            //chart1.MouseWheel += chart1_MouseWheel;
            //chart1.MouseClick += chart1_MouseClick;

            var poles = new Complex[4];

            poles[0] = new Complex(-1e12, 0);
            poles[1] = new Complex(-3.4e13, 0);
            poles[2] = new Complex(-6.7e13, 0);
            poles[3] = new Complex(-1e14, 0);


            //poles[0] = new Complex(-0.5212, 0.0000) * 1e13;
            //poles[1] = new Complex(-6.4908, 0.0000) * 1e13;
            //poles[2] = new Complex(-3.7259, 4.8398) * 1e13;
            //poles[3] = new Complex(-3.7259, -4.8398) * 1e13;

            /*
            var s = new Complex[21];

            for (int i = 0; i < 21; i++)
            {
                s[i] = new Complex(0, f0[i]);
            }

            var LAMBD = Matrix<Complex>.Build.Diagonal(poles);
            int Ns = f0.Length; int N = poles.Length; int Nc = 1;

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
                scale = scale + c0.Norm(2)/Ns;
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
                        A1[jj, inda + m] = -Dk[jj, m]*c0[jj]; // c0 is a Vector
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
                        var sm = new Complex(0,0);
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
                        B[m1] = 2;B[m1 + 1] = 0;
                        var koko = C[m1]; C[m1] = koko.Real; C[m1 + 1] = koko.Imaginary;
                        m1 = m1 + 1;
                    }
                }
            }

            var ZER = LAMBD - B.OuterProduct(C)/D;

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


                //exportData("C:\\Users\\OFADC\\Desktop\\test.txt", A);

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
            */

            var fit = GrapheneConductivity.VectorFitting(f0, c0, poles);

            for (int i = 0; i < 21; i++)
            {
                chart1.Series[0].Points.AddXY(f0[i] / 1e12, c0[i].Real);

                chart1.Series[1].Points.AddXY(f0[i] / 1e12, fit[i].Real);
            }





            /*
            //var x3 = new double[4];

            //x3[0] = alglib.legendrecalculate(3, 3.3);

            //GaussLegendreRule rule = new GaussLegendreRule(0.0, 10.0, 5);

            var xx1 = new PolynomialChaos(0.0, 0.5, 8, 21);

            var x3 = xx1.Abscissas;


            var f = linspace(1e10,1e12,21);

            //var (c, A0, G0) = GrapheneProperties.intraband_conductivity(300, 0.33e-3, 0.1, f);

            var cond = new Complex[x3.Length];
            Complex[] x4 = new Complex[f.Length];
            Complex[] x5 = new Complex[f.Length];


            for (int ff = 0; ff < f.Length; ff++)
            {
                for (int i = 0; i < x3.Length; i++)
                {
                    var (c, A0, G0) = GrapheneConductivity.intraband_conductivity(300, 0.11e-3, x3[i], f);
                    cond[i] = c[ff];
                }

                (x4[ff], x5[ff]) = xx1.Statistics(cond);

                Console.WriteLine(x5[ff].Real + "" + x5[ff].Imaginary + "i");
            }


            */
            //var (x4,x5) = xx1.Statistics(cond);









        }


        private void chart1_MouseClick(object sender, MouseEventArgs e)
        {
            var chart = (Chart)sender;
            var xAxis = chart.ChartAreas[0].AxisX;
            var yAxis = chart.ChartAreas[0].AxisY;

            try
            {

                var a0 = chart.HitTest(e.X, e.Y);

                if (a0.ChartElementType == ChartElementType.DataPoint)
                {
                    Console.WriteLine(chart.Series[0].Points[a0.PointIndex].XValue.ToString() + " " + chart.Series[0].Points[a0.PointIndex].YValues[0].ToString());


                }

            }
            catch { }
        }


        private void chart1_MouseWheel(object sender, MouseEventArgs e)
        {
            var chart = (Chart)sender;
            var xAxis = chart.ChartAreas[0].AxisX;
            var yAxis = chart.ChartAreas[0].AxisY;

            try
            {
                if (e.Delta < 0) // Scrolled down.
                {
                    xAxis.ScaleView.ZoomReset();
                    yAxis.ScaleView.ZoomReset();
                }
                else if (e.Delta > 0) // Scrolled up.
                {
                    var xMin = xAxis.ScaleView.ViewMinimum;
                    var xMax = xAxis.ScaleView.ViewMaximum;
                    var yMin = yAxis.ScaleView.ViewMinimum;
                    var yMax = yAxis.ScaleView.ViewMaximum;

                    var posXStart = xAxis.PixelPositionToValue(e.Location.X) - (xMax - xMin) / 2;
                    var posXFinish = xAxis.PixelPositionToValue(e.Location.X) + (xMax - xMin) / 2;
                    var posYStart = yAxis.PixelPositionToValue(e.Location.Y) - (yMax - yMin) / 2;
                    var posYFinish = yAxis.PixelPositionToValue(e.Location.Y) + (yMax - yMin) / 2;


                    xAxis.ScaleView.Zoom(posXStart, posXFinish);
                    yAxis.ScaleView.Zoom(posYStart, posYFinish);
                }
            }
            catch { }
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

            exportData(folderSave + "\\signal.txt", fd.signalMonitor);

            if (!(monitor.frequencies == null))
            {
                for (int k = 0; k < monitor.frequencies.Length; k++)
                {
                    var saveMat = new Complex[fd.N, fd.M];

                    for (int i = 0; i < fd.N; i++)
                    {
                        for (int j=0; j < fd.M; j++)
                        {
                            saveMat[i, j] = new Complex(fd.efxReal[i, j, k], fd.efxImag[i, j, k]);
                        }
                    }

                    exportData(folderSave + "\\Ex_f=[" + (monitor.frequencies[k]).ToString() + "].txt", saveMat);

                    for (int i = 0; i < fd.N; i++)
                    {
                        for (int j = 0; j < fd.M; j++)
                        {
                            saveMat[i, j] = new Complex(fd.efyReal[i, j, k], fd.efyImag[i, j, k]);
                        }
                    }

                    exportData(folderSave + "\\Ey_f=[" + (monitor.frequencies[k]).ToString() + "].txt", saveMat);

                }
            }

            if (!(monitor.trLocation == null | monitor.trLocation.GetLength(1)==0))
            {

                exportData(folderSave + "\\Ex_transient.txt", fd.exTimeMonitors);
                exportData(folderSave + "\\Ey_transient.txt", fd.eyTimeMonitors);

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

        

        private void grapheneButton_Click(object sender, EventArgs e)
        {

            var s1 = new GrapheneForm(grapheneLayers);

            s1.ShowDialog();

            grapheneLayers = s1.grapheneLayers;

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

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void modalButton_Click(object sender, EventArgs e)
        {
                        
            (effectiveIndex, eigenVectors) = m1.ModeSolver(int.Parse(modeNo.Text), double.Parse(effID.Text));

            indexButton.Enabled = true;

            MessageBox.Show("The eigenvalue analysis has been completed successfully!", "Mode analysis completed", MessageBoxButtons.OK, MessageBoxIcon.Information);

        }

        private void checkButton_Click(object sender, EventArgs e)
        {
            domain dm1 = new domain();

            dm1.freq = double.Parse(frequencyText.Text) * 1e12;
            dm1.bw = double.Parse(bandwidthText.Text) * 1e12;
            dm1.c2l = int.Parse(c2lText.Text);
            dm1.noPulses = int.Parse(noPulsesText.Text);

            dm1.limits = new double[2];

            dm1.limits[0] = 1e-6 * (double.Parse(xmaxText.Text) - double.Parse(xminText.Text));
            dm1.limits[1] = 1e-6 * (double.Parse(ymaxText.Text) - double.Parse(yminText.Text));

            double[,] limits = new double[2, 2];
            limits[0, 0] = double.Parse(xminText.Text);
            limits[0, 1] = double.Parse(xmaxText.Text);
            limits[1, 0] = double.Parse(yminText.Text);
            limits[1, 1] = double.Parse(ymaxText.Text);


            m1 = new ModalSolverModule();

            var dx = m1.InitializeDomain(dm1);

            dofText.Text = (4 * m1.M * m1.N).ToString();
            deltaText.Text = (dx * 1e6).ToString("0.0000");

            m1.MakeMedium(mat, voxel_matrix);

            m1.GrapheneDefinition(grapheneLayers, limits);

            m1.ConstructMatrix();

            modalButton.Enabled = true;

        }

        private void xaxisLabel_Click(object sender, EventArgs e)
        {

        }

        private void indexButton_Click(object sender, EventArgs e)
        {
            var ef1 = new EffectiveIndex(effectiveIndex, eigenVectors, folderSave, new int[2] {m1.M, m1.N});

            ef1.ShowDialog();

            /*
            for (int i = 0; i < effectiveIndex.Length; i++)
            {
                Console.WriteLine(effectiveIndex[i] + " ");
            }
            */


        }

        private void pointsButton_Click(object sender, EventArgs e)
        {
            if (int.Parse(polyOrderText.Text)> int.Parse(quadOrderText.Text))
            {
                MessageBox.Show("The quadrature order is less than the polynomial one. Minimum quadrature order is used instead.", "Quadrature order is too low!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                quadOrderText.Text = polyOrderText.Text;
            }

            xx1 = new PolynomialChaos(double.Parse(lowerLimitText.Text), double.Parse(upperLimitText.Text), int.Parse(polyOrderText.Text), int.Parse(quadOrderText.Text));

            //var x3 = xx1.Abscissas;

            var p1 = new EvaluationPoints(xx1.Abscissas);

            p1.ShowDialog();

        }

        public void exportData(string filename, Complex[,] data)
        {
            using (TextWriter tw = new StreamWriter(filename))
            {
                string st = "";

                for (int i = 0; i < data.GetLength(0); i++)
                {
                    for (int j = 0; j < data.GetLength(1); j++)
                    {
                        if (data[i, j].Imaginary >= 0)
                        {
                            st += data[i,j].Real + "+" + data[i,j].Imaginary + "i ";
                        }
                        else
                        {
                            st += data[i,j].Real + "" + data[i,j].Imaginary + "i ";
                        }

                    }

                    tw.Write(st.Remove(st.Length - 1));
                    tw.WriteLine();
                    st = "";

                }


            }
        }

        public void exportData(string filename, double[,] data)
        {
            using (TextWriter tw = new StreamWriter(filename))
            {
                string st = "";

                for (int i = 0; i < data.GetLength(0); i++)
                {
                    for (int j = 0; j < data.GetLength(1); j++)
                    {
                        st += data[i, j] + " ";
                    }

                    tw.Write(st.Remove(st.Length - 1));
                    tw.WriteLine();
                    st = "";

                }
            }
        }


        public void exportData(string filename, Matrix<double> data)
        {
            using (TextWriter tw = new StreamWriter(filename))
            {
                string st = "";

                for (int i = 0; i < data.RowCount; i++)
                {
                    for (int j = 0; j < data.ColumnCount; j++)
                    {
                        st += data[i, j] + " ";
                    }

                    tw.Write(st.Remove(st.Length - 1));
                    tw.WriteLine();
                    st = "";

                }
            }
        }

        public void exportData(string filename, Matrix<Complex> data)
        {
            using (TextWriter tw = new StreamWriter(filename))
            {
                string st = "";

                for (int i = 0; i < data.RowCount; i++)
                {
                    for (int j = 0; j < data.ColumnCount; j++)
                    {
                        if (data[i, j].Imaginary >= 0)
                        {
                            st += data[i, j].Real + "+" + data[i, j].Imaginary + "i ";
                        }
                        else
                        {
                            st += data[i, j].Real + "" + data[i, j].Imaginary + "i ";
                        }

                    }

                    tw.Write(st.Remove(st.Length - 1));
                    tw.WriteLine();
                    st = "";

                }
            }
        }


        private void evalSelectionButton_Click(object sender, EventArgs e)
        {

            filesPC = new OpenFileDialog();
            filesPC.Filter = "Txt files|*.txt";
            filesPC.Multiselect = true;

            if (filesPC.ShowDialog() == DialogResult.OK)
            {
                var fileContent = string.Empty;
                string sFileName = filesPC.FileNames[0];

                if (filesPC.FileNames.Length != xx1.Abscissas.Length)
                {
                    MessageBox.Show("The number of the selected files does not match to the evaluation points. Please select the correct number of files.", "Wrong number of selected files!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {
                    folderSave = System.IO.Path.GetDirectoryName(filesPC.FileName);

                    string[][] list = File.ReadAllLines(filesPC.FileNames[0]).Select(l => l.Split(' ')).ToArray().ToArray();
                    int rows = list.Length;
                    int cols = list.Max(subArray => subArray.Length);

                    for (int i = 0; i < filesPC.FileNames.Length; i++)
                    {
                        list = File.ReadAllLines(filesPC.FileNames[i]).Select(l => l.Split(' ')).ToArray().ToArray();
                        if (list.Length != rows | list.Max(subArray => subArray.Length) != cols)
                        {
                            MessageBox.Show("The data dimensions of the selected files do not match.", "Wrong files are selected!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            chk = false;
                            break;
                        }

                    }


 
                }

                if (chk)
                {
                    statButton.Enabled = true;
                }

            }
        }

        private void statButton_Click(object sender, EventArgs e)
        {
            string regexPattern = @"([-+]?\d+\.?\d*|[-+]?\d*\.?\d+?[e E]+[-+]?\d*)" + @"([\+-])" + @"([-+]?\d+\.?\d*|[-+]?\d*\.?\d+?[e E]+[-+]?\d*)" + @"i" + @"\s*";

            Regex regex = new Regex(regexPattern);




            if (chk)
            {
                // Check data (Complex of Real)
                string[][] list = File.ReadAllLines(filesPC.FileNames[0]).Select(l => l.Split(' ')).ToArray().ToArray();
                int rows = list.Length;
                int cols = list.Max(subArray => subArray.Length);
                
                if (list[0][0].IndexOf("i") > 0)
                {
                    // Complex data

                    if (!regex.IsMatch(list[0][cols - 1]))
                    {
                        cols -= 1;
                    }


                    var evalMatrix = new Complex[rows, cols, filesPC.FileNames.Length];

                    for (int k = 0; k < filesPC.FileNames.Length; k++)
                    {
                        list = File.ReadAllLines(filesPC.FileNames[k]).Select(l => l.Split(' ')).ToArray().ToArray();

                        for (int i = 0; i < rows; i++)
                        {
                            cols = list[i].Length;
                            for (int jj = 0; jj < cols; jj++)
                            {

                                Match match = regex.Match(list[i][jj]);

                                if (match.Success)
                                {
                                    double img;
                                    double real = double.Parse(match.Groups[1].Value, CultureInfo.InvariantCulture);

                                    if (match.Groups[2].Value == "+")
                                    {
                                        img = double.Parse(match.Groups[3].Value, CultureInfo.InvariantCulture);
                                    }
                                    else
                                    {
                                        img = -double.Parse(match.Groups[3].Value, CultureInfo.InvariantCulture);
                                    }

                                    evalMatrix[i, jj, k] = new Complex(real, img);
                                }

                            }
                        }
                    }

                    Complex[] evalData = new Complex[evalMatrix.GetLength(2)];

                    Complex[,] meanValue = new Complex[evalMatrix.GetLength(0), evalMatrix.GetLength(1)];
                    Complex[,] stdValue = new Complex[evalMatrix.GetLength(0), evalMatrix.GetLength(1)];

                    for (int i = 0; i < evalMatrix.GetLength(0); i++)
                    {
                        for (int j = 0; j < evalMatrix.GetLength(1); j++)
                        {
                            for (int k = 0; k < evalMatrix.GetLength(2); k++)
                            {
                                evalData[k] = evalMatrix[i, j, k];
                            }
                            (meanValue[i, j], stdValue[i, j]) = xx1.Statistics(evalData);
                        }
                    }

                    exportData(folderSave + "\\meanValue.txt", meanValue);
                    exportData(folderSave + "\\stdValue.txt", stdValue);

                }
                else
                {
                    // Real data

                    var evalMatrix = new double[rows, cols, filesPC.FileNames.Length];

                    for (int k = 0; k < filesPC.FileNames.Length; k++)
                    {
                        list = File.ReadAllLines(filesPC.FileNames[k]).Select(l => l.Split(' ')).ToArray().ToArray();

                        for (int i = 0; i < rows; i++)
                        {
                            cols = list[i].Length;
                            for (int jj = 0; jj < cols; jj++)
                            {
                                evalMatrix[i, jj, k] = double.Parse(list[i][jj]);
                            }
                        }
                    }

                    double[] evalData = new double[evalMatrix.GetLength(2)];

                    double[,] meanValue = new double[evalMatrix.GetLength(0), evalMatrix.GetLength(1)];
                    double[,] stdValue = new double[evalMatrix.GetLength(0), evalMatrix.GetLength(1)];

                    for (int i = 0; i < evalMatrix.GetLength(0); i++)
                    {
                        for (int j = 0; j < evalMatrix.GetLength(1); j++)
                        {
                            for (int k = 0; k < evalMatrix.GetLength(2); k++)
                            {
                                evalData[k] = evalMatrix[i, j, k];
                            }
                            (meanValue[i, j], stdValue[i, j]) = xx1.Statistics(evalData);
                        }
                    }

                    exportData(folderSave + "\\meanValue.txt", meanValue);
                    exportData(folderSave + "\\stdValue.txt", stdValue);

                }

            }
        }
    }
}
