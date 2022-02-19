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
