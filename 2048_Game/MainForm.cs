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
//MySQL
using MySql.Data.MySqlClient;

namespace _2048_Game
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }
        //全域變數
        int[,] Coordinate = new int[4, 4];
        int PlayTime = 0, GetScore = 0;
        bool Check, CheckTimeMode;
        int CheckMove = 0, CheckAdd = 0, CheckActive = 0, CheckRule = 0;
        //全域變數
        private void timer1_Tick(object sender, EventArgs e)
        {
            //若使用者焦點在方塊上則更改焦點
            foreach (Button obj in groupBox2.Controls)
            {
                if (obj.Focused == true)
                {
                    lblPoint.Focus();
                }
            }
            PlayTime++;
            tSSLTime.Text = DateTime.Now.ToString();
            tSSLPlayTime.Text = "已經玩了：" + PlayTime + " 秒";
            if (CheckTimeMode == true)
            {
                CheckRule--;
                statusStrip1.Items[2].Text = "倒數：" + CheckRule + " 秒";
            }
            if (CheckRule == 0)
            {
                CheckTimeMode = false;
                CheckRule = 5;
                CheckStatus();
            }
        }
        private void MainForm_KeyUp(object sender, KeyEventArgs e)
        {
            switch (e.KeyData.ToString())
            {
                default:
                    {
                        //無動作
                        break;
                    }
                case "Up":
                    {
                        NumChangeLocation();
                        MoveNum(-1, 3, 0, 1);
                        AddNum("Right+Up", -1, 3, 0, 1);
                        MoveNum(-1, 3, 0, 1);
                        LocationChangeNum();
                        CheckStatus();
                        break;
                    }
                case "Down":
                    {
                        NumChangeLocation();
                        MoveNum(-1, 0, 0, -1);
                        AddNum("Left+Down", -1, 0, 0, -1);
                        MoveNum(-1, 0, 0, -1);
                        LocationChangeNum();
                        CheckStatus();
                        break;
                    }
                case "Left":
                    {
                        NumChangeLocation();
                        MoveNum(0, -1, -1, 0);
                        AddNum("Left+Down", 0, -1, -1, 0);
                        MoveNum(0, -1, -1, 0);
                        LocationChangeNum();
                        CheckStatus();
                        break;
                    }
                case "Right":
                    {
                        NumChangeLocation();
                        MoveNum(3, -1, 1, 0);
                        AddNum("Right+Up", 3, -1, 1, 0);
                        MoveNum(3, -1, 1, 0);
                        LocationChangeNum();
                        CheckStatus();
                        break;
                    }
            }
        }
        private void MainForm_Load(object sender, EventArgs e)
        {
            //選擇模式
            TSMIClassic.PerformClick();
            TSMIRules.PerformClick();
            //在隨機位置產生兩個隨機的數字
            FirstLoad();
            ReadScore(TSMIClassic.Text, 1);
        }
        public void FirstLoad()
        {
            int FirstCheck = 0;
            do
            {
                FirstCheck = 0;
                Reset();
                Rand();
                Rand();
                foreach (Button obj in groupBox2.Controls)
                {
                    if (obj.Text == "4")
                    {
                        FirstCheck++;
                    }
                }
            } while (FirstCheck == 2);
            if (TSMIX.Checked == true)
            {
                //隨機產生一障礙物
                NumChangeLocation();
                Check = false;
                Random obj = new Random();
                int x = 0, y = 0;
                do
                {
                    x = obj.Next(0, 4);
                    y = obj.Next(0, 4);
                    if (Coordinate[x, y] == 0)
                    {
                        Check = true;
                        Coordinate[x, y] = 10;
                        LocationChangeNum();
                    }
                } while (Check == false);
                NumColor();
            }
        }
        public void AddNum(string Direction, int Limit_x1, int Limit_y1, int Limit_x2, int Limit_y2)
        {
            if (Direction == "Right+Up")
            {
                for (int i = 3; i > -1; i--)
                {
                    for (int j = 3; j > -1; j--)
                    {
                        //檢查空白並防止溢位
                        if (Coordinate[i, j] != 0 && i != Limit_x1 && j != Limit_y1)
                        {
                            if (Coordinate[i + Limit_x2, j + Limit_y2] == Coordinate[i, j])
                            {
                                Coordinate[i + Limit_x2, j + Limit_y2] += Coordinate[i, j];
                                GetScore += Coordinate[i + Limit_x2, j + Limit_y2];
                                Coordinate[i, j] = 0;
                                CheckAdd++;
                            }
                        }

                    }
                }
            }
            else if (Direction == "Left+Down")
            {
                for (int i = 0; i < 4; i++)
                {
                    for (int j = 0; j < 4; j++)
                    {
                        //檢查空白並防止溢位
                        if (Coordinate[i, j] != 0 && i != Limit_x1 && j != Limit_y1)
                        {
                            if (Coordinate[i + Limit_x2, j + Limit_y2] == Coordinate[i, j])
                            {
                                Coordinate[i + Limit_x2, j + Limit_y2] += Coordinate[i, j];
                                GetScore += Coordinate[i + Limit_x2, j + Limit_y2];
                                Coordinate[i, j] = 0;
                                CheckAdd++;
                            }
                        }
                    }
                }
            }
        }
        public void MoveNum(int Limit_x1, int Limit_y1, int Limit_x2, int Limit_y2)
        {
            //執行次數
            for (int run = 0; run < 3; run++)
            {
                for (int i = 0; i < 4; i++)
                {
                    for (int j = 0; j < 4; j++)
                    {
                        //檢查空白並防止溢位
                        if (Coordinate[i, j] != 0 && i != Limit_x1 && j != Limit_y1)
                        {
                            if (Coordinate[i + Limit_x2, j + Limit_y2] == 0)
                            {
                                Coordinate[i + Limit_x2, j + Limit_y2] = Coordinate[i, j];
                                Coordinate[i, j] = 0;
                                CheckMove++;
                            }
                        }
                    }
                }
            }
        }
        public void CheckNum(int Limit_x1, int Limit_y1, int Limit_x2, int Limit_y2)
        {
            for (int i = 0; i < 4; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    //檢查空白並防止溢位
                    if (Coordinate[i, j] != 0 && i != Limit_x1 && j != Limit_y1)
                    {
                        if (Coordinate[i + Limit_x2, j + Limit_y2] == 0 || Coordinate[i + Limit_x2, j + Limit_y2] == Coordinate[i, j])
                        {
                            CheckActive++;
                        }
                    }
                }
            }

        }
        //數字轉換用
        public void NumChangeLocation()
        {
            //把空白的文字轉成零，不然會錯誤
            foreach (Button obj in groupBox2.Controls)
            {
                if (obj.Text == "")
                {
                    obj.Text = "0";
                }
            }
            //變數
            Coordinate[0, 0] = int.Parse(x0y0.Text);
            Coordinate[0, 1] = int.Parse(x0y1.Text);
            Coordinate[0, 2] = int.Parse(x0y2.Text);
            Coordinate[0, 3] = int.Parse(x0y3.Text);
            Coordinate[1, 0] = int.Parse(x1y0.Text);
            Coordinate[1, 1] = int.Parse(x1y1.Text);
            Coordinate[1, 2] = int.Parse(x1y2.Text);
            Coordinate[1, 3] = int.Parse(x1y3.Text);
            Coordinate[2, 0] = int.Parse(x2y0.Text);
            Coordinate[2, 1] = int.Parse(x2y1.Text);
            Coordinate[2, 2] = int.Parse(x2y2.Text);
            Coordinate[2, 3] = int.Parse(x2y3.Text);
            Coordinate[3, 0] = int.Parse(x3y0.Text);
            Coordinate[3, 1] = int.Parse(x3y1.Text);
            Coordinate[3, 2] = int.Parse(x3y2.Text);
            Coordinate[3, 3] = int.Parse(x3y3.Text);
            //把零的文字轉成空白，供使用者觀看
            foreach (Button obj in groupBox2.Controls)
            {
                if (obj.Text == "0")
                {
                    obj.Text = "";
                }
            }
        }
        //數字轉換用
        public void LocationChangeNum()
        {
            x0y0.Text = Coordinate[0, 0].ToString();
            x0y1.Text = Coordinate[0, 1].ToString();
            x0y2.Text = Coordinate[0, 2].ToString();
            x0y3.Text = Coordinate[0, 3].ToString();
            x1y0.Text = Coordinate[1, 0].ToString();
            x1y1.Text = Coordinate[1, 1].ToString();
            x1y2.Text = Coordinate[1, 2].ToString();
            x1y3.Text = Coordinate[1, 3].ToString();
            x2y0.Text = Coordinate[2, 0].ToString();
            x2y1.Text = Coordinate[2, 1].ToString();
            x2y2.Text = Coordinate[2, 2].ToString();
            x2y3.Text = Coordinate[2, 3].ToString();
            x3y0.Text = Coordinate[3, 0].ToString();
            x3y1.Text = Coordinate[3, 1].ToString();
            x3y2.Text = Coordinate[3, 2].ToString();
            x3y3.Text = Coordinate[3, 3].ToString();
            //把零的文字轉成空白，供使用者觀看
            foreach (Button obj in groupBox2.Controls)
            {
                if (obj.Text == "0")
                {
                    obj.Text = "";
                }
            }
        }
        //在隨機位置產生2或4
        public void Rand()
        {
            //先檢查是否有空格可以產生數字
            //若無則不動作
            int checknum = 0;
            foreach (Button btnobj in groupBox2.Controls)
            {
                if (btnobj.Text == "")
                {
                    checknum++;
                }
            }
            if (checknum > 0)
            {
                NumChangeLocation();
                Check = false;
                Random obj = new Random();
                int temp = 0, x = 0, y = 0;
                temp = 2 * obj.Next(1, 3);
                do
                {
                    x = obj.Next(0, 4);
                    y = obj.Next(0, 4);
                    if (Coordinate[x, y] == 0)
                    {
                        Check = true;
                        Coordinate[x, y] = temp;
                        LocationChangeNum();
                    }
                } while (Check == false);
            }
            NumColor();
        }
        //重置
        public void Reset()
        {
            foreach (Button obj in groupBox2.Controls)
            {
                obj.Text = "0";
            }
            NumChangeLocation();
            GetScore = 0;
            PlayTime = 0;
            timer1.Enabled = true;
            CheckTimeMode = false;
            lblPoint.Text = "Score：" + GetScore;
            if (statusStrip1.Items.Count > 2)
            {
                statusStrip1.Items.RemoveAt(2);
            }
            if (TSMITime.Checked == true)
            {
                CheckRule = 10;
                CheckTimeMode = true;
                statusStrip1.Items.Add("倒數：" + CheckRule + " 秒");
            }
            else if (TSMIMove.Checked == true)
            {
                CheckRule = 3;
                statusStrip1.Items.Add("可動：" + CheckRule + " 步");
            }
            else if (TSMIX.Checked == true)
            {

            }
        }
        //重新繪製groupBox
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
        //重新繪製groupBox
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
        //檢查目前遊戲狀態
        public void CheckStatus()
        {
            ////檢查上下左右是否有可以移動或加起來的數字////
            CheckActive = 0;
            CheckNum(-1, 3, 0, 1);
            CheckNum(-1, 0, 0, -1);
            CheckNum(0, -1, -1, 0);
            CheckNum(3, -1, 1, 0);
            //Time模式時間到時
            if (CheckTimeMode == false && TSMITime.Checked == true)
            {
                CheckMove = 0;
                CheckAdd = 0;
                CheckActive = 0;
            }
            //通關提示語
            foreach (Button obj in groupBox2.Controls)
            {
                if (obj.Text == "2048")
                {
                    MessageBox.Show("恭喜達到2048！");
                }
            }
            lblPoint.Text = "Score：" + GetScore;
            //若數字無移動與數字無相加就不進行動作
            if (CheckMove != 0 || CheckAdd != 0)
            {
                //Move模式動一步就-1
                if (TSMIMove.Checked == true)
                {
                    //Move模式如果成功相加步數+1
                    if (CheckAdd > 0 && CheckRule < 5)
                    {
                        CheckRule++;
                    }
                    else
                    {
                        CheckRule--;
                    }
                    statusStrip1.Items[2].Text = "可動：" + CheckRule + " 步";
                    //Move模式步數用完
                    if (CheckRule == 0 && TSMIMove.Checked == true)
                    {
                        CheckActive = 0;
                    }
                }
                //Time模式如果成功相加秒數+1
                if (TSMITime.Checked == true && CheckAdd > 0 && CheckRule < 10)
                {
                    CheckRule++;
                }
                Rand();
            }
            //遊戲結束 寫入成績
            if (CheckActive == 0)
            {
                timer1.Enabled = false;
                MessageBox.Show("Game Over");
                if (TSMIClassic.Checked == true)
                {
                    WriteScore(TSMIClassic.Text, 1);
                }
                else if (TSMITime.Checked == true)
                {
                    WriteScore(TSMITime.Text, 3);
                }
                else if (TSMIMove.Checked == true)
                {
                    WriteScore(TSMIMove.Text, 5);
                }
                else if (TSMIX.Checked == true)
                {
                    WriteScore(TSMIX.Text, 7);
                }
                Reset();
                FirstLoad();
            }
            CheckMove = 0;
            CheckAdd = 0;
        }
        //檢查是否突破最高分數，若有則寫入紀錄檔&上傳資料庫
        public void WriteScore(string SaveName, int SaveLine)
        {
            //寫入檔案
            try
            {
                StreamReader Read = new StreamReader(@"./Config.Dat", Encoding.UTF8);
                string str = Read.ReadToEnd();
                Read.Close();
                if (str.IndexOf(SaveName) >= 0)
                {
                    if (GetScore > int.Parse(str.Split('：', '\n')[SaveLine]))
                    {
                        str = str.Replace(SaveName + "：" + str.Split('：', '\n')[SaveLine], SaveName + "：" + GetScore.ToString());
                        StreamWriter Write = new StreamWriter(@"./Config.Dat");
                        Write.Write(str);
                        Write.Close();
                        lblBestScore.Text = "Best Score：" + GetScore;
                        MessageBox.Show("恭喜突破自己最高紀錄！");
                    }
                }
            }
            catch (Exception)
            {
                StreamWriter Write = new StreamWriter(@"./Config.Dat");
                if (SaveName == "Classic")
                {
                    Write.WriteLine("Classic：" + GetScore);
                    Write.WriteLine("Time：0");
                    Write.WriteLine("Move：0");
                    Write.WriteLine("X：0");
                }
                else if (SaveName == "Time")
                {
                    Write.WriteLine("Classic：0");
                    Write.WriteLine("Time：" + GetScore);
                    Write.WriteLine("Move：0");
                    Write.WriteLine("X：0");
                }
                else if (SaveName == "Move")
                {
                    Write.WriteLine("Classic：0");
                    Write.WriteLine("Time：0");
                    Write.WriteLine("Move：" + GetScore);
                    Write.WriteLine("X：0");
                }
                else if (SaveName == "X")
                {
                    Write.WriteLine("Classic：");
                    Write.WriteLine("Time：0");
                    Write.WriteLine("Move：0");
                    Write.WriteLine("X：0" + GetScore);
                }
                Write.Close();
                lblBestScore.Text = "Best Score：" + GetScore;
            }
            try
            {
                int i = 0;
                //開始資料庫連結
                string Server = "Server=shuang.myftp.org;Port=3306;Database=finalproject;User=test;Pwd=test;CharSet=utf8;";
                //選擇資料庫
                string Search = "SELECT * FROM 2048Rank utf8 ORDER BY Score DESC";
                MySqlConnection sqlcon = new MySqlConnection(Server);
                sqlcon.Open();
                MySqlCommand cmd = new MySqlCommand(Search, sqlcon);
                MySqlDataReader myDataReader = cmd.ExecuteReader();
                while (myDataReader.Read())
                {
                    if (int.Parse(myDataReader["Score"].ToString()) > GetScore && myDataReader["Mode"].ToString() == SaveName)
                    {
                        i++;
                    }
                }
                sqlcon.Close();
                if (i < 11 && GetScore > 0)
                {
                    //上傳資料庫
                    Update ShowPost = new Update(GetScore, SaveName, PlayTime);
                    ShowPost.ShowDialog();
                }
                else
                {
                    MessageBox.Show("未突破其他人記錄");
                }
            }
            catch (Exception)
            {
                MessageBox.Show("伺服器連結發生問題！");
            }

        }
        //尋找最佳成績，若無則新增一紀錄檔
        public void ReadScore(string ReadName, int ReadLine)
        {
            try
            {
                StreamReader Read = new StreamReader(@"./Config.Dat", Encoding.UTF8);
                string str = Read.ReadToEnd();
                if (str.IndexOf(ReadName) >= 0)
                {
                    lblBestScore.Text = "Best Score：" + str.Split('：', '\n')[ReadLine];
                }
                Read.Close();
            }
            catch (Exception)
            {
                StreamWriter Write = new StreamWriter(@"./Config.Dat");
                Write.WriteLine("Classic：0");
                Write.WriteLine("Time：0");
                Write.WriteLine("Move：0");
                Write.WriteLine("X：0");
                Write.Close();
            }
        }
        private void TSMIReset_Click(object sender, EventArgs e)
        {
            Reset();
            FirstLoad();
        }
        public void NumColor()
        {
            foreach (Button obj in groupBox2.Controls)
            {
                if (obj.Text == "2")
                {
                    obj.BackColor = Color.Pink;
                }
                else if (obj.Text == "4")
                {
                    obj.BackColor = Color.Plum;
                }
                else if (obj.Text == "8")
                {
                    obj.BackColor = Color.PowderBlue;
                }
                else if (obj.Text == "16")
                {
                    obj.BackColor = Color.Purple;
                }
                else if (obj.Text == "32")
                {
                    obj.BackColor = Color.Red;
                }
                else if (obj.Text == "64")
                {
                    obj.BackColor = Color.RosyBrown;
                }
                else if (obj.Text == "128")
                {
                    obj.BackColor = Color.RoyalBlue;
                }
                else if (obj.Text == "256")
                {
                    obj.BackColor = Color.SaddleBrown;
                }
                else if (obj.Text == "512")
                {
                    obj.BackColor = Color.Salmon;
                }
                else if (obj.Text == "1024")
                {
                    obj.BackColor = Color.SandyBrown;
                }
                else if (obj.Text == "2048")
                {
                    obj.BackColor = Color.SeaGreen;
                }
                else if (obj.Text == "")
                {
                    obj.BackColor = Button.DefaultBackColor;
                }
                else if (obj.Text == "10")
                {
                    obj.BackColor = Color.Black;
                }
            }
        }

        private void TSMIClassic_Click(object sender, EventArgs e)
        {
            TSMIClassic.Checked = true;
            TSMITime.Checked = false;
            TSMIMove.Checked = false;
            TSMIX.Checked = false;
            Reset();
            FirstLoad();
            ReadScore(TSMIClassic.Text, 1);
            this.Text = "2048  [Classic]";
        }

        private void TSMITime_Click(object sender, EventArgs e)
        {
            TSMIClassic.Checked = false;
            TSMITime.Checked = true;
            TSMIMove.Checked = false;
            TSMIX.Checked = false;
            Reset();
            FirstLoad();
            ReadScore(TSMITime.Text, 3);
            this.Text = "2048  [Time]";
        }

        private void TSMIMove_Click(object sender, EventArgs e)
        {
            TSMIClassic.Checked = false;
            TSMITime.Checked = false;
            TSMIMove.Checked = true;
            TSMIX.Checked = false;
            Reset();
            FirstLoad();
            ReadScore(TSMITime.Text, 5);
            this.Text = "2048  [Move]";
        }
        private void TSMIX_Click(object sender, EventArgs e)
        {
            TSMIClassic.Checked = false;
            TSMITime.Checked = false;
            TSMIMove.Checked = false;
            TSMIX.Checked = true;
            Reset();
            FirstLoad();
            ReadScore(TSMIX.Text, 7);
            this.Text = "2048  [X]";
        }
        private void TSMIAbout_Click(object sender, EventArgs e)
        {
            MessageBox.Show("By.shuangrain", "視窗程式設計期末專題報告");
        }

        private void TSMIRules_Click(object sender, EventArgs e)
        {
            string msg;
            msg = "每次控制所有方塊向同一個方向運動\n";
            msg += "兩個相同數字的方塊撞在一起之後合並成為他們的和\n";
            msg += "每次操作之後會在空白的方格處隨機生成一個2或者4\n";
            msg += "最終得到一個'2048'的方塊就算勝利！\n\n";
            msg += "Classic：如果格子填滿且無法相加或移動時結算。\n";
            msg += "Time：如果數字成功相加秒數會加一上限十秒，剩下秒數為零時結算。\n";
            msg += "Move：如果數字成功相加步數會加一上限五步，剩下步數為零時結算。\n";
            msg += "X：隨機產生一格障礙物，且會隨著數字移動，如果格子填滿且無法相加或移動時結算。";
            MessageBox.Show(msg, "遊戲說明");
        }

        private void TSMIRank_Click(object sender, EventArgs e)
        {
            Rank ShowRank = new Rank();
            ShowRank.ShowDialog();
        }
    }
}
