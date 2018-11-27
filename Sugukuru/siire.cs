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
    public partial class siire : Form
    {
        
        private string Constr;
        string name;
        string date;
        string num;
        int cnt;
        string date2;
        int num2;


        public siire()
        {
            InitializeComponent();
            this.Constr = ConfigurationManager.AppSettings["Ddconkey"];
        }

        private void siire_Load(object sender, EventArgs e)
        {
            String sql = "SELECT `顧客名`,`受注日` FROM `受注` inner join `顧客情報` on `受注`.`顧客コード` = `顧客情報`.`顧客コード`;";
            DataSet dset = new DataSet("受注");
            MySqlConnection con = new MySqlConnection(this.Constr);
            con.Open();
            MySqlDataAdapter mAdp = new MySqlDataAdapter(sql, con);
            mAdp.Fill(dset, "受注");
            con.Close();
            k_table.DataSource = dset.Tables["受注"];


            k_table.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            k_table.ReadOnly = true;

            DateTime dtNow = DateTime.Now;
            date2 = dtNow.Year.ToString() + "-" + dtNow.Month.ToString() + "-" + dtNow.Day.ToString(); 

        }

        

        private void button1_Click(object sender, EventArgs e)
        {
            String sql2 = "SELECT `受注コード` FROM `受注` inner join `顧客情報` on `受注`.`顧客コード` = `顧客情報`.`顧客コード` WHERE `顧客名`='" + name + "' AND `受注日`='" + date + "';";
            DataSet dset2 = new DataSet("受注");
            MySqlConnection con = new MySqlConnection(this.Constr);
            con.Open();
            MySqlDataAdapter mAdp2 = new MySqlDataAdapter(sql2, con);
            mAdp2.Fill(dset2, "受注");
            c_table.DataSource = dset2.Tables["受注"];
            this.num = c_table.CurrentRow.Cells["受注コード"].Value.ToString();
            String sql = "SELECT `車名`,`型式`,`グレード`,`年式`,`外装色`,`内装色`,`走行距離`,`変速システム`,`排気量`,`燃料`,`キズ状態`,`受注情報コード` FROM `受注情報` WHERE `受注コード` =" + num + ";";
            DataSet dset = new DataSet("受注情報");
            MySqlDataAdapter mAdp = new MySqlDataAdapter(sql, con);
            mAdp.Fill(dset, "受注情報");
            con.Close();
            this.cnt = dset.Tables["受注情報"].Rows.Count;

            c_table.DataSource = dset.Tables["受注情報"];
        }

        private void k_table_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            nameBox.Text = k_table.CurrentRow.Cells["顧客名"].Value.ToString();
            this.name = nameBox.Text;
            dateBox.Text = k_table.CurrentRow.Cells["受注日"].Value.ToString();
            this.date = dateBox.Text;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            MySqlConnection con = new MySqlConnection(this.Constr);
            con.Open();
            for (int i = 0; i < cnt; i++)
            {
                String sql = "INSERT INTO sugukuru.車輌情報 (車輌コード, 受注情報コード, 出品番号, 車名, 型式, グレード, 年式, 外装色, 内装色, 走行距離, 変速システム, 名義変更期限, 車輌画像, 排気量, 燃料, キズ状態, 委託金, 出品者都合落札取消フラグ, ナンバー有りフラグ, 移転登録フラグ, 抹消登録フラグ, 仕入れ日, 仕入先) VALUES ('0', '" + c_table.Rows[i].Cells[16].Value.ToString() + "', '0', '" + c_table.Rows[i].Cells[5].Value.ToString() + "', '" + c_table.Rows[i].Cells[6].Value.ToString() + "', '" + c_table.Rows[i].Cells[7].Value.ToString() + "', '" + c_table.Rows[i].Cells[8].Value.ToString() + "', '0', '" + c_table.Rows[i].Cells[10].Value.ToString() + "', '" + c_table.Rows[i].Cells[11].Value.ToString() + "', '0', '0', '" + c_table.Rows[i].Cells[12].Value.ToString() + "', '" + c_table.Rows[i].Cells[13].Value.ToString() + "', '" + c_table.Rows[i].Cells[14].Value.ToString() + "', '0', '0', '0', '0', '0', '0', '" + date2 + "', '" + c_table.Rows[i].Cells[4].Value.ToString() + "');";
                Console.WriteLine(sql);
                MySqlCommand cmd = new MySqlCommand(sql, con);
                cmd.ExecuteNonQuery();
            }
            String sql2 = "SELECT MAX(`車輌コード`) as a FROM sugukuru.車輌情報;";
            DataSet dset2 = new DataSet("車輌情報");
            MySqlDataAdapter mAdp2 = new MySqlDataAdapter(sql2, con);
            mAdp2.Fill(dset2, "車輌情報");
            String a = dset2.Tables["車輌情報"].Rows[0]["a"].ToString();
            this.num2 = Convert.ToInt32(dset2.Tables["車輌情報"].Rows[0]["a"]);
            for (int i = 0; i < cnt; i++)
            {
                String sql = "INSERT INTO `車輌代金` (`車輌コード`,`落札価格`,`買手数料`,`オークション諸経費`,`自税預かり`)VALUES("+ (this.num2 - cnt + (i + 1)).ToString() +"," + c_table.Rows[i].Cells[0].Value.ToString() + "," + c_table.Rows[i].Cells[1].Value.ToString() + "," + c_table.Rows[i].Cells[2].Value.ToString() + "," + c_table.Rows[i].Cells[3].Value.ToString() + ");";
                Console.WriteLine(sql);
                MySqlCommand cmd = new MySqlCommand(sql, con);
                cmd.ExecuteNonQuery();
            }
            con.Close();
            this.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
        }


        
    }
}
