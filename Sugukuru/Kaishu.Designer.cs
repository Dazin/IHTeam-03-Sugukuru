﻿namespace Sugukuru
{
    partial class Kaishu
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
            this.label1 = new System.Windows.Forms.Label();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.button1 = new System.Windows.Forms.Button();
            this.btOpen = new System.Windows.Forms.Button();
            this.btLoadSeikyu = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("MS UI Gothic", 18F);
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(106, 24);
            this.label1.TabIndex = 1;
            this.label1.Text = "回収画面";
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(25, 63);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersVisible = false;
            this.dataGridView1.RowTemplate.Height = 21;
            this.dataGridView1.Size = new System.Drawing.Size(956, 444);
            this.dataGridView1.TabIndex = 2;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(25, 513);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(117, 39);
            this.button1.TabIndex = 3;
            this.button1.Text = "一括消し込みする";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // btOpen
            // 
            this.btOpen.Location = new System.Drawing.Point(255, 25);
            this.btOpen.Name = "btOpen";
            this.btOpen.Size = new System.Drawing.Size(103, 23);
            this.btOpen.TabIndex = 4;
            this.btOpen.Text = "全銀ファイル読込";
            this.btOpen.UseVisualStyleBackColor = true;
            this.btOpen.Click += new System.EventHandler(this.btOpen_Click);
            // 
            // btLoadSeikyu
            // 
            this.btLoadSeikyu.Location = new System.Drawing.Point(145, 25);
            this.btLoadSeikyu.Name = "btLoadSeikyu";
            this.btLoadSeikyu.Size = new System.Drawing.Size(104, 23);
            this.btLoadSeikyu.TabIndex = 5;
            this.btLoadSeikyu.Text = "請求情報読込";
            this.btLoadSeikyu.UseVisualStyleBackColor = true;
            this.btLoadSeikyu.Click += new System.EventHandler(this.button2_Click);
            // 
            // Kaishu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1007, 569);
            this.Controls.Add(this.btLoadSeikyu);
            this.Controls.Add(this.btOpen);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.label1);
            this.Name = "Kaishu";
            this.Text = "Kaishu";
            this.Load += new System.EventHandler(this.Kaishu_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button btOpen;
        private System.Windows.Forms.Button btLoadSeikyu;
    }
}