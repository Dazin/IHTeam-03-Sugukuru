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
            String sql = "SELECT `車名` FROM `受注情報` WHERE `受注コード` =" + num + ";";
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
                String sql = "INSERT INTO `車輌代金` (`落札価格`,`買手数料`,`オークション諸経費`,`自税預かり`)VALUES(" + c_table.Rows[i].Cells[0].Value.ToString() + "," + c_table.Rows[i].Cells[1].Value.ToString() + "," + c_table.Rows[i].Cells[2].Value.ToString() + "," + c_table.Rows[i].Cells[3].Value.ToString() + ");";
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
