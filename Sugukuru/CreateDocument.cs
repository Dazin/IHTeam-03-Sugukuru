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
    public partial class CreateDocument : Form
    {
        public CreateDocument()
        {
            InitializeComponent();
        }

        private void CreateDocument_Load(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridView table = new DataGridView()
            {
                Font = new Font("Meiryo UI", 9),
                Dock = DockStyle.Top,
                ColumnCount = 5,
                SelectionMode = DataGridViewSelectionMode.FullRowSelect, //行選択
                AllowUserToResizeRows = false, //行の高さをユーザーが変更できないようにする
                RowHeadersVisible = false,      //Rowヘッダーを隠す
                ReadOnly = true,                 //編集不可
                AllowUserToAddRows = false,    //一番下の新しい行を非表示
                CellBorderStyle = DataGridViewCellBorderStyle.None,  //グリッド非表示
                Parent = this,
            };
        }

        private void DeliveryDocument_CheckedChanged(object sender, EventArgs e)
        {

        }
    }
}
