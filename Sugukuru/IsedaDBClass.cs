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
    class IsedaDBClass
    {
        private String StrKey;


        public DataSet Select_Custemer()
        {
            this.StrKey = ConfigurationManager.AppSettings["Ddconkey"];
            DateTime dt = DateTime.Now;
            DataSet dset = new DataSet("Custemer");
            MySqlConnection con = new MySqlConnection(this.StrKey);
            String sql = "SELECT `顧客コード`,`顧客名` FROM `顧客情報`;";

            con.Open();
            MySqlDataAdapter mAdp = new MySqlDataAdapter(sql, con);
            mAdp.Fill(dset, "Custemer");
            con.Close();
            return dset;

        }

        public String Juchu_Select()
        {
            DataSet dset = new DataSet("SugukuruJuchu");
            this.StrKey = ConfigurationManager.AppSettings["Ddconkey"];
            DateTime dt = DateTime.Now;
            MySqlConnection con = new MySqlConnection(this.StrKey);
            String Selectsql = "SELECT MAX(`受注コード`)  + 1 as Code FROM `受注`";

            con.Open();
            MySqlDataAdapter mAdp = new MySqlDataAdapter(Selectsql, con);
            mAdp.Fill(dset, "SugukuruJuchu");
            con.Close();
            return dset.Tables["SugukuruJuchu"].Rows[0]["Code"].ToString();
        }

        public void Juchu_Insert2(String Custemer)
        {

            DataSet dset = new DataSet("SugukuruJuchu");
            this.StrKey = ConfigurationManager.AppSettings["Ddconkey"];
            DateTime dt = DateTime.Now;
            MySqlConnection con = new MySqlConnection(this.StrKey);

            String sql = "INSERT INTO `受注`" +
                         "(`顧客コード`,`受注日`)" +
                         "VALUES (" + Custemer + ",'" + dt.ToString("yyyy/MM/dd") + "');";
            con.Open();
            MySqlCommand cmd = new MySqlCommand(sql, con);
            cmd.ExecuteNonQuery();
            con.Close();
        }


        public void Juchu_Insert(String SelectNo,String Custemer,String CarName,String CarGrade,String CarModelYear,String CarColor,String CarShiht,String CarDistance,String CarMoney,String CarOtehr,String CarModel,String CarDelivery,int Count)
        {

            this.StrKey = ConfigurationManager.AppSettings["Ddconkey"];
            DateTime dt = DateTime.Now;
            MySqlConnection con = new MySqlConnection(this.StrKey);
            String sql2 = "INSERT INTO `受注情報`" +
                          "(`受注コード`,`車名`,`グレード`,`年式`,`外装色`,`走行距離`,`変速システム`,`調達希望予算`,`キズ状態`,`型式`,`納品先`)"+
                          "VALUES (" + SelectNo + ",'" + CarName + "','" + CarGrade + "','" + CarModelYear + "','" + CarColor + "','" + CarDistance + "','" + CarShiht + "','" + CarMoney + "','" + CarOtehr + "','" + CarModel + "','" + CarDelivery + "')";
                          for(int i = 1; i < Count; i++){
                              sql2 += ",(" + SelectNo + ",'" + CarName + "','" + CarGrade + "','" + CarModelYear + "','" + CarColor + "','" + CarDistance + "','" + CarShiht + "','" + CarMoney + "','" + CarOtehr + "','" + CarModel + "','" + CarDelivery + "')";
                          }
            con.Open();
            MySqlCommand cmd2 = new MySqlCommand(sql2, con);
            cmd2.ExecuteNonQuery();
            con.Close();
        }


    }
}
