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
    public partial class Materials : Form
    {

        public struct material {public double er; public double mr; public double sigma; };

        public material[] mat;

        public Materials(int totalMaterials, material[] mat)
        {
            InitializeComponent();

            dataGridView1.RowCount = totalMaterials+1;

            dataGridView1.AllowUserToAddRows = false;

            if (!(mat == null))
            {
                for (int i = 0; i < totalMaterials; i++)
                {
                    dataGridView1[0, i].Value = i+1;
                    dataGridView1[1, i].Value = mat[i].er;
                    dataGridView1[2, i].Value = mat[i].mr;
                    dataGridView1[3, i].Value = mat[i].sigma;
                }
            }
            else
            {
                for (int i = 0; i < totalMaterials; i++)
                {
                    dataGridView1[0, i].Value = i + 1;
                }
            }

            

        }

        private void okButton_Click(object sender, EventArgs e)
        {
            bool sq = false;
            for (int i = 0; i < dataGridView1.Rows.Count; i++)
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
                    double.Parse(dataGridView1.Rows[i].Cells[1].Value.ToString());
                    double.Parse(dataGridView1.Rows[i].Cells[2].Value.ToString());
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
                mat = new material[dataGridView1.Rows.Count];


                for (int i = 0; i < dataGridView1.Rows.Count; i++)
                {
                    mat[i].er = double.Parse(dataGridView1.Rows[i].Cells[1].Value.ToString());
                    mat[i].mr = double.Parse(dataGridView1.Rows[i].Cells[2].Value.ToString());
                    mat[i].sigma = double.Parse(dataGridView1.Rows[i].Cells[3].Value.ToString());
                }

                this.Close();
            }
        }
    }
}
