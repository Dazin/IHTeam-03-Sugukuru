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
    public partial class Ukesho : Form
    {
        String conStr;
        String juchuCode = "1";
        public Ukesho(String jCode)
        {
            InitializeComponent();
            this.conStr = ConfigurationManager.AppSettings["DdConKey"];
            this.juchuCode = jCode;
        }
        public Ukesho()
        {
            InitializeComponent();
        }

        private void Ukesho_Load(object sender, EventArgs e)
        {
//            String[] sWidth = new String[] { "車名", "型式", "グレード", "年式", "外装色", "内装色", "走行距離", "変速システム", "排気量", "燃料", "キズ状態", "調達希望予算", "納品先", "車輌代金", "登録手続代行費用", "自動車税", "納期" };
            String[] sWidth = new String[] { "車名", "納品先", "車輌代金", "登録手続代行費用", "自動車税", "納期" };
            int i = 1;
            foreach (String str in sWidth)
            {
                dataGridView1.Columns.Add("car"+i, str);
                ++i;
            }
            //車情報複数DGVに読み込み
            LoadCarsInfo();


                        //受注情報を取得しセット。



            //抽出データ格納データセット作成
            DataSet dSet = new DataSet("data");
            // DB接続オブジェクト作成
            MySqlConnection con = new MySqlConnection(this.conStr);
            //DB接続
            con.Open();
            //SQL作成
            String sql = "SELECT k.顧客コード, k.顧客名, k.電話番号, k.入金方法, j.受注日, j.合計車輌代金, 合計登録手続代行費用, 合計車輌代金 + 合計登録手続代行費用 + 合計自動車税 AS 合計金額 FROM 受注 j, 顧客情報 k "
                + "WHERE j.顧客コード = k.顧客コード AND j.受注コード = " + this.juchuCode + ";"
                ;
            //SQL文と接続情報を指定し、データアダプタ作成
            MySqlDataAdapter mAdp = new MySqlDataAdapter(sql, con);
            //抽出データをデータセットへ取得
            mAdp.Fill(dSet, "data");
            //DB切断
            con.Close();
            //抽出件数チェック
            DataTable data = dSet.Tables["data"];
            int ResCnt = data.Rows.Count;
            if (ResCnt != 0)
            {
                lbClient.Text = data.Rows[0]["顧客名"].ToString() + "御中";
//                lbPrice.Text = String.Format("{0:#,0}", data.Rows[0]["合計金額"]) + "円";
//                lbPrice2.Text = lbPrice.Text;
                //                lbCarPrice2.Text = String.Format("{0:#,0}", data.Rows[0]["合計車輌代金"]) + "円";
//                lbCharges.Text = String.Format("{0:#,0}", data.Rows[0]["合計登録手続代行費用"]) + "円";
                lbWay.Text = data.Rows[0]["入金方法"].ToString();
                lbDateOrder.Text = DateTime.Parse(data.Rows[0]["受注日"].ToString()).ToString("yyyy年MM月dd日");

            }



            lbDateIssue.Text = DateTime.Today.ToString("yyyy年MM月dd日");

            lbStaff.Text = "担当:"+"竹久";
            lbMail.Text = "mail:sugukuru@hal.com";

        }


        private void LoadCarsInfo()
        {
            // DGVの行を空にする。
            dataGridView1.Rows.Clear();

            //抽出データ格納データセット作成
            DataSet dSet = new DataSet("data");
            // DB接続オブジェクト作成
            MySqlConnection con = new MySqlConnection(this.conStr);
            //DB接続
            con.Open();
            //SQL作成
            String sql = "SELECT 車名,納品先,車輌代金,登録手続代行費用,自動車税,納期 FROM 受注情報 WHERE 受注コード = " + this.juchuCode +";"
                ;
            //SQL文と接続情報を指定し、データアダプタ作成
            MySqlDataAdapter mAdp = new MySqlDataAdapter(sql, con);
            //抽出データをデータセットへ取得
            mAdp.Fill(dSet, "data");
            //DB切断
            con.Close();
            //抽出件数チェック
            DataTable data = dSet.Tables["data"];
            int ResCnt = data.Rows.Count;

            int totalCarPrice = 0;
            int totalCharge = 0;
            int totalPrice = 0;

            for (int i = 0; i < ResCnt; i++){
                //                String[] sWidth = new String[] { "車名", "納品先", "車輌代金", "登録手続代行費用", "自動車税", "納期" };
                String carName = data.Rows[i]["車名"].ToString();
                String s2 = data.Rows[i]["納品先"].ToString();
                String s3 = data.Rows[i]["車輌代金"].ToString();
                totalCarPrice += int.Parse(data.Rows[i]["車輌代金"].ToString());
                totalCharge += int.Parse(data.Rows[i]["登録手続代行費用"].ToString()) + int.Parse(data.Rows[i]["自動車税"].ToString());
                String s4 = data.Rows[i]["登録手続代行費用"].ToString();
                String s5 = data.Rows[i]["自動車税"].ToString();
                String s6 = data.Rows[i]["納期"].ToString();
                dataGridView1.Rows.Add(carName,s2,s3,s4,s5,s6);
            }
            lbCarPrice2.Text = String.Format("{0:#,0}", totalCarPrice) + "円";
            lbCharges.Text = String.Format("{0:#,0}", totalCharge) + "円";
            lbPrice.Text = String.Format("{0:#,0}", totalCarPrice + totalCharge) + "円";
            lbPrice2.Text = lbPrice.Text;


        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
