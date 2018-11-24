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
        public Kaishu()
        {
            InitializeComponent();
            this.conStr = ConfigurationManager.AppSettings["DdConKey"];
        }

        private void Kaishu_Load(object sender, EventArgs e)
        {

            dataGridView1.Rows.Add("10001", "太郎", "080-XXXX-XXXX", "100,000", "100,000", "30年11月27日", "20,000", "80,000", "未回収");
        }



        private void btOpen_Click(object sender, EventArgs e)
        {
            //OpenFileDialogクラスのインスタンスを作成
            OpenFileDialog ofd = new OpenFileDialog();

            //はじめのファイル名を指定する
            //はじめに「ファイル名」で表示される文字列を指定する
//            ofd.FileName = "default.html";
            ofd.FileName = "";
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
                        ,System.Text.Encoding.GetEncoding("shift_jis") //文字コード指定して読み込み
                        );
                    //                    Console.WriteLine(sr.ReadToEnd()); //全件一括表示

                    int iDataType = 0;
                    StringBuilder strOutput = new StringBuilder();
                    while (sr.EndOfStream == false) //一行ずつ読み込む
                    {
                        string line = sr.ReadLine();
                        Console.WriteLine(line);

                        if (int.TryParse(line.Substring(0, 1), out iDataType))
                        {
                            switch (iDataType)
                            {
                                case 2:                                    //データレコード
                                    int[] fWidth = new int[] { 1, 6, 6, 6, 10, 10, 10, 48, 15, 15, 1, 20, 52 };
                                    String[] sWidth = new String[] { "データ区分", "照会番号", "勘定日", "起算日", "金額", "うち他店券金額", "振込依頼人コード", "振込依頼人名", "仕向銀行名", "仕向支店名", "取消区分", "EDI情報", "ダミー" };
                                    int i = 0;
                                    int linenum = 0;
                            foreach (int val in fWidth)
                                    {
                                    Console.WriteLine(sWidth[i].ToString() + ":" + line.Substring(linenum, val));
                                        linenum += val; //現在位置をプラスする。
                                        ++i;
                                    }
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

        private void button2_Click(object sender, EventArgs e)
        {
            //抽出データ格納データセット作成
            DataSet dSet = new DataSet("data");
            // DB接続オブジェクト作成
            MySqlConnection con = new MySqlConnection(this.conStr);
            //DB接続
            con.Open();
            //SQL作成
            String sql = "SELECT * FROM 顧客情報";
            //SQL文と接続情報を指定し、データアダプタ作成
            MySqlDataAdapter mAdp = new MySqlDataAdapter(sql, con);
            //抽出データをデータセットへ取得
            mAdp.Fill(dSet, "data");
            //DB切断
            con.Close();
            //抽出件数チェック
            int ResCnt = dSet.Tables["data"].Rows.Count;
            if (ResCnt != 0)
            {
                DataTable data = dSet.Tables["data"];
               String kCode = data.Rows[0]["顧客コード"].ToString();
    //            TxZip.Text = data.Rows[0]["zip"].ToString();
  //              TxAddr.Text = data.Rows[0]["addr"].ToString();
                dataGridView1.Rows.Add(kCode, "太郎", "080-XXXX-XXXX", "100,000", "100,000", "30年11月27日", "20,000", "80,000", "未回収");
            }
        }
    }
}
