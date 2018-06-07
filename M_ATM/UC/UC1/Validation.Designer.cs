namespace M_ATM.UC.UC1
{
    partial class Validation
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.Cardpanel = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.PassPanel = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.btnOk = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.lbThongBao = new System.Windows.Forms.Label();
            this.Cardpanel.SuspendLayout();
            this.PassPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(78, 49);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(213, 25);
            this.textBox1.TabIndex = 0;
            // 
            // Cardpanel
            // 
            this.Cardpanel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.Cardpanel.Controls.Add(this.label1);
            this.Cardpanel.Controls.Add(this.textBox1);
            this.Cardpanel.Location = new System.Drawing.Point(140, 93);
            this.Cardpanel.Name = "Cardpanel";
            this.Cardpanel.Size = new System.Drawing.Size(351, 100);
            this.Cardpanel.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label1.Location = new System.Drawing.Point(78, 18);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(105, 18);
            this.label1.TabIndex = 1;
            this.label1.Text = "Nhập vào mã thẻ";
            // 
            // PassPanel
            // 
            this.PassPanel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.PassPanel.Controls.Add(this.label2);
            this.PassPanel.Controls.Add(this.textBox2);
            this.PassPanel.Location = new System.Drawing.Point(140, 96);
            this.PassPanel.Name = "PassPanel";
            this.PassPanel.Size = new System.Drawing.Size(351, 100);
            this.PassPanel.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label2.Location = new System.Drawing.Point(78, 18);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(119, 18);
            this.label2.TabIndex = 1;
            this.label2.Text = "Nhập vào mật khẩu";
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(78, 49);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(213, 25);
            this.textBox2.TabIndex = 0;
            // 
            // btnOk
            // 
            this.btnOk.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnOk.Location = new System.Drawing.Point(504, 247);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(142, 50);
            this.btnOk.TabIndex = 2;
            this.btnOk.Text = "Ok";
            this.btnOk.UseVisualStyleBackColor = true;
            this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancel.Location = new System.Drawing.Point(504, 303);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(142, 50);
            this.btnCancel.TabIndex = 3;
            this.btnCancel.Text = "Hủy";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // lbThongBao
            // 
            this.lbThongBao.AutoSize = true;
            this.lbThongBao.ForeColor = System.Drawing.Color.Red;
            this.lbThongBao.Location = new System.Drawing.Point(140, 55);
            this.lbThongBao.MaximumSize = new System.Drawing.Size(351, 0);
            this.lbThongBao.MinimumSize = new System.Drawing.Size(351, 0);
            this.lbThongBao.Name = "lbThongBao";
            this.lbThongBao.Size = new System.Drawing.Size(351, 18);
            this.lbThongBao.TabIndex = 4;
            this.lbThongBao.Text = "label3";
            this.lbThongBao.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lbThongBao.Visible = false;
            // 
            // Validation
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.lbThongBao);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOk);
            this.Controls.Add(this.PassPanel);
            this.Controls.Add(this.Cardpanel);
            this.Font = new System.Drawing.Font("Roboto", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "Validation";
            this.Size = new System.Drawing.Size(649, 374);
            this.Load += new System.EventHandler(this.Validation_Load);
            this.Cardpanel.ResumeLayout(false);
            this.Cardpanel.PerformLayout();
            this.PassPanel.ResumeLayout(false);
            this.PassPanel.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Panel Cardpanel;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel PassPanel;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.Button btnOk;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Label lbThongBao;
    }
}
