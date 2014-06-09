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
    public partial class Rank : Form
    {
        public Rank()
        {
            InitializeComponent();
        }

        private void Rank_Load(object sender, EventArgs e)
        {
            try
            {
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
                    if (myDataReader["Mode"].ToString() == "Classic" && listClassic.Items.Count < 10)
                    {
                        ListViewItem ItemAdd = new ListViewItem(myDataReader["Name"].ToString());
                        ItemAdd.SubItems.Add(myDataReader["Score"].ToString() + "分");
                        ItemAdd.SubItems.Add(myDataReader["PlayTime"].ToString() + "秒");
                        ItemAdd.SubItems.Add(myDataReader["Date"].ToString());
                        listClassic.Items.Add(ItemAdd);
                    }
                    else if (myDataReader["Mode"].ToString() == "Time" && listTime.Items.Count < 10)
                    {
                        ListViewItem ItemAdd = new ListViewItem(myDataReader["Name"].ToString());
                        ItemAdd.SubItems.Add(myDataReader["Score"].ToString() + "分");
                        ItemAdd.SubItems.Add(myDataReader["PlayTime"].ToString() + "秒");
                        ItemAdd.SubItems.Add(myDataReader["Date"].ToString());
                        listTime.Items.Add(ItemAdd);
                    }
                    else if (myDataReader["Mode"].ToString() == "Move" && listMove.Items.Count < 10)
                    {
                        ListViewItem ItemAdd = new ListViewItem(myDataReader["Name"].ToString());
                        ItemAdd.SubItems.Add(myDataReader["Score"].ToString() + "分");
                        ItemAdd.SubItems.Add(myDataReader["PlayTime"].ToString() + "秒");
                        ItemAdd.SubItems.Add(myDataReader["Date"].ToString());
                        listMove.Items.Add(ItemAdd);
                    }
                    else if (myDataReader["Mode"].ToString() == "X" && listX.Items.Count < 10)
                    {
                        ListViewItem ItemAdd = new ListViewItem(myDataReader["Name"].ToString());
                        ItemAdd.SubItems.Add(myDataReader["Score"].ToString() + "分");
                        ItemAdd.SubItems.Add(myDataReader["PlayTime"].ToString() + "秒");
                        ItemAdd.SubItems.Add(myDataReader["Date"].ToString());
                        listX.Items.Add(ItemAdd);
                    }
                }
                sqlcon.Close();
            }
            catch (Exception)
            {
                MessageBox.Show("伺服器連結中斷！");
            }
        }
    }
}
