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
        String conStr = "";
        String sql = "";
        public Ukesho()
        {
            InitializeComponent();
            this.conStr = ConfigurationManager.AppSettings["DbConkey"];
        }

        private void Ukesho_Load(object sender, EventArgs e)
        {
            lbClient.Text = "株式会社HAL"+"御中";

            lbPrice.Text = "2,240,000円";
            lbLimit.Text = "2018年12月25日";
            lbWay.Text = "銀行振込";
            lbPlace.Text = "株式会社HAL車庫";

            lbCar.Text = "車名：" + "シルビア";
            lbGrade.Text = "グレード：" + "G";
            lbYear.Text = "年式："+"2002";
            lbColor.Text = "カラー："+"ホワイト";
            lbDistance.Text = "走行距離：" + "8万km";
            lbSystem.Text = "変速システム："+"オートマ";

            lbCarPrice.Text = "2,000,000円";
            lbComission.Text = "200,000円";
            lbTax.Text = "40,000円";

            lbCarPrice2.Text = "2,000,000円";
            lbCharges.Text = "240,000円";
            lbPrice2.Text = "2,240,000円";

            lbDateIssue.Text = "2018年11月05日";
            lbDateOrder.Text = "2018年11月01日";

            lbStaff.Text = "担当:"+"鈴木";
            lbMail.Text = "mail:Sugukuru@hal.com";

        }
    }
}
