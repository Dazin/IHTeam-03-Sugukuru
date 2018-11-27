namespace Sugukuru
{
    partial class Form1
    {
        /// <summary>
        /// 必要なデザイナー変数です。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 使用中のリソースをすべてクリーンアップします。
        /// </summary>
        /// <param name="disposing">マネージド リソースを破棄する場合は true を指定し、その他の場合は false を指定します。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows フォーム デザイナーで生成されたコード

        /// <summary>
        /// デザイナー サポートに必要なメソッドです。このメソッドの内容を
        /// コード エディターで変更しないでください。
        /// </summary>
        private void InitializeComponent()
        {
            this.LbList = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.SalesList = new System.Windows.Forms.RadioButton();
            this.ReceiptList = new System.Windows.Forms.RadioButton();
            this.ShippingList = new System.Windows.Forms.RadioButton();
            this.radioButton1 = new System.Windows.Forms.RadioButton();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.Button = new System.Windows.Forms.DataGridViewButtonColumn();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // LbList
            // 
            this.LbList.AutoSize = true;
            this.LbList.Font = new System.Drawing.Font("MS UI Gothic", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.LbList.Location = new System.Drawing.Point(485, 46);
            this.LbList.Name = "LbList";
            this.LbList.Size = new System.Drawing.Size(79, 33);
            this.LbList.TabIndex = 12;
            this.LbList.Text = "一覧";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.SalesList);
            this.groupBox1.Controls.Add(this.ReceiptList);
            this.groupBox1.Controls.Add(this.ShippingList);
            this.groupBox1.Controls.Add(this.radioButton1);
            this.groupBox1.Location = new System.Drawing.Point(22, 27);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(231, 104);
            this.groupBox1.TabIndex = 11;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "groupBox1";
            // 
            // SalesList
            // 
            this.SalesList.AutoSize = true;
            this.SalesList.Location = new System.Drawing.Point(115, 68);
            this.SalesList.Name = "SalesList";
            this.SalesList.Size = new System.Drawing.Size(71, 16);
            this.SalesList.TabIndex = 3;
            this.SalesList.TabStop = true;
            this.SalesList.Text = "売上伝票";
            this.SalesList.UseVisualStyleBackColor = true;
            this.SalesList.CheckedChanged += new System.EventHandler(this.SalesList_CheckedChanged);
            // 
            // ReceiptList
            // 
            this.ReceiptList.AutoSize = true;
            this.ReceiptList.Location = new System.Drawing.Point(115, 35);
            this.ReceiptList.Name = "ReceiptList";
            this.ReceiptList.Size = new System.Drawing.Size(95, 16);
            this.ReceiptList.TabIndex = 2;
            this.ReceiptList.TabStop = true;
            this.ReceiptList.Text = "物品受領一覧";
            this.ReceiptList.UseVisualStyleBackColor = true;
            this.ReceiptList.CheckedChanged += new System.EventHandler(this.ReceiptList_CheckedChanged);
            // 
            // ShippingList
            // 
            this.ShippingList.AutoSize = true;
            this.ShippingList.Location = new System.Drawing.Point(7, 68);
            this.ShippingList.Name = "ShippingList";
            this.ShippingList.Size = new System.Drawing.Size(71, 16);
            this.ShippingList.TabIndex = 1;
            this.ShippingList.TabStop = true;
            this.ShippingList.Text = "出荷一覧";
            this.ShippingList.UseVisualStyleBackColor = true;
            this.ShippingList.CheckedChanged += new System.EventHandler(this.ShippingList_CheckedChanged);
            // 
            // radioButton1
            // 
            this.radioButton1.AutoSize = true;
            this.radioButton1.Location = new System.Drawing.Point(7, 35);
            this.radioButton1.Name = "radioButton1";
            this.radioButton1.Size = new System.Drawing.Size(71, 16);
            this.radioButton1.TabIndex = 0;
            this.radioButton1.TabStop = true;
            this.radioButton1.Text = "納品一覧";
            this.radioButton1.UseVisualStyleBackColor = true;
            this.radioButton1.CheckedChanged += new System.EventHandler(this.radioButton1_CheckedChanged);
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Button});
            this.dataGridView1.Location = new System.Drawing.Point(50, 171);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowTemplate.Height = 21;
            this.dataGridView1.Size = new System.Drawing.Size(992, 483);
            this.dataGridView1.TabIndex = 10;
            this.dataGridView1.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            // 
            // Button
            // 
            this.Button.HeaderText = "印刷";
            this.Button.Name = "Button";
            this.Button.Text = "作成";
            this.Button.UseColumnTextForButtonValue = true;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1064, 681);
            this.Controls.Add(this.LbList);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.dataGridView1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label LbList;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton SalesList;
        private System.Windows.Forms.RadioButton ReceiptList;
        private System.Windows.Forms.RadioButton ShippingList;
        private System.Windows.Forms.RadioButton radioButton1;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.DataGridViewButtonColumn Button;
    }
}

