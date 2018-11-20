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
    public partial class Kaishu : Form
    {
        public Kaishu()
        {
            InitializeComponent();
        }

        private void Kaishu_Load(object sender, EventArgs e)
        {
            dataGridView1.Rows.Add("10001", "太郎", "080-XXXX-XXXX", "100,000", "100,000", "20181127", "20,000", "80,000", "未回収");
        }
    }
}
