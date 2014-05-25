namespace _2048_Game
{
    partial class MainForm
    {
        /// <summary>
        /// 設計工具所需的變數。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清除任何使用中的資源。
        /// </summary>
        /// <param name="disposing">如果應該處置 Managed 資源則為 true，否則為 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form 設計工具產生的程式碼

        /// <summary>
        /// 此為設計工具支援所需的方法 - 請勿使用程式碼編輯器
        /// 修改這個方法的內容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.d4 = new System.Windows.Forms.Button();
            this.d3 = new System.Windows.Forms.Button();
            this.d2 = new System.Windows.Forms.Button();
            this.d1 = new System.Windows.Forms.Button();
            this.c4 = new System.Windows.Forms.Button();
            this.c3 = new System.Windows.Forms.Button();
            this.c2 = new System.Windows.Forms.Button();
            this.c1 = new System.Windows.Forms.Button();
            this.b4 = new System.Windows.Forms.Button();
            this.b3 = new System.Windows.Forms.Button();
            this.b2 = new System.Windows.Forms.Button();
            this.b1 = new System.Windows.Forms.Button();
            this.a4 = new System.Windows.Forms.Button();
            this.a3 = new System.Windows.Forms.Button();
            this.a2 = new System.Windows.Forms.Button();
            this.a1 = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.lblBestScore = new System.Windows.Forms.Label();
            this.lblPoint = new System.Windows.Forms.Label();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.tSSLTime = new System.Windows.Forms.ToolStripStatusLabel();
            this.tSSLPlayTime = new System.Windows.Forms.ToolStripStatusLabel();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.TSMIReset = new System.Windows.Forms.ToolStripMenuItem();
            this.TSMIMode = new System.Windows.Forms.ToolStripMenuItem();
            this.TSMIAbout = new System.Windows.Forms.ToolStripMenuItem();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.d4);
            this.groupBox2.Controls.Add(this.d3);
            this.groupBox2.Controls.Add(this.d2);
            this.groupBox2.Controls.Add(this.d1);
            this.groupBox2.Controls.Add(this.c4);
            this.groupBox2.Controls.Add(this.c3);
            this.groupBox2.Controls.Add(this.c2);
            this.groupBox2.Controls.Add(this.c1);
            this.groupBox2.Controls.Add(this.b4);
            this.groupBox2.Controls.Add(this.b3);
            this.groupBox2.Controls.Add(this.b2);
            this.groupBox2.Controls.Add(this.b1);
            this.groupBox2.Controls.Add(this.a4);
            this.groupBox2.Controls.Add(this.a3);
            this.groupBox2.Controls.Add(this.a2);
            this.groupBox2.Controls.Add(this.a1);
            this.groupBox2.Location = new System.Drawing.Point(6, 120);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(390, 414);
            this.groupBox2.TabIndex = 4;
            this.groupBox2.TabStop = false;
            this.groupBox2.Paint += new System.Windows.Forms.PaintEventHandler(this.groupBox2_Paint);
            // 
            // d4
            // 
            this.d4.AutoEllipsis = true;
            this.d4.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.d4.Font = new System.Drawing.Font("微軟正黑體", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.d4.Location = new System.Drawing.Point(294, 309);
            this.d4.Name = "d4";
            this.d4.Size = new System.Drawing.Size(90, 90);
            this.d4.TabIndex = 15;
            this.d4.TabStop = false;
            this.d4.UseVisualStyleBackColor = true;
            // 
            // d3
            // 
            this.d3.AutoEllipsis = true;
            this.d3.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.d3.Font = new System.Drawing.Font("微軟正黑體", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.d3.Location = new System.Drawing.Point(294, 213);
            this.d3.Name = "d3";
            this.d3.Size = new System.Drawing.Size(90, 90);
            this.d3.TabIndex = 14;
            this.d3.TabStop = false;
            this.d3.UseVisualStyleBackColor = true;
            // 
            // d2
            // 
            this.d2.AutoEllipsis = true;
            this.d2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.d2.Font = new System.Drawing.Font("微軟正黑體", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.d2.Location = new System.Drawing.Point(294, 117);
            this.d2.Name = "d2";
            this.d2.Size = new System.Drawing.Size(90, 90);
            this.d2.TabIndex = 13;
            this.d2.TabStop = false;
            this.d2.UseVisualStyleBackColor = true;
            // 
            // d1
            // 
            this.d1.AutoEllipsis = true;
            this.d1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.d1.Font = new System.Drawing.Font("微軟正黑體", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.d1.Location = new System.Drawing.Point(294, 21);
            this.d1.Name = "d1";
            this.d1.Size = new System.Drawing.Size(90, 90);
            this.d1.TabIndex = 12;
            this.d1.TabStop = false;
            this.d1.UseVisualStyleBackColor = true;
            // 
            // c4
            // 
            this.c4.AutoEllipsis = true;
            this.c4.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.c4.Font = new System.Drawing.Font("微軟正黑體", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.c4.Location = new System.Drawing.Point(198, 309);
            this.c4.Name = "c4";
            this.c4.Size = new System.Drawing.Size(90, 90);
            this.c4.TabIndex = 11;
            this.c4.TabStop = false;
            this.c4.UseVisualStyleBackColor = true;
            // 
            // c3
            // 
            this.c3.AutoEllipsis = true;
            this.c3.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.c3.Font = new System.Drawing.Font("微軟正黑體", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.c3.Location = new System.Drawing.Point(198, 213);
            this.c3.Name = "c3";
            this.c3.Size = new System.Drawing.Size(90, 90);
            this.c3.TabIndex = 10;
            this.c3.TabStop = false;
            this.c3.UseVisualStyleBackColor = true;
            // 
            // c2
            // 
            this.c2.AutoEllipsis = true;
            this.c2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.c2.Font = new System.Drawing.Font("微軟正黑體", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.c2.Location = new System.Drawing.Point(198, 117);
            this.c2.Name = "c2";
            this.c2.Size = new System.Drawing.Size(90, 90);
            this.c2.TabIndex = 9;
            this.c2.TabStop = false;
            this.c2.UseVisualStyleBackColor = true;
            // 
            // c1
            // 
            this.c1.AutoEllipsis = true;
            this.c1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.c1.Font = new System.Drawing.Font("微軟正黑體", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.c1.Location = new System.Drawing.Point(198, 21);
            this.c1.Name = "c1";
            this.c1.Size = new System.Drawing.Size(90, 90);
            this.c1.TabIndex = 8;
            this.c1.TabStop = false;
            this.c1.UseVisualStyleBackColor = true;
            // 
            // b4
            // 
            this.b4.AutoEllipsis = true;
            this.b4.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.b4.Font = new System.Drawing.Font("微軟正黑體", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.b4.Location = new System.Drawing.Point(102, 309);
            this.b4.Name = "b4";
            this.b4.Size = new System.Drawing.Size(90, 90);
            this.b4.TabIndex = 7;
            this.b4.TabStop = false;
            this.b4.UseVisualStyleBackColor = true;
            // 
            // b3
            // 
            this.b3.AutoEllipsis = true;
            this.b3.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.b3.Font = new System.Drawing.Font("微軟正黑體", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.b3.Location = new System.Drawing.Point(102, 213);
            this.b3.Name = "b3";
            this.b3.Size = new System.Drawing.Size(90, 90);
            this.b3.TabIndex = 6;
            this.b3.TabStop = false;
            this.b3.UseVisualStyleBackColor = true;
            // 
            // b2
            // 
            this.b2.AutoEllipsis = true;
            this.b2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.b2.Font = new System.Drawing.Font("微軟正黑體", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.b2.Location = new System.Drawing.Point(102, 117);
            this.b2.Name = "b2";
            this.b2.Size = new System.Drawing.Size(90, 90);
            this.b2.TabIndex = 5;
            this.b2.TabStop = false;
            this.b2.UseVisualStyleBackColor = true;
            // 
            // b1
            // 
            this.b1.AutoEllipsis = true;
            this.b1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.b1.Font = new System.Drawing.Font("微軟正黑體", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.b1.Location = new System.Drawing.Point(102, 21);
            this.b1.Name = "b1";
            this.b1.Size = new System.Drawing.Size(90, 90);
            this.b1.TabIndex = 4;
            this.b1.TabStop = false;
            this.b1.UseVisualStyleBackColor = true;
            // 
            // a4
            // 
            this.a4.AutoEllipsis = true;
            this.a4.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.a4.Font = new System.Drawing.Font("微軟正黑體", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.a4.Location = new System.Drawing.Point(6, 309);
            this.a4.Name = "a4";
            this.a4.Size = new System.Drawing.Size(90, 90);
            this.a4.TabIndex = 3;
            this.a4.TabStop = false;
            this.a4.UseVisualStyleBackColor = true;
            // 
            // a3
            // 
            this.a3.AutoEllipsis = true;
            this.a3.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.a3.Font = new System.Drawing.Font("微軟正黑體", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.a3.Location = new System.Drawing.Point(6, 213);
            this.a3.Name = "a3";
            this.a3.Size = new System.Drawing.Size(90, 90);
            this.a3.TabIndex = 2;
            this.a3.TabStop = false;
            this.a3.UseVisualStyleBackColor = true;
            // 
            // a2
            // 
            this.a2.AutoEllipsis = true;
            this.a2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.a2.Font = new System.Drawing.Font("微軟正黑體", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.a2.Location = new System.Drawing.Point(6, 117);
            this.a2.Name = "a2";
            this.a2.Size = new System.Drawing.Size(90, 90);
            this.a2.TabIndex = 1;
            this.a2.TabStop = false;
            this.a2.UseVisualStyleBackColor = true;
            // 
            // a1
            // 
            this.a1.AutoEllipsis = true;
            this.a1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.a1.Font = new System.Drawing.Font("微軟正黑體", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.a1.Location = new System.Drawing.Point(6, 21);
            this.a1.Name = "a1";
            this.a1.Size = new System.Drawing.Size(90, 90);
            this.a1.TabIndex = 0;
            this.a1.TabStop = false;
            this.a1.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.lblBestScore);
            this.groupBox1.Controls.Add(this.lblPoint);
            this.groupBox1.Location = new System.Drawing.Point(12, 27);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(378, 87);
            this.groupBox1.TabIndex = 5;
            this.groupBox1.TabStop = false;
            this.groupBox1.Paint += new System.Windows.Forms.PaintEventHandler(this.groupBox1_Paint);
            // 
            // lblBestScore
            // 
            this.lblBestScore.AutoSize = true;
            this.lblBestScore.Font = new System.Drawing.Font("微軟正黑體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.lblBestScore.Location = new System.Drawing.Point(6, 18);
            this.lblBestScore.Name = "lblBestScore";
            this.lblBestScore.Size = new System.Drawing.Size(116, 20);
            this.lblBestScore.TabIndex = 2;
            this.lblBestScore.Text = "Best Score：0 ";
            // 
            // lblPoint
            // 
            this.lblPoint.AutoSize = true;
            this.lblPoint.Font = new System.Drawing.Font("微軟正黑體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.lblPoint.Location = new System.Drawing.Point(6, 53);
            this.lblPoint.Name = "lblPoint";
            this.lblPoint.Size = new System.Drawing.Size(80, 20);
            this.lblPoint.TabIndex = 0;
            this.lblPoint.Text = "Score：0 ";
            // 
            // statusStrip1
            // 
            this.statusStrip1.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tSSLTime,
            this.tSSLPlayTime});
            this.statusStrip1.Location = new System.Drawing.Point(0, 541);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.RenderMode = System.Windows.Forms.ToolStripRenderMode.ManagerRenderMode;
            this.statusStrip1.Size = new System.Drawing.Size(401, 22);
            this.statusStrip1.SizingGrip = false;
            this.statusStrip1.TabIndex = 6;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // tSSLTime
            // 
            this.tSSLTime.Name = "tSSLTime";
            this.tSSLTime.Size = new System.Drawing.Size(193, 17);
            this.tSSLTime.Spring = true;
            this.tSSLTime.Text = "tSSLTime";
            // 
            // tSSLPlayTime
            // 
            this.tSSLPlayTime.Name = "tSSLPlayTime";
            this.tSSLPlayTime.Size = new System.Drawing.Size(193, 17);
            this.tSSLPlayTime.Spring = true;
            this.tSSLPlayTime.Text = "tSSLPlayTime";
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Interval = 1000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // menuStrip1
            // 
            this.menuStrip1.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.TSMIReset,
            this.TSMIMode,
            this.TSMIAbout});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(401, 24);
            this.menuStrip1.TabIndex = 7;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // TSMIReset
            // 
            this.TSMIReset.Name = "TSMIReset";
            this.TSMIReset.Size = new System.Drawing.Size(83, 20);
            this.TSMIReset.Text = "New Game";
            this.TSMIReset.Click += new System.EventHandler(this.TSMIReset_Click);
            // 
            // TSMIMode
            // 
            this.TSMIMode.Name = "TSMIMode";
            this.TSMIMode.Size = new System.Drawing.Size(55, 20);
            this.TSMIMode.Text = "Mode";
            // 
            // TSMIAbout
            // 
            this.TSMIAbout.Name = "TSMIAbout";
            this.TSMIAbout.Size = new System.Drawing.Size(55, 20);
            this.TSMIAbout.Text = "About";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.ClientSize = new System.Drawing.Size(401, 563);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.menuStrip1);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.groupBox2);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.MainMenuStrip = this.menuStrip1;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "2048   By.shuangrain";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.Form1_KeyUp);
            this.groupBox2.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button a1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel tSSLTime;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Button d4;
        private System.Windows.Forms.Button d3;
        private System.Windows.Forms.Button d2;
        private System.Windows.Forms.Button d1;
        private System.Windows.Forms.Button c4;
        private System.Windows.Forms.Button c3;
        private System.Windows.Forms.Button c2;
        private System.Windows.Forms.Button c1;
        private System.Windows.Forms.Button b4;
        private System.Windows.Forms.Button b3;
        private System.Windows.Forms.Button b2;
        private System.Windows.Forms.Button b1;
        private System.Windows.Forms.Button a4;
        private System.Windows.Forms.Button a3;
        private System.Windows.Forms.Button a2;
        private System.Windows.Forms.ToolStripStatusLabel tSSLPlayTime;
        private System.Windows.Forms.Label lblPoint;
        private System.Windows.Forms.Label lblBestScore;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem TSMIReset;
        private System.Windows.Forms.ToolStripMenuItem TSMIMode;
        private System.Windows.Forms.ToolStripMenuItem TSMIAbout;
    }
}

