using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;

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
            NumChangeLocation();
            switch (e.KeyData.ToString())
            {
                case "Up":
                    {
                        Move_Up();
                        Add_Up();
                        Move_Up();
                        break;
                    }
                case "Down":
                    {
                        Move_Down();
                        Add_Down();
                        Move_Down();
                        break;
                    }
                case "Left":
                    {
                        Move_Left();
                        Add_Left();
                        Move_Left();
                        break;
                    }
                case "Right":
                    {
                        Move_Right();
                        Add_Right();
                        Move_Right();
                        break;
                    }
            }
            LocationChangeNum();
            lblPoint.Text = "Score：" + getPoint;
            //若數字無移動與數字無相加就不進行動作
            if (checkmove != 0 || checkadd!=0)
            {
                rand();
                checkmove = 0;
                checkadd = 0;
                checkzero = 0;
            }
            else if (checkmove == 0 && checkadd == 0 && checkzero == 0)
            {
                MessageBox.Show("Game Over");
                reset();
            }
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            //在隨機位置產生兩個隨機的數字
            rand();
            rand();
            //尋找最佳成績
            //StreamWriter Write = new StreamWriter(@"/1.txt");
            //Write.WriteLine("");
            //Write.WriteLine("Best Score：159159");
            //Write.WriteLine("");
            //Write.Close();
            //StreamReader Read = new StreamReader(@"/1.txt", Encoding.UTF8);
            //Read.Close();
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
        public void reset()
        {
            foreach (Button obj in groupBox2.Controls)
            {
                obj.Text = "0";
            }
            NumChangeLocation();
            getPoint = 0;
            lblPoint.Text = "Score：" + getPoint;
            rand();
            rand();
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            reset();
        }
    }
}
