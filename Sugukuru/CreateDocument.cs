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
using System.Data.SqlClient;

namespace Sugukuru
{
    public partial class CreateDocument : Form
    {

        String ConStr;
        String SQL = "";
        DateTime dtNow = DateTime.Now;
        private string No;
        private string lbText;
        int iList = 0;
        DialogResult Res;
        DialogResult dr;
        double taxmoney = 0;
        String date = "";
        String orderno = "";
        String money = "";
        String suppliers = "";
        String castomerNo = "";
        String OrderNo = "";
        public CreateDocument(string No,string lbText)
        {
            InitializeComponent();
            this.ConStr = ConfigurationManager.AppSettings["DdConKey"];
            this.No = No;
            this.lbText = lbText;
           
        }

        private void CreateDocument_Load(object sender, EventArgs e)
        {
            iList = int.Parse(No);      

            LbYear.Text = dtNow.Year.ToString();     //現在の年を取得
            LbMonth.Text = dtNow.Month.ToString();   //現在の月を取得
            LbDay.Text = dtNow.Day.ToString();       //現在の日を取得
 
            date = LbYear.Text +"-" + LbMonth.Text + "-" + LbDay.Text.ToString();

            if ("納品一覧".Equals(lbText))
            {
                label17.Text = "納品書";
                label1.Text = "";
                label20.Text = LbMonth.Text;
                label21.Text = LbDay.Text;
                label3.Text = "納品No.";
                SQL = "SELECT 車輌情報.受注情報コード AS No,車輌情報.車名 AS 車輌名,車輌代金.落札価格 AS 金額,車輌情報.キズ状態 AS 摘要 FROM 車輌代金 INNER JOIN 車輌情報 ON 車輌代金.車輌コード = 車輌情報.車輌コード WHERE 受注情報コード = " + iList + ";";

                MySqlConnection con = new MySqlConnection(this.ConStr);
                con.Open();
                DataSet dSet = new DataSet("sugukuru");

                MySqlDataAdapter mAdp = new MySqlDataAdapter(SQL, ConStr);

                mAdp.Fill(dSet, "sugukuru");
                dataGridView1.DataSource = dSet.Tables["sugukuru"];
                dataGridView1.Columns[0].HeaderText = "No";
                dataGridView1.Columns[1].HeaderText = "車輌名";
                dataGridView1.Columns[2].HeaderText = "金額";
                dataGridView1.Columns[3].HeaderText = "摘要";

                dataGridView1.RowHeadersVisible = false;
                dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;



                SQL = "SELECT SUM(車輌代金.落札価格) AS 合計金額,車輌情報.仕入先,車輌情報.受注情報コード AS 納品番号 FROM 車輌代金 INNER JOIN 車輌情報 ON 車輌代金.車輌コード = 車輌情報.車輌コード WHERE 車輌情報.受注情報コード = " + iList + ";";
                DataSet dSet1 = new DataSet("sugukuru");
                MySqlDataAdapter mAdp1 = new MySqlDataAdapter(SQL, ConStr);
                mAdp1.Fill(dSet1, "sugukuru");
                money = dSet1.Tables["sugukuru"].Rows[0]["合計金額"].ToString();
                suppliers = dSet1.Tables["sugukuru"].Rows[0]["仕入先"].ToString();
                orderno = dSet1.Tables["sugukuru"].Rows[0]["納品番号"].ToString();
                //*** DB切断
                con.Close();
                double tax = double.Parse(money);
                tax = tax * 0.08;
                taxmoney = double.Parse(money);
                taxmoney = taxmoney + tax;
                label16.Text = taxmoney.ToString();
                label15.Text = tax.ToString();
                textBox1.Text = suppliers;
                label13.Text = orderno;
            }
            else if ("物品受領一覧".Equals(lbText))
            {
                label17.Text = "";
                label3.Text = "";
                label7.Text = "";
                label13.Text = "";
                label9.Text = "";
                label13.Text = "";
                lbText = "";
                SQL = "SELECT 車輌情報.受注情報コード AS No,車輌情報.車名 AS 車輌名,車輌代金.落札価格 AS 金額,車輌情報.キズ状態 AS 摘要 FROM 車輌代金 INNER JOIN 車輌情報 ON 車輌代金.車輌コード = 車輌情報.車輌コード WHERE 受注情報コード = " + iList + ";";
            
                MySqlConnection con = new MySqlConnection(this.ConStr);
                con.Open();
                DataSet dSet = new DataSet("sugukuru");

                MySqlDataAdapter mAdp = new MySqlDataAdapter(SQL, ConStr);

                mAdp.Fill(dSet, "sugukuru");
                dataGridView1.DataSource = dSet.Tables["sugukuru"];
                dataGridView1.Columns[0].HeaderText = "No";
                dataGridView1.Columns[1].HeaderText = "車輌名";
                dataGridView1.Columns[2].HeaderText = "金額";
                dataGridView1.Columns[3].HeaderText = "摘要";

                dataGridView1.RowHeadersVisible = false;
                dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;



                SQL = "SELECT SUM(車輌代金.落札価格) AS 合計金額,車輌情報.仕入先,車輌情報.受注情報コード AS 納品番号 FROM 車輌代金 INNER JOIN 車輌情報 ON 車輌代金.車輌コード = 車輌情報.車輌コード WHERE 車輌情報.受注情報コード = " + iList + ";";
                DataSet dSet1 = new DataSet("sugukuru");
                MySqlDataAdapter mAdp1 = new MySqlDataAdapter(SQL, ConStr);
                mAdp1.Fill(dSet1, "sugukuru");
                money = dSet1.Tables["sugukuru"].Rows[0]["合計金額"].ToString();
                suppliers = dSet1.Tables["sugukuru"].Rows[0]["仕入先"].ToString();
                orderno = dSet1.Tables["sugukuru"].Rows[0]["納品番号"].ToString();
                //*** DB切断
                con.Close();
                double tax = double.Parse(money);
                tax = tax * 0.08;
                taxmoney = double.Parse(money);
                taxmoney = taxmoney + tax;
                label16.Text = taxmoney.ToString();
                label15.Text = tax.ToString();
                textBox1.Text = suppliers;



            }
            else if ("売上伝票".Equals(lbText))
            {
                label1.Text = "";
                label17.Text = "売上伝票";
                label3.Text = "売上No.";
                label7.Text = "売上日     月     日";
                label20.Text = LbMonth.Text;
                label21.Text = LbDay.Text;
                label13.Text = "";
                label9.Text = "";

                SQL = "SELECT 車輌情報.受注情報コード AS No,車輌情報.車名 AS 車輌名,車輌代金.落札価格 AS 金額,車輌情報.キズ状態 AS 摘要 FROM 車輌代金 INNER JOIN 車輌情報 ON 車輌代金.車輌コード = 車輌情報.車輌コード WHERE 受注情報コード = " + iList + ";";
                MySqlConnection con = new MySqlConnection(this.ConStr);
                con.Open();
                DataSet dSet = new DataSet("sugukuru");

                MySqlDataAdapter mAdp = new MySqlDataAdapter(SQL, ConStr);

                mAdp.Fill(dSet, "sugukuru");
                dataGridView1.DataSource = dSet.Tables["sugukuru"];
                dataGridView1.Columns[0].HeaderText = "No";
                dataGridView1.Columns[1].HeaderText = "車輌名";
                dataGridView1.Columns[2].HeaderText = "金額";
                dataGridView1.Columns[3].HeaderText = "摘要";

                dataGridView1.RowHeadersVisible = false;
                dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;



                SQL = "SELECT SUM(車輌代金.落札価格) AS 合計金額,車輌情報.仕入先,車輌情報.受注情報コード AS 納品番号 FROM 車輌代金 INNER JOIN 車輌情報 ON 車輌代金.車輌コード = 車輌情報.車輌コード WHERE 車輌情報.受注情報コード = " + iList + ";";
                DataSet dSet1 = new DataSet("sugukuru");
                MySqlDataAdapter mAdp1 = new MySqlDataAdapter(SQL, ConStr);
                mAdp1.Fill(dSet1, "sugukuru");
                money = dSet1.Tables["sugukuru"].Rows[0]["合計金額"].ToString();
                suppliers = dSet1.Tables["sugukuru"].Rows[0]["仕入先"].ToString();
                orderno = dSet1.Tables["sugukuru"].Rows[0]["納品番号"].ToString();
                //*** DB切断
                con.Close();
                double tax = double.Parse(money);
                tax = tax * 0.08;
                taxmoney = double.Parse(money);
                taxmoney = taxmoney + tax;
                label16.Text = taxmoney.ToString();
                label15.Text = tax.ToString();
                textBox1.Text = suppliers;
            } 
            else if ("出荷一覧".Equals(lbText))
            {
                label1.Text = "";
                label17.Text = "出荷指示書";
                label3.Text = "出荷No.";
                label7.Text = "出荷日     月     日";
                label20.Text = LbMonth.Text;
                label21.Text = LbDay.Text;
                label9.Text = "出荷印";

                SQL = "SELECT 車輌情報.受注情報コード AS No,車輌情報.車名 AS 車輌名,車輌代金.落札価格 AS 金額,車輌情報.キズ状態 AS 摘要 FROM 車輌代金 INNER JOIN 車輌情報 ON 車輌代金.車輌コード = 車輌情報.車輌コード WHERE 受注情報コード = " + iList + ";";
                MySqlConnection con = new MySqlConnection(this.ConStr);
                con.Open();
                DataSet dSet = new DataSet("sugukuru");

                MySqlDataAdapter mAdp = new MySqlDataAdapter(SQL, ConStr);

                mAdp.Fill(dSet, "sugukuru");
                dataGridView1.DataSource = dSet.Tables["sugukuru"];
                dataGridView1.Columns[0].HeaderText = "No";
                dataGridView1.Columns[1].HeaderText = "車輌名";
                dataGridView1.Columns[2].HeaderText = "金額";
                dataGridView1.Columns[3].HeaderText = "摘要";

                dataGridView1.RowHeadersVisible = false;
                dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;



                SQL = "SELECT SUM(車輌代金.落札価格) AS 合計金額,車輌情報.仕入先,車輌情報.受注情報コード AS 納品番号 FROM 車輌代金 INNER JOIN 車輌情報 ON 車輌代金.車輌コード = 車輌情報.車輌コード WHERE 車輌情報.受注情報コード = " + iList + ";";
                DataSet dSet1 = new DataSet("sugukuru");
                MySqlDataAdapter mAdp1 = new MySqlDataAdapter(SQL, ConStr);
                mAdp1.Fill(dSet1, "sugukuru");
                money = dSet1.Tables["sugukuru"].Rows[0]["合計金額"].ToString();
                suppliers = dSet1.Tables["sugukuru"].Rows[0]["仕入先"].ToString();
                orderno = dSet1.Tables["sugukuru"].Rows[0]["納品番号"].ToString();
                //*** DB切断
                con.Close();
                double tax = double.Parse(money);
                tax = tax * 0.08;
                taxmoney = double.Parse(money);
                taxmoney = taxmoney + tax;
                label16.Text = taxmoney.ToString();
                label15.Text = tax.ToString();
                textBox1.Text = suppliers;
                label13.Text = orderno;


            }

            
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void LbMonth_Click(object sender, EventArgs e)
        {

        }

        private void LbDay_Click(object sender, EventArgs e)
        {

        }

        private void LbYear_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridView dgv = (DataGridView)sender;
        }

