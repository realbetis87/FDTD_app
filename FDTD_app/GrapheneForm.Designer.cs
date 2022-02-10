
namespace FDTD_app
{
    partial class GrapheneForm
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
            this.nVec = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.xPos = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.yPos = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.length = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.mc = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.gamma = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.temperature = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nonL = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.b0 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.nVec,
            this.xPos,
            this.yPos,
            this.length,
            this.mc,
            this.gamma,
            this.temperature,
            this.nonL,
            this.b0});
            this.dataGridView1.Location = new System.Drawing.Point(12, 30);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(867, 150);
            this.dataGridView1.TabIndex = 0;
            // 
            // okButton
            // 
            this.okButton.Location = new System.Drawing.Point(418, 239);
            this.okButton.Name = "okButton";
            this.okButton.Size = new System.Drawing.Size(75, 23);
            this.okButton.TabIndex = 1;
            this.okButton.Text = "OK";
            this.okButton.UseVisualStyleBackColor = true;
            this.okButton.Click += new System.EventHandler(this.okButton_Click);
            // 
            // nVec
            // 
            this.nVec.HeaderText = "Normal Vector";
            this.nVec.Items.AddRange(new object[] {
            "x",
            "y"});
            this.nVec.Name = "nVec";
            this.nVec.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.nVec.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.nVec.Width = 50;
            // 
            // xPos
            // 
            this.xPos.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
            this.xPos.HeaderText = "x Start Point (um)";
            this.xPos.Name = "xPos";
            this.xPos.Width = 85;
            // 
            // yPos
            // 
            this.yPos.HeaderText = "y Start Point (um)";
            this.yPos.Name = "yPos";
            this.yPos.Width = 90;
            // 
            // length
            // 
            this.length.HeaderText = "Length (um)";
            this.length.Name = "length";
            // 
            // mc
            // 
            this.mc.HeaderText = "Chemical Potential (eV)";
            this.mc.Name = "mc";
            // 
            // gamma
            // 
            this.gamma.HeaderText = "Scattering Rate (meV)";
            this.gamma.Name = "gamma";
            // 
            // temperature
            // 
            this.temperature.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
            this.temperature.HeaderText = "Temperature (K)";
            this.temperature.Name = "temperature";
            this.temperature.Width = 99;
            // 
            // nonL
            // 
            this.nonL.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
            this.nonL.HeaderText = "Non-Linearity";
            this.nonL.Name = "nonL";
            this.nonL.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.nonL.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.nonL.Width = 94;
            // 
            // b0
            // 
            this.b0.HeaderText = "Magnetic Bias (T)";
            this.b0.Name = "b0";
            // 
            // GrapheneForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(902, 290);
            this.Controls.Add(this.okButton);
            this.Controls.Add(this.dataGridView1);
            this.Name = "GrapheneForm";
            this.Text = "GrapheneForm";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button okButton;
        private System.Windows.Forms.DataGridViewComboBoxColumn nVec;
        private System.Windows.Forms.DataGridViewTextBoxColumn xPos;
        private System.Windows.Forms.DataGridViewTextBoxColumn yPos;
        private System.Windows.Forms.DataGridViewTextBoxColumn length;
        private System.Windows.Forms.DataGridViewTextBoxColumn mc;
        private System.Windows.Forms.DataGridViewTextBoxColumn gamma;
        private System.Windows.Forms.DataGridViewTextBoxColumn temperature;
        private System.Windows.Forms.DataGridViewCheckBoxColumn nonL;
        private System.Windows.Forms.DataGridViewTextBoxColumn b0;
    }
}