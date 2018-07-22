namespace _2048.Winform.Dialog
{
    partial class RankDialog
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(RankDialog));
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabClassic = new System.Windows.Forms.TabPage();
            this.listClassic = new System.Windows.Forms.ListView();
            this.CHName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.CHSorce = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.CHPlayTime = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.CHUpdataTime = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.tabTime = new System.Windows.Forms.TabPage();
            this.listTime = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader4 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.tabMove = new System.Windows.Forms.TabPage();
            this.listMove = new System.Windows.Forms.ListView();
            this.columnHeader5 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader6 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader7 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader8 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.tabBlock = new System.Windows.Forms.TabPage();
            this.listBlock = new System.Windows.Forms.ListView();
            this.columnHeader9 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader10 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader11 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader12 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.tabControl1.SuspendLayout();
            this.tabClassic.SuspendLayout();
            this.tabTime.SuspendLayout();
            this.tabMove.SuspendLayout();
            this.tabBlock.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabClassic);
            this.tabControl1.Controls.Add(this.tabTime);
            this.tabControl1.Controls.Add(this.tabMove);
            this.tabControl1.Controls.Add(this.tabBlock);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Font = new System.Drawing.Font("微軟正黑體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(384, 362);
            this.tabControl1.TabIndex = 0;
            // 
            // tabClassic
            // 
            this.tabClassic.Controls.Add(this.listClassic);
            this.tabClassic.Location = new System.Drawing.Point(4, 29);
            this.tabClassic.Name = "tabClassic";
            this.tabClassic.Padding = new System.Windows.Forms.Padding(3);
            this.tabClassic.Size = new System.Drawing.Size(376, 329);
            this.tabClassic.TabIndex = 0;
            this.tabClassic.Text = "Classic";
            this.tabClassic.UseVisualStyleBackColor = true;
            // 
            // listClassic
            // 
            this.listClassic.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.CHName,
            this.CHSorce,
            this.CHPlayTime,
            this.CHUpdataTime});
            this.listClassic.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listClassic.Font = new System.Drawing.Font("微軟正黑體", 10F);
            this.listClassic.Location = new System.Drawing.Point(3, 3);
            this.listClassic.Name = "listClassic";
            this.listClassic.Size = new System.Drawing.Size(370, 323);
            this.listClassic.TabIndex = 0;
            this.listClassic.UseCompatibleStateImageBehavior = false;
            this.listClassic.View = System.Windows.Forms.View.Details;
            // 
            // CHName
            // 
            this.CHName.Text = "名稱";
            // 
            // CHSorce
            // 
            this.CHSorce.Text = "分數";
            // 
            // CHPlayTime
            // 
            this.CHPlayTime.Text = "遊玩時間";
            this.CHPlayTime.Width = 82;
            // 
            // CHUpdataTime
            // 
            this.CHUpdataTime.Text = "更新時間";
            this.CHUpdataTime.Width = 81;
            // 
            // tabTime
            // 
            this.tabTime.Controls.Add(this.listTime);
            this.tabTime.Location = new System.Drawing.Point(4, 29);
            this.tabTime.Name = "tabTime";
            this.tabTime.Padding = new System.Windows.Forms.Padding(3);
            this.tabTime.Size = new System.Drawing.Size(376, 329);
            this.tabTime.TabIndex = 1;
            this.tabTime.Text = "Time";
            this.tabTime.UseVisualStyleBackColor = true;
            // 
            // listTime
            // 
            this.listTime.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader3,
            this.columnHeader4});
            this.listTime.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listTime.Font = new System.Drawing.Font("微軟正黑體", 10F);
            this.listTime.Location = new System.Drawing.Point(3, 3);
            this.listTime.Name = "listTime";
            this.listTime.Size = new System.Drawing.Size(370, 323);
            this.listTime.TabIndex = 1;
            this.listTime.UseCompatibleStateImageBehavior = false;
            this.listTime.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "名稱";
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "分數";
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "遊玩時間";
            this.columnHeader3.Width = 82;
            // 
            // columnHeader4
            // 
            this.columnHeader4.Text = "更新時間";
            this.columnHeader4.Width = 81;
            // 
            // tabMove
            // 
            this.tabMove.Controls.Add(this.listMove);
            this.tabMove.Location = new System.Drawing.Point(4, 29);
            this.tabMove.Name = "tabMove";
            this.tabMove.Padding = new System.Windows.Forms.Padding(3);
            this.tabMove.Size = new System.Drawing.Size(376, 329);
            this.tabMove.TabIndex = 2;
            this.tabMove.Text = "Move";
            this.tabMove.UseVisualStyleBackColor = true;
            // 
            // listMove
            // 
            this.listMove.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader5,
            this.columnHeader6,
            this.columnHeader7,
            this.columnHeader8});
            this.listMove.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listMove.Font = new System.Drawing.Font("微軟正黑體", 10F);
            this.listMove.Location = new System.Drawing.Point(3, 3);
            this.listMove.Name = "listMove";
            this.listMove.Size = new System.Drawing.Size(370, 323);
            this.listMove.TabIndex = 1;
            this.listMove.UseCompatibleStateImageBehavior = false;
            this.listMove.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader5
            // 
            this.columnHeader5.Text = "名稱";
            // 
            // columnHeader6
            // 
            this.columnHeader6.Text = "分數";
            // 
            // columnHeader7
            // 
            this.columnHeader7.Text = "遊玩時間";
            this.columnHeader7.Width = 82;
            // 
            // columnHeader8
            // 
            this.columnHeader8.Text = "更新時間";
            this.columnHeader8.Width = 81;
            // 
            // tabBlock
            // 
            this.tabBlock.Controls.Add(this.listBlock);
            this.tabBlock.Location = new System.Drawing.Point(4, 29);
            this.tabBlock.Name = "tabBlock";
            this.tabBlock.Padding = new System.Windows.Forms.Padding(3);
            this.tabBlock.Size = new System.Drawing.Size(376, 329);
            this.tabBlock.TabIndex = 3;
            this.tabBlock.Text = "Block";
            this.tabBlock.UseVisualStyleBackColor = true;
            // 
            // listBlock
            // 
            this.listBlock.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader9,
            this.columnHeader10,
            this.columnHeader11,
            this.columnHeader12});
            this.listBlock.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listBlock.Font = new System.Drawing.Font("微軟正黑體", 10F);
            this.listBlock.Location = new System.Drawing.Point(3, 3);
            this.listBlock.Name = "listBlock";
            this.listBlock.Size = new System.Drawing.Size(370, 323);
            this.listBlock.TabIndex = 1;
            this.listBlock.UseCompatibleStateImageBehavior = false;
            this.listBlock.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader9
            // 
            this.columnHeader9.Text = "名稱";
            // 
            // columnHeader10
            // 
            this.columnHeader10.Text = "分數";
            // 
            // columnHeader11
            // 
            this.columnHeader11.Text = "遊玩時間";
            this.columnHeader11.Width = 82;
            // 
            // columnHeader12
            // 
            this.columnHeader12.Text = "更新時間";
            this.columnHeader12.Width = 81;
            // 
            // RankDialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.ClientSize = new System.Drawing.Size(384, 362);
            this.Controls.Add(this.tabControl1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "RankDialog";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Rank";
            this.Load += new System.EventHandler(this.RankDialog_Load);
            this.tabControl1.ResumeLayout(false);
            this.tabClassic.ResumeLayout(false);
            this.tabTime.ResumeLayout(false);
            this.tabMove.ResumeLayout(false);
            this.tabBlock.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabClassic;
        private System.Windows.Forms.ListView listClassic;
        private System.Windows.Forms.ColumnHeader CHName;
        private System.Windows.Forms.ColumnHeader CHSorce;
        private System.Windows.Forms.ColumnHeader CHPlayTime;
        private System.Windows.Forms.ColumnHeader CHUpdataTime;
        private System.Windows.Forms.TabPage tabTime;
        private System.Windows.Forms.ListView listTime;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.ColumnHeader columnHeader4;
        private System.Windows.Forms.TabPage tabMove;
        private System.Windows.Forms.ListView listMove;
        private System.Windows.Forms.ColumnHeader columnHeader5;
        private System.Windows.Forms.ColumnHeader columnHeader6;
        private System.Windows.Forms.ColumnHeader columnHeader7;
        private System.Windows.Forms.ColumnHeader columnHeader8;
        private System.Windows.Forms.TabPage tabBlock;
        private System.Windows.Forms.ListView listBlock;
        private System.Windows.Forms.ColumnHeader columnHeader9;
        private System.Windows.Forms.ColumnHeader columnHeader10;
        private System.Windows.Forms.ColumnHeader columnHeader11;
        private System.Windows.Forms.ColumnHeader columnHeader12;
    }
}