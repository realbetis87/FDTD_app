
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
            this.button1 = new System.Windows.Forms.Button();
            this.modeNo = new System.Windows.Forms.TextBox();
            this.monitorButton = new System.Windows.Forms.Button();
            this.pulseLabel = new System.Windows.Forms.Label();
            this.noPulsesText = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.grapheneButton = new System.Windows.Forms.Button();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.effID = new System.Windows.Forms.TextBox();
            this.modalButton = new System.Windows.Forms.Button();
            this.checkButton = new System.Windows.Forms.Button();
            this.dofText = new System.Windows.Forms.TextBox();
            this.deltaText = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.tableLayoutPanel3 = new System.Windows.Forms.TableLayoutPanel();
            this.indexButton = new System.Windows.Forms.Button();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.tableLayoutPanel4 = new System.Windows.Forms.TableLayoutPanel();
            this.aboutButton = new System.Windows.Forms.Button();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.tableLayoutPanel5 = new System.Windows.Forms.TableLayoutPanel();
            this.label16 = new System.Windows.Forms.Label();
            this.statButton = new System.Windows.Forms.Button();
            this.label15 = new System.Windows.Forms.Label();
            this.evalSelectionButton = new System.Windows.Forms.Button();
            this.label11 = new System.Windows.Forms.Label();
            this.pointsButton = new System.Windows.Forms.Button();
            this.label12 = new System.Windows.Forms.Label();
            this.quadOrderText = new System.Windows.Forms.TextBox();
            this.label14 = new System.Windows.Forms.Label();
            this.polyOrderText = new System.Windows.Forms.TextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.upperLimitText = new System.Windows.Forms.TextBox();
            this.lowerLimitText = new System.Windows.Forms.TextBox();
            this.groupBox1.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.tableLayoutPanel3.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.tableLayoutPanel4.SuspendLayout();
            this.groupBox5.SuspendLayout();
            this.tableLayoutPanel5.SuspendLayout();
            this.SuspendLayout();
            // 
            // frequencyText
            // 
            this.frequencyText.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.tableLayoutPanel2.SetColumnSpan(this.frequencyText, 2);
            this.frequencyText.Location = new System.Drawing.Point(126, 3);
            this.frequencyText.Name = "frequencyText";
            this.frequencyText.Size = new System.Drawing.Size(43, 20);
            this.frequencyText.TabIndex = 2;
            this.frequencyText.Text = "2";
            this.frequencyText.TextChanged += new System.EventHandler(this.frequency_TextChanged);
            // 
            // frequencyLabel
            // 
            this.frequencyLabel.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.frequencyLabel.AutoSize = true;
            this.tableLayoutPanel2.SetColumnSpan(this.frequencyLabel, 3);
            this.frequencyLabel.Location = new System.Drawing.Point(18, 5);
            this.frequencyLabel.Name = "frequencyLabel";
            this.frequencyLabel.Size = new System.Drawing.Size(86, 13);
            this.frequencyLabel.TabIndex = 3;
            this.frequencyLabel.Text = "Frequency [THz]";
            this.frequencyLabel.Click += new System.EventHandler(this.label1_Click);
            // 
            // bandwidthText
            // 
            this.tableLayoutPanel2.SetColumnSpan(this.bandwidthText, 2);
            this.bandwidthText.Location = new System.Drawing.Point(126, 27);
            this.bandwidthText.Name = "bandwidthText";
            this.bandwidthText.Size = new System.Drawing.Size(43, 20);
            this.bandwidthText.TabIndex = 4;
            this.bandwidthText.Text = "2";
            // 
            // bandwidthLabel
            // 
            this.bandwidthLabel.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.bandwidthLabel.AutoSize = true;
            this.tableLayoutPanel2.SetColumnSpan(this.bandwidthLabel, 3);
            this.bandwidthLabel.Location = new System.Drawing.Point(18, 29);
            this.bandwidthLabel.Name = "bandwidthLabel";
            this.bandwidthLabel.Size = new System.Drawing.Size(86, 13);
            this.bandwidthLabel.TabIndex = 5;
            this.bandwidthLabel.Text = "Bandwidth [THz]";
            this.bandwidthLabel.Click += new System.EventHandler(this.label1_Click_1);
            // 
            // c2lText
            // 
            this.tableLayoutPanel2.SetColumnSpan(this.c2lText, 2);
            this.c2lText.Location = new System.Drawing.Point(126, 51);
            this.c2lText.Name = "c2lText";
            this.c2lText.Size = new System.Drawing.Size(43, 20);
            this.c2lText.TabIndex = 6;
            this.c2lText.Text = "30";
            // 
            // c2lLabel
            // 
            this.c2lLabel.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.c2lLabel.AutoSize = true;
            this.tableLayoutPanel2.SetColumnSpan(this.c2lLabel, 3);
            this.c2lLabel.Location = new System.Drawing.Point(17, 53);
            this.c2lLabel.Name = "c2lLabel";
            this.c2lLabel.Size = new System.Drawing.Size(88, 13);
            this.c2lLabel.TabIndex = 7;
            this.c2lLabel.Text = "Wavelength ratio";
            // 
            // button2
            // 
            this.button2.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.tableLayoutPanel4.SetColumnSpan(this.button2, 4);
            this.button2.Location = new System.Drawing.Point(81, 41);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(79, 23);
            this.button2.TabIndex = 8;
            this.button2.Text = "Initial Check";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // sourceButton
            // 
            this.sourceButton.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.tableLayoutPanel4.SetColumnSpan(this.sourceButton, 2);
            this.sourceButton.Location = new System.Drawing.Point(22, 6);
            this.sourceButton.Name = "sourceButton";
            this.sourceButton.Size = new System.Drawing.Size(75, 23);
            this.sourceButton.TabIndex = 9;
            this.sourceButton.Text = "Sources";
            this.sourceButton.UseVisualStyleBackColor = true;
            this.sourceButton.Click += new System.EventHandler(this.sourceButton_Click);
            // 
            // xaxisLabel
            // 
            this.xaxisLabel.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.xaxisLabel.AutoSize = true;
            this.xaxisLabel.Location = new System.Drawing.Point(3, 149);
            this.xaxisLabel.Name = "xaxisLabel";
            this.xaxisLabel.Size = new System.Drawing.Size(33, 13);
            this.xaxisLabel.TabIndex = 10;
            this.xaxisLabel.Text = "x-axis";
            this.xaxisLabel.Click += new System.EventHandler(this.xaxisLabel_Click);
            // 
            // yaxisLabel
            // 
            this.yaxisLabel.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.yaxisLabel.AutoSize = true;
            this.yaxisLabel.Location = new System.Drawing.Point(3, 174);
            this.yaxisLabel.Name = "yaxisLabel";
            this.yaxisLabel.Size = new System.Drawing.Size(33, 13);
            this.yaxisLabel.TabIndex = 11;
            this.yaxisLabel.Text = "y-axis";
            // 
            // minLabel
            // 
            this.minLabel.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.minLabel.AutoSize = true;
            this.tableLayoutPanel2.SetColumnSpan(this.minLabel, 2);
            this.minLabel.Location = new System.Drawing.Point(62, 125);
            this.minLabel.Name = "minLabel";
            this.minLabel.Size = new System.Drawing.Size(46, 13);
            this.minLabel.TabIndex = 12;
            this.minLabel.Text = "min [um]";
            // 
            // maxLabel
            // 
            this.maxLabel.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.maxLabel.AutoSize = true;
            this.tableLayoutPanel2.SetColumnSpan(this.maxLabel, 2);
            this.maxLabel.Location = new System.Drawing.Point(137, 125);
            this.maxLabel.Name = "maxLabel";
            this.maxLabel.Size = new System.Drawing.Size(49, 13);
            this.maxLabel.TabIndex = 13;
            this.maxLabel.Text = "max [um]";
            // 
            // xminText
            // 
            this.xminText.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.tableLayoutPanel2.SetColumnSpan(this.xminText, 2);
            this.xminText.Location = new System.Drawing.Point(57, 147);
            this.xminText.Name = "xminText";
            this.xminText.Size = new System.Drawing.Size(55, 20);
            this.xminText.TabIndex = 14;
            this.xminText.Text = "-200";
            this.xminText.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // xmaxText
            // 
            this.xmaxText.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.tableLayoutPanel2.SetColumnSpan(this.xmaxText, 2);
            this.xmaxText.Location = new System.Drawing.Point(132, 147);
            this.xmaxText.Name = "xmaxText";
            this.xmaxText.Size = new System.Drawing.Size(59, 20);
            this.xmaxText.TabIndex = 15;
            this.xmaxText.Text = "200";
            this.xmaxText.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // ymaxText
            // 
            this.ymaxText.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.tableLayoutPanel2.SetColumnSpan(this.ymaxText, 2);
            this.ymaxText.Location = new System.Drawing.Point(132, 171);
            this.ymaxText.Name = "ymaxText";
            this.ymaxText.Size = new System.Drawing.Size(59, 20);
            this.ymaxText.TabIndex = 17;
            this.ymaxText.Text = "200";
            this.ymaxText.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // yminText
            // 
            this.yminText.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.tableLayoutPanel2.SetColumnSpan(this.yminText, 2);
            this.yminText.Location = new System.Drawing.Point(56, 171);
            this.yminText.Name = "yminText";
            this.yminText.Size = new System.Drawing.Size(58, 20);
            this.yminText.TabIndex = 16;
            this.yminText.Text = "-200";
            this.yminText.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // simButton
            // 
            this.simButton.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.tableLayoutPanel4.SetColumnSpan(this.simButton, 4);
            this.simButton.Enabled = false;
            this.simButton.Location = new System.Drawing.Point(73, 198);
            this.simButton.Name = "simButton";
            this.simButton.Size = new System.Drawing.Size(95, 23);
            this.simButton.TabIndex = 18;
            this.simButton.Text = "Start Simulation";
            this.simButton.UseVisualStyleBackColor = true;
            this.simButton.Click += new System.EventHandler(this.simButton_Click);
            // 
            // MText
            // 
            this.MText.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.MText.Location = new System.Drawing.Point(172, 135);
            this.MText.Name = "MText";
            this.MText.ReadOnly = true;
            this.MText.Size = new System.Drawing.Size(65, 20);
            this.MText.TabIndex = 26;
            this.MText.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // dyText
            // 
            this.dyText.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.dyText.Location = new System.Drawing.Point(51, 135);
            this.dyText.Name = "dyText";
            this.dyText.ReadOnly = true;
            this.dyText.Size = new System.Drawing.Size(65, 20);
            this.dyText.TabIndex = 25;
            this.dyText.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // NText
            // 
            this.NText.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.NText.Location = new System.Drawing.Point(172, 105);
            this.NText.Name = "NText";
            this.NText.ReadOnly = true;
            this.NText.Size = new System.Drawing.Size(65, 20);
            this.NText.TabIndex = 24;
            this.NText.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // dxText
            // 
            this.dxText.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.dxText.Location = new System.Drawing.Point(51, 105);
            this.dxText.Name = "dxText";
            this.dxText.ReadOnly = true;
            this.dxText.Size = new System.Drawing.Size(65, 20);
            this.dxText.TabIndex = 23;
            this.dxText.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // noLabel
            // 
            this.noLabel.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.noLabel.AutoSize = true;
            this.noLabel.Location = new System.Drawing.Point(174, 87);
            this.noLabel.Name = "noLabel";
            this.noLabel.Size = new System.Drawing.Size(61, 13);
            this.noLabel.TabIndex = 22;
            this.noLabel.Text = "No of steps";
            // 
            // stepLabel
            // 
            this.stepLabel.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.stepLabel.AutoSize = true;
            this.stepLabel.Location = new System.Drawing.Point(69, 87);
            this.stepLabel.Name = "stepLabel";
            this.stepLabel.Size = new System.Drawing.Size(29, 13);
            this.stepLabel.TabIndex = 21;
            this.stepLabel.Text = "Step";
            this.stepLabel.Click += new System.EventHandler(this.label2_Click);
            // 
            // label3
            // 
            this.label3.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(3, 138);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(41, 13);
            this.label3.TabIndex = 20;
            this.label3.Text = "dy [um]";
            // 
            // label4
            // 
            this.label4.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(3, 108);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(41, 13);
            this.label4.TabIndex = 19;
            this.label4.Text = "dx [um]";
            this.label4.Click += new System.EventHandler(this.label4_Click);
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(149, 138);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(16, 13);
            this.label1.TabIndex = 28;
            this.label1.Text = "M";
            // 
            // label2
            // 
            this.label2.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(150, 108);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(15, 13);
            this.label2.TabIndex = 27;
            this.label2.Text = "N";
            // 
            // label5
            // 
            this.label5.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(151, 168);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(14, 13);
            this.label5.TabIndex = 32;
            this.label5.Text = "T";
            // 
            // TText
            // 
            this.TText.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.TText.Location = new System.Drawing.Point(172, 165);
            this.TText.Name = "TText";
            this.TText.ReadOnly = true;
            this.TText.Size = new System.Drawing.Size(65, 20);
            this.TText.TabIndex = 31;
            this.TText.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // dtText
            // 
            this.dtText.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.dtText.Location = new System.Drawing.Point(51, 165);
            this.dtText.Name = "dtText";
            this.dtText.ReadOnly = true;
            this.dtText.Size = new System.Drawing.Size(65, 20);
            this.dtText.TabIndex = 30;
            this.dtText.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label6
            // 
            this.label6.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(3, 168);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(33, 13);
            this.label6.TabIndex = 29;
            this.label6.Text = "dt [fs]";
            // 
            // materialButton
            // 
            this.materialButton.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.materialButton.Location = new System.Drawing.Point(31, 41);
            this.materialButton.Name = "materialButton";
            this.materialButton.Size = new System.Drawing.Size(99, 23);
            this.materialButton.TabIndex = 33;
            this.materialButton.Text = "Assign Materials";
            this.materialButton.UseVisualStyleBackColor = true;
            this.materialButton.Click += new System.EventHandler(this.button3_Click);
            // 
            // button1
            // 
            this.button1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.button1.Location = new System.Drawing.Point(30, 6);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(100, 23);
            this.button1.TabIndex = 1;
            this.button1.Text = "Load Voxel Model";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_click);
            // 
            // modeNo
            // 
            this.modeNo.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.modeNo.Location = new System.Drawing.Point(114, 92);
            this.modeNo.Name = "modeNo";
            this.modeNo.Size = new System.Drawing.Size(71, 20);
            this.modeNo.TabIndex = 0;
            this.modeNo.Text = "3";
            this.modeNo.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // monitorButton
            // 
            this.monitorButton.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.tableLayoutPanel4.SetColumnSpan(this.monitorButton, 2);
            this.monitorButton.Location = new System.Drawing.Point(143, 6);
            this.monitorButton.Name = "monitorButton";
            this.monitorButton.Size = new System.Drawing.Size(75, 23);
            this.monitorButton.TabIndex = 36;
            this.monitorButton.Text = "Monitors";
            this.monitorButton.UseVisualStyleBackColor = true;
            this.monitorButton.Click += new System.EventHandler(this.monitorButton_Click);
            // 
            // pulseLabel
            // 
            this.pulseLabel.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.pulseLabel.AutoSize = true;
            this.tableLayoutPanel2.SetColumnSpan(this.pulseLabel, 3);
            this.pulseLabel.Location = new System.Drawing.Point(17, 77);
            this.pulseLabel.Name = "pulseLabel";
            this.pulseLabel.Size = new System.Drawing.Size(89, 13);
            this.pulseLabel.TabIndex = 38;
            this.pulseLabel.Text = "Number of pulses";
            // 
            // noPulsesText
            // 
            this.tableLayoutPanel2.SetColumnSpan(this.noPulsesText, 2);
            this.noPulsesText.Location = new System.Drawing.Point(126, 75);
            this.noPulsesText.Name = "noPulsesText";
            this.noPulsesText.Size = new System.Drawing.Size(43, 20);
            this.noPulsesText.TabIndex = 37;
            this.noPulsesText.Text = "5";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.tableLayoutPanel1);
            this.groupBox1.Location = new System.Drawing.Point(143, 29);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(174, 137);
            this.groupBox1.TabIndex = 39;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Medium Definition";
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.grapheneButton, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.materialButton, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.button1, 0, 0);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(7, 24);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 3;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(161, 107);
            this.tableLayoutPanel1.TabIndex = 52;
            // 
            // grapheneButton
            // 
            this.grapheneButton.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.grapheneButton.Location = new System.Drawing.Point(32, 77);
            this.grapheneButton.Name = "grapheneButton";
            this.grapheneButton.Size = new System.Drawing.Size(97, 23);
            this.grapheneButton.TabIndex = 34;
            this.grapheneButton.Text = "Graphene Layers";
            this.grapheneButton.UseVisualStyleBackColor = true;
            this.grapheneButton.Click += new System.EventHandler(this.grapheneButton_Click);
            // 
            // label7
            // 
            this.label7.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(3, 95);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(90, 13);
            this.label7.TabIndex = 40;
            this.label7.Text = "Number of modes";
            // 
            // label8
            // 
            this.label8.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(3, 125);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(77, 13);
            this.label8.TabIndex = 42;
            this.label8.Text = "Search around";
            this.label8.Click += new System.EventHandler(this.label8_Click);
            // 
            // effID
            // 
            this.effID.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.effID.Location = new System.Drawing.Point(114, 122);
            this.effID.Name = "effID";
            this.effID.Size = new System.Drawing.Size(71, 20);
            this.effID.TabIndex = 41;
            this.effID.Text = "5";
            // 
            // modalButton
            // 
            this.modalButton.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.tableLayoutPanel3.SetColumnSpan(this.modalButton, 2);
            this.modalButton.Enabled = false;
            this.modalButton.Location = new System.Drawing.Point(52, 151);
            this.modalButton.Name = "modalButton";
            this.modalButton.Size = new System.Drawing.Size(95, 23);
            this.modalButton.TabIndex = 43;
            this.modalButton.Text = "Mode Analysis";
            this.modalButton.UseVisualStyleBackColor = true;
            this.modalButton.Click += new System.EventHandler(this.modalButton_Click);
            // 
            // checkButton
            // 
            this.checkButton.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.tableLayoutPanel3.SetColumnSpan(this.checkButton, 2);
            this.checkButton.Location = new System.Drawing.Point(60, 5);
            this.checkButton.Name = "checkButton";
            this.checkButton.Size = new System.Drawing.Size(79, 23);
            this.checkButton.TabIndex = 44;
            this.checkButton.Text = "Initial Check";
            this.checkButton.UseVisualStyleBackColor = true;
            this.checkButton.Click += new System.EventHandler(this.checkButton_Click);
            // 
            // dofText
            // 
            this.dofText.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.dofText.Location = new System.Drawing.Point(117, 60);
            this.dofText.Name = "dofText";
            this.dofText.ReadOnly = true;
            this.dofText.Size = new System.Drawing.Size(65, 20);
            this.dofText.TabIndex = 48;
            this.dofText.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // deltaText
            // 
            this.deltaText.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.deltaText.Location = new System.Drawing.Point(17, 60);
            this.deltaText.Name = "deltaText";
            this.deltaText.ReadOnly = true;
            this.deltaText.Size = new System.Drawing.Size(65, 20);
            this.deltaText.TabIndex = 47;
            this.deltaText.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label9
            // 
            this.label9.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(121, 44);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(58, 13);
            this.label9.TabIndex = 46;
            this.label9.Text = "Unknowns";
            // 
            // label10
            // 
            this.label10.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(16, 44);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(68, 13);
            this.label10.TabIndex = 45;
            this.label10.Text = "Cell size [um]";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.tableLayoutPanel2);
            this.groupBox2.Location = new System.Drawing.Point(391, 12);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(212, 221);
            this.groupBox2.TabIndex = 49;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Domain Attributes";
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 5;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 19.9026F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 16.01948F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 16.01948F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 16.01948F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 16.01948F));
            this.tableLayoutPanel2.Controls.Add(this.yaxisLabel, 0, 7);
            this.tableLayoutPanel2.Controls.Add(this.frequencyLabel, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.bandwidthText, 3, 1);
            this.tableLayoutPanel2.Controls.Add(this.bandwidthLabel, 0, 1);
            this.tableLayoutPanel2.Controls.Add(this.c2lLabel, 0, 2);
            this.tableLayoutPanel2.Controls.Add(this.pulseLabel, 0, 3);
            this.tableLayoutPanel2.Controls.Add(this.frequencyText, 3, 0);
            this.tableLayoutPanel2.Controls.Add(this.c2lText, 3, 2);
            this.tableLayoutPanel2.Controls.Add(this.noPulsesText, 3, 3);
            this.tableLayoutPanel2.Controls.Add(this.xaxisLabel, 0, 6);
            this.tableLayoutPanel2.Controls.Add(this.minLabel, 1, 5);
            this.tableLayoutPanel2.Controls.Add(this.maxLabel, 3, 5);
            this.tableLayoutPanel2.Controls.Add(this.xminText, 1, 6);
            this.tableLayoutPanel2.Controls.Add(this.yminText, 1, 7);
            this.tableLayoutPanel2.Controls.Add(this.ymaxText, 3, 7);
            this.tableLayoutPanel2.Controls.Add(this.xmaxText, 3, 6);
            this.tableLayoutPanel2.Location = new System.Drawing.Point(6, 19);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 8;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(200, 194);
            this.tableLayoutPanel2.TabIndex = 52;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.tableLayoutPanel3);
            this.groupBox3.Location = new System.Drawing.Point(391, 252);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(212, 235);
            this.groupBox3.TabIndex = 50;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Modal Solver";
            // 
            // tableLayoutPanel3
            // 
            this.tableLayoutPanel3.ColumnCount = 2;
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel3.Controls.Add(this.label10, 0, 1);
            this.tableLayoutPanel3.Controls.Add(this.effID, 1, 4);
            this.tableLayoutPanel3.Controls.Add(this.modeNo, 1, 3);
            this.tableLayoutPanel3.Controls.Add(this.label9, 1, 1);
            this.tableLayoutPanel3.Controls.Add(this.label7, 0, 3);
            this.tableLayoutPanel3.Controls.Add(this.label8, 0, 4);
            this.tableLayoutPanel3.Controls.Add(this.dofText, 1, 2);
            this.tableLayoutPanel3.Controls.Add(this.deltaText, 0, 2);
            this.tableLayoutPanel3.Controls.Add(this.checkButton, 0, 0);
            this.tableLayoutPanel3.Controls.Add(this.modalButton, 0, 5);
            this.tableLayoutPanel3.Controls.Add(this.indexButton, 0, 6);
            this.tableLayoutPanel3.Location = new System.Drawing.Point(6, 19);
            this.tableLayoutPanel3.Name = "tableLayoutPanel3";
            this.tableLayoutPanel3.RowCount = 7;
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 16.09414F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 11.82121F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 14.41611F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 14.41611F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 14.41611F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 14.41611F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 14.4202F));
            this.tableLayoutPanel3.Size = new System.Drawing.Size(200, 210);
            this.tableLayoutPanel3.TabIndex = 52;
            // 
            // indexButton
            // 
            this.indexButton.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.tableLayoutPanel3.SetColumnSpan(this.indexButton, 2);
            this.indexButton.Enabled = false;
            this.indexButton.Location = new System.Drawing.Point(62, 184);
            this.indexButton.Name = "indexButton";
            this.indexButton.Size = new System.Drawing.Size(75, 23);
            this.indexButton.TabIndex = 49;
            this.indexButton.Text = "Results";
            this.indexButton.UseVisualStyleBackColor = true;
            this.indexButton.Click += new System.EventHandler(this.indexButton_Click);
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.tableLayoutPanel4);
            this.groupBox4.Location = new System.Drawing.Point(97, 205);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(253, 255);
            this.groupBox4.TabIndex = 51;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Full-wave Simulation";
            // 
            // tableLayoutPanel4
            // 
            this.tableLayoutPanel4.ColumnCount = 4;
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 30F));
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 30F));
            this.tableLayoutPanel4.Controls.Add(this.simButton, 0, 6);
            this.tableLayoutPanel4.Controls.Add(this.dxText, 1, 3);
            this.tableLayoutPanel4.Controls.Add(this.noLabel, 3, 2);
            this.tableLayoutPanel4.Controls.Add(this.stepLabel, 1, 2);
            this.tableLayoutPanel4.Controls.Add(this.sourceButton, 0, 0);
            this.tableLayoutPanel4.Controls.Add(this.label4, 0, 3);
            this.tableLayoutPanel4.Controls.Add(this.label5, 2, 5);
            this.tableLayoutPanel4.Controls.Add(this.label3, 0, 4);
            this.tableLayoutPanel4.Controls.Add(this.label1, 2, 4);
            this.tableLayoutPanel4.Controls.Add(this.TText, 3, 5);
            this.tableLayoutPanel4.Controls.Add(this.label2, 2, 3);
            this.tableLayoutPanel4.Controls.Add(this.monitorButton, 2, 0);
            this.tableLayoutPanel4.Controls.Add(this.MText, 3, 4);
            this.tableLayoutPanel4.Controls.Add(this.NText, 3, 3);
            this.tableLayoutPanel4.Controls.Add(this.dtText, 1, 5);
            this.tableLayoutPanel4.Controls.Add(this.label6, 0, 5);
            this.tableLayoutPanel4.Controls.Add(this.dyText, 1, 4);
            this.tableLayoutPanel4.Controls.Add(this.button2, 0, 1);
            this.tableLayoutPanel4.Location = new System.Drawing.Point(6, 19);
            this.tableLayoutPanel4.Name = "tableLayoutPanel4";
            this.tableLayoutPanel4.RowCount = 7;
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 15.52578F));
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 15.52578F));
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 13.35217F));
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 13.35683F));
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 13.35683F));
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 13.35683F));
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 15.52578F));
            this.tableLayoutPanel4.Size = new System.Drawing.Size(242, 229);
            this.tableLayoutPanel4.TabIndex = 52;
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
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.tableLayoutPanel5);
            this.groupBox5.Location = new System.Drawing.Point(639, 140);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(211, 265);
            this.groupBox5.TabIndex = 52;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "Polynomial Chaos Analysis";
            // 
            // tableLayoutPanel5
            // 
            this.tableLayoutPanel5.ColumnCount = 3;
            this.tableLayoutPanel5.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 23.80952F));
            this.tableLayoutPanel5.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 38.09524F));
            this.tableLayoutPanel5.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 38.09524F));
            this.tableLayoutPanel5.Controls.Add(this.label16, 0, 3);
            this.tableLayoutPanel5.Controls.Add(this.statButton, 1, 7);
            this.tableLayoutPanel5.Controls.Add(this.label15, 0, 1);
            this.tableLayoutPanel5.Controls.Add(this.evalSelectionButton, 1, 6);
            this.tableLayoutPanel5.Controls.Add(this.label11, 1, 0);
            this.tableLayoutPanel5.Controls.Add(this.pointsButton, 1, 4);
            this.tableLayoutPanel5.Controls.Add(this.label12, 2, 0);
            this.tableLayoutPanel5.Controls.Add(this.quadOrderText, 2, 3);
            this.tableLayoutPanel5.Controls.Add(this.label14, 2, 2);
            this.tableLayoutPanel5.Controls.Add(this.polyOrderText, 1, 3);
            this.tableLayoutPanel5.Controls.Add(this.label13, 1, 2);
            this.tableLayoutPanel5.Controls.Add(this.upperLimitText, 2, 1);
            this.tableLayoutPanel5.Controls.Add(this.lowerLimitText, 1, 1);
            this.tableLayoutPanel5.Location = new System.Drawing.Point(6, 19);
            this.tableLayoutPanel5.Name = "tableLayoutPanel5";
            this.tableLayoutPanel5.RowCount = 8;
            this.tableLayoutPanel5.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 7.003934F));
            this.tableLayoutPanel5.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 13.28515F));
            this.tableLayoutPanel5.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 13.28515F));
            this.tableLayoutPanel5.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 13.28515F));
            this.tableLayoutPanel5.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 13.28515F));
            this.tableLayoutPanel5.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 13.28515F));
            this.tableLayoutPanel5.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 13.28515F));
            this.tableLayoutPanel5.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 13.28515F));
            this.tableLayoutPanel5.Size = new System.Drawing.Size(200, 239);
            this.tableLayoutPanel5.TabIndex = 13;
            // 
            // label16
            // 
            this.label16.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(7, 87);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(33, 13);
            this.label16.TabIndex = 9;
            this.label16.Text = "Order";
            // 
            // statButton
            // 
            this.statButton.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.tableLayoutPanel5.SetColumnSpan(this.statButton, 2);
            this.statButton.Enabled = false;
            this.statButton.Location = new System.Drawing.Point(73, 209);
            this.statButton.Name = "statButton";
            this.statButton.Size = new System.Drawing.Size(100, 23);
            this.statButton.TabIndex = 12;
            this.statButton.Text = "Export Statistics";
            this.statButton.UseVisualStyleBackColor = true;
            this.statButton.Click += new System.EventHandler(this.statButton_Click);
            // 
            // label15
            // 
            this.label15.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(9, 25);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(28, 13);
            this.label15.TabIndex = 8;
            this.label15.Text = "Limit";
            // 
            // evalSelectionButton
            // 
            this.evalSelectionButton.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.tableLayoutPanel5.SetColumnSpan(this.evalSelectionButton, 2);
            this.evalSelectionButton.Location = new System.Drawing.Point(73, 175);
            this.evalSelectionButton.Name = "evalSelectionButton";
            this.evalSelectionButton.Size = new System.Drawing.Size(100, 23);
            this.evalSelectionButton.TabIndex = 11;
            this.evalSelectionButton.Text = "Select Files...";
            this.evalSelectionButton.UseVisualStyleBackColor = true;
            this.evalSelectionButton.Click += new System.EventHandler(this.evalSelectionButton_Click);
            // 
            // label11
            // 
            this.label11.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(67, 3);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(36, 13);
            this.label11.TabIndex = 4;
            this.label11.Text = "Lower";
            // 
            // pointsButton
            // 
            this.pointsButton.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.tableLayoutPanel5.SetColumnSpan(this.pointsButton, 2);
            this.pointsButton.Location = new System.Drawing.Point(73, 113);
            this.pointsButton.Name = "pointsButton";
            this.pointsButton.Size = new System.Drawing.Size(100, 23);
            this.pointsButton.TabIndex = 10;
            this.pointsButton.Text = "Evaluation Points";
            this.pointsButton.UseVisualStyleBackColor = true;
            this.pointsButton.Click += new System.EventHandler(this.pointsButton_Click);
            // 
            // label12
            // 
            this.label12.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(143, 3);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(36, 13);
            this.label12.TabIndex = 5;
            this.label12.Text = "Upper";
            // 
            // quadOrderText
            // 
            this.quadOrderText.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.quadOrderText.Location = new System.Drawing.Point(132, 83);
            this.quadOrderText.Name = "quadOrderText";
            this.quadOrderText.Size = new System.Drawing.Size(59, 20);
            this.quadOrderText.TabIndex = 3;
            this.quadOrderText.Text = "12";
            // 
            // label14
            // 
            this.label14.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(131, 65);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(60, 13);
            this.label14.TabIndex = 7;
            this.label14.Text = "Quadrature";
            // 
            // polyOrderText
            // 
            this.polyOrderText.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.polyOrderText.Location = new System.Drawing.Point(55, 83);
            this.polyOrderText.Name = "polyOrderText";
            this.polyOrderText.Size = new System.Drawing.Size(59, 20);
            this.polyOrderText.TabIndex = 2;
            this.polyOrderText.Text = "8";
            // 
            // label13
            // 
            this.label13.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(56, 65);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(57, 13);
            this.label13.TabIndex = 6;
            this.label13.Text = "Polynomial";
            // 
            // upperLimitText
            // 
            this.upperLimitText.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.upperLimitText.Location = new System.Drawing.Point(132, 21);
            this.upperLimitText.Name = "upperLimitText";
            this.upperLimitText.Size = new System.Drawing.Size(59, 20);
            this.upperLimitText.TabIndex = 1;
            this.upperLimitText.Text = "0.5";
            // 
            // lowerLimitText
            // 
            this.lowerLimitText.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lowerLimitText.Location = new System.Drawing.Point(55, 21);
            this.lowerLimitText.Name = "lowerLimitText";
            this.lowerLimitText.Size = new System.Drawing.Size(59, 20);
            this.lowerLimitText.TabIndex = 0;
            this.lowerLimitText.Text = "0";
            // 
            // CoreForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(930, 522);
            this.Controls.Add(this.groupBox5);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.aboutButton);
            this.Name = "CoreForm";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.groupBox1.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.tableLayoutPanel3.ResumeLayout(false);
            this.tableLayoutPanel3.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.tableLayoutPanel4.ResumeLayout(false);
            this.tableLayoutPanel4.PerformLayout();
            this.groupBox5.ResumeLayout(false);
            this.tableLayoutPanel5.ResumeLayout(false);
            this.tableLayoutPanel5.PerformLayout();
            this.ResumeLayout(false);

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
        private System.Windows.Forms.Button aboutButton;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox modeNo;
        private System.Windows.Forms.Button monitorButton;
        private System.Windows.Forms.Label pulseLabel;
        private System.Windows.Forms.TextBox noPulsesText;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox effID;
        private System.Windows.Forms.Button modalButton;
        private System.Windows.Forms.Button checkButton;
        private System.Windows.Forms.TextBox dofText;
        private System.Windows.Forms.TextBox deltaText;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Button grapheneButton;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel3;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel4;
        private System.Windows.Forms.Button indexButton;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox quadOrderText;
        private System.Windows.Forms.TextBox polyOrderText;
        private System.Windows.Forms.TextBox upperLimitText;
        private System.Windows.Forms.TextBox lowerLimitText;
        private System.Windows.Forms.Button pointsButton;
        private System.Windows.Forms.Button evalSelectionButton;
        private System.Windows.Forms.Button statButton;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel5;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label label16;
    }
}

