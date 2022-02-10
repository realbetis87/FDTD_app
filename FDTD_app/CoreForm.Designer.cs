
namespace FDTD_app
{
    partial class CoreForm
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
            this.frequencyText = new System.Windows.Forms.TextBox();
            this.frequencyLabel = new System.Windows.Forms.Label();
            this.bandwidthText = new System.Windows.Forms.TextBox();
            this.bandwidthLabel = new System.Windows.Forms.Label();
            this.c2lText = new System.Windows.Forms.TextBox();
            this.c2lLabel = new System.Windows.Forms.Label();
            this.button2 = new System.Windows.Forms.Button();
            this.sourceButton = new System.Windows.Forms.Button();
            this.xaxisLabel = new System.Windows.Forms.Label();
            this.yaxisLabel = new System.Windows.Forms.Label();
            this.minLabel = new System.Windows.Forms.Label();
            this.maxLabel = new System.Windows.Forms.Label();
            this.xminText = new System.Windows.Forms.TextBox();
            this.xmaxText = new System.Windows.Forms.TextBox();
            this.ymaxText = new System.Windows.Forms.TextBox();
            this.yminText = new System.Windows.Forms.TextBox();
            this.simButton = new System.Windows.Forms.Button();
            this.MText = new System.Windows.Forms.TextBox();
            this.dyText = new System.Windows.Forms.TextBox();
            this.NText = new System.Windows.Forms.TextBox();
            this.dxText = new System.Windows.Forms.TextBox();
            this.noLabel = new System.Windows.Forms.Label();
            this.stepLabel = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.TText = new System.Windows.Forms.TextBox();
            this.dtText = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.materialButton = new System.Windows.Forms.Button();
            this.grapheneButton = new System.Windows.Forms.Button();
            this.aboutButton = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // frequencyText
            // 
            this.frequencyText.Location = new System.Drawing.Point(684, 46);
            this.frequencyText.Name = "frequencyText";
            this.frequencyText.Size = new System.Drawing.Size(74, 20);
            this.frequencyText.TabIndex = 2;
            this.frequencyText.Text = "2";
            this.frequencyText.TextChanged += new System.EventHandler(this.frequency_TextChanged);
            // 
            // frequencyLabel
            // 
            this.frequencyLabel.AutoSize = true;
            this.frequencyLabel.Location = new System.Drawing.Point(592, 49);
            this.frequencyLabel.Name = "frequencyLabel";
            this.frequencyLabel.Size = new System.Drawing.Size(86, 13);
            this.frequencyLabel.TabIndex = 3;
            this.frequencyLabel.Text = "Frequency [THz]";
            this.frequencyLabel.Click += new System.EventHandler(this.label1_Click);
            // 
            // bandwidthText
            // 
            this.bandwidthText.Location = new System.Drawing.Point(684, 72);
            this.bandwidthText.Name = "bandwidthText";
            this.bandwidthText.Size = new System.Drawing.Size(74, 20);
            this.bandwidthText.TabIndex = 4;
            this.bandwidthText.Text = "2";
            // 
            // bandwidthLabel
            // 
            this.bandwidthLabel.AutoSize = true;
            this.bandwidthLabel.Location = new System.Drawing.Point(592, 75);
            this.bandwidthLabel.Name = "bandwidthLabel";
            this.bandwidthLabel.Size = new System.Drawing.Size(86, 13);
            this.bandwidthLabel.TabIndex = 5;
            this.bandwidthLabel.Text = "Bandwidth [THz]";
            this.bandwidthLabel.Click += new System.EventHandler(this.label1_Click_1);
            // 
            // c2lText
            // 
            this.c2lText.Location = new System.Drawing.Point(684, 98);
            this.c2lText.Name = "c2lText";
            this.c2lText.Size = new System.Drawing.Size(74, 20);
            this.c2lText.TabIndex = 6;
            this.c2lText.Text = "30";
            // 
            // c2lLabel
            // 
            this.c2lLabel.AutoSize = true;
            this.c2lLabel.Location = new System.Drawing.Point(590, 101);
            this.c2lLabel.Name = "c2lLabel";
            this.c2lLabel.Size = new System.Drawing.Size(88, 13);
            this.c2lLabel.TabIndex = 7;
            this.c2lLabel.Text = "Wavelength ratio";
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(651, 246);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(79, 27);
            this.button2.TabIndex = 8;
            this.button2.Text = "Initial Check";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // sourceButton
            // 
            this.sourceButton.Location = new System.Drawing.Point(117, 95);
            this.sourceButton.Name = "sourceButton";
            this.sourceButton.Size = new System.Drawing.Size(75, 23);
            this.sourceButton.TabIndex = 9;
            this.sourceButton.Text = "Add source";
            this.sourceButton.UseVisualStyleBackColor = true;
            this.sourceButton.Click += new System.EventHandler(this.sourceButton_Click);
            // 
            // xaxisLabel
            // 
            this.xaxisLabel.AutoSize = true;
            this.xaxisLabel.Location = new System.Drawing.Point(581, 165);
            this.xaxisLabel.Name = "xaxisLabel";
            this.xaxisLabel.Size = new System.Drawing.Size(33, 13);
            this.xaxisLabel.TabIndex = 10;
            this.xaxisLabel.Text = "x-axis";
            // 
            // yaxisLabel
            // 
            this.yaxisLabel.AutoSize = true;
            this.yaxisLabel.Location = new System.Drawing.Point(581, 191);
            this.yaxisLabel.Name = "yaxisLabel";
            this.yaxisLabel.Size = new System.Drawing.Size(33, 13);
            this.yaxisLabel.TabIndex = 11;
            this.yaxisLabel.Text = "y-axis";
            // 
            // minLabel
            // 
            this.minLabel.AutoSize = true;
            this.minLabel.Location = new System.Drawing.Point(632, 146);
            this.minLabel.Name = "minLabel";
            this.minLabel.Size = new System.Drawing.Size(46, 13);
            this.minLabel.TabIndex = 12;
            this.minLabel.Text = "min [um]";
            // 
            // maxLabel
            // 
            this.maxLabel.AutoSize = true;
            this.maxLabel.Location = new System.Drawing.Point(709, 146);
            this.maxLabel.Name = "maxLabel";
            this.maxLabel.Size = new System.Drawing.Size(49, 13);
            this.maxLabel.TabIndex = 13;
            this.maxLabel.Text = "max [um]";
            // 
            // xminText
            // 
            this.xminText.Location = new System.Drawing.Point(620, 162);
            this.xminText.Name = "xminText";
            this.xminText.Size = new System.Drawing.Size(65, 20);
            this.xminText.TabIndex = 14;
            this.xminText.Text = "-200";
            this.xminText.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // xmaxText
            // 
            this.xmaxText.Location = new System.Drawing.Point(702, 162);
            this.xmaxText.Name = "xmaxText";
            this.xmaxText.Size = new System.Drawing.Size(65, 20);
            this.xmaxText.TabIndex = 15;
            this.xmaxText.Text = "200";
            this.xmaxText.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // ymaxText
            // 
            this.ymaxText.Location = new System.Drawing.Point(702, 188);
            this.ymaxText.Name = "ymaxText";
            this.ymaxText.Size = new System.Drawing.Size(65, 20);
            this.ymaxText.TabIndex = 17;
            this.ymaxText.Text = "200";
            this.ymaxText.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // yminText
            // 
            this.yminText.Location = new System.Drawing.Point(620, 188);
            this.yminText.Name = "yminText";
            this.yminText.Size = new System.Drawing.Size(65, 20);
            this.yminText.TabIndex = 16;
            this.yminText.Text = "-200";
            this.yminText.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // simButton
            // 
            this.simButton.Enabled = false;
            this.simButton.Location = new System.Drawing.Point(651, 395);
            this.simButton.Name = "simButton";
            this.simButton.Size = new System.Drawing.Size(95, 27);
            this.simButton.TabIndex = 18;
            this.simButton.Text = "Start Simulation";
            this.simButton.UseVisualStyleBackColor = true;
            this.simButton.Click += new System.EventHandler(this.simButton_Click);
            // 
            // MText
            // 
            this.MText.Location = new System.Drawing.Point(705, 324);
            this.MText.Name = "MText";
            this.MText.ReadOnly = true;
            this.MText.Size = new System.Drawing.Size(65, 20);
            this.MText.TabIndex = 26;
            this.MText.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // dyText
            // 
            this.dyText.Location = new System.Drawing.Point(593, 324);
            this.dyText.Name = "dyText";
            this.dyText.ReadOnly = true;
            this.dyText.Size = new System.Drawing.Size(65, 20);
            this.dyText.TabIndex = 25;
            this.dyText.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // NText
            // 
            this.NText.Location = new System.Drawing.Point(705, 298);
            this.NText.Name = "NText";
            this.NText.ReadOnly = true;
            this.NText.Size = new System.Drawing.Size(65, 20);
            this.NText.TabIndex = 24;
            this.NText.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // dxText
            // 
            this.dxText.Location = new System.Drawing.Point(593, 298);
            this.dxText.Name = "dxText";
            this.dxText.ReadOnly = true;
            this.dxText.Size = new System.Drawing.Size(65, 20);
            this.dxText.TabIndex = 23;
            this.dxText.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // noLabel
            // 
            this.noLabel.AutoSize = true;
            this.noLabel.Location = new System.Drawing.Point(709, 282);
            this.noLabel.Name = "noLabel";
            this.noLabel.Size = new System.Drawing.Size(61, 13);
            this.noLabel.TabIndex = 22;
            this.noLabel.Text = "No of steps";
            // 
            // stepLabel
            // 
            this.stepLabel.AutoSize = true;
            this.stepLabel.Location = new System.Drawing.Point(605, 282);
            this.stepLabel.Name = "stepLabel";
            this.stepLabel.Size = new System.Drawing.Size(29, 13);
            this.stepLabel.TabIndex = 21;
            this.stepLabel.Text = "Step";
            this.stepLabel.Click += new System.EventHandler(this.label2_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(554, 327);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(41, 13);
            this.label3.TabIndex = 20;
            this.label3.Text = "dy [um]";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(554, 301);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(41, 13);
            this.label4.TabIndex = 19;
            this.label4.Text = "dx [um]";
            this.label4.Click += new System.EventHandler(this.label4_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(684, 327);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(16, 13);
            this.label1.TabIndex = 28;
            this.label1.Text = "M";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(684, 301);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(15, 13);
            this.label2.TabIndex = 27;
            this.label2.Text = "N";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(667, 353);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(33, 13);
            this.label5.TabIndex = 32;
            this.label5.Text = "Tmax";
            // 
            // TText
            // 
            this.TText.Location = new System.Drawing.Point(705, 350);
            this.TText.Name = "TText";
            this.TText.ReadOnly = true;
            this.TText.Size = new System.Drawing.Size(65, 20);
            this.TText.TabIndex = 31;
            this.TText.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // dtText
            // 
            this.dtText.Location = new System.Drawing.Point(593, 350);
            this.dtText.Name = "dtText";
            this.dtText.ReadOnly = true;
            this.dtText.Size = new System.Drawing.Size(65, 20);
            this.dtText.TabIndex = 30;
            this.dtText.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(554, 353);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(33, 13);
            this.label6.TabIndex = 29;
            this.label6.Text = "dt [fs]";
            // 
            // materialButton
            // 
            this.materialButton.Location = new System.Drawing.Point(104, 232);
            this.materialButton.Name = "materialButton";
            this.materialButton.Size = new System.Drawing.Size(100, 23);
            this.materialButton.TabIndex = 33;
            this.materialButton.Text = "Assign materials";
            this.materialButton.UseVisualStyleBackColor = true;
            this.materialButton.Click += new System.EventHandler(this.button3_Click);
            // 
            // grapheneButton
            // 
            this.grapheneButton.Location = new System.Drawing.Point(92, 343);
            this.grapheneButton.Name = "grapheneButton";
            this.grapheneButton.Size = new System.Drawing.Size(122, 23);
            this.grapheneButton.TabIndex = 34;
            this.grapheneButton.Text = "Graphene Layers";
            this.grapheneButton.UseVisualStyleBackColor = true;
            this.grapheneButton.Click += new System.EventHandler(this.grapheneButton_Click);
            // 
            // aboutButton
            // 
            this.aboutButton.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.aboutButton.Image = global::FDTD_app.Properties.Resources.about_icon;
            this.aboutButton.Location = new System.Drawing.Point(12, 12);
            this.aboutButton.Name = "aboutButton";
            this.aboutButton.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.aboutButton.Size = new System.Drawing.Size(35, 35);
            this.aboutButton.TabIndex = 35;
            this.aboutButton.UseVisualStyleBackColor = true;
            this.aboutButton.Click += new System.EventHandler(this.aboutButton_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(333, 250);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(109, 23);
            this.button1.TabIndex = 1;
            this.button1.Text = "Load Voxel Model";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_click);
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(300, 191);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(174, 20);
            this.textBox1.TabIndex = 0;
            this.textBox1.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // CoreForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.aboutButton);
            this.Controls.Add(this.grapheneButton);
            this.Controls.Add(this.materialButton);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.TText);
            this.Controls.Add(this.dtText);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.MText);
            this.Controls.Add(this.dyText);
            this.Controls.Add(this.NText);
            this.Controls.Add(this.dxText);
            this.Controls.Add(this.noLabel);
            this.Controls.Add(this.stepLabel);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.simButton);
            this.Controls.Add(this.ymaxText);
            this.Controls.Add(this.yminText);
            this.Controls.Add(this.xmaxText);
            this.Controls.Add(this.xminText);
            this.Controls.Add(this.maxLabel);
            this.Controls.Add(this.minLabel);
            this.Controls.Add(this.yaxisLabel);
            this.Controls.Add(this.xaxisLabel);
            this.Controls.Add(this.sourceButton);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.c2lLabel);
            this.Controls.Add(this.c2lText);
            this.Controls.Add(this.bandwidthLabel);
            this.Controls.Add(this.bandwidthText);
            this.Controls.Add(this.frequencyLabel);
            this.Controls.Add(this.frequencyText);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.textBox1);
            this.Name = "CoreForm";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.TextBox frequencyText;
        private System.Windows.Forms.Label frequencyLabel;
        private System.Windows.Forms.TextBox bandwidthText;
        private System.Windows.Forms.Label bandwidthLabel;
        private System.Windows.Forms.TextBox c2lText;
        private System.Windows.Forms.Label c2lLabel;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button sourceButton;
        private System.Windows.Forms.Label xaxisLabel;
        private System.Windows.Forms.Label yaxisLabel;
        private System.Windows.Forms.Label minLabel;
        private System.Windows.Forms.Label maxLabel;
        private System.Windows.Forms.TextBox xminText;
        private System.Windows.Forms.TextBox xmaxText;
        private System.Windows.Forms.TextBox ymaxText;
        private System.Windows.Forms.TextBox yminText;
        private System.Windows.Forms.Button simButton;
        private System.Windows.Forms.TextBox MText;
        private System.Windows.Forms.TextBox dyText;
        private System.Windows.Forms.TextBox NText;
        private System.Windows.Forms.TextBox dxText;
        private System.Windows.Forms.Label noLabel;
        private System.Windows.Forms.Label stepLabel;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox TText;
        private System.Windows.Forms.TextBox dtText;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button materialButton;
        private System.Windows.Forms.Button grapheneButton;
        private System.Windows.Forms.Button aboutButton;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox textBox1;
    }
}

