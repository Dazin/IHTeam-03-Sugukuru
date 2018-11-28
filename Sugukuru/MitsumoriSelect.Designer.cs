namespace Sugukuru
{
    partial class MitsumoriSelect
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.button1 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.Gtable = new System.Windows.Forms.DataGridView();
            this.nameBox = new System.Windows.Forms.TextBox();
            this.dateBox = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.Gtable)).BeginInit();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(359, 228);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 0;
            this.button1.Text = "見積書作成";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 12);
            this.label1.TabIndex = 2;
            this.label1.Text = "受注選択";
            // 
            // Gtable
            // 
            this.Gtable.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.Gtable.Location = new System.Drawing.Point(43, 35);
            this.Gtable.Name = "Gtable";
            this.Gtable.RowTemplate.Height = 21;
            this.Gtable.Size = new System.Drawing.Size(245, 216);
            this.Gtable.TabIndex = 1;
            this.Gtable.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.Gtable_SelectedRows);
            // 
            // nameBox
            // 
            this.nameBox.Location = new System.Drawing.Point(332, 84);
            this.nameBox.Name = "nameBox";
            this.nameBox.Size = new System.Drawing.Size(100, 19);
            this.nameBox.TabIndex = 3;
            // 
            // dateBox
            // 
            this.dateBox.Location = new System.Drawing.Point(332, 134);
            this.dateBox.Name = "dateBox";
            this.dateBox.Size = new System.Drawing.Size(100, 19);
            this.dateBox.TabIndex = 4;
            // 
            // MitsumoriSelect
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(444, 263);
            this.Controls.Add(this.dateBox);
            this.Controls.Add(this.nameBox);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.Gtable);
            this.Controls.Add(this.button1);
            this.Name = "MitsumoriSelect";
            this.Text = "MitsumoriSelect";
            this.Load += new System.EventHandler(this.MitsumoriSelect_Load);
            ((System.ComponentModel.ISupportInitialize)(this.Gtable)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView Gtable;
        private System.Windows.Forms.TextBox nameBox;
        private System.Windows.Forms.TextBox dateBox;
    }
}