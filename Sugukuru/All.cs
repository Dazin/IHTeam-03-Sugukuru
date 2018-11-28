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
    public partial class All : Form
    {
        public All()
        {
            InitializeComponent();
        }

        private void btUkeshoSelect_Click(object sender, EventArgs e)
        {
            openForm(new Sugukuru.UkeshoSelect());

        }

        private void btJuchu_Click(object sender, EventArgs e)
        {
            openForm(new Sugukuru.Juchu());
        }

        private void openForm(Form newFrm)
        {
            foreach (var frm in Controls.OfType<Form>()) this.Controls.Remove(frm); //フォーム削除

            Form form = newFrm;
            // TopLevelコントロールでないようにする。
            form.TopLevel = false;
            // 外枠を消す.
            form.FormBorderStyle = FormBorderStyle.None;
            // 配置されているコントロールを表示する.
            form.Visible = true;
            form.Location = new Point(0, 50);
            this.Controls.Add(form);
        }

        private void btMitsumori_Click(object sender, EventArgs e)
        {
            openForm(new Sugukuru.MitsumoriSelect());
        }
    }
}
