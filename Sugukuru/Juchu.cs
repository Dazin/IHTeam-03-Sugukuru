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
    public partial class Juchu : Form
    {
        public String JuchuCode = "";
        public String JuchuShift = "";
        public int Count = 0;
        public Boolean Custemerflg = true;



        public Juchu()
        {
            InitializeComponent();
            IsedaDBClass db = new IsedaDBClass();
            JuchuCode = db.Juchu_Select();
            if (JuchuCode == "0" || JuchuCode == null)
            {
                JuchuCode = "1";
            }
            comboBox4.DataSource = db.Select_Custemer().Tables["Custemer"];
            comboBox4.ValueMember = "顧客コード";
            comboBox4.DisplayMember = "顧客名";


        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void Juchu_Load(object sender, EventArgs e)
        {
            if (radioButton1.Checked == true)
            {
                JuchuShift = "ミッション";
            }
            else
            {
                JuchuShift = "オートマ";

            }


        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
        private void TextBox1_KeyPress(object sender,System.Windows.Forms.KeyPressEventArgs e)
        {
            //0～9と、バックスペース以外の時は、イベントをキャンセルする
            if ((e.KeyChar < '0' || '9' < e.KeyChar) && e.KeyChar != '\b'){
                e.Handled = true;
            }
        }

        private void label12_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            IsedaDBClass db = new IsedaDBClass();
            if (Custemerflg)
            {
                db.Juchu_Insert2(comboBox4.SelectedValue.ToString());
                Custemerflg = false;
            }
            Form form = new Sugukuru.JuchuMulti(JuchuCode,comboBox4.ValueMember);
            form.ShowDialog();
            form.Dispose();//閉じられたらリソース開放
            this.Close();
        }

        private void comboBox4_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

            DialogResult result = MessageBox.Show("内容を登録し、完了してもよろしいですか？",
            "確認",
            MessageBoxButtons.OKCancel,
            MessageBoxIcon.Exclamation,
            MessageBoxDefaultButton.Button2);
            if (result == DialogResult.OK)
            {
                this.Close();
            }
            else if (result == DialogResult.Cancel)
            {

            }

            if (textBox1.Text == "")
            {
                Count = 0;
            }
            else
            {
                Count = Convert.ToInt16(textBox1.Text);

            }
            IsedaDBClass db = new IsedaDBClass();
            if (Custemerflg)
            {
                db.Juchu_Insert2(comboBox4.SelectedValue.ToString());
                Custemerflg = false;
            }

            db.Juchu_Insert(JuchuCode, comboBox4.ValueMember, textBox8.Text, comboBox1.Text, textBox6.Text, textBox3.Text, JuchuShift, textBox4.Text, textBox2.Text, textBox5.Text, textBox6.Text, textBox9.Text,Count);
        }
        
        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }


    }
}
