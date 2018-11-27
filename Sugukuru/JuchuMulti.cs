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
    public partial class JuchuMulti : Form
    {
        public int Count = 0;
        private String Code = "";
        private  String Custemer = "";
        public String JuchuShift = "";

        public JuchuMulti(String JuchuCode,String JuchuCustemer)
        {
            this.Code = JuchuCode;
            this.Custemer = JuchuCustemer;
            InitializeComponent();
        }


        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
        private void TextBox1_KeyPress(object sender, System.Windows.Forms.KeyPressEventArgs e)
        {
            //0～9と、バックスペース以外の時は、イベントをキャンセルする
            if ((e.KeyChar < '0' || '9' < e.KeyChar) && e.KeyChar != '\b'){
                e.Handled = true;
            }
            
        }

        private void JuchuMulti_Load(object sender, EventArgs e)
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

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "")
            {
                Count = 0;
            }
            else
            {
                Count = Convert.ToInt16(textBox1.Text);

            }
            IsedaDBClass db = new IsedaDBClass();
            db.Juchu_Insert(Code, Custemer, textBox8.Text, comboBox1.Text, textBox4.Text, textBox3.Text, JuchuShift, textBox4.Text, textBox2.Text, textBox5.Text, textBox6.Text, textBox9.Text, Count);
            DialogResult result = MessageBox.Show("登録しました。",
            "確認",
            MessageBoxButtons.OK,
            MessageBoxIcon.Exclamation,
            MessageBoxDefaultButton.Button2);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("受注を完了してもよろしいですか？",
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
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
