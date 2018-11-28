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
    public partial class MitsumoriSelect : Form
    {
        private string Constr;
        string name;
        string date;

        public MitsumoriSelect()
        {
            InitializeComponent();
            this.Constr = ConfigurationManager.AppSettings["Ddconkey"];
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Mitsumori a = new Mitsumori(name,date);
            this.Hide();
            a.ShowDialog();
            a.Dispose();
            this.Show();
        }

        private void MitsumoriSelect_Load(object sender, EventArgs e)
        {
            String sql = "SELECT `顧客名`,`受注日` FROM `受注` inner join `顧客情報` on `受注`.`顧客コード` = `顧客情報`.`顧客コード`;";
            DataSet dset = new DataSet("受注");
            MySqlConnection con = new MySqlConnection(this.Constr);
            con.Open();
            MySqlDataAdapter mAdp = new MySqlDataAdapter(sql, con);
            mAdp.Fill(dset, "受注");
            con.Close();
            Gtable.DataSource=dset.Tables["受注"];


            Gtable.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            Gtable.ReadOnly = true;
        }

        

        private void Gtable_SelectedRows(object sender, DataGridViewCellEventArgs e)
        {
            nameBox.Text = Gtable.CurrentRow.Cells["顧客名"].Value.ToString();
            this.name = nameBox.Text;
            dateBox.Text = Gtable.CurrentRow.Cells["受注日"].Value.ToString();
            this.date = dateBox.Text;
        }
        
    }
}
