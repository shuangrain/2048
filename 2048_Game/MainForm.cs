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
        bool check;
        int checkmove = 1, checkadd = 0, checkzero = 0;
        //全域變數
        private void timer1_Tick(object sender, EventArgs e)
        {
            btnReset.Focus();
            PlayTime++;
            tSSLTime.Text = tSSLTime.Text = DateTime.Now.ToString();
            tSSLPlayTime.Text = "已經玩了：" + PlayTime + " 秒";
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
            //在隨機位置產生兩個隨機的數字
            rand();
            rand();
            //尋找最佳成績，若無則新增一紀錄檔
            try
            {
                StreamReader Read = new StreamReader(@"./Config.Dat", Encoding.UTF8);
                string str = Read.ReadToEnd();
                if (str.IndexOf("Best Score") >= 0)
                {
                    lblBestScore.Text = "Best Score：" + str.Split('：', '\n')[1];
                }
                Read.Close();
            }
            catch (Exception)
            {
                StreamWriter Write = new StreamWriter(@"./Config.Dat");
                Write.WriteLine("Best Score：0");
                Write.Close();
            }
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
                            checkadd++;
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
                            checkadd++;
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
                            checkadd++;
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
                            checkadd++;
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
                                checkmove++;
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
                                checkmove++;
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
                                checkmove++;
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
                                checkmove++;
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
                    checkzero++;
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
        public void rand()
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
                check = false;
                Random obj = new Random();
                int temp = 0, x = 0, y = 0;
                temp = 2 * obj.Next(1, 3);
                do
                {
                    x = obj.Next(0, 4);
                    y = obj.Next(0, 4);
                    if (Location_ex[x, y] == 0)
                    {
                        check = true;
                        Location_ex[x, y] = temp;
                        LocationChangeNum();
                    }
                } while (check == false);
            }
        }
        //重置
        public void reset()
        {
            foreach (Button obj in groupBox2.Controls)
            {
                obj.Text = "0";
            }
            NumChangeLocation();
            getPoint = 0;
            PlayTime = 0;
            lblPoint.Text = "Score：" + getPoint;
            rand();
            rand();
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            reset();
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
            lblPoint.Text = "Score：" + getPoint;
            //若數字無移動與數字無相加就不進行動作
            if (checkmove != 0 || checkadd != 0)
            {
                rand();
                checkmove = 0;
                checkadd = 0;
                checkzero = 0;
            }
            else if (checkmove == 0 && checkadd == 0 && checkzero == 0)
            {
                //檢查是否突破最高分數，若有則寫入紀錄檔
                try
                {
                    StreamReader Read = new StreamReader(@"./Config.Dat", Encoding.UTF8);
                    string str = Read.ReadToEnd();
                    Read.Close();
                    if (str.IndexOf("Best Score") >= 0)
                    {
                        if (getPoint > int.Parse(str.Split('：', '\n')[1]))
                        {
                            str = str.Replace(str.Split('：', '\n')[1], getPoint.ToString());
                            StreamWriter Write = new StreamWriter(@"./Config.Dat");
                            Write.WriteLine(str);
                            Write.Close();
                            lblBestScore.Text = "Best Score：" + getPoint;
                            MessageBox.Show("恭喜突破最高紀錄！");
                        }
                        else
                        {
                            MessageBox.Show("差一點點，再加油！");
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
                reset();
            }
        }
    }
}
