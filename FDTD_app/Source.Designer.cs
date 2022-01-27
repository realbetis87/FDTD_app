
namespace FDTD_app
{
    partial class Source
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
            this.okButton = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.xL = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.yl = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.exy = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.st = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // okButton
            // 
            this.okButton.Location = new System.Drawing.Point(144, 347);
            this.okButton.Name = "okButton";
            this.okButton.Size = new System.Drawing.Size(129, 23);
            this.okButton.TabIndex = 3;
            this.okButton.Text = "OK";
            this.okButton.UseVisualStyleBackColor = true;
            this.okButton.Click += new System.EventHandler(this.okButton_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.xL,
            this.yl,
            this.exy,
            this.st});
            this.dataGridView1.Location = new System.Drawing.Point(22, 12);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(432, 301);
            this.dataGridView1.TabIndex = 8;
            this.dataGridView1.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            // 
            // xL
            // 
            this.xL.HeaderText = "x [um]";
            this.xL.Name = "xL";
            // 
            // yl
            // 
            this.yl.HeaderText = "y [um]";
            this.yl.Name = "yl";
            // 
            // exy
            // 
            this.exy.HeaderText = "Direction";
            this.exy.Items.AddRange(new object[] {
            "Ex",
            "Ey"});
            this.exy.Name = "exy";
            this.exy.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.exy.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.exy.Width = 80;
            // 
            // st
            // 
            this.st.HeaderText = "Strength";
            this.st.Name = "st";
            // 
            // Source
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(478, 386);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.okButton);
            this.Name = "Source";
            this.Text = "Source";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button okButton;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.DataGridViewTextBoxColumn xL;
        private System.Windows.Forms.DataGridViewTextBoxColumn yl;
        private System.Windows.Forms.DataGridViewComboBoxColumn exy;
        private System.Windows.Forms.DataGridViewTextBoxColumn st;
    }
}