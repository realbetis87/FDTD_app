using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FDTD_app
{
    public partial class Source : Form
    {
        public double[,] su;

        public struct sources { public double[] position; public string orientation; public double amplitude; };

        public sources[] source;

                public Source(sources[] source)
        {
            InitializeComponent();
            /*
            dataGridView1.RowCount = ar.GetLength(0)+1;
            su = new double[ar.GetLength(0), 4];

            for (int i = 0; i < ar.GetLength(0); i++)
            {

                dataGridView1[0, i].Value = ar[i, 0]; su[i, 0] = ar[i, 0];
                dataGridView1[1, i].Value = ar[i, 1]; su[i, 1] = ar[i, 1];
                dataGridView1[3, i].Value = ar[i, 3]; su[i, 3] = ar[i, 3];

                su[i, 2] = ar[i, 2];

                if (ar[i, 2] == 1)
                    dataGridView1[2, i].Value = "Ex";
                else
                    dataGridView1[2, i].Value = "Ey";
            }

            */

            if (!(source == null))
            {
                dataGridView1.RowCount = source.Length + 1;

                for (int i = 0; i < source.Length; i++)
                {
                    dataGridView1[0, i].Value = source[i].position[0];
                    dataGridView1[1, i].Value = source[i].position[1];
                    dataGridView1[2, i].Value = source[i].orientation;
                    dataGridView1[3, i].Value = source[i].amplitude;

                    this.source = source;

                 }
            }
            else
            {
                dataGridView1.RowCount = 1;
            }



        }

        private void okButton_Click(object sender, EventArgs e)
        {
            bool sq = false;
            for (int i = 0; i < dataGridView1.Rows.Count - 1; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    if (dataGridView1.Rows[i].Cells[j].Value == null)
                    {
                        sq = true;
                        MessageBox.Show("Some cells are empty!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        break;
                    }

                }

                if (sq) break;

                try
                {
                    double.Parse(dataGridView1.Rows[i].Cells[0].Value.ToString());
                    double.Parse(dataGridView1.Rows[i].Cells[1].Value.ToString());
                    double.Parse(dataGridView1.Rows[i].Cells[3].Value.ToString());
                }
                catch
                {
                    sq = true;
                    MessageBox.Show("Some values are not arithmetic!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    break;
                }
            }

            if (!sq)
            {
                source = new sources[dataGridView1.Rows.Count-1];

                Console.WriteLine(source.Length);

                for (int i = 0; i < dataGridView1.Rows.Count-1; i++)
                {
                    source[i].position = new double[2];
                    source[i].position[0] = double.Parse(dataGridView1.Rows[i].Cells[0].Value.ToString());
                    source[i].position[1] = double.Parse(dataGridView1.Rows[i].Cells[1].Value.ToString());

                    source[i].orientation = dataGridView1.Rows[i].Cells[2].Value.ToString();
                    source[i].amplitude = double.Parse(dataGridView1.Rows[i].Cells[3].Value.ToString());
                }


                /*
                su = new double[dataGridView1.Rows.Count - 1, 4];


                for (int i = 0; i < dataGridView1.Rows.Count - 1; i++)
                {
                    su[i, 0] = double.Parse(dataGridView1.Rows[i].Cells[0].Value.ToString());
                    su[i, 1] = double.Parse(dataGridView1.Rows[i].Cells[1].Value.ToString());
                    if (dataGridView1[2, i].Value.ToString() == "Ex")
                        su[i, 2] = 1;
                    else
                        su[i, 2] = 2;
                    su[i, 3] = double.Parse(dataGridView1.Rows[i].Cells[3].Value.ToString());
                }

                Console.WriteLine(String.Join(" ", su.Cast<double>()));
                */
                this.Close();
            }

            


            
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

    }
}
