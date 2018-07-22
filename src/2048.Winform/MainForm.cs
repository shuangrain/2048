using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
//讀寫檔案
using System.IO;
//畫GroupBox
using System.Drawing.Drawing2D;
using _2048.Winform.Dialog;
using _2048.Core.Mode;
using _2048.Core.Service;
using _2048.Core.Model;
using System.Threading.Tasks;

namespace _2048.Winform
{
    public partial class MainForm : Form
    {
        private RankService _rankService = null;
        private GameMode _mode = null;
        private bool _hasNotify2048 = false;
        private bool _gameStart = false;

        public MainForm()
        {
            InitializeComponent();

            _rankService = new RankService();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            // 選擇模式
            TSMI_Rules.PerformClick();
            TSMI_ClassicMode.PerformClick();
        }

        /// <summary>
        /// 移動
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MainForm_KeyUp(object sender, KeyEventArgs e)
        {
            _mode.HasAddNumInThisRound = false;
            _mode.HasMoveNumInThisRound = false;

            switch (e.KeyData)
            {
                case Keys.Up:
                    {
                        _mode.Up();
                        break;
                    }
                case Keys.Down:
                    {
                        _mode.Down();
                        break;
                    }
                case Keys.Left:
                    {
                        _mode.Left();
                        break;
                    }
                case Keys.Right:
                    {
                        _mode.Right();
                        break;
                    }
                default:
                    {
                        return;
                    }
            }

            // 畫 UI
            Tuple<int, int> newNumPoint = null;
            if (_mode.HasMoveNumInThisRound || _mode.HasAddNumInThisRound)
            {
                newNumPoint = _mode.AddRandNum();
            }

            drawingToUI(newNumPoint);
            refreshGameStatus();
        }

        /// <summary>
        /// 計時器
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void timer_Tick(object sender, EventArgs e)
        {
            tSSLTime.Text = DateTime.Now.ToString();
            refreshGameStatus();
        }

        /// <summary>
        /// 將數值 Mapping 到 UI 上
        /// </summary>
        private void drawingToUI(Tuple<int, int> newNumPosition = null)
        {
            lblPoint.Text = $"Score：{_mode.Score}";

            // 把零的文字轉成空白，供使用者觀看
            var getBtnColor = new Func<int, Color>((value) =>
            {
                switch (value)
                {
                    case -999:
                        {
                            return Color.Black;
                        }
                    case 0:
                        {
                            return Button.DefaultBackColor;
                        }
                    case 2:
                        {
                            return Color.Pink;
                        }
                    case 4:
                        {
                            return Color.Plum;
                        }
                    case 8:
                        {
                            return Color.PowderBlue;
                        }
                    case 16:
                        {
                            return Color.Purple;
                        }
                    case 32:
                        {
                            return Color.Red;
                        }
                    case 64:
                        {
                            return Color.RosyBrown;
                        }
                    case 128:
                        {
                            return Color.RoyalBlue;
                        }
                    case 256:
                        {
                            return Color.SaddleBrown;
                        }
                    case 512:
                        {
                            return Color.Salmon;
                        }
                    case 1024:
                        {
                            return Color.SandyBrown;
                        }
                    case 2048:
                        {
                            return Color.SeaGreen;
                        }
                    default:
                        {
                            return Button.DefaultBackColor;
                        }
                }
            });

            for (int x = 0; x < _mode.Board.GetLength(0); x++)
            {
                for (int y = 0; y < _mode.Board.GetLength(1); y++)
                {
                    int value = _mode.Board[x, y];
                    string targetButtonName = $"x{x}y{y}";
                    var targetButton = groupBox2.Controls.OfType<Button>()
                                                         .Where(btn => btn.Name == targetButtonName)
                                                         .FirstOrDefault();

                    // 檢查是否已達 2048
                    if (value == 2048 && !_hasNotify2048)
                    {
                        _hasNotify2048 = true;
                        MessageBox.Show("恭喜達到 2048！");
                    }

                    // 焦點不能為按鈕
                    if (targetButton.Focused == true)
                    {
                        lblPoint.Focus();
                    }

                    // 新數字提示
                    if (newNumPosition != null)
                    {
                        string newNumButtonName = $"x{newNumPosition.Item1}y{newNumPosition.Item2}";
                        if (targetButtonName == newNumButtonName)
                        {
                            targetButton.FlatAppearance.BorderSize = 3;
                            targetButton.FlatAppearance.BorderColor = Color.Red;
                        }
                        else
                        {
                            targetButton.FlatAppearance.BorderSize = 1;
                            targetButton.FlatAppearance.BorderColor = Color.Black;
                        }
                    }

                    // 修改當前按鈕文字與顏色
                    targetButton.BackColor = getBtnColor(value);
                    targetButton.Text = (value > 0) ? value.ToString() : string.Empty;
                }
            }
        }

