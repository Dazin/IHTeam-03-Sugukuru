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
    public partial class Form1 : Form
    {
        String ConStr;
        String SQL = "";
        String lbText = "";

        public Form1()
        {
            InitializeComponent();
            this.ConStr = ConfigurationManager.AppSettings["DdConKey"];
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            SQL = "SELECT 車輌情報.受注情報コード,車輌情報.仕入れ日,車輌情報.車名,車輌代金.落札価格 FROM 車輌代金 INNER JOIN 車輌情報 ON 車輌代金.車輌コード = 車輌情報.車輌コード GROUP BY 受注情報コード;";
            if (((RadioButton)sender).Checked)
            {
                lbText = (((RadioButton)sender).Text);
                LbList.Text = lbText;
                MySqlConnection con = new MySqlConnection(this.ConStr);
                con.Open();
                DataSet dSet = new DataSet("sugukuru");
                MySqlDataAdapter mAdp = new MySqlDataAdapter(SQL, ConStr);
                mAdp.Fill(dSet, "sugukuru");
                dataGridView1.DataSource = dSet.Tables["sugukuru"];

                dataGridView1.Columns[0].HeaderText = "納品書作成";
                dataGridView1.Columns[1].HeaderText = "納品番号";
                dataGridView1.Columns[2].HeaderText = "納品日";
                dataGridView1.Columns[3].HeaderText = "車輌名";
                dataGridView1.Columns[4].HeaderText = "金額";

                dataGridView1.RowHeadersVisible = false;
                dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;

                //*** DB切断
                con.Close();
            }


        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

            DataGridView dgv = (DataGridView)sender;
            if (dgv.Columns[e.ColumnIndex].Name == "Button")
            {
                int rowIndex = dataGridView1.CurrentCell.RowIndex;
                String No = (dataGridView1.Rows[rowIndex].Cells[1].Value.ToString());
                MessageBox.Show(No);


                this.Hide();//自分自身を非表示にする
                CreateDocument form = new Sugukuru.CreateDocument(No, lbText);
                form.ShowDialog();
                form.Dispose();//閉じられたらリソース開放
                this.Show();//自分自身を再表示する
            }
        }

        private void ReceiptList_CheckedChanged(object sender, EventArgs e)
        {
            SQL = "SELECT 車輌情報.受注情報コード,車輌情報.仕入れ日,車輌情報.車名,車輌代金.落札価格 FROM 車輌代金 INNER JOIN 車輌情報 ON 車輌代金.車輌コード = 車輌情報.車輌コード GROUP BY 受注情報コード;";
            if (((RadioButton)sender).Checked)
            {
                lbText = (((RadioButton)sender).Text);
                LbList.Text = lbText;
                MySqlConnection con = new MySqlConnection(this.ConStr);
                con.Open();
                DataSet dSet = new DataSet("sugukuru");
                MySqlDataAdapter mAdp = new MySqlDataAdapter(SQL, ConStr);
                mAdp.Fill(dSet, "sugukuru");
                dataGridView1.DataSource = dSet.Tables["sugukuru"];

                dataGridView1.Columns[0].HeaderText = "受領書書作成";
                dataGridView1.Columns[1].HeaderText = "納品番号";
                dataGridView1.Columns[2].HeaderText = "受領日";
                dataGridView1.Columns[3].HeaderText = "車輌名";
                dataGridView1.Columns[4].HeaderText = "金額";

                dataGridView1.RowHeadersVisible = false;
                dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;

                //*** DB切断
                con.Close();
            }

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void ShippingList_CheckedChanged(object sender, EventArgs e)
        {
            SQL = "SELECT 車輌情報.受注情報コード,車輌情報.仕入れ日,車輌情報.車名,車輌代金.落札価格 FROM 車輌代金 INNER JOIN 車輌情報 ON 車輌代金.車輌コード = 車輌情報.車輌コード GROUP BY 受注情報コード;";
            if (((RadioButton)sender).Checked)
            {
                lbText = (((RadioButton)sender).Text);
                LbList.Text = lbText;
                MySqlConnection con = new MySqlConnection(this.ConStr);
                con.Open();
                DataSet dSet = new DataSet("sugukuru");
                MySqlDataAdapter mAdp = new MySqlDataAdapter(SQL, ConStr);
                mAdp.Fill(dSet, "sugukuru");
                dataGridView1.DataSource = dSet.Tables["sugukuru"];

                dataGridView1.Columns[0].HeaderText = "出荷指示書作成";
                dataGridView1.Columns[1].HeaderText = "出荷番号";
                dataGridView1.Columns[2].HeaderText = "出荷日";
                dataGridView1.Columns[3].HeaderText = "車輌名";
                dataGridView1.Columns[4].HeaderText = "金額";

                dataGridView1.RowHeadersVisible = false;
                dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;

                //*** DB切断
                con.Close();
            }
        }

        private void SalesList_CheckedChanged(object sender, EventArgs e)
        {
            SQL = "SELECT 車輌情報.受注情報コード,車輌情報.仕入れ日,車輌情報.車名,車輌代金.落札価格 FROM 車輌代金 INNER JOIN 車輌情報 ON 車輌代金.車輌コード = 車輌情報.車輌コード GROUP BY 受注情報コード;";
            if (((RadioButton)sender).Checked)
            {
                lbText = (((RadioButton)sender).Text);
                LbList.Text = lbText;
                MySqlConnection con = new MySqlConnection(this.ConStr);
                con.Open();
                DataSet dSet = new DataSet("sugukuru");
                MySqlDataAdapter mAdp = new MySqlDataAdapter(SQL, ConStr);
                mAdp.Fill(dSet, "sugukuru");
                dataGridView1.DataSource = dSet.Tables["sugukuru"];

                dataGridView1.Columns[0].HeaderText = "売上伝票作成";
                dataGridView1.Columns[1].HeaderText = "売上番号";
                dataGridView1.Columns[2].HeaderText = "売上日";
                dataGridView1.Columns[3].HeaderText = "車輌名";
                dataGridView1.Columns[4].HeaderText = "金額";

                dataGridView1.RowHeadersVisible = false;
                dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;

                //*** DB切断
                con.Close();
            }
        }
    }
}
