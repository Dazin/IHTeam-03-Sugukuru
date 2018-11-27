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

    public partial class UkeshoSelect : Form
    {
        String conStr;

        public UkeshoSelect()
        {
            InitializeComponent();
            this.conStr = ConfigurationManager.AppSettings["DdConKey"];
        }
        private void LoadTable()
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
            String sql = "SELECT k.顧客コード, k.顧客名, j.受注コード, j.件名 FROM 受注 j, 顧客情報 k WHERE j.顧客コード = k.顧客コード;"
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
            for (int i = 0; i < ResCnt; i++)
            //                if (ResCnt != 0)
            {
                String jCode = data.Rows[i]["受注コード"].ToString();
                String kCode = data.Rows[i]["顧客コード"].ToString();
                String kName = data.Rows[i]["顧客名"].ToString();
                String jKenmei = data.Rows[i]["件名"].ToString();
                dataGridView1.Rows.Add(jCode, kCode, kName, jKenmei);
            }
        }

        private void initProc(object sender, EventArgs e)
        {
            String[] sWidth = new String[] { "受注コード", "顧客コード", "顧客名", "件名" };
            int i = 1;
            foreach (String str in sWidth)
            {
                dataGridView1.Columns.Add("car" + i, str);
                ++i;
            }
            LoadTable();


            DataGridViewButtonColumn dgvButton = new DataGridViewButtonColumn();
            dgvButton.Name = "選択ボタン";
            dgvButton.HeaderText = "選択ボタン";
            dgvButton.Text = "選択";
            dgvButton.UseColumnTextForButtonValue = true;

            dataGridView1.Columns.Add(dgvButton);
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 4)
            {
                //MessageBox.Show("チェック完了");
                //                MessageBox.Show(e.RowIndex.ToString());
                String juchuCode = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
//                MessageBox.Show(juchuCode);//受注コード表示。
                                                                                          //受注コードをUkeshoに渡す。

                this.Hide();//自分自身を非表示にする
                Form form = new Sugukuru.Ukesho(juchuCode);
                form.ShowDialog();
                form.Dispose();//閉じられたらリソース開放
                this.Show();//自分自身を再表示する

            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
