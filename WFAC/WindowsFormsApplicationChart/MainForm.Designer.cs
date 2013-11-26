namespace WindowsFormsApplicationChart
{
    partial class MainForm
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
			System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea5 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
			System.Windows.Forms.DataVisualization.Charting.Series series5 = new System.Windows.Forms.DataVisualization.Charting.Series();
			this.cutsPanel = new System.Windows.Forms.Panel();
			this.cutCollectionPanel = new System.Windows.Forms.Panel();
			this.cutDetailsPanel = new System.Windows.Forms.Panel();
			this.label6 = new System.Windows.Forms.Label();
			this.label5 = new System.Windows.Forms.Label();
			this.label4 = new System.Windows.Forms.Label();
			this.label3 = new System.Windows.Forms.Label();
			this.x2TextBox = new System.Windows.Forms.TextBox();
			this.label2 = new System.Windows.Forms.Label();
			this.x1TextBox = new System.Windows.Forms.TextBox();
			this.label1 = new System.Windows.Forms.Label();
			this.menuPanel = new System.Windows.Forms.MenuStrip();
			this.loadMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.saveMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.mousePositionLabel = new System.Windows.Forms.Label();
			this.minMaxPanel = new System.Windows.Forms.Panel();
			this.yLogCheckBox = new System.Windows.Forms.CheckBox();
			this.yMaxTextBox = new System.Windows.Forms.TextBox();
			this.yMinTextBox = new System.Windows.Forms.TextBox();
			this.xLogCheckBox = new System.Windows.Forms.CheckBox();
			this.xMaxTextBox = new System.Windows.Forms.TextBox();
			this.xMinTextBox = new System.Windows.Forms.TextBox();
			this.yMaxLabel = new System.Windows.Forms.Label();
			this.yMinLabel = new System.Windows.Forms.Label();
			this.xMaxLabel = new System.Windows.Forms.Label();
			this.xMinLabel = new System.Windows.Forms.Label();
			this.chart = new System.Windows.Forms.DataVisualization.Charting.Chart();
			this.tbDeltaX = new System.Windows.Forms.TextBox();
			this.tbDeltaY = new System.Windows.Forms.TextBox();
			this.tbSlope = new System.Windows.Forms.TextBox();
			this.tbArea = new System.Windows.Forms.TextBox();
			this.cutsPanel.SuspendLayout();
			this.cutDetailsPanel.SuspendLayout();
			this.menuPanel.SuspendLayout();
			this.minMaxPanel.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.chart)).BeginInit();
			this.SuspendLayout();
			// 
			// cutsPanel
			// 
			this.cutsPanel.BackColor = System.Drawing.Color.Transparent;
			this.cutsPanel.Controls.Add(this.cutCollectionPanel);
			this.cutsPanel.Controls.Add(this.cutDetailsPanel);
			this.cutsPanel.Dock = System.Windows.Forms.DockStyle.Right;
			this.cutsPanel.Location = new System.Drawing.Point(1248, 44);
			this.cutsPanel.Margin = new System.Windows.Forms.Padding(0);
			this.cutsPanel.Name = "cutsPanel";
			this.cutsPanel.Size = new System.Drawing.Size(400, 650);
			this.cutsPanel.TabIndex = 1;
			// 
			// cutCollectionPanel
			// 
			this.cutCollectionPanel.AutoScroll = true;
			this.cutCollectionPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.cutCollectionPanel.Location = new System.Drawing.Point(8, 488);
			this.cutCollectionPanel.Margin = new System.Windows.Forms.Padding(6);
			this.cutCollectionPanel.Name = "cutCollectionPanel";
			this.cutCollectionPanel.Size = new System.Drawing.Size(384, 327);
			this.cutCollectionPanel.TabIndex = 1;
			// 
			// cutDetailsPanel
			// 
			this.cutDetailsPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.cutDetailsPanel.Controls.Add(this.tbArea);
			this.cutDetailsPanel.Controls.Add(this.tbSlope);
			this.cutDetailsPanel.Controls.Add(this.tbDeltaY);
			this.cutDetailsPanel.Controls.Add(this.tbDeltaX);
			this.cutDetailsPanel.Controls.Add(this.label6);
			this.cutDetailsPanel.Controls.Add(this.label5);
			this.cutDetailsPanel.Controls.Add(this.label4);
			this.cutDetailsPanel.Controls.Add(this.label3);
			this.cutDetailsPanel.Controls.Add(this.x2TextBox);
			this.cutDetailsPanel.Controls.Add(this.label2);
			this.cutDetailsPanel.Controls.Add(this.x1TextBox);
			this.cutDetailsPanel.Controls.Add(this.label1);
			this.cutDetailsPanel.Location = new System.Drawing.Point(8, 2);
			this.cutDetailsPanel.Margin = new System.Windows.Forms.Padding(2);
			this.cutDetailsPanel.Name = "cutDetailsPanel";
			this.cutDetailsPanel.Size = new System.Drawing.Size(384, 477);
			this.cutDetailsPanel.TabIndex = 3;
			// 
			// label6
			// 
			this.label6.Location = new System.Drawing.Point(20, 245);
			this.label6.Margin = new System.Windows.Forms.Padding(20, 19, 20, 0);
			this.label6.Name = "label6";
			this.label6.Size = new System.Drawing.Size(84, 25);
			this.label6.TabIndex = 10;
			this.label6.Text = "deltaY";
			// 
			// label5
			// 
			this.label5.AutoSize = true;
			this.label5.Location = new System.Drawing.Point(20, 335);
			this.label5.Margin = new System.Windows.Forms.Padding(20, 19, 20, 0);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(57, 25);
			this.label5.TabIndex = 8;
			this.label5.Text = "Area";
			// 
			// label4
			// 
			this.label4.AutoSize = true;
			this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.label4.Location = new System.Drawing.Point(20, 290);
			this.label4.Margin = new System.Windows.Forms.Padding(20, 19, 20, 0);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(68, 26);
			this.label4.TabIndex = 6;
			this.label4.Text = "Slope";
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Location = new System.Drawing.Point(20, 200);
			this.label3.Margin = new System.Windows.Forms.Padding(20, 19, 20, 0);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(73, 25);
			this.label3.TabIndex = 4;
			this.label3.Text = "deltaX";
			// 
			// x2TextBox
			// 
			this.x2TextBox.Location = new System.Drawing.Point(26, 146);
			this.x2TextBox.Margin = new System.Windows.Forms.Padding(20, 10, 20, 0);
			this.x2TextBox.Name = "x2TextBox";
			this.x2TextBox.Size = new System.Drawing.Size(324, 31);
			this.x2TextBox.TabIndex = 3;
			this.x2TextBox.Text = "0";
			this.x2TextBox.TextChanged += new System.EventHandler(this.xTextBox_TextChanged);
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(20, 112);
			this.label2.Margin = new System.Windows.Forms.Padding(20, 19, 20, 0);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(38, 25);
			this.label2.TabIndex = 2;
			this.label2.Text = "X2";
			// 
			// x1TextBox
			// 
			this.x1TextBox.Location = new System.Drawing.Point(26, 54);
			this.x1TextBox.Margin = new System.Windows.Forms.Padding(20, 10, 20, 0);
			this.x1TextBox.Name = "x1TextBox";
			this.x1TextBox.Size = new System.Drawing.Size(324, 31);
			this.x1TextBox.TabIndex = 1;
			this.x1TextBox.Text = "0";
			this.x1TextBox.TextChanged += new System.EventHandler(this.xTextBox_TextChanged);
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(20, 19);
			this.label1.Margin = new System.Windows.Forms.Padding(20, 19, 20, 0);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(38, 25);
			this.label1.TabIndex = 0;
			this.label1.Text = "X1";
			// 
			// menuPanel
			// 
			this.menuPanel.BackColor = System.Drawing.SystemColors.Window;
			this.menuPanel.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.loadMenuItem,
            this.saveMenuItem});
			this.menuPanel.Location = new System.Drawing.Point(0, 0);
			this.menuPanel.Name = "menuPanel";
			this.menuPanel.Padding = new System.Windows.Forms.Padding(12, 4, 0, 4);
			this.menuPanel.Size = new System.Drawing.Size(1648, 44);
			this.menuPanel.TabIndex = 0;
			// 
			// loadMenuItem
			// 
			this.loadMenuItem.Name = "loadMenuItem";
			this.loadMenuItem.Size = new System.Drawing.Size(151, 36);
			this.loadMenuItem.Text = "ЗАГРУЗИТЬ";
			this.loadMenuItem.Click += new System.EventHandler(this.loadMenuItem_Click);
			// 
			// saveMenuItem
			// 
			this.saveMenuItem.Name = "saveMenuItem";
			this.saveMenuItem.Size = new System.Drawing.Size(164, 36);
			this.saveMenuItem.Text = "СОХРАНИТЬ";
			this.saveMenuItem.Click += new System.EventHandler(this.saveMenuItem_Click);
			// 
			// mousePositionLabel
			// 
			this.mousePositionLabel.AutoSize = true;
			this.mousePositionLabel.Location = new System.Drawing.Point(617, 9);
			this.mousePositionLabel.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
			this.mousePositionLabel.Name = "mousePositionLabel";
			this.mousePositionLabel.Size = new System.Drawing.Size(125, 25);
			this.mousePositionLabel.TabIndex = 1001;
			this.mousePositionLabel.Text = "X = 0; Y = 0";
			this.mousePositionLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// minMaxPanel
			// 
			this.minMaxPanel.Controls.Add(this.yLogCheckBox);
			this.minMaxPanel.Controls.Add(this.yMaxTextBox);
			this.minMaxPanel.Controls.Add(this.yMinTextBox);
			this.minMaxPanel.Controls.Add(this.xLogCheckBox);
			this.minMaxPanel.Controls.Add(this.xMaxTextBox);
			this.minMaxPanel.Controls.Add(this.xMinTextBox);
			this.minMaxPanel.Controls.Add(this.yMaxLabel);
			this.minMaxPanel.Controls.Add(this.yMinLabel);
			this.minMaxPanel.Controls.Add(this.xMaxLabel);
			this.minMaxPanel.Controls.Add(this.xMinLabel);
			this.minMaxPanel.Dock = System.Windows.Forms.DockStyle.Top;
			this.minMaxPanel.Location = new System.Drawing.Point(0, 44);
			this.minMaxPanel.Margin = new System.Windows.Forms.Padding(6);
			this.minMaxPanel.Name = "minMaxPanel";
			this.minMaxPanel.Size = new System.Drawing.Size(1248, 48);
			this.minMaxPanel.TabIndex = 0;
			// 
			// yLogCheckBox
			// 
			this.yLogCheckBox.AutoSize = true;
			this.yLogCheckBox.Location = new System.Drawing.Point(1078, 10);
			this.yLogCheckBox.Margin = new System.Windows.Forms.Padding(10, 6, 6, 6);
			this.yLogCheckBox.Name = "yLogCheckBox";
			this.yLogCheckBox.Size = new System.Drawing.Size(103, 29);
			this.yLogCheckBox.TabIndex = 2;
			this.yLogCheckBox.Text = "LOG Y";
			this.yLogCheckBox.UseVisualStyleBackColor = true;
			this.yLogCheckBox.CheckedChanged += new System.EventHandler(this.logCheckBox_CheckedChanged);
			// 
			// yMaxTextBox
			// 
			this.yMaxTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.yMaxTextBox.Location = new System.Drawing.Point(766, 6);
			this.yMaxTextBox.Margin = new System.Windows.Forms.Padding(6);
			this.yMaxTextBox.MaximumSize = new System.Drawing.Size(116, 20);
			this.yMaxTextBox.MinimumSize = new System.Drawing.Size(116, 20);
			this.yMaxTextBox.Name = "yMaxTextBox";
			this.yMaxTextBox.Size = new System.Drawing.Size(116, 31);
			this.yMaxTextBox.TabIndex = 7;
			// 
			// yMinTextBox
			// 
			this.yMinTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.yMinTextBox.Location = new System.Drawing.Point(538, 6);
			this.yMinTextBox.Margin = new System.Windows.Forms.Padding(6);
			this.yMinTextBox.MaximumSize = new System.Drawing.Size(116, 20);
			this.yMinTextBox.MinimumSize = new System.Drawing.Size(116, 20);
			this.yMinTextBox.Name = "yMinTextBox";
			this.yMinTextBox.Size = new System.Drawing.Size(116, 31);
			this.yMinTextBox.TabIndex = 6;
			// 
			// xLogCheckBox
			// 
			this.xLogCheckBox.AutoSize = true;
			this.xLogCheckBox.Location = new System.Drawing.Point(940, 10);
			this.xLogCheckBox.Margin = new System.Windows.Forms.Padding(10, 6, 6, 6);
			this.xLogCheckBox.Name = "xLogCheckBox";
			this.xLogCheckBox.Size = new System.Drawing.Size(102, 29);
			this.xLogCheckBox.TabIndex = 1;
			this.xLogCheckBox.Text = "LOG X";
			this.xLogCheckBox.UseVisualStyleBackColor = true;
			this.xLogCheckBox.CheckedChanged += new System.EventHandler(this.logCheckBox_CheckedChanged);
			// 
			// xMaxTextBox
			// 
			this.xMaxTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.xMaxTextBox.Location = new System.Drawing.Point(316, 6);
			this.xMaxTextBox.Margin = new System.Windows.Forms.Padding(6);
			this.xMaxTextBox.MaximumSize = new System.Drawing.Size(116, 20);
			this.xMaxTextBox.MinimumSize = new System.Drawing.Size(116, 20);
			this.xMaxTextBox.Name = "xMaxTextBox";
			this.xMaxTextBox.Size = new System.Drawing.Size(116, 31);
			this.xMaxTextBox.TabIndex = 5;
			// 
			// xMinTextBox
			// 
			this.xMinTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.xMinTextBox.Location = new System.Drawing.Point(96, 6);
			this.xMinTextBox.Margin = new System.Windows.Forms.Padding(6);
			this.xMinTextBox.MaximumSize = new System.Drawing.Size(116, 20);
			this.xMinTextBox.MinimumSize = new System.Drawing.Size(116, 20);
			this.xMinTextBox.Name = "xMinTextBox";
			this.xMinTextBox.Size = new System.Drawing.Size(116, 31);
			this.xMinTextBox.TabIndex = 4;
			// 
			// yMaxLabel
			// 
			this.yMaxLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.yMaxLabel.AutoSize = true;
			this.yMaxLabel.Location = new System.Drawing.Point(688, 12);
			this.yMaxLabel.Margin = new System.Windows.Forms.Padding(6, 0, 0, 0);
			this.yMaxLabel.Name = "yMaxLabel";
			this.yMaxLabel.Size = new System.Drawing.Size(73, 25);
			this.yMaxLabel.TabIndex = 3;
			this.yMaxLabel.Text = "Y max";
			this.yMaxLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// yMinLabel
			// 
			this.yMinLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.yMinLabel.AutoSize = true;
			this.yMinLabel.Location = new System.Drawing.Point(466, 12);
			this.yMinLabel.Margin = new System.Windows.Forms.Padding(6, 0, 0, 0);
			this.yMinLabel.Name = "yMinLabel";
			this.yMinLabel.Size = new System.Drawing.Size(67, 25);
			this.yMinLabel.TabIndex = 2;
			this.yMinLabel.Text = "Y min";
			this.yMinLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// xMaxLabel
			// 
			this.xMaxLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.xMaxLabel.AutoSize = true;
			this.xMaxLabel.Location = new System.Drawing.Point(238, 12);
			this.xMaxLabel.Margin = new System.Windows.Forms.Padding(6, 0, 0, 0);
			this.xMaxLabel.Name = "xMaxLabel";
			this.xMaxLabel.Size = new System.Drawing.Size(72, 25);
			this.xMaxLabel.TabIndex = 1;
			this.xMaxLabel.Text = "X max";
			this.xMaxLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// xMinLabel
			// 
			this.xMinLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.xMinLabel.AutoSize = true;
			this.xMinLabel.Location = new System.Drawing.Point(24, 12);
			this.xMinLabel.Margin = new System.Windows.Forms.Padding(6, 0, 0, 0);
			this.xMinLabel.Name = "xMinLabel";
			this.xMinLabel.Size = new System.Drawing.Size(66, 25);
			this.xMinLabel.TabIndex = 0;
			this.xMinLabel.Text = "X min";
			this.xMinLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// chart
			// 
			chartArea5.AxisX.IntervalAutoMode = System.Windows.Forms.DataVisualization.Charting.IntervalAutoMode.VariableCount;
			chartArea5.AxisY.IntervalAutoMode = System.Windows.Forms.DataVisualization.Charting.IntervalAutoMode.VariableCount;
			chartArea5.Name = "ChartArea1";
			this.chart.ChartAreas.Add(chartArea5);
			this.chart.Dock = System.Windows.Forms.DockStyle.Fill;
			this.chart.Location = new System.Drawing.Point(0, 92);
			this.chart.Margin = new System.Windows.Forms.Padding(6);
			this.chart.Name = "chart";
			series5.BorderWidth = 2;
			series5.ChartArea = "ChartArea1";
			series5.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
			series5.Color = System.Drawing.Color.Green;
			series5.Name = "Series1";
			this.chart.Series.Add(series5);
			this.chart.Size = new System.Drawing.Size(1248, 602);
			this.chart.TabIndex = 1002;
			// 
			// tbDeltaX
			// 
			this.tbDeltaX.BackColor = System.Drawing.Color.White;
			this.tbDeltaX.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.tbDeltaX.Location = new System.Drawing.Point(110, 200);
			this.tbDeltaX.Name = "tbDeltaX";
			this.tbDeltaX.ReadOnly = true;
			this.tbDeltaX.Size = new System.Drawing.Size(100, 24);
			this.tbDeltaX.TabIndex = 12;
			this.tbDeltaX.Text = "0";
			// 
			// tbDeltaY
			// 
			this.tbDeltaY.BackColor = System.Drawing.Color.White;
			this.tbDeltaY.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.tbDeltaY.Location = new System.Drawing.Point(110, 245);
			this.tbDeltaY.Name = "tbDeltaY";
			this.tbDeltaY.ReadOnly = true;
			this.tbDeltaY.Size = new System.Drawing.Size(100, 24);
			this.tbDeltaY.TabIndex = 13;
			this.tbDeltaY.Text = "0";
			// 
			// tbSlope
			// 
			this.tbSlope.BackColor = System.Drawing.Color.White;
			this.tbSlope.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.tbSlope.Location = new System.Drawing.Point(110, 290);
			this.tbSlope.Name = "tbSlope";
			this.tbSlope.ReadOnly = true;
			this.tbSlope.Size = new System.Drawing.Size(100, 24);
			this.tbSlope.TabIndex = 14;
			this.tbSlope.Text = "0";
			// 
			// tbArea
			// 
			this.tbArea.BackColor = System.Drawing.Color.White;
			this.tbArea.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.tbArea.Location = new System.Drawing.Point(110, 335);
			this.tbArea.Name = "tbArea";
			this.tbArea.ReadOnly = true;
			this.tbArea.Size = new System.Drawing.Size(100, 24);
			this.tbArea.TabIndex = 15;
			this.tbArea.Text = "0";
			// 
			// MainForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = System.Drawing.SystemColors.Window;
			this.ClientSize = new System.Drawing.Size(1648, 694);
			this.Controls.Add(this.chart);
			this.Controls.Add(this.minMaxPanel);
			this.Controls.Add(this.mousePositionLabel);
			this.Controls.Add(this.cutsPanel);
			this.Controls.Add(this.menuPanel);
			this.MainMenuStrip = this.menuPanel;
			this.Margin = new System.Windows.Forms.Padding(6);
			this.MinimumSize = new System.Drawing.Size(1654, 704);
			this.Name = "MainForm";
			this.SizeChanged += new System.EventHandler(this.mainForm_SizeChanged);
			this.cutsPanel.ResumeLayout(false);
			this.cutDetailsPanel.ResumeLayout(false);
			this.cutDetailsPanel.PerformLayout();
			this.menuPanel.ResumeLayout(false);
			this.menuPanel.PerformLayout();
			this.minMaxPanel.ResumeLayout(false);
			this.minMaxPanel.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.chart)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel cutsPanel;
        private System.Windows.Forms.MenuStrip menuPanel;
        private System.Windows.Forms.ToolStripMenuItem loadMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveMenuItem;
        private System.Windows.Forms.Panel cutDetailsPanel;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label mousePositionLabel;
        private System.Windows.Forms.Panel cutCollectionPanel;
        private System.Windows.Forms.Panel minMaxPanel;
        private System.Windows.Forms.CheckBox xLogCheckBox;
        private System.Windows.Forms.TextBox yMaxTextBox;
        private System.Windows.Forms.TextBox yMinTextBox;
        private System.Windows.Forms.TextBox xMaxTextBox;
        private System.Windows.Forms.TextBox xMinTextBox;
        private System.Windows.Forms.Label yMaxLabel;
        private System.Windows.Forms.Label yMinLabel;
        private System.Windows.Forms.Label xMaxLabel;
        private System.Windows.Forms.Label xMinLabel;
        private System.Windows.Forms.DataVisualization.Charting.Chart chart;
        private System.Windows.Forms.CheckBox yLogCheckBox;
		private System.Windows.Forms.Label label6;
		public System.Windows.Forms.TextBox tbDeltaX;
		public System.Windows.Forms.TextBox tbArea;
		public System.Windows.Forms.TextBox tbSlope;
		public System.Windows.Forms.TextBox tbDeltaY;
		public System.Windows.Forms.TextBox x1TextBox;
		public System.Windows.Forms.TextBox x2TextBox;
    }
}