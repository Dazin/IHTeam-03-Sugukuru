using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using MySql.Data.MySqlClient;
namespace Sugukuru
{
    class IsedaDBSeikyu
    {

        private String StrKey;

        public DataSet Select_List()
        {
            this.StrKey = ConfigurationManager.AppSettings["DdConKey"];
            DateTime dt = DateTime.Now;
            DataSet dset = new DataSet("Seikyu");
            MySqlConnection con = new MySqlConnection(this.StrKey);

            String sql = "SELECT c.顧客コード,顧客名,売掛金 AS 合計金額,(c.与信限度額 - 売掛金) 残与信 " +
                         "FROM 売上情報 a " +
                         "INNER JOIN 受注 b ON a.受注コード = b.受注コード " +
                         "INNER JOIN 顧客情報 c ON b.顧客コード = c.顧客コード " +
                         "WHERE DATE_FORMAT(売上日,'%Y%m') = '"+dt.Year+dt.Month+"'"+
                         "GROUP BY 顧客名;";

            con.Open();
            MySqlDataAdapter mAdp = new MySqlDataAdapter(sql, con);
            mAdp.Fill(dset, "Seikyu");
            con.Close();
            return dset;
        }

        public void Seikyu_Insert(String Seikyu_Money,String title,String due_date,String date,String Custemer){
            this.StrKey = ConfigurationManager.AppSettings["DdConKey"];
            DateTime dt = DateTime.Now;
            MySqlConnection con = new MySqlConnection(this.StrKey);
            String sql2 = "INSERT INTO `請求明細`" +
                          "(`請求金額`,`件名`,`支払い期限`,`請求状態`,`請求日`,`顧客コード`)" +
                          "VALUES (" + Seikyu_Money + ",'" + title + "','" + due_date + "',1,'" + date + "','" + Custemer + "')";
            con.Open();
            MySqlCommand cmd2 = new MySqlCommand(sql2, con);
            cmd2.ExecuteNonQuery();
            con.Close();


        }

    }

    }

