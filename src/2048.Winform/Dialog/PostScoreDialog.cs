using _2048.Core.Model;
using _2048.Core.Service;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _2048.Winform
{
    public partial class PostScoreDialog : Form
    {
        private readonly RankService _rankService = null;
        private readonly ScoreRankModel _scoreRank = null;

        public PostScoreDialog(ScoreRankModel model)
        {
            InitializeComponent();

            _rankService = new RankService();
            _scoreRank = model;
        }

        private void PostScoreDialog_Load(object sender, EventArgs e)
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine($"獲得：{_scoreRank.Score} 分！");
            sb.AppendLine("恭喜刷新排行榜！");

            lblMsg.Text = sb.ToString();
        }

        private void btnSend_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(textName.Text))
            {
                MessageBox.Show("請輸入暱稱", "錯誤");
                return;
            }

            _scoreRank.Name = textName.Text.Trim();
            _rankService.PostScoreAsync(_scoreRank).ContinueWith(taskResult =>
            {
                if (taskResult.Result?.RtnCode != 1)
                {
                    MessageBox.Show(taskResult.Result?.RtnMsg ?? "系統繁忙中，請稍後再試。", "錯誤");
                }
                else
                {
                    btnClose.PerformClick();
                }
            }, TaskScheduler.FromCurrentSynchronizationContext());
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
            this.Dispose();
        }
    }
}