        private void textBox14_TextChanged(object sender, EventArgs e)
        {

        }

        private void label13_Click(object sender, EventArgs e)
        {

        }
        
        private void button1_Click(object sender, EventArgs e)
        {
            dr = MessageBox.Show("印刷しますか？", "確認", MessageBoxButtons.YesNo);
            
            if ("出荷一覧".Equals(lbText))
            {
                if (dr == DialogResult.Yes)
                {

                    //     SQL = "INSERT INTO sugukuru.売上情報(売上コード, 請求明細コード, 受注コード, 売上金額, 売上日, 会計科目) VALUES('','"+ orderno + "', '"+ orderno + "', '"+ taxmoney +"', '"+ date +"', NULL);";
                    SQL = "INSERT INTO sugukuru.売上情報(売上コード, 請求明細コード, 受注コード, 売上金額, 売上日, 会計科目) VALUES(0, " + orderno + "," + orderno + ", " + taxmoney + ", '" + date + "', NULL);";

                    MySqlConnection con = new MySqlConnection(this.ConStr);
                    con.Open();
                    DataSet dSet2 = new DataSet("sugukuru");
                    MySqlDataAdapter mAdp2 = new MySqlDataAdapter(SQL, ConStr);
                    MySqlCommand insert = new MySqlCommand(SQL, con);

                    insert.ExecuteNonQuery();

                    SQL = "SELECT 受注コード FROM 受注情報 WHERE 受注情報コード = "+ iList +";";
                   
                   

                    DataSet dSet5 = new DataSet("sugukuru");
                    MySqlDataAdapter mAdp5 = new MySqlDataAdapter(SQL, ConStr);
                    mAdp5.Fill(dSet5, "sugukuru");
                    OrderNo = dSet5.Tables["sugukuru"].Rows[0]["受注コード"].ToString();
                    

                    SQL = "SELECT 顧客情報.顧客コード FROM 受注 INNER JOIN 顧客情報 ON 受注.顧客コード = 顧客情報.顧客コード WHERE 受注コード = "+ OrderNo +";";
 
                    DataSet dSet3 = new DataSet("sugukuru");
                    MySqlDataAdapter mAdp3 = new MySqlDataAdapter(SQL, ConStr);
                    mAdp3.Fill(dSet3, "sugukuru");
                    castomerNo = dSet3.Tables["sugukuru"].Rows[0]["顧客コード"].ToString();




                    SQL = "UPDATE `sugukuru`.`顧客情報` SET `売掛金` = 売掛金 + "+ taxmoney +" WHERE `顧客情報`.`顧客コード` = "+ castomerNo +";";
       
                    DataSet dSet4 = new DataSet("sugukuru");
                    MySqlDataAdapter mAdp4 = new MySqlDataAdapter(SQL, ConStr);
                    MySqlCommand insert2 = new MySqlCommand(SQL, con);

                    insert2.ExecuteNonQuery();

                    //*** DB切断
                    con.Close();
                    String msg = "完了しました。";
                    MessageBox.Show(msg);
                }
            }
            
            

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }
    }
}
