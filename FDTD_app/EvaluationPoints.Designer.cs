
namespace FDTD_app
{
    partial class EvaluationPoints
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.pointNo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.evalPoint = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.pointNo,
            this.evalPoint});
            this.dataGridView1.Location = new System.Drawing.Point(55, 12);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(254, 398);
            this.dataGridView1.TabIndex = 0;
            // 
            // pointNo
            // 
            this.pointNo.HeaderText = "No.";
            this.pointNo.Name = "pointNo";
            this.pointNo.Width = 60;
            // 
            // evalPoint
            // 
            this.evalPoint.HeaderText = "Evaluation Point";
            this.evalPoint.Name = "evalPoint";
            this.evalPoint.Width = 150;
            // 
            // EvaluationPoints
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(386, 434);
            this.Controls.Add(this.dataGridView1);
            this.Name = "EvaluationPoints";
            this.Text = "EvaluationPoints";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.DataGridViewTextBoxColumn pointNo;
        private System.Windows.Forms.DataGridViewTextBoxColumn evalPoint;
    }
}