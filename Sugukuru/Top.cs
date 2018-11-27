using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Sugukuru
{
    public partial class Top : Form
    {
        public Top()
        {
            InitializeComponent();
        }

        private void btMitsumori_Click(object sender, EventArgs e)
        {
            this.Hide();//自分自身を非表示にする
            Form form = new Sugukuru.Form6();
            form.ShowDialog();
            form.Dispose();//閉じられたらリソース開放
            this.Show();//自分自身を再表示する
        }

        private void btUkesho_Click(object sender, EventArgs e)
        {
            this.Hide();//自分自身を非表示にする
            Form form = new Sugukuru.Ukesho();
            form.ShowDialog();
            form.Dispose();//閉じられたらリソース開放
            this.Show();//自分自身を再表示する
        }

        private void btKaishu_Click(object sender, EventArgs e)
        {
            this.Hide();//自分自身を非表示にする
            Form form = new Sugukuru.Kaishu();
            form.ShowDialog();
            form.Dispose();//閉じられたらリソース開放
            this.Show();//自分自身を再表示する
        }

        private void btSeikyuKobetsu_Click(object sender, EventArgs e)
        {
            this.Hide();//自分自身を非表示にする
            Form form = new Sugukuru.Seikyu_kobetu();
            form.ShowDialog();
            form.Dispose();//閉じられたらリソース開放
            this.Show();//自分自身を再表示する
        }

        private void btSeikyusho_Click(object sender, EventArgs e)
        {
            this.Hide();//自分自身を非表示にする
            Form form = new Sugukuru.Seikyusho();
            form.ShowDialog();
            form.Dispose();//閉じられたらリソース開放
            this.Show();//自分自身を再表示する
        }

        private void btSeikyu_Click(object sender, EventArgs e)
        {
            this.Hide();//自分自身を非表示にする
            Form form = new Sugukuru.Seikyu();
            form.ShowDialog();
            form.Dispose();//閉じられたらリソース開放
            this.Show();//自分自身を再表示する
        }

        private void btJuchu_Click(object sender, EventArgs e)
        {
            this.Hide();//自分自身を非表示にする
            Form form = new Sugukuru.Juchu();
            form.ShowDialog();
            form.Dispose();//閉じられたらリソース開放
            this.Show();//自分自身を再表示する
        }

        private void btCreateDocument_Click(object sender, EventArgs e)
        {
            this.Hide();//自分自身を非表示にする
            Form form = new Sugukuru.Form1();
            form.ShowDialog();
            form.Dispose();//閉じられたらリソース開放
            this.Show();//自分自身を再表示する
        }

        private void btShiire_Click(object sender, EventArgs e)
        {
            this.Hide();//自分自身を非表示にする
            Form form = new Sugukuru.siire();
            form.ShowDialog();
            form.Dispose();//閉じられたらリソース開放
            this.Show();//自分自身を再表示する
        }

        private void Top_Load(object sender, EventArgs e)
        {

        }

        private void Top_Load_1(object sender, EventArgs e)
        {

        }

        private void btUkeshoSelect_Click(object sender, EventArgs e)
        {
            this.Hide();//自分自身を非表示にする
            Form form = new Sugukuru.UkeshoSelect();
            form.ShowDialog();
            form.Dispose();//閉じられたらリソース開放
            this.Show();//自分自身を再表示する
        }
    }
}
