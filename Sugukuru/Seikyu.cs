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
    public partial class Seikyu : Form
    {
        public Seikyu()
        {
            InitializeComponent();
        }

        private void Shiire_Load(object sender, EventArgs e)
        {
            Boolean flg = false;
            DateTime dt = DateTime.Now;
            IsedaDBSeikyu db = new IsedaDBSeikyu();
            label2.Text = ""+ (dt.Month - 1).ToString() + "月度のご請求";
            label3.Text = "" + dt.Year.ToString() +"年" + dt.Month.ToString() + "月15日";
            dataGridView1.DataSource = db.Select_List().Tables["Seikyu"];
            for(int i = 0;i < dataGridView1.RowCount;i++){
                if (Convert.ToInt32(dataGridView1.Rows[i].Cells[3].Value) < 0)
                {
                    flg = true;
                    break;
                }
            }
            if (flg)
            {
                DialogResult result = MessageBox.Show("与信限度額を超過している顧客が存在します。\n請求書を即時発行してもよろしいですか？",
                "確認",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Exclamation,
                MessageBoxDefaultButton.Button2);
                if (result == DialogResult.Yes)
                {

                }

            }
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }
    }
}
