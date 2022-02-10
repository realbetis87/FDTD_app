using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using Complex = System.Numerics.Complex;


namespace FDTD_app
{
    public partial class GrapheneForm : Form
    {
        public struct grapheneProperties { public string orientation; public double[] startPos; public double length;  public double mc; public double gamma; public double temperature; public bool nonL; public double b0; };


        public grapheneProperties[] grapheneLayers;

        public GrapheneForm(grapheneProperties[] grapheneLayers)
        {
            InitializeComponent();

            if (!(grapheneLayers == null))
            {
                dataGridView1.RowCount = grapheneLayers.Length + 1;

                for (int i = 0; i < grapheneLayers.Length; i++)
                {
                    dataGridView1[0, i].Value = grapheneLayers[i].orientation;
                    dataGridView1[1, i].Value = grapheneLayers[i].startPos[0];
                    dataGridView1[2, i].Value = grapheneLayers[i].startPos[1];
                    dataGridView1[3, i].Value = grapheneLayers[i].length;
                    dataGridView1[4, i].Value = grapheneLayers[i].mc;
                    dataGridView1[5, i].Value = grapheneLayers[i].gamma;
                    dataGridView1[6, i].Value = grapheneLayers[i].temperature;
                    dataGridView1[7, i].Value = grapheneLayers[i].nonL;
                    dataGridView1[8, i].Value = grapheneLayers[i].b0;

                    this.grapheneLayers = grapheneLayers;

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
                for (int j = 0; j < 9; j++)
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
                    double.Parse(dataGridView1.Rows[i].Cells[1].Value.ToString());
                    double.Parse(dataGridView1.Rows[i].Cells[3].Value.ToString());
                    double.Parse(dataGridView1.Rows[i].Cells[4].Value.ToString());
                    double.Parse(dataGridView1.Rows[i].Cells[5].Value.ToString());
                    double.Parse(dataGridView1.Rows[i].Cells[6].Value.ToString());
                    double.Parse(dataGridView1.Rows[i].Cells[8].Value.ToString());

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
                grapheneLayers = new grapheneProperties[dataGridView1.Rows.Count - 1];

                Console.WriteLine(grapheneLayers.Length);

                for (int i = 0; i < dataGridView1.Rows.Count - 1; i++)
                {
                    grapheneLayers[i].orientation = dataGridView1.Rows[i].Cells[0].Value.ToString();
                    grapheneLayers[i].startPos = new double[2];
                    grapheneLayers[i].startPos[0] = double.Parse(dataGridView1.Rows[i].Cells[1].Value.ToString());
                    grapheneLayers[i].startPos[1] = double.Parse(dataGridView1.Rows[i].Cells[2].Value.ToString());
                    grapheneLayers[i].length = double.Parse(dataGridView1.Rows[i].Cells[3].Value.ToString());
                    grapheneLayers[i].mc = double.Parse(dataGridView1.Rows[i].Cells[4].Value.ToString());
                    grapheneLayers[i].gamma = double.Parse(dataGridView1.Rows[i].Cells[5].Value.ToString());
                    grapheneLayers[i].temperature = double.Parse(dataGridView1.Rows[i].Cells[6].Value.ToString());
                    grapheneLayers[i].nonL = Convert.ToBoolean(dataGridView1.Rows[i].Cells[7].Value);
                    grapheneLayers[i].b0 = double.Parse(dataGridView1.Rows[i].Cells[8].Value.ToString());

                }

                this.Close();
            }
        }


    }
}
