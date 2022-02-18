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
    public partial class EvaluationPoints : Form
    {
        public EvaluationPoints(double[] points)
        {
            InitializeComponent();

            dataGridView1.RowCount = points.Length + 1;

            dataGridView1.AllowUserToAddRows = false;

            dataGridView1.Columns[1].DefaultCellStyle.Format = "0.000000";

            for (int i = 0; i < points.Length; i++)
            {
                dataGridView1[0, i].Value = i + 1;
                dataGridView1[1, i].Value = points[i];
            }

        }
    }
}
