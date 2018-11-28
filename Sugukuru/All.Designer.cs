namespace Sugukuru
{
    partial class All
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
            this.btUkeshoSelect = new System.Windows.Forms.Button();
            this.btJuchu = new System.Windows.Forms.Button();
            this.btMitsumori = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btUkeshoSelect
            // 
            this.btUkeshoSelect.Location = new System.Drawing.Point(121, 12);
            this.btUkeshoSelect.Name = "btUkeshoSelect";
            this.btUkeshoSelect.Size = new System.Drawing.Size(103, 33);
            this.btUkeshoSelect.TabIndex = 0;
            this.btUkeshoSelect.Text = "請書選択";
            this.btUkeshoSelect.UseVisualStyleBackColor = true;
            this.btUkeshoSelect.Click += new System.EventHandler(this.btUkeshoSelect_Click);
            // 
            // btJuchu
            // 
            this.btJuchu.Location = new System.Drawing.Point(12, 12);
            this.btJuchu.Name = "btJuchu";
            this.btJuchu.Size = new System.Drawing.Size(103, 33);
            this.btJuchu.TabIndex = 1;
            this.btJuchu.Text = "受注";
            this.btJuchu.UseVisualStyleBackColor = true;
            this.btJuchu.Click += new System.EventHandler(this.btJuchu_Click);
            // 
            // btMitsumori
            // 
            this.btMitsumori.Location = new System.Drawing.Point(230, 12);
            this.btMitsumori.Name = "btMitsumori";
            this.btMitsumori.Size = new System.Drawing.Size(103, 33);
            this.btMitsumori.TabIndex = 2;
            this.btMitsumori.Text = "見積書作成";
            this.btMitsumori.UseVisualStyleBackColor = true;
            this.btMitsumori.Click += new System.EventHandler(this.btMitsumori_Click);
            // 
            // All
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(526, 330);
            this.Controls.Add(this.btMitsumori);
            this.Controls.Add(this.btJuchu);
            this.Controls.Add(this.btUkeshoSelect);
            this.Name = "All";
            this.Text = "All";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btUkeshoSelect;
        private System.Windows.Forms.Button btJuchu;
        private System.Windows.Forms.Button btMitsumori;
    }
}