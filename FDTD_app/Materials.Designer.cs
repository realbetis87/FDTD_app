
namespace FDTD_app
{
    partial class Materials
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
            this.okButton = new System.Windows.Forms.Button();
            this.matNo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.erCol = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.mrCol = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.condCol = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.matNo,
            this.erCol,
            this.mrCol,
            this.condCol});
            this.dataGridView1.Location = new System.Drawing.Point(37, 12);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(445, 299);
            this.dataGridView1.TabIndex = 0;
            // 
            // okButton
            // 
            this.okButton.Location = new System.Drawing.Point(227, 342);
            this.okButton.Name = "okButton";
            this.okButton.Size = new System.Drawing.Size(75, 23);
            this.okButton.TabIndex = 1;
            this.okButton.Text = "OK";
            this.okButton.UseVisualStyleBackColor = true;
            this.okButton.Click += new System.EventHandler(this.okButton_Click);
            // 
            // matNo
            // 
            this.matNo.HeaderText = "No.";
            this.matNo.Name = "matNo";
            this.matNo.ReadOnly = true;
            // 
            // erCol
            // 
            this.erCol.HeaderText = "Relative permittivity";
            this.erCol.Name = "erCol";
            // 
            // mrCol
            // 
            this.mrCol.HeaderText = "Relative Permeability";
            this.mrCol.Name = "mrCol";
            // 
            // condCol
            // 
            this.condCol.HeaderText = "Conductivity";
            this.condCol.Name = "condCol";
            // 
            // Materials
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(529, 450);
            this.Controls.Add(this.okButton);
            this.Controls.Add(this.dataGridView1);
            this.Name = "Materials";
            this.Text = "Materials";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button okButton;
        private System.Windows.Forms.DataGridViewTextBoxColumn matNo;
        private System.Windows.Forms.DataGridViewTextBoxColumn erCol;
        private System.Windows.Forms.DataGridViewTextBoxColumn mrCol;
        private System.Windows.Forms.DataGridViewTextBoxColumn condCol;
    }
}