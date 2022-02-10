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
    public partial class Monitors : Form
    {

        public struct monitors { public double[] frequencies; public double[,] trLocation; };

        public monitors monitor;

        public Monitors(monitors monitor)
        {
            InitializeComponent();

            if (!(monitor.frequencies == null))
            {
                dataGridView1.RowCount = monitor.frequencies.Length + 1;

                for (int i = 0; i < monitor.frequencies.Length; i++)
                {
                    dataGridView1[0, i].Value = monitor.frequencies[i];

                    this.monitor = monitor;

                }
            }
            else
            {
                dataGridView1.RowCount = 1;
            }

            if (!(monitor.trLocation == null))
            {
                dataGridView2.RowCount = monitor.trLocation.GetLength(1) + 1;

                for (int i = 0; i < monitor.trLocation.GetLength(1); i++)
                {
                    dataGridView2[0, i].Value = monitor.trLocation[0, i];
                    dataGridView2[1, i].Value = monitor.trLocation[1, i];

                    this.monitor = monitor;

                }
            }
            else
            {
                dataGridView2.RowCount = 1;
            }

        }

        private void okButton_Click(object sender, EventArgs e)
        {
            bool sq = false;
            for (int i = 0; i < dataGridView1.Rows.Count - 1; i++)
            {

                if (dataGridView1.Rows[i].Cells[0].Value == null)
                {
                    sq = true;
                    MessageBox.Show("Some cells are empty!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }

                if (sq) break;

                try
                {
                    double.Parse(dataGridView1.Rows[i].Cells[0].Value.ToString());
                }
                catch
                {
                    sq = true;
                    MessageBox.Show("Some values are not arithmetic!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    break;
                }
            }

            for (int i = 0; i < dataGridView2.Rows.Count - 1; i++)
            {

                if (dataGridView2.Rows[i].Cells[0].Value == null || dataGridView2.Rows[i].Cells[1].Value == null)
                {
                    sq = true;
                    MessageBox.Show("Some cells are empty!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }

                if (sq) break;

                try
                {
                    double.Parse(dataGridView2.Rows[i].Cells[0].Value.ToString());
                    double.Parse(dataGridView2.Rows[i].Cells[1].Value.ToString());
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
                monitor.frequencies = new double[dataGridView1.Rows.Count - 1];

                for (int i = 0; i < dataGridView1.Rows.Count - 1; i++)
                {
                    monitor.frequencies[i] = double.Parse(dataGridView1.Rows[i].Cells[0].Value.ToString());
                }

                monitor.trLocation = new double[2,dataGridView2.Rows.Count - 1];

                for (int i = 0; i < dataGridView2.Rows.Count - 1; i++)
                {
                    monitor.trLocation[0, i] = double.Parse(dataGridView2.Rows[i].Cells[0].Value.ToString());
                    monitor.trLocation[1, i] = double.Parse(dataGridView2.Rows[i].Cells[1].Value.ToString());
                }


                this.Close();
            }
        }
    }
}
