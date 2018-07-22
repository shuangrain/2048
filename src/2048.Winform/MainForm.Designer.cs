namespace _2048.Winform
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
            this.x0y0 = new System.Windows.Forms.Button();
            this.x0y1 = new System.Windows.Forms.Button();
            this.x0y2 = new System.Windows.Forms.Button();
            this.x0y3 = new System.Windows.Forms.Button();
            this.x1y0 = new System.Windows.Forms.Button();
            this.x1y1 = new System.Windows.Forms.Button();
            this.x1y2 = new System.Windows.Forms.Button();
            this.x1y3 = new System.Windows.Forms.Button();
            this.x2y0 = new System.Windows.Forms.Button();
            this.x2y1 = new System.Windows.Forms.Button();
            this.x2y2 = new System.Windows.Forms.Button();
            this.x2y3 = new System.Windows.Forms.Button();
            this.x3y0 = new System.Windows.Forms.Button();
            this.x3y1 = new System.Windows.Forms.Button();
            this.x3y2 = new System.Windows.Forms.Button();
            this.x3y3 = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.lblBestScore = new System.Windows.Forms.Label();
            this.lblPoint = new System.Windows.Forms.Label();
            this.statusStrip = new System.Windows.Forms.StatusStrip();
            this.tSSLTime = new System.Windows.Forms.ToolStripStatusLabel();
            this.tSSLPlayTime = new System.Windows.Forms.ToolStripStatusLabel();
            this.timer = new System.Windows.Forms.Timer(this.components);
            this.menuStrip = new System.Windows.Forms.MenuStrip();
            this.TSMI_Reset = new System.Windows.Forms.ToolStripMenuItem();
            this.TSMIMode = new System.Windows.Forms.ToolStripMenuItem();
            this.TSMI_ClassicMode = new System.Windows.Forms.ToolStripMenuItem();
            this.TSMI_Time = new System.Windows.Forms.ToolStripMenuItem();
            this.TSMI_Move = new System.Windows.Forms.ToolStripMenuItem();
            this.TSMI_BlockMode = new System.Windows.Forms.ToolStripMenuItem();
            this.TSMI_Rules = new System.Windows.Forms.ToolStripMenuItem();
            this.TSMI_Rank = new System.Windows.Forms.ToolStripMenuItem();
            this.TSMI_About = new System.Windows.Forms.ToolStripMenuItem();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.statusStrip.SuspendLayout();
            this.menuStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.x0y0);
            this.groupBox2.Controls.Add(this.x0y1);
            this.groupBox2.Controls.Add(this.x0y2);
            this.groupBox2.Controls.Add(this.x0y3);
            this.groupBox2.Controls.Add(this.x1y0);
            this.groupBox2.Controls.Add(this.x1y1);
            this.groupBox2.Controls.Add(this.x1y2);
            this.groupBox2.Controls.Add(this.x1y3);
            this.groupBox2.Controls.Add(this.x2y0);
            this.groupBox2.Controls.Add(this.x2y1);
            this.groupBox2.Controls.Add(this.x2y2);
            this.groupBox2.Controls.Add(this.x2y3);
            this.groupBox2.Controls.Add(this.x3y0);
            this.groupBox2.Controls.Add(this.x3y1);
            this.groupBox2.Controls.Add(this.x3y2);
            this.groupBox2.Controls.Add(this.x3y3);
            this.groupBox2.Location = new System.Drawing.Point(6, 120);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(390, 414);
            this.groupBox2.TabIndex = 4;
            this.groupBox2.TabStop = false;
            this.groupBox2.Paint += new System.Windows.Forms.PaintEventHandler(this.groupBox2_Paint);
            // 
            // x0y0
            // 
            this.x0y0.AutoEllipsis = true;
            this.x0y0.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.x0y0.Font = new System.Drawing.Font("微軟正黑體", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.x0y0.Location = new System.Drawing.Point(6, 309);
            this.x0y0.Name = "x0y0";
            this.x0y0.Size = new System.Drawing.Size(90, 90);
            this.x0y0.TabIndex = 0;
            this.x0y0.TabStop = false;
            this.x0y0.UseVisualStyleBackColor = true;
            // 
            // x0y1
            // 
            this.x0y1.AutoEllipsis = true;
            this.x0y1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.x0y1.Font = new System.Drawing.Font("微軟正黑體", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.x0y1.Location = new System.Drawing.Point(6, 213);
            this.x0y1.Name = "x0y1";
            this.x0y1.Size = new System.Drawing.Size(90, 90);
            this.x0y1.TabIndex = 4;
            this.x0y1.TabStop = false;
            this.x0y1.UseVisualStyleBackColor = true;
            // 
            // x0y2
            // 
            this.x0y2.AutoEllipsis = true;
            this.x0y2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.x0y2.Font = new System.Drawing.Font("微軟正黑體", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.x0y2.Location = new System.Drawing.Point(6, 117);
            this.x0y2.Name = "x0y2";
            this.x0y2.Size = new System.Drawing.Size(90, 90);
            this.x0y2.TabIndex = 8;
            this.x0y2.TabStop = false;
            this.x0y2.UseVisualStyleBackColor = true;
            // 
            // x0y3
            // 
            this.x0y3.AutoEllipsis = true;
            this.x0y3.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.x0y3.Font = new System.Drawing.Font("微軟正黑體", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.x0y3.Location = new System.Drawing.Point(6, 21);
            this.x0y3.Name = "x0y3";
            this.x0y3.Size = new System.Drawing.Size(90, 90);
            this.x0y3.TabIndex = 12;
            this.x0y3.TabStop = false;
            this.x0y3.UseVisualStyleBackColor = true;
            // 
            // x1y0
            // 
            this.x1y0.AutoEllipsis = true;
            this.x1y0.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.x1y0.Font = new System.Drawing.Font("微軟正黑體", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.x1y0.Location = new System.Drawing.Point(102, 309);
            this.x1y0.Name = "x1y0";
            this.x1y0.Size = new System.Drawing.Size(90, 90);
            this.x1y0.TabIndex = 1;
            this.x1y0.TabStop = false;
            this.x1y0.UseVisualStyleBackColor = true;
            // 
            // x1y1
            // 
            this.x1y1.AutoEllipsis = true;
            this.x1y1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.x1y1.Font = new System.Drawing.Font("微軟正黑體", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.x1y1.Location = new System.Drawing.Point(102, 213);
            this.x1y1.Name = "x1y1";
            this.x1y1.Size = new System.Drawing.Size(90, 90);
            this.x1y1.TabIndex = 5;
            this.x1y1.TabStop = false;
            this.x1y1.UseVisualStyleBackColor = true;
            // 
            // x1y2
            // 
            this.x1y2.AutoEllipsis = true;
            this.x1y2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.x1y2.Font = new System.Drawing.Font("微軟正黑體", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.x1y2.Location = new System.Drawing.Point(102, 117);
            this.x1y2.Name = "x1y2";
            this.x1y2.Size = new System.Drawing.Size(90, 90);
            this.x1y2.TabIndex = 9;
            this.x1y2.TabStop = false;
            this.x1y2.UseVisualStyleBackColor = true;
            // 
            // x1y3
            // 
            this.x1y3.AutoEllipsis = true;
            this.x1y3.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.x1y3.Font = new System.Drawing.Font("微軟正黑體", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.x1y3.Location = new System.Drawing.Point(102, 21);
            this.x1y3.Name = "x1y3";
            this.x1y3.Size = new System.Drawing.Size(90, 90);
            this.x1y3.TabIndex = 13;
            this.x1y3.TabStop = false;
            this.x1y3.UseVisualStyleBackColor = true;
            // 
            // x2y0
            // 
            this.x2y0.AutoEllipsis = true;
            this.x2y0.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.x2y0.Font = new System.Drawing.Font("微軟正黑體", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.x2y0.Location = new System.Drawing.Point(198, 309);
            this.x2y0.Name = "x2y0";
            this.x2y0.Size = new System.Drawing.Size(90, 90);
            this.x2y0.TabIndex = 2;
            this.x2y0.TabStop = false;
            this.x2y0.UseVisualStyleBackColor = true;
            // 
            // x2y1
            // 
            this.x2y1.AutoEllipsis = true;
            this.x2y1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.x2y1.Font = new System.Drawing.Font("微軟正黑體", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.x2y1.Location = new System.Drawing.Point(198, 213);
            this.x2y1.Name = "x2y1";
            this.x2y1.Size = new System.Drawing.Size(90, 90);
            this.x2y1.TabIndex = 6;
            this.x2y1.TabStop = false;
            this.x2y1.UseVisualStyleBackColor = true;
            // 
            // x2y2
            // 
            this.x2y2.AutoEllipsis = true;
            this.x2y2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.x2y2.Font = new System.Drawing.Font("微軟正黑體", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.x2y2.Location = new System.Drawing.Point(198, 117);
            this.x2y2.Name = "x2y2";
            this.x2y2.Size = new System.Drawing.Size(90, 90);
            this.x2y2.TabIndex = 10;
            this.x2y2.TabStop = false;
            this.x2y2.UseVisualStyleBackColor = true;
            // 
            // x2y3
            // 
            this.x2y3.AutoEllipsis = true;
            this.x2y3.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.x2y3.Font = new System.Drawing.Font("微軟正黑體", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.x2y3.Location = new System.Drawing.Point(198, 21);
            this.x2y3.Name = "x2y3";
            this.x2y3.Size = new System.Drawing.Size(90, 90);
            this.x2y3.TabIndex = 14;
            this.x2y3.TabStop = false;
            this.x2y3.UseVisualStyleBackColor = true;
            // 
            // x3y0
            // 
            this.x3y0.AutoEllipsis = true;
            this.x3y0.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.x3y0.Font = new System.Drawing.Font("微軟正黑體", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.x3y0.Location = new System.Drawing.Point(294, 309);
            this.x3y0.Name = "x3y0";
            this.x3y0.Size = new System.Drawing.Size(90, 90);
            this.x3y0.TabIndex = 3;
            this.x3y0.TabStop = false;
            this.x3y0.UseVisualStyleBackColor = true;
            // 
            // x3y1
            // 
            this.x3y1.AutoEllipsis = true;
            this.x3y1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.x3y1.Font = new System.Drawing.Font("微軟正黑體", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.x3y1.Location = new System.Drawing.Point(294, 213);
            this.x3y1.Name = "x3y1";
            this.x3y1.Size = new System.Drawing.Size(90, 90);
            this.x3y1.TabIndex = 7;
            this.x3y1.TabStop = false;
            this.x3y1.UseVisualStyleBackColor = true;
            // 
            // x3y2
            // 
            this.x3y2.AutoEllipsis = true;
            this.x3y2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.x3y2.Font = new System.Drawing.Font("微軟正黑體", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.x3y2.Location = new System.Drawing.Point(294, 117);
            this.x3y2.Name = "x3y2";
            this.x3y2.Size = new System.Drawing.Size(90, 90);
            this.x3y2.TabIndex = 11;
            this.x3y2.TabStop = false;
            this.x3y2.UseVisualStyleBackColor = true;
            // 
            // x3y3
            // 
            this.x3y3.AutoEllipsis = true;
            this.x3y3.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.x3y3.Font = new System.Drawing.Font("微軟正黑體", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.x3y3.Location = new System.Drawing.Point(294, 21);
            this.x3y3.Name = "x3y3";
            this.x3y3.Size = new System.Drawing.Size(90, 90);
            this.x3y3.TabIndex = 15;
            this.x3y3.TabStop = false;
            this.x3y3.UseVisualStyleBackColor = true;
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
            // statusStrip
            // 
            this.statusStrip.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.statusStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tSSLTime,
            this.tSSLPlayTime});
            this.statusStrip.Location = new System.Drawing.Point(0, 541);
            this.statusStrip.Name = "statusStrip";
            this.statusStrip.Size = new System.Drawing.Size(401, 22);
            this.statusStrip.SizingGrip = false;
            this.statusStrip.TabIndex = 6;
            this.statusStrip.Text = "statusStrip";
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
            // timer
            // 
            this.timer.Enabled = true;
            this.timer.Interval = 500;
            this.timer.Tick += new System.EventHandler(this.timer_Tick);
            // 
            // menuStrip
            // 
            this.menuStrip.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.menuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.TSMI_Reset,
            this.TSMIMode,
            this.TSMI_Rules,
            this.TSMI_Rank,
            this.TSMI_About});
            this.menuStrip.Location = new System.Drawing.Point(0, 0);
            this.menuStrip.Name = "menuStrip";
            this.menuStrip.Size = new System.Drawing.Size(401, 24);
            this.menuStrip.TabIndex = 7;
            this.menuStrip.Text = "menuStrip";
            // 
            // TSMI_Reset
            // 
            this.TSMI_Reset.Name = "TSMI_Reset";
            this.TSMI_Reset.Size = new System.Drawing.Size(82, 20);
            this.TSMI_Reset.Text = "New Game";
            this.TSMI_Reset.Click += new System.EventHandler(this.TSMI_Reset_Click);
            // 
            // TSMIMode
            // 
            this.TSMIMode.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.TSMI_ClassicMode,
            this.TSMI_Time,
            this.TSMI_Move,
            this.TSMI_BlockMode});
            this.TSMIMode.Name = "TSMIMode";
            this.TSMIMode.Size = new System.Drawing.Size(54, 20);
            this.TSMIMode.Text = "Mode";
            // 
            // TSMI_ClassicMode
            // 
            this.TSMI_ClassicMode.CheckOnClick = true;
            this.TSMI_ClassicMode.Name = "TSMI_ClassicMode";
            this.TSMI_ClassicMode.Size = new System.Drawing.Size(180, 22);
            this.TSMI_ClassicMode.Text = "Classic";
            this.TSMI_ClassicMode.Click += new System.EventHandler(this.TSMI_ClassicMode_Click);
            // 
            // TSMI_Time
            // 
            this.TSMI_Time.CheckOnClick = true;
            this.TSMI_Time.Name = "TSMI_Time";
            this.TSMI_Time.Size = new System.Drawing.Size(180, 22);
            this.TSMI_Time.Text = "Time";
            this.TSMI_Time.Click += new System.EventHandler(this.TSMI_Time_Click);
            // 
            // TSMI_Move
            // 
            this.TSMI_Move.CheckOnClick = true;
            this.TSMI_Move.Name = "TSMI_Move";
            this.TSMI_Move.Size = new System.Drawing.Size(180, 22);
            this.TSMI_Move.Text = "Move";
            this.TSMI_Move.Click += new System.EventHandler(this.TSMI_Move_Click);
            // 
            // TSMI_BlockMode
            // 
            this.TSMI_BlockMode.Name = "TSMI_BlockMode";
            this.TSMI_BlockMode.Size = new System.Drawing.Size(180, 22);
            this.TSMI_BlockMode.Text = "Block";
            this.TSMI_BlockMode.Click += new System.EventHandler(this.TSMI_BlockMode_Click);
            // 
            // TSMI_Rules
            // 
            this.TSMI_Rules.Name = "TSMI_Rules";
            this.TSMI_Rules.Size = new System.Drawing.Size(49, 20);
            this.TSMI_Rules.Text = "Rules";
            this.TSMI_Rules.Click += new System.EventHandler(this.TSMI_Rules_Click);
            // 
            // TSMI_Rank
            // 
            this.TSMI_Rank.Name = "TSMI_Rank";
            this.TSMI_Rank.Size = new System.Drawing.Size(47, 20);
            this.TSMI_Rank.Text = "Rank";
            this.TSMI_Rank.Click += new System.EventHandler(this.TSMI_Rank_Click);
            // 
            // TSMI_About
            // 
            this.TSMI_About.Name = "TSMI_About";
            this.TSMI_About.Size = new System.Drawing.Size(54, 20);
            this.TSMI_About.Text = "About";
            this.TSMI_About.Click += new System.EventHandler(this.TSMI_About_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.ClientSize = new System.Drawing.Size(401, 563);
            this.Controls.Add(this.statusStrip);
            this.Controls.Add(this.menuStrip);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.groupBox2);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.MainMenuStrip = this.menuStrip;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "2048";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.MainForm_KeyUp);
            this.groupBox2.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.statusStrip.ResumeLayout(false);
            this.statusStrip.PerformLayout();
            this.menuStrip.ResumeLayout(false);
            this.menuStrip.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button x0y3;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.StatusStrip statusStrip;
        private System.Windows.Forms.ToolStripStatusLabel tSSLTime;
        private System.Windows.Forms.Timer timer;
        private System.Windows.Forms.Button x0y0;
        private System.Windows.Forms.Button x0y1;
        private System.Windows.Forms.Button x0y2;
        private System.Windows.Forms.Button x1y0;
        private System.Windows.Forms.Button x1y1;
        private System.Windows.Forms.Button x1y2;
        private System.Windows.Forms.Button x1y3;
        private System.Windows.Forms.Button x2y0;
        private System.Windows.Forms.Button x2y1;
        private System.Windows.Forms.Button x2y2;
        private System.Windows.Forms.Button x2y3;
        private System.Windows.Forms.Button x3y0;
        private System.Windows.Forms.Button x3y1;
        private System.Windows.Forms.Button x3y2;
        private System.Windows.Forms.Button x3y3;
        private System.Windows.Forms.ToolStripStatusLabel tSSLPlayTime;
        private System.Windows.Forms.Label lblPoint;
        private System.Windows.Forms.Label lblBestScore;
        private System.Windows.Forms.MenuStrip menuStrip;
        private System.Windows.Forms.ToolStripMenuItem TSMI_Reset;
        private System.Windows.Forms.ToolStripMenuItem TSMIMode;
        private System.Windows.Forms.ToolStripMenuItem TSMI_About;
        private System.Windows.Forms.ToolStripMenuItem TSMI_ClassicMode;
        private System.Windows.Forms.ToolStripMenuItem TSMI_Time;
        private System.Windows.Forms.ToolStripMenuItem TSMI_Move;
        private System.Windows.Forms.ToolStripMenuItem TSMI_BlockMode;
        private System.Windows.Forms.ToolStripMenuItem TSMI_Rules;
        private System.Windows.Forms.ToolStripMenuItem TSMI_Rank;
    }
}

