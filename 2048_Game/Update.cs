using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
//MySQL
using MySql.Data.MySqlClient;

namespace _2048_Game
{
    public partial class Update : Form
    {
        int GetScore, PlayTime;
        string SaveName;
        string Time = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
        public Update(int DataGetScore, string DataSaveName, int DataPlayTime)
        {
            InitializeComponent();
            GetScore = DataGetScore;
            SaveName = DataSaveName;
            PlayTime = DataPlayTime;
        }
        private void Post_Load(object sender, EventArgs e)
        {
            lblMsg.Text = "獲得：" + GetScore + "分！";
            lblMsg.Text += "\n恭喜刷新排行榜！";
        }
        private void btnSend_Click(object sender, EventArgs e)
        {
            //上傳資料庫
            try
            {
                if (textName.Text == "")
                {
                    MessageBox.Show("請輸入暱稱");
                }
                else
                {
                    //開始資料庫連結
                    string Server = "Server=shuang.myftp.org;Port=3306;Database=finalproject;User=test;Pwd=test;CharSet=utf8;";
                    //準備輸入進資料庫的內容
                    string Insert = "INSERT INTO 2048Rank (Name,Mode,Score,Date,PlayTime) VALUES('" + textName.Text + "','" + SaveName + "','" + GetScore + "','" + Time + "','" + PlayTime + "')";
                    MySqlConnection sqlcon = new MySqlConnection(Server);
                    sqlcon.Open();
                    //開始寫入
                    MySqlCommand mySqlCmd = new MySqlCommand(Insert);
                    mySqlCmd.Connection = sqlcon;
                    mySqlCmd.ExecuteNonQuery();
                    mySqlCmd.Connection.Close();
                    sqlcon.Close();
                    MessageBox.Show("已送出！");
                    this.Close();
                }
            }
            catch (Exception)
            {
                MessageBox.Show("伺服器連結發生問題！");
            }
        }
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