        /// <summary>
        /// 檢查遊戲是否已結束
        /// </summary>
        private void refreshGameStatus()
        {
            if (!_gameStart)
            {
                return;
            }

            tSSLPlayTime.Text = _mode.GetTipMessage();
            if (_mode.IsLose())
            {
                _gameStart = false;
                MessageBox.Show($"獲得：{_mode.Score} 分", "遊戲結束");

                if (_rankService.CanFindServer && _rankService.CanAddRank(_mode.ModeType, _mode.Score))
                {
                    var postScoreDialog = new PostScoreDialog(new ScoreRankModel
                    {
                        ModeType = _mode.ModeType,
                        PlayTime = _mode.PlayTime,
                        Score = _mode.Score
                    });
                    postScoreDialog.FormClosed += (sender, args) =>
                    {
                        getTopScoreInThisMode(_mode.ModeType);
                        TSMI_Rank.PerformClick();
                    };
                    postScoreDialog.ShowDialog();
                }
            }
        }

        /// <summary>
        /// 重置遊戲
        /// </summary>
        public void ResetGame()
        {
            _mode.Initi();
            drawingToUI();
            getTopScoreInThisMode(_mode.ModeType);

            _gameStart = true;

            foreach (Button btn in groupBox2.Controls)
            {
                btn.FlatAppearance.BorderSize = 1;
                btn.FlatAppearance.BorderColor = Color.Black;
            }
        }

        /// <summary>
        /// 尋找最佳成績，若無則新增一紀錄檔
        /// </summary>
        /// <param name="ReadName"></param>
        /// <param name="ReadLine"></param>
        private void getTopScoreInThisMode(ModeType modeType)
        {
            lblBestScore.Text = "Best Score：pending...";

            _rankService.GetScoreAsync(modeType).ContinueWith(task =>
            {
                int? topScore = task.Result?.OrderByDescending(x => x.Score).FirstOrDefault()?.Score;
                lblBestScore.Text = $"Best Score：{topScore.GetValueOrDefault()}";
            }, TaskScheduler.FromCurrentSynchronizationContext());
        }

        #region 功能選單

        private void TSMI_ClassicMode_Click(object sender, EventArgs e)
        {
            TSMI_ClassicMode.Checked = true;
            TSMI_Time.Checked = false;
            TSMI_Move.Checked = false;
            TSMI_BlockMode.Checked = false;

            _mode = new ClassicMode();
            ResetGame();

            this.Text = "2048  [ClassicMode]";
        }

        private void TSMI_Time_Click(object sender, EventArgs e)
        {
            TSMI_ClassicMode.Checked = false;
            TSMI_Time.Checked = true;
            TSMI_Move.Checked = false;
            TSMI_BlockMode.Checked = false;

            _mode = new TimeMode();
            ResetGame();

            this.Text = "2048  [TimeMode]";
        }

        private void TSMI_Move_Click(object sender, EventArgs e)
        {
            TSMI_ClassicMode.Checked = false;
            TSMI_Time.Checked = false;
            TSMI_Move.Checked = true;
            TSMI_BlockMode.Checked = false;

            _mode = new MoveMode();
            ResetGame();

            this.Text = "2048  [MoveMode]";
        }

        private void TSMI_BlockMode_Click(object sender, EventArgs e)
        {
            TSMI_ClassicMode.Checked = false;
            TSMI_Time.Checked = false;
            TSMI_Move.Checked = false;
            TSMI_BlockMode.Checked = true;

            _mode = new BlockMode();
            ResetGame();

            this.Text = "2048  [BlockMode]";
        }

        private void TSMI_About_Click(object sender, EventArgs e)
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine("v20140523 視窗程式設計期末專題報告");
            sb.AppendLine("v20180722 重構優化");

            sb.AppendLine().AppendLine("GitHub：https://github.com/shuangrain/2048");

            MessageBox.Show(sb.ToString(), "修改歷程");
        }

        private void TSMI_Rules_Click(object sender, EventArgs e)
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine("每次控制所有方塊向同一個方向運動");
            sb.AppendLine("兩個相同數字的方塊撞在一起之後合並成為他們的和");
            sb.AppendLine("每次操作之後會在空白的方格處隨機生成一個2或者4");
            sb.AppendLine("最終得到一個'2048'的方塊就算勝利！").AppendLine();
            sb.AppendLine("Classic：如果格子填滿且無法相加或移動時結算。");
            sb.AppendLine("Time：如果數字成功相加秒數會加一上限十秒，剩下秒數為零時結算。");
            sb.AppendLine("Move：如果數字成功相加步數會加一上限五步，剩下步數為零時結算。");
            sb.AppendLine("Block：隨機產生一格障礙物，且會隨著數字移動，如果格子填滿且無法相加或移動時結算。");

