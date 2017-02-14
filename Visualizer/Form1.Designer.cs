namespace Visualizer
{
    partial class Form1
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
            this.pbRender = new System.Windows.Forms.PictureBox();
            this.btnGenerate = new System.Windows.Forms.Button();
            this.nudWidth = new System.Windows.Forms.NumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.nudShoreLine = new System.Windows.Forms.NumericUpDown();
            this.Depth = new System.Windows.Forms.Label();
            this.nudDepth = new System.Windows.Forms.NumericUpDown();
            this.label4 = new System.Windows.Forms.Label();
            this.nudHeight = new System.Windows.Forms.NumericUpDown();
            this.label3 = new System.Windows.Forms.Label();
            this.nudSeaLevel = new System.Windows.Forms.NumericUpDown();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnLoad = new System.Windows.Forms.Button();
            this.btnExport = new System.Windows.Forms.Button();
            this.diagExport = new System.Windows.Forms.SaveFileDialog();
            this.browSave = new System.Windows.Forms.FolderBrowserDialog();
            this.diagLoad = new System.Windows.Forms.OpenFileDialog();
            this.cboStyle = new System.Windows.Forms.ComboBox();
            this.label9 = new System.Windows.Forms.Label();
            this.cbOccludeWater = new System.Windows.Forms.CheckBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnRandomSeed = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.nudSeed = new System.Windows.Forms.NumericUpDown();
            this.label7 = new System.Windows.Forms.Label();
            this.nudScaleY = new System.Windows.Forms.NumericUpDown();
            this.label5 = new System.Windows.Forms.Label();
            this.nudScaleX = new System.Windows.Forms.NumericUpDown();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.button1 = new System.Windows.Forms.Button();
            this.lbloffsetx = new System.Windows.Forms.Label();
            this.nudOffsetX = new System.Windows.Forms.NumericUpDown();
            this.label10 = new System.Windows.Forms.Label();
            this.nudOffsetY = new System.Windows.Forms.NumericUpDown();
            ((System.ComponentModel.ISupportInitialize)(this.pbRender)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudWidth)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudShoreLine)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudDepth)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudHeight)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudSeaLevel)).BeginInit();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudSeed)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudScaleY)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudScaleX)).BeginInit();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudOffsetX)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudOffsetY)).BeginInit();
            this.SuspendLayout();
            // 
            // pbRender
            // 
            this.pbRender.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pbRender.Location = new System.Drawing.Point(12, 12);
            this.pbRender.Name = "pbRender";
            this.pbRender.Size = new System.Drawing.Size(256, 256);
            this.pbRender.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbRender.TabIndex = 2;
            this.pbRender.TabStop = false;
            // 
            // btnGenerate
            // 
            this.btnGenerate.Location = new System.Drawing.Point(358, 198);
            this.btnGenerate.Name = "btnGenerate";
            this.btnGenerate.Size = new System.Drawing.Size(75, 23);
            this.btnGenerate.TabIndex = 3;
            this.btnGenerate.Text = "Generate";
            this.btnGenerate.UseVisualStyleBackColor = true;
            this.btnGenerate.Click += new System.EventHandler(this.btnGenerate_Click);
            // 
            // nudWidth
            // 
            this.nudWidth.Increment = new decimal(new int[] {
            64,
            0,
            0,
            0});
            this.nudWidth.Location = new System.Drawing.Point(69, 12);
            this.nudWidth.Maximum = new decimal(new int[] {
            4096,
            0,
            0,
            0});
            this.nudWidth.Name = "nudWidth";
            this.nudWidth.Size = new System.Drawing.Size(73, 20);
            this.nudWidth.TabIndex = 4;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(38, 13);
            this.label1.TabIndex = 5;
            this.label1.Text = "Width:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 120);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(58, 13);
            this.label2.TabIndex = 7;
            this.label2.Text = "ShoreLine:";
            // 
            // nudShoreLine
            // 
            this.nudShoreLine.Increment = new decimal(new int[] {
            64,
            0,
            0,
            0});
            this.nudShoreLine.Location = new System.Drawing.Point(69, 116);
            this.nudShoreLine.Maximum = new decimal(new int[] {
            4096,
            0,
            0,
            0});
            this.nudShoreLine.Name = "nudShoreLine";
            this.nudShoreLine.Size = new System.Drawing.Size(73, 20);
            this.nudShoreLine.TabIndex = 6;
            // 
            // Depth
            // 
            this.Depth.AutoSize = true;
            this.Depth.Location = new System.Drawing.Point(6, 68);
            this.Depth.Name = "Depth";
            this.Depth.Size = new System.Drawing.Size(39, 13);
            this.Depth.TabIndex = 9;
            this.Depth.Text = "Depth:";
            // 
            // nudDepth
            // 
            this.nudDepth.Increment = new decimal(new int[] {
            64,
            0,
            0,
            0});
            this.nudDepth.Location = new System.Drawing.Point(69, 64);
            this.nudDepth.Maximum = new decimal(new int[] {
            4096,
            0,
            0,
            0});
            this.nudDepth.Name = "nudDepth";
            this.nudDepth.Size = new System.Drawing.Size(73, 20);
            this.nudDepth.TabIndex = 8;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(6, 42);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(41, 13);
            this.label4.TabIndex = 11;
            this.label4.Text = "Height:";
            // 
            // nudHeight
            // 
            this.nudHeight.Increment = new decimal(new int[] {
            64,
            0,
            0,
            0});
            this.nudHeight.Location = new System.Drawing.Point(69, 38);
            this.nudHeight.Maximum = new decimal(new int[] {
            4096,
            0,
            0,
            0});
            this.nudHeight.Name = "nudHeight";
            this.nudHeight.Size = new System.Drawing.Size(73, 20);
            this.nudHeight.TabIndex = 10;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 94);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(52, 13);
            this.label3.TabIndex = 13;
            this.label3.Text = "SeaLevel";
            // 
            // nudSeaLevel
            // 
            this.nudSeaLevel.Increment = new decimal(new int[] {
            64,
            0,
            0,
            0});
            this.nudSeaLevel.Location = new System.Drawing.Point(69, 90);
            this.nudSeaLevel.Maximum = new decimal(new int[] {
            4096,
            0,
            0,
            0});
            this.nudSeaLevel.Name = "nudSeaLevel";
            this.nudSeaLevel.Size = new System.Drawing.Size(73, 20);
            this.nudSeaLevel.TabIndex = 12;
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(277, 169);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 23);
            this.btnSave.TabIndex = 24;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnLoad
            // 
            this.btnLoad.Location = new System.Drawing.Point(358, 169);
            this.btnLoad.Name = "btnLoad";
            this.btnLoad.Size = new System.Drawing.Size(75, 23);
            this.btnLoad.TabIndex = 25;
            this.btnLoad.Text = "Load";
            this.btnLoad.UseVisualStyleBackColor = true;
            this.btnLoad.Click += new System.EventHandler(this.btnLoad_Click);
            // 
            // btnExport
            // 
            this.btnExport.Location = new System.Drawing.Point(518, 245);
            this.btnExport.Name = "btnExport";
            this.btnExport.Size = new System.Drawing.Size(75, 23);
            this.btnExport.TabIndex = 26;
            this.btnExport.Text = "Export";
            this.btnExport.UseVisualStyleBackColor = true;
            this.btnExport.Click += new System.EventHandler(this.btnExport_Click);
            // 
            // diagExport
            // 
            this.diagExport.Filter = "Bitmap Image|*.bmp";
            // 
            // diagLoad
            // 
            this.diagLoad.FileName = "openFileDialog1";
            // 
            // cboStyle
            // 
            this.cboStyle.FormattingEnabled = true;
            this.cboStyle.Location = new System.Drawing.Point(68, 119);
            this.cboStyle.Name = "cboStyle";
            this.cboStyle.Size = new System.Drawing.Size(74, 21);
            this.cboStyle.TabIndex = 27;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(6, 122);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(33, 13);
            this.label9.TabIndex = 28;
            this.label9.Text = "Style:";
            // 
            // cbOccludeWater
            // 
            this.cbOccludeWater.AutoSize = true;
            this.cbOccludeWater.Location = new System.Drawing.Point(9, 198);
            this.cbOccludeWater.Name = "cbOccludeWater";
            this.cbOccludeWater.Size = new System.Drawing.Size(98, 17);
            this.cbOccludeWater.TabIndex = 29;
            this.cbOccludeWater.Text = "Occlude Water";
            this.cbOccludeWater.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            this.groupBox1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.groupBox1.Controls.Add(this.nudOffsetY);
            this.groupBox1.Controls.Add(this.lbloffsetx);
            this.groupBox1.Controls.Add(this.btnRandomSeed);
            this.groupBox1.Controls.Add(this.nudOffsetX);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.label10);
            this.groupBox1.Controls.Add(this.nudSeed);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.nudScaleY);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.nudScaleX);
            this.groupBox1.Controls.Add(this.cbOccludeWater);
            this.groupBox1.Controls.Add(this.label9);
            this.groupBox1.Controls.Add(this.cboStyle);
            this.groupBox1.Location = new System.Drawing.Point(439, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(154, 227);
            this.groupBox1.TabIndex = 30;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Landscape";
            // 
            // btnRandomSeed
            // 
            this.btnRandomSeed.Location = new System.Drawing.Point(67, 90);
            this.btnRandomSeed.Name = "btnRandomSeed";
            this.btnRandomSeed.Size = new System.Drawing.Size(75, 23);
            this.btnRandomSeed.TabIndex = 32;
            this.btnRandomSeed.Text = "Random";
            this.btnRandomSeed.UseVisualStyleBackColor = true;
            this.btnRandomSeed.Click += new System.EventHandler(this.btnRandomSeed_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(6, 68);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(35, 13);
            this.label6.TabIndex = 37;
            this.label6.Text = "Seed:";
            // 
            // nudSeed
            // 
            this.nudSeed.Location = new System.Drawing.Point(69, 64);
            this.nudSeed.Maximum = new decimal(new int[] {
            2147483647,
            0,
            0,
            0});
            this.nudSeed.Name = "nudSeed";
            this.nudSeed.Size = new System.Drawing.Size(73, 20);
            this.nudSeed.TabIndex = 36;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(6, 42);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(47, 13);
            this.label7.TabIndex = 35;
            this.label7.Text = "Scale Y:";
            // 
            // nudScaleY
            // 
            this.nudScaleY.DecimalPlaces = 3;
            this.nudScaleY.Increment = new decimal(new int[] {
            1,
            0,
            0,
            196608});
            this.nudScaleY.Location = new System.Drawing.Point(69, 38);
            this.nudScaleY.Maximum = new decimal(new int[] {
            4096,
            0,
            0,
            0});
            this.nudScaleY.Name = "nudScaleY";
            this.nudScaleY.Size = new System.Drawing.Size(73, 20);
            this.nudScaleY.TabIndex = 34;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(6, 16);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(47, 13);
            this.label5.TabIndex = 31;
            this.label5.Text = "Scale X:";
            // 
            // nudScaleX
            // 
            this.nudScaleX.DecimalPlaces = 3;
            this.nudScaleX.Increment = new decimal(new int[] {
            1,
            0,
            0,
            196608});
            this.nudScaleX.Location = new System.Drawing.Point(69, 12);
            this.nudScaleX.Maximum = new decimal(new int[] {
            4096,
            0,
            0,
            0});
            this.nudScaleX.Name = "nudScaleX";
            this.nudScaleX.Size = new System.Drawing.Size(73, 20);
            this.nudScaleX.TabIndex = 30;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Controls.Add(this.nudWidth);
            this.groupBox2.Controls.Add(this.nudShoreLine);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.nudDepth);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.Depth);
            this.groupBox2.Controls.Add(this.nudSeaLevel);
            this.groupBox2.Controls.Add(this.nudHeight);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Location = new System.Drawing.Point(280, 12);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(153, 151);
            this.groupBox2.TabIndex = 31;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Map";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(274, 227);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(156, 23);
            this.button1.TabIndex = 32;
            this.button1.Text = "Generate + Random Seed";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // lbloffsetx
            // 
            this.lbloffsetx.AutoSize = true;
            this.lbloffsetx.Location = new System.Drawing.Point(6, 150);
            this.lbloffsetx.Name = "lbloffsetx";
            this.lbloffsetx.Size = new System.Drawing.Size(45, 13);
            this.lbloffsetx.TabIndex = 15;
            this.lbloffsetx.Text = "OffsetX:";
            // 
            // nudOffsetX
            // 
            this.nudOffsetX.DecimalPlaces = 3;
            this.nudOffsetX.Increment = new decimal(new int[] {
            1,
            0,
            0,
            196608});
            this.nudOffsetX.Location = new System.Drawing.Point(69, 146);
            this.nudOffsetX.Maximum = new decimal(new int[] {
            4096,
            0,
            0,
            0});
            this.nudOffsetX.Minimum = new decimal(new int[] {
            4096,
            0,
            0,
            -2147483648});
            this.nudOffsetX.Name = "nudOffsetX";
            this.nudOffsetX.Size = new System.Drawing.Size(73, 20);
            this.nudOffsetX.TabIndex = 14;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(6, 176);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(45, 13);
            this.label10.TabIndex = 17;
            this.label10.Text = "OffsetY:";
            // 
            // nudOffsetY
            // 
            this.nudOffsetY.DecimalPlaces = 3;
            this.nudOffsetY.Increment = new decimal(new int[] {
            1,
            0,
            0,
            196608});
            this.nudOffsetY.Location = new System.Drawing.Point(69, 172);
            this.nudOffsetY.Maximum = new decimal(new int[] {
            4096,
            0,
            0,
            0});
            this.nudOffsetY.Minimum = new decimal(new int[] {
            4096,
            0,
            0,
            -2147483648});
            this.nudOffsetY.Name = "nudOffsetY";
            this.nudOffsetY.Size = new System.Drawing.Size(73, 20);
            this.nudOffsetY.TabIndex = 38;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(603, 280);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btnExport);
            this.Controls.Add(this.btnLoad);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.btnGenerate);
            this.Controls.Add(this.pbRender);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Map Visualizer";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pbRender)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudWidth)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudShoreLine)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudDepth)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudHeight)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudSeaLevel)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudSeed)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudScaleY)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudScaleX)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudOffsetX)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudOffsetY)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.PictureBox pbRender;
        private System.Windows.Forms.Button btnGenerate;
        private System.Windows.Forms.NumericUpDown nudWidth;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.NumericUpDown nudShoreLine;
        private System.Windows.Forms.Label Depth;
        private System.Windows.Forms.NumericUpDown nudDepth;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.NumericUpDown nudHeight;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.NumericUpDown nudSeaLevel;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnLoad;
        private System.Windows.Forms.Button btnExport;
        private System.Windows.Forms.SaveFileDialog diagExport;
        private System.Windows.Forms.FolderBrowserDialog browSave;
        private System.Windows.Forms.OpenFileDialog diagLoad;
        private System.Windows.Forms.ComboBox cboStyle;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.CheckBox cbOccludeWater;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button btnRandomSeed;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.NumericUpDown nudSeed;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.NumericUpDown nudScaleY;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.NumericUpDown nudScaleX;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label lbloffsetx;
        private System.Windows.Forms.NumericUpDown nudOffsetX;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.NumericUpDown nudOffsetY;
    }
}

