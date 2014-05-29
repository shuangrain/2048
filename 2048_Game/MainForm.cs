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

namespace _2048_Game
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }
        //全域變數
        int[,] Location_ex = new int[4, 4];
        int PlayTime = 0, getPoint = 0;
        bool Check, CheckTimeMode, CheckMoveMode;
        int CheckMove = 0, CheckAdd = 0, CheckActive = 0, CheckRule = 100;
        //全域變數
        private void timer1_Tick(object sender, EventArgs e)
        {
            //若使用者焦點在方塊上則更改焦點
            if (a1.Focused == true || a2.Focused == true || a3.Focused == true || a4.Focused == true || b1.Focused == true || b2.Focused == true || b3.Focused == true || b4.Focused == true || c1.Focused == true || c2.Focused == true || c3.Focused == true || c4.Focused == true || d1.Focused == true || d2.Focused == true || d3.Focused == true || d4.Focused == true)
            {
                lblPoint.Focus();
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
                CheckRule = 100;
                CheckStatus();
            }
        }
        private void Form1_KeyUp(object sender, KeyEventArgs e)
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
                        Move_Up();
                        Add_Up();
                        Move_Up();
                        LocationChangeNum();
                        CheckStatus();
                        break;
                    }
                case "Down":
                    {
                        NumChangeLocation();
                        Move_Down();
                        Add_Down();
                        Move_Down();
                        LocationChangeNum();
                        CheckStatus();
                        break;
                    }
                case "Left":
                    {
                        NumChangeLocation();
                        Move_Left();
                        Add_Left();
                        Move_Left();
                        LocationChangeNum();
                        CheckStatus();
                        break;
                    }
                case "Right":
                    {
                        NumChangeLocation();
                        Move_Right();
                        Add_Right();
                        Move_Right();
                        LocationChangeNum();
                        CheckStatus();
                        break;
                    }
            }
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            //選擇模式
            TSMIClassic.PerformClick();
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
        }
        public void Add_Up()
        {
            //檢查數字是否可以加起來
            for (int i = 0; i < 4; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    //檢查空白並防止溢位
                    if (Location_ex[i, j] != 0 && j != 0)
                    {
                        if (Location_ex[i, j - 1] == Location_ex[i, j])
                        {
                            Location_ex[i, j - 1] += Location_ex[i, j];
                            Location_ex[i, j] = 0;
                            CheckAdd++;
                            getPoint += Location_ex[i, j - 1];
                        }
                    }
                }
            }
        }
        public void Add_Down()
        {
            //檢查數字是否可以加起來
            for (int i = 3; i > -1; i--)
            {
                for (int j = 3; j > -1; j--)
                {
                    //檢查空白並防止溢位
                    if (Location_ex[i, j] != 0 && j + 1 < 4)
                    {
                        if (Location_ex[i, j + 1] == Location_ex[i, j])
                        {
                            Location_ex[i, j + 1] += Location_ex[i, j];
                            Location_ex[i, j] = 0;
                            CheckAdd++;
                            getPoint += Location_ex[i, j + 1];
                        }
                    }
                }
            }
        }
        public void Add_Left()
        {
            //檢查數字是否可以加起來
            for (int i = 0; i < 4; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    //檢查空白並防止溢位
                    if (Location_ex[i, j] != 0 && i != 0)
                    {
                        if (Location_ex[i - 1, j] == Location_ex[i, j])
                        {
                            Location_ex[i - 1, j] += Location_ex[i, j];
                            Location_ex[i, j] = 0;
                            CheckAdd++;
                            getPoint += Location_ex[i - 1, j];
                        }
                    }
                }
            }
        }
        public void Add_Right()
        {
            //檢查數字是否可以加起來
            for (int i = 3; i > -1; i--)
            {
                for (int j = 3; j > -1; j--)
                {
                    //檢查空白並防止溢位
                    if (Location_ex[i, j] != 0 && i + 1 < 4)
                    {
                        if (Location_ex[i + 1, j] == Location_ex[i, j])
                        {
                            Location_ex[i + 1, j] += Location_ex[i, j];
                            Location_ex[i, j] = 0;
                            CheckAdd++;
                            getPoint += Location_ex[i + 1, j];
                        }
                    }
                }
            }
        }
        public void Move_Up()
        {
            //移動數字
            for (int run = 0; run < 3; run++)
            {
                for (int i = 0; i < 4; i++)
                {
                    for (int j = 0; j < 4; j++)
                    {
                        //檢查空白並防止溢位
                        if (Location_ex[i, j] != 0 && j != 0)
                        {
                            if (Location_ex[i, j - 1] == 0)
                            {
                                Location_ex[i, j - 1] = Location_ex[i, j];
                                Location_ex[i, j] = 0;
                                CheckMove++;
                            }
                        }
                    }
                }
            }
        }
        public void Move_Down()
        {
            //移動數字
            for (int run = 0; run < 3; run++)
            {
                for (int i = 3; i > -1; i--)
                {
                    for (int j = 3; j > -1; j--)
                    {
                        //檢查空白並防止溢位
                        if (Location_ex[i, j] != 0 && j + 1 < 4)
                        {
                            if (Location_ex[i, j + 1] == 0)
                            {
                                Location_ex[i, j + 1] = Location_ex[i, j];
                                Location_ex[i, j] = 0;
                                CheckMove++;
                            }
                        }
                    }
                }
            }
        }
        public void Move_Left()
        {
            //移動數字
            for (int run = 0; run < 3; run++)
            {
                for (int i = 0; i < 4; i++)
                {
                    for (int j = 0; j < 4; j++)
                    {
                        //檢查空白並防止溢位
                        if (Location_ex[i, j] != 0 && i != 0)
                        {
                            if (Location_ex[i - 1, j] == 0)
                            {
                                Location_ex[i - 1, j] = Location_ex[i, j];
                                Location_ex[i, j] = 0;
                                CheckMove++;
                            }
                        }
                    }
                }
            }
        }
        public void Move_Right()
        {
            //移動數字
            for (int run = 0; run < 3; run++)
            {
                for (int i = 3; i > -1; i--)
                {
                    for (int j = 3; j > -1; j--)
                    {
                        //檢查空白並防止溢位
                        if (Location_ex[i, j] != 0 && i + 1 < 4)
                        {
                            if (Location_ex[i + 1, j] == 0)
                            {
                                Location_ex[i + 1, j] = Location_ex[i, j];
                                Location_ex[i, j] = 0;
                                CheckMove++;
                            }
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
            Location_ex[0, 0] = int.Parse(a1.Text);
            Location_ex[0, 1] = int.Parse(a2.Text);
            Location_ex[0, 2] = int.Parse(a3.Text);
            Location_ex[0, 3] = int.Parse(a4.Text);
            Location_ex[1, 0] = int.Parse(b1.Text);
            Location_ex[1, 1] = int.Parse(b2.Text);
            Location_ex[1, 2] = int.Parse(b3.Text);
            Location_ex[1, 3] = int.Parse(b4.Text);
            Location_ex[2, 0] = int.Parse(c1.Text);
            Location_ex[2, 1] = int.Parse(c2.Text);
            Location_ex[2, 2] = int.Parse(c3.Text);
            Location_ex[2, 3] = int.Parse(c4.Text);
            Location_ex[3, 0] = int.Parse(d1.Text);
            Location_ex[3, 1] = int.Parse(d2.Text);
            Location_ex[3, 2] = int.Parse(d3.Text);
            Location_ex[3, 3] = int.Parse(d4.Text);
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
            a1.Text = Location_ex[0, 0].ToString();
            a2.Text = Location_ex[0, 1].ToString();
            a3.Text = Location_ex[0, 2].ToString();
            a4.Text = Location_ex[0, 3].ToString();
            b1.Text = Location_ex[1, 0].ToString();
            b2.Text = Location_ex[1, 1].ToString();
            b3.Text = Location_ex[1, 2].ToString();
            b4.Text = Location_ex[1, 3].ToString();
            c1.Text = Location_ex[2, 0].ToString();
            c2.Text = Location_ex[2, 1].ToString();
            c3.Text = Location_ex[2, 2].ToString();
            c4.Text = Location_ex[2, 3].ToString();
            d1.Text = Location_ex[3, 0].ToString();
            d2.Text = Location_ex[3, 1].ToString();
            d3.Text = Location_ex[3, 2].ToString();
            d4.Text = Location_ex[3, 3].ToString();
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
                    if (Location_ex[x, y] == 0)
                    {
                        Check = true;
                        Location_ex[x, y] = temp;
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
            getPoint = 0;
            PlayTime = 0;
            CheckTimeMode = false;
            lblPoint.Text = "Score：" + getPoint;
            if (statusStrip1.Items.Count > 2)
            {
                statusStrip1.Items.RemoveAt(2);
            }
            if (TSMITime.Checked == true)
            {
                CheckRule = 100;
                CheckTimeMode = true;
                statusStrip1.Items.Add("倒數：" + CheckRule + " 秒");
            }
            else if (TSMIMove.Checked == true)
            {
                CheckRule = 100;
                CheckMoveMode = true;
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
            CheckActive = 0;
            ////檢查上下左右是否有可以移動或加起來的數字////
            //上
            for (int i = 0; i < 4; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    //檢查空白並防止溢位
                    if (Location_ex[i, j] != 0 && j != 0)
                    {
                        if (Location_ex[i, j - 1] == 0)
                        {
                            CheckActive++;
                        }
                        if (Location_ex[i, j - 1] == Location_ex[i, j])
                        {
                            CheckActive++;
                        }
                    }
                }
            }
            //下
            for (int i = 3; i > -1; i--)
            {
                for (int j = 3; j > -1; j--)
                {
                    //檢查空白並防止溢位
                    if (Location_ex[i, j] != 0 && j + 1 < 4)
                    {
                        if (Location_ex[i, j + 1] == 0)
                        {
                            CheckActive++;
                        }
                        if (Location_ex[i, j + 1] == Location_ex[i, j])
                        {
                            CheckActive++;
                        }
                    }
                }
            }
            //左
            for (int i = 0; i < 4; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    //檢查空白並防止溢位
                    if (Location_ex[i, j] != 0 && i != 0)
                    {
                        if (Location_ex[i - 1, j] == 0)
                        {
                            CheckActive++;
                        }
                        if (Location_ex[i - 1, j] == Location_ex[i, j])
                        {
                            CheckActive++;
                        }
                    }
                }
            }
            //右
            for (int i = 3; i > -1; i--)
            {
                for (int j = 3; j > -1; j--)
                {
                    //檢查空白並防止溢位
                    if (Location_ex[i, j] != 0 && i + 1 < 4)
                    {
                        if (Location_ex[i + 1, j] == 0)
                        {
                            CheckActive++;
                        }
                        if (Location_ex[i + 1, j] == Location_ex[i, j])
                        {
                            CheckActive++;
                        }
                    }
                }
            }
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
            lblPoint.Text = "Score：" + getPoint;
            //若數字無移動與數字無相加就不進行動作
            if (CheckMove != 0 || CheckAdd != 0)
            {
                Rand();
                CheckMove = 0;
                CheckAdd = 0;
                //Move模式動一步就-1
                if (TSMIMove.Checked == true)
                {
                    CheckRule--;
                    statusStrip1.Items[2].Text = "可動：" + CheckRule + " 步";
                    //Move模式步數用完
                    if (CheckRule==0 && TSMIMove.Checked == true)
                    {
                        CheckActive = 0;
                    }
                }
            }
            if (CheckActive == 0)
            {
                MessageBox.Show("Game Over");
                if (TSMIClassic.Checked == true)
                {
                    SaveScore(TSMIClassic.Text, 1);
                }
                else if (TSMITime.Checked == true)
                {
                    SaveScore(TSMITime.Text, 3);
                }
                else if (TSMIMove.Checked == true)
                {
                    SaveScore(TSMITime.Text, 5);
                }
                else if (TSMIX.Checked == true)
                {
                    SaveScore(TSMIX.Text, 4);
                }
                Reset();
                FirstLoad();
            }
        }
        //檢查是否突破最高分數，若有則寫入紀錄檔
        public void SaveScore(string SaveName, int SaveLine)
        {
            try
            {
                StreamReader Read = new StreamReader(@"./Config.Dat", Encoding.UTF8);
                string str = Read.ReadToEnd();
                Read.Close();
                if (str.IndexOf(SaveName) >= 0)
                {
                    if (getPoint > int.Parse(str.Split('：', '\n')[SaveLine]))
                    {
                        str = str.Replace(SaveName + "：" + str.Split('：', '\n')[SaveLine], SaveName + "：" + getPoint.ToString());
                        StreamWriter Write = new StreamWriter(@"./Config.Dat");
                        Write.Write(str);
                        Write.Close();
                        lblBestScore.Text = "Best Score：" + getPoint;
                        MessageBox.Show("恭喜突破最高紀錄！");
                    }
                    else
                    {
                        MessageBox.Show("差一點點突破，再加油！");
                    }
                }
            }
            catch (Exception)
            {
                StreamWriter Write = new StreamWriter(@"./Config.Dat");
                if (SaveName == "Classic")
                {
                    Write.WriteLine("Classic：" + getPoint);
                    Write.WriteLine("Time：0");
                    Write.WriteLine("Move：0");
                    Write.WriteLine("X：0");
                }
                else if (SaveName == "Time")
                {
                    Write.WriteLine("Classic：0");
                    Write.WriteLine("Time：" + getPoint);
                    Write.WriteLine("Move：0");
                    Write.WriteLine("X：0");
                }
                else if (SaveName == "Move")
                {
                    Write.WriteLine("Classic：0");
                    Write.WriteLine("Time：0");
                    Write.WriteLine("Move：" + getPoint);
                    Write.WriteLine("X：0");
                }
                else if (SaveName == "X")
                {
                    Write.WriteLine("Classic：");
                    Write.WriteLine("Time：0");
                    Write.WriteLine("Move：0");
                    Write.WriteLine("X：0" + getPoint);
                }
                Write.Close();
                lblBestScore.Text = "Best Score：" + getPoint;
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
            }
        }

        private void TSMIClassic_Click(object sender, EventArgs e)
        {
            TSMIClassic.Checked = true;
            TSMITime.Checked = false;
            TSMIMove.Checked = false;
            Reset();
            FirstLoad();
            ReadScore(TSMIClassic.Text, 1);
        }

        private void TSMITime_Click(object sender, EventArgs e)
        {
            TSMIClassic.Checked = false;
            TSMITime.Checked = true;
            TSMIMove.Checked = false;
            Reset();
            FirstLoad();
            ReadScore(TSMITime.Text, 3);
        }

        private void TSMIMove_Click(object sender, EventArgs e)
        {
            TSMIClassic.Checked = false;
            TSMITime.Checked = false;
            TSMIMove.Checked = true;
            Reset();
            FirstLoad();
            ReadScore(TSMITime.Text, 5);
        }
        private void TSMIX_Click(object sender, EventArgs e)
        {

        }
        private void TSMIAbout_Click(object sender, EventArgs e)
        {
            MessageBox.Show("U101B117  許民聖", "視窗程式設計期末專題報告");
        }

        private void TSMIRules_Click(object sender, EventArgs e)
        {
            MessageBox.Show("每次控制所有方塊向同一個方向運動\n兩個相同數字的方塊撞在一起之後合並成為他們的和\n每次操作之後會在空白的方格處隨機生成一個2或者4\n最終得到一個'2048'的方塊就算勝利！\n\n Classic：如果格子填滿且無法相加或移動時結算\n\n Time：如果剩下秒數為零時結算\n\n Move：如果剩下步數為零時結算\n\n ", "遊戲說明");
        }
    }
}
