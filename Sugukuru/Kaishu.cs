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
    public partial class Kaishu : Form
    {
        String conStr;
        Boolean flag = false;
        public Kaishu()
        {
            InitializeComponent();
            this.conStr = ConfigurationManager.AppSettings["DdConKey"];
        }

        private void Kaishu_Load(object sender, EventArgs e)
        {
            dataGridView1.Columns.Add("kCode", "顧客コード");
            dataGridView1.Columns.Add("kName", "顧客名");
            dataGridView1.Columns.Add("kTel", "電話番号");
            dataGridView1.Columns.Add("seikyu", "請求金額");
            dataGridView1.Columns[3].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dataGridView1.Columns.Add("nyukin", "入金日");
            dataGridView1.Columns.Add("nyukinGaku", "入金額");
            dataGridView1.Columns[5].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dataGridView1.Columns.Add("mikaishu", "未回収金額");
            dataGridView1.Columns[6].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dataGridView1.Columns.Add("status", "状態");
//            dataGridView1.Rows.Add("10001", "太郎", "080-XXXX-XXXX",  "100,000", "30年11月27日", "20,000", "80,000", "未回収");
        }




        private void btLoadSeikyu_Click(object sender, EventArgs e)
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
            String sql = "SELECT k.顧客コード, k.顧客名, k.電話番号, s.請求金額 FROM 請求明細 s, 受注 j, 顧客情報 k "
                +"WHERE s.受注コード = j.受注コード AND j.顧客コード = k.顧客コード"
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
                String kCode = data.Rows[0]["顧客コード"].ToString();
                String kName = data.Rows[0]["顧客名"].ToString();
                String kTel = data.Rows[0]["電話番号"].ToString();
                String sPrice = String.Format("{0:#,0}", data.Rows[0]["請求金額"]);
                String nyukinDate = "30年11月27日";//入金があったらここに格納する。
                String nyukinGaku = "3,100,000"; //入金学をここに入れる。
                String mikaishu = "不明";
                String status = "未回収";
                Decimal num1 = 0;
                Decimal num2 = 0;
                Decimal num3 = 0;
                if (Decimal.TryParse(sPrice, out num1) == true && Decimal.TryParse(nyukinGaku, out num2) == true)
                { 
                     num3 = num1 - num2;
                    mikaishu = String.Format("{0:#,0}", num3);
                    if(num3 <0) {
                        status = "過入金";
                    }
                }
                dataGridView1.Rows.Add(kCode, kName, kTel, sPrice, nyukinDate , nyukinGaku, mikaishu, status);
            }
        }


        private void btLoadZengin_Click(object sender, EventArgs e)
        {
            //OpenFileDialogクラスのインスタンスを作成
            OpenFileDialog ofd = new OpenFileDialog();

            //はじめのファイル名を指定する
            //はじめに「ファイル名」で表示される文字列を指定する
            //            ofd.FileName = "default.html";
            ofd.FileName = "入金インポートサンプル.txt";
            //はじめに表示されるフォルダを指定する
            //指定しない（空の文字列）の時は、現在のディレクトリが表示される
            ofd.InitialDirectory = @"C:\";
            //[ファイルの種類]に表示される選択肢を指定する
            //指定しないとすべてのファイルが表示される
            ofd.Filter = "HTMLファイル(*.html;*.htm)|*.html;*.htm|すべてのファイル(*.*)|*.*";
            //[ファイルの種類]ではじめに選択されるものを指定する
            //2番目の「すべてのファイル」が選択されているようにする
            ofd.FilterIndex = 2;
            //タイトルを設定する
            ofd.Title = "開くファイルを選択してください";
            //ダイアログボックスを閉じる前に現在のディレクトリを復元するようにする
            ofd.RestoreDirectory = true;
            //存在しないファイルの名前が指定されたとき警告を表示する
            //デフォルトでTrueなので指定する必要はない
            ofd.CheckFileExists = true;
            //存在しないパスが指定されたとき警告を表示する
            //デフォルトでTrueなので指定する必要はない
            ofd.CheckPathExists = true;

            //ダイアログを表示する
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                //OKボタンがクリックされたとき、選択されたファイル名を表示する
                Console.WriteLine(ofd.FileName); //ファイル名出力


                //OKボタンがクリックされたとき、選択されたファイルを読み取り専用で開く
                System.IO.Stream stream;
                stream = ofd.OpenFile();
                if (stream != null)
                {
                    //内容を読み込み、表示する
                    System.IO.StreamReader sr =
                        new System.IO.StreamReader(stream
                        , System.Text.Encoding.GetEncoding("shift_jis") //文字コード指定して読み込み
                        );
                    //                    Console.WriteLine(sr.ReadToEnd()); //全件一括表示

                    int iDataType = 0;
                    StringBuilder strOutput = new StringBuilder();


                    //テーブルの中身を空にする。
                    MySqlConnection con = new MySqlConnection(this.conStr);
                    // コマンドを作成
                    MySqlCommand cmd = new MySqlCommand("TRUNCATE TABLE 全銀", con);
                    // オープン
                    cmd.Connection.Open();
                    // 実行
                    cmd.ExecuteNonQuery();
                    // クローズ
                    cmd.Connection.Close();
                    //テーブルの中身を空にする。 ここまで

                    while (sr.EndOfStream == false) //一行ずつ読み込む
                    {
                        string line = sr.ReadLine();
                        Console.WriteLine(line);

                        String strInsert = "insert into 全銀 (`データ区分`, `照会番号`, `勘定日`, `起算日`, `金額`, `うち他店券金額`, `振込依頼人コード`, `振込依頼人名`, `仕向銀行名`, `仕向支店名`, `取消区分`, `EDI情報`, `ダミー`) values ("; //インサート文の一部
                        String strInsertCheck = strInsert; //チェック用
                        if (int.TryParse(line.Substring(0, 1), out iDataType))
                        {
                            switch (iDataType)
                            {
                                case 2:                                    //データレコード
                                    int[] fWidth = new int[] { 1, 6, 6, 6, 10, 10, 10, 48, 15, 15, 1, 20, 52 };
                                    String[] sWidth = new String[] { "データ区分", "照会番号", "勘定日", "起算日", "金額", "うち他店券金額", "振込依頼人コード", "振込依頼人名", "仕向銀行名", "仕向支店名", "取消区分", "EDI情報", "ダミー" };
                                    int i = 0;//データ種類名取り出し用
                                    int linenum = 0;//値取り出し用
                                    foreach (int val in fWidth)
                                    {
                                        Console.WriteLine(sWidth[i].ToString() + ":" + line.Substring(linenum, val));
                                        //(sWidth[i].ToString() データ種類
                                        //line.Substring(linenum, val)); データ
                                        if (strInsert != strInsertCheck) { strInsert += ','; }//初回以外カンマを入れる。
                                        strInsert += '"' + line.Substring(linenum, val) + '"';
                                        linenum += val; //現在位置をプラスする。
                                        ++i;
                                    }
                                    strInsert += ")";
                                    Console.WriteLine(strInsert);

                                    con = new MySqlConnection(this.conStr);
                                    // コマンドを作成
                                    cmd = new MySqlCommand(strInsert, con);
                                    // オープン
                                    cmd.Connection.Open();
                                    // 実行
                                    cmd.ExecuteNonQuery();
                                    // クローズ
                                    cmd.Connection.Close();

                                    //インサート終了後、flagをtrueにする。
                                    flag = true;

                                    break;
                                default:
                                    break;
                            }
                        }
                    }
                    sr.Close();
                    stream.Close();
                }

            }

        }
    }
}
