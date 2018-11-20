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

        private void Form2_Load(object sender, EventArgs e)
        {
            DataTable table = new DataTable("Table");

            table.Columns.Add("取引先名（敬称略）");

            table.Rows.Add("服部忍者スクール株式会社");
            table.Rows.Add("株式会社滝渕産業");
            table.Rows.Add("株式会社伊勢田の会");
            table.Rows.Add("株市会社竹久コーポ");


            dataGridView1.DataSource = table;
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
    }
}
