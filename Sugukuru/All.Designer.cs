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
            this.btSeikyu = new System.Windows.Forms.Button();
            this.btSeikyusho = new System.Windows.Forms.Button();
            this.btSeikyuKobetsu = new System.Windows.Forms.Button();
            this.btKaishu = new System.Windows.Forms.Button();
            this.btShiire = new System.Windows.Forms.Button();
            this.btCreateDocument = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btUkeshoSelect
            // 
            this.btUkeshoSelect.Location = new System.Drawing.Point(174, 12);
            this.btUkeshoSelect.Name = "btUkeshoSelect";
            this.btUkeshoSelect.Size = new System.Drawing.Size(75, 23);
            this.btUkeshoSelect.TabIndex = 0;
            this.btUkeshoSelect.Text = "請書選択";
            this.btUkeshoSelect.UseVisualStyleBackColor = true;
            this.btUkeshoSelect.Click += new System.EventHandler(this.btUkeshoSelect_Click);
            // 
            // btJuchu
            // 
            this.btJuchu.Location = new System.Drawing.Point(12, 12);
            this.btJuchu.Name = "btJuchu";
            this.btJuchu.Size = new System.Drawing.Size(75, 23);
            this.btJuchu.TabIndex = 1;
            this.btJuchu.Text = "受注";
            this.btJuchu.UseVisualStyleBackColor = true;
            this.btJuchu.Click += new System.EventHandler(this.btJuchu_Click);
            // 
            // btMitsumori
            // 
            this.btMitsumori.Location = new System.Drawing.Point(93, 12);
            this.btMitsumori.Name = "btMitsumori";
            this.btMitsumori.Size = new System.Drawing.Size(75, 23);
            this.btMitsumori.TabIndex = 2;
            this.btMitsumori.Text = "見積書作成";
            this.btMitsumori.UseVisualStyleBackColor = true;
            this.btMitsumori.Click += new System.EventHandler(this.btMitsumori_Click);
            // 
            // btSeikyu
            // 
            this.btSeikyu.Location = new System.Drawing.Point(255, 12);
            this.btSeikyu.Name = "btSeikyu";
            this.btSeikyu.Size = new System.Drawing.Size(75, 23);
            this.btSeikyu.TabIndex = 9;
            this.btSeikyu.Text = "請求";
            this.btSeikyu.UseVisualStyleBackColor = true;
            this.btSeikyu.Click += new System.EventHandler(this.btSeikyu_Click);
            // 
            // btSeikyusho
            // 
            this.btSeikyusho.Location = new System.Drawing.Point(417, 12);
            this.btSeikyusho.Name = "btSeikyusho";
            this.btSeikyusho.Size = new System.Drawing.Size(75, 23);
            this.btSeikyusho.TabIndex = 8;
            this.btSeikyusho.Text = "請求書";
            this.btSeikyusho.UseVisualStyleBackColor = true;
            this.btSeikyusho.Click += new System.EventHandler(this.btSeikyusho_Click);
            // 
            // btSeikyuKobetsu
            // 
            this.btSeikyuKobetsu.Location = new System.Drawing.Point(336, 12);
            this.btSeikyuKobetsu.Name = "btSeikyuKobetsu";
            this.btSeikyuKobetsu.Size = new System.Drawing.Size(75, 23);
            this.btSeikyuKobetsu.TabIndex = 7;
            this.btSeikyuKobetsu.Text = "請求個別";
            this.btSeikyuKobetsu.UseVisualStyleBackColor = true;
            this.btSeikyuKobetsu.Click += new System.EventHandler(this.btSeikyuKobetsu_Click);
            // 
            // btKaishu
            // 
            this.btKaishu.Location = new System.Drawing.Point(498, 12);
            this.btKaishu.Name = "btKaishu";
            this.btKaishu.Size = new System.Drawing.Size(75, 23);
            this.btKaishu.TabIndex = 6;
            this.btKaishu.Text = "回収";
            this.btKaishu.UseVisualStyleBackColor = true;
            this.btKaishu.Click += new System.EventHandler(this.btKaishu_Click);
            // 
            // btShiire
            // 
            this.btShiire.Location = new System.Drawing.Point(660, 12);
            this.btShiire.Name = "btShiire";
            this.btShiire.Size = new System.Drawing.Size(75, 23);
            this.btShiire.TabIndex = 11;
            this.btShiire.Text = "仕入";
            this.btShiire.UseVisualStyleBackColor = true;
            this.btShiire.Click += new System.EventHandler(this.btShiire_Click);
            // 
            // btCreateDocument
            // 
            this.btCreateDocument.Location = new System.Drawing.Point(579, 12);
            this.btCreateDocument.Name = "btCreateDocument";
            this.btCreateDocument.Size = new System.Drawing.Size(75, 23);
            this.btCreateDocument.TabIndex = 10;
            this.btCreateDocument.Text = "書類作成";
            this.btCreateDocument.UseVisualStyleBackColor = true;
            this.btCreateDocument.Click += new System.EventHandler(this.btCreateDocument_Click);
            // 
            // All
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(770, 330);
            this.Controls.Add(this.btShiire);
            this.Controls.Add(this.btCreateDocument);
            this.Controls.Add(this.btSeikyu);
            this.Controls.Add(this.btSeikyusho);
            this.Controls.Add(this.btSeikyuKobetsu);
            this.Controls.Add(this.btKaishu);
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
        private System.Windows.Forms.Button btSeikyu;
        private System.Windows.Forms.Button btSeikyusho;
        private System.Windows.Forms.Button btSeikyuKobetsu;
        private System.Windows.Forms.Button btKaishu;
        private System.Windows.Forms.Button btShiire;
        private System.Windows.Forms.Button btCreateDocument;
    }
}