            MessageBox.Show(sb.ToString(), "遊戲說明");
        }

        private void TSMI_Rank_Click(object sender, EventArgs e)
        {
            new RankDialog().ShowDialog();
        }

        private void TSMI_Reset_Click(object sender, EventArgs e)
        {
            ResetGame();
        }

        #endregion

        #region 重新繪製 UI

        private void groupBox1_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.Clear(groupBox1.BackColor);
            Rectangle Rtg_LT = new Rectangle();
            Rectangle Rtg_RT = new Rectangle();
            Rectangle Rtg_LB = new Rectangle();
            Rectangle Rtg_RB = new Rectangle();
            Rtg_LT.X = 0; Rtg_LT.Y = 7; Rtg_LT.Width = 10; Rtg_LT.Height = 10;
            Rtg_RT.X = e.ClipRectangle.Width - 11; Rtg_RT.Y = 7; Rtg_RT.Width = 10; Rtg_RT.Height = 10;
            Rtg_LB.X = 0; Rtg_LB.Y = e.ClipRectangle.Height - 11; Rtg_LB.Width = 10; Rtg_LB.Height = 10;
            Rtg_RB.X = e.ClipRectangle.Width - 11; Rtg_RB.Y = e.ClipRectangle.Height - 11; Rtg_RB.Width = 10; Rtg_RB.Height = 10;
            Color color = Color.FromArgb(51, 94, 168);
            Pen Pen_AL = new Pen(color, 1);
            Pen_AL.Color = color;
            Brush brush = new HatchBrush(HatchStyle.Divot, color);
            e.Graphics.DrawString(groupBox1.Text, groupBox1.Font, brush, 6, 0);
            e.Graphics.DrawArc(Pen_AL, Rtg_LT, 180, 90);
            e.Graphics.DrawArc(Pen_AL, Rtg_RT, 270, 90);
            e.Graphics.DrawArc(Pen_AL, Rtg_LB, 90, 90);
            e.Graphics.DrawArc(Pen_AL, Rtg_RB, 0, 90);
            e.Graphics.DrawLine(Pen_AL, 5, 7, 6, 7);
            e.Graphics.DrawLine(Pen_AL, e.Graphics.MeasureString(groupBox1.Text, groupBox1.Font).Width + 3, 7, e.ClipRectangle.Width - 7, 7);
            e.Graphics.DrawLine(Pen_AL, 0, 13, 0, e.ClipRectangle.Height - 7);
            e.Graphics.DrawLine(Pen_AL, 6, e.ClipRectangle.Height - 1, e.ClipRectangle.Width - 7, e.ClipRectangle.Height - 1);
            e.Graphics.DrawLine(Pen_AL, e.ClipRectangle.Width - 1, e.ClipRectangle.Height - 7, e.ClipRectangle.Width - 1, 13);
        }

        private void groupBox2_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.Clear(groupBox2.BackColor);
            Rectangle Rtg_LT = new Rectangle();
            Rectangle Rtg_RT = new Rectangle();
            Rectangle Rtg_LB = new Rectangle();
            Rectangle Rtg_RB = new Rectangle();
            Rtg_LT.X = 0; Rtg_LT.Y = 7; Rtg_LT.Width = 10; Rtg_LT.Height = 10;
            Rtg_RT.X = e.ClipRectangle.Width - 11; Rtg_RT.Y = 7; Rtg_RT.Width = 10; Rtg_RT.Height = 10;
            Rtg_LB.X = 0; Rtg_LB.Y = e.ClipRectangle.Height - 11; Rtg_LB.Width = 10; Rtg_LB.Height = 10;
            Rtg_RB.X = e.ClipRectangle.Width - 11; Rtg_RB.Y = e.ClipRectangle.Height - 11; Rtg_RB.Width = 10; Rtg_RB.Height = 10;
            Color color = Color.FromArgb(51, 94, 168);
            Pen Pen_AL = new Pen(color, 1);
            Pen_AL.Color = color;
            Brush brush = new HatchBrush(HatchStyle.Divot, color);
            e.Graphics.DrawString(groupBox2.Text, groupBox2.Font, brush, 6, 0);
            e.Graphics.DrawArc(Pen_AL, Rtg_LT, 180, 90);
            e.Graphics.DrawArc(Pen_AL, Rtg_RT, 270, 90);
            e.Graphics.DrawArc(Pen_AL, Rtg_LB, 90, 90);
            e.Graphics.DrawArc(Pen_AL, Rtg_RB, 0, 90);
            e.Graphics.DrawLine(Pen_AL, 5, 7, 6, 7);
            e.Graphics.DrawLine(Pen_AL, e.Graphics.MeasureString(groupBox2.Text, groupBox2.Font).Width + 3, 7, e.ClipRectangle.Width - 7, 7);
            e.Graphics.DrawLine(Pen_AL, 0, 13, 0, e.ClipRectangle.Height - 7);
            e.Graphics.DrawLine(Pen_AL, 6, e.ClipRectangle.Height - 1, e.ClipRectangle.Width - 7, e.ClipRectangle.Height - 1);
            e.Graphics.DrawLine(Pen_AL, e.ClipRectangle.Width - 1, e.ClipRectangle.Height - 7, e.ClipRectangle.Width - 1, 13);
        }

        #endregion
    }
}
