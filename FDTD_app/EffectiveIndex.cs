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


using Complex = System.Numerics.Complex;


namespace FDTD_app
{
    public partial class EffectiveIndex : Form
    {
        private CSparse.Matrix<Complex> eigenvectors;
        private string folder;
        private int N, M;

        public EffectiveIndex(Complex[] modes, CSparse.Matrix<Complex> eigenvectors, string folder, int[] cells)
        {
            InitializeComponent();

            dataGridView1.RowCount = modes.Length + 1;

            dataGridView1.AllowUserToAddRows = false;

            dataGridView1.Columns[1].DefaultCellStyle.Format = "0.000000";

            for (int i = 0; i < modes.Length; i++)
            {
                dataGridView1[0, i].Value = i + 1;
                dataGridView1[1, i].Value = modes[i];
            }

            this.eigenvectors = eigenvectors;
            this.folder = folder;

            N = cells[0];
            M = cells[1];

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            var senderGrid = (DataGridView)sender;

            if (senderGrid.Columns[e.ColumnIndex] is DataGridViewButtonColumn &&
                e.RowIndex >= 0)
            {

                var Z0 = GrapheneConductivity.h0;

                using (TextWriter tw = new StreamWriter(folder + "\\Ex_mode=[" + (e.RowIndex+1).ToString() + "].txt"))
                {
                    string st = "";
                    for (int i = 0; i < eigenvectors.RowCount/4; i++)
                    {
                        
                        if (eigenvectors.At(i, e.RowIndex).Imaginary >= 0)
                        {
                            st += eigenvectors.At(i, e.RowIndex).Real*Z0 + "+" + eigenvectors.At(i, e.RowIndex).Imaginary * Z0 + "i ";
                        }
                        else
                        {
                            st += eigenvectors.At(i, e.RowIndex).Real * Z0 + "" + eigenvectors.At(i, e.RowIndex).Imaginary * Z0 + "i ";
                        }
                        

                        if ((i + 1) % M == 0)
                        {
                            tw.Write(st.Remove(st.Length - 1));
                            tw.WriteLine();
                            st = "";
                        }

                    }


                }

                using (TextWriter tw = new StreamWriter(folder + "\\Ey_mode=[" + (e.RowIndex + 1).ToString() + "].txt"))
                {
                    string st = "";
                    for (int i = eigenvectors.RowCount / 4; i < 2 * eigenvectors.RowCount / 4; i++)
                    {

                        if (eigenvectors.At(i, e.RowIndex).Imaginary >= 0)
                        {
                            st += eigenvectors.At(i, e.RowIndex).Real * Z0 + "+" + eigenvectors.At(i, e.RowIndex).Imaginary * Z0 + "i ";
                        }
                        else
                        {
                            st += eigenvectors.At(i, e.RowIndex).Real * Z0 + "" + eigenvectors.At(i, e.RowIndex).Imaginary * Z0 + "i ";
                        }


                        if ((i + 1) % M == 0)
                        {
                            tw.Write(st.Remove(st.Length - 1));
                            tw.WriteLine();
                            st = "";
                        }

                    }


                }

                using (TextWriter tw = new StreamWriter(folder + "\\Hx_mode=[" + (e.RowIndex + 1).ToString() + "].txt"))
                {
                    string st = "";
                    for (int i = 2 * eigenvectors.RowCount / 4; i < 3 * eigenvectors.RowCount / 4; i++)
                    {

                        if (eigenvectors.At(i, e.RowIndex).Imaginary >= 0)
                        {
                            st += eigenvectors.At(i, e.RowIndex).Real + "+" + eigenvectors.At(i, e.RowIndex).Imaginary + "i ";
                        }
                        else
                        {
                            st += eigenvectors.At(i, e.RowIndex).Real + "" + eigenvectors.At(i, e.RowIndex).Imaginary + "i ";
                        }


                        if ((i + 1) % M == 0)
                        {
                            tw.Write(st.Remove(st.Length - 1));
                            tw.WriteLine();
                            st = "";
                        }

                    }


                }

                using (TextWriter tw = new StreamWriter(folder + "\\Hy_mode=[" + (e.RowIndex + 1).ToString() + "].txt"))
                {

                    string st = "";
                    for (int i = 3 * eigenvectors.RowCount / 4; i < eigenvectors.RowCount; i++)
                    {

                        if (eigenvectors.At(i, e.RowIndex).Imaginary >= 0)
                        {
                            st += eigenvectors.At(i, e.RowIndex).Real + "+" + eigenvectors.At(i, e.RowIndex).Imaginary + "i ";
                        }
                        else
                        {
                            st += eigenvectors.At(i, e.RowIndex).Real + "" + eigenvectors.At(i, e.RowIndex).Imaginary + "i ";
                        }


                        if ((i + 1) % M == 0)
                        {
                            tw.Write(st.Remove(st.Length - 1));
                            tw.WriteLine();
                            st = "";
                        }

                    }


                }


            }
        }
    }
}
