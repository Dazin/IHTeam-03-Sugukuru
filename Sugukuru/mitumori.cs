using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Configuration;
using MySql.Data.MySqlClient;

namespace Sugukuru
{
    public partial class mitumori : Form
    {
        private string Constr;
        string name;
        string date;
        string num;
        int cnt;

        public mitumori(string name,string date)
        {
            InitializeComponent();
            this.Constr = ConfigurationManager.AppSettings["Ddconkey"];
            this.name = name;
            this.date = date;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            namelb.Text = this.name + "様";
            String sql2 = "SELECT `受注コード` FROM `受注` inner join `顧客情報` on `受注`.`顧客コード` = `顧客情報`.`顧客コード` WHERE `顧客名`='" + name + "' AND `受注日`='"+date+"';";
            DataSet dset2 = new DataSet("受注");
            MySqlConnection con = new MySqlConnection(this.Constr);
            con.Open();
            MySqlDataAdapter mAdp2 = new MySqlDataAdapter(sql2, con);
            mAdp2.Fill(dset2, "受注");
            Gtable.DataSource = dset2.Tables["受注"];
            this.num = Gtable.CurrentRow.Cells["受注コード"].Value.ToString();
            String sql = "SELECT `車名`,`型式`,`車輌代金`,`自動車税`,`登録手続代行費用`,`グレード`,`年式`,`外装色`,`走行距離`,`変速システム`,`排気量`,`キズ状態` FROM `受注情報` WHERE `受注コード` =" + num + ";";
            DataSet dset = new DataSet("受注情報");
            MySqlDataAdapter mAdp = new MySqlDataAdapter(sql, con);
            mAdp.Fill(dset, "受注情報");
            con.Close();
            this.cnt = dset2.Tables["受注"].Rows.Count;
            Gtable.DataSource = dset.Tables["受注情報"];
        }

        private void button2_Click(object sender, EventArgs e)
        {
            MySqlConnection con = new MySqlConnection(this.Constr);
            con.Open();
            for(int i=0;i<cnt;i++){
                String sql = "UPDATE `受注情報` SET `車輌代金` = " + Gtable.Rows[i].Cells[2].Value.ToString() + ",`自動車税` = " + Gtable.Rows[i].Cells[3].Value.ToString() + ",`登録手続代行費用` = " + Gtable.Rows[i].Cells[4].Value.ToString() + " WHERE `受注コード` = " + this.num + ";";
                Console.WriteLine(sql);
                MySqlCommand cmd = new MySqlCommand(sql, con);
                cmd.ExecuteNonQuery();
            }
            String sql2 = "UPDATE `受注` SET `合計車輌代金` = " + kurumatb.Text.ToString() + ",`合計自動車税` = " + zeitb.Text.ToString() + ",`合計登録手続代行費用` = " + syohitb.Text.ToString() + " WHERE `受注コード` = " + this.num + ";";
            Console.WriteLine(sql2);
            MySqlCommand cmd2 = new MySqlCommand(sql2, con);
            cmd2.ExecuteNonQuery();
            con.Close();
            this.Close();
        }

    }
}
