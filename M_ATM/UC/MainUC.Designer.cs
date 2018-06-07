namespace M_ATM.UC
{
    partial class MainUC
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
            this.components = new System.ComponentModel.Container();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.btnRutTien = new System.Windows.Forms.Button();
            this.btnVanTinTaiKhoan = new System.Windows.Forms.Button();
            this.btnChuyenKhoan = new System.Windows.Forms.Button();
            this.btnXemLichSu = new System.Windows.Forms.Button();
            this.btnDoiMaPin = new System.Windows.Forms.Button();
            this.button7 = new System.Windows.Forms.Button();
            this.helloPanel = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.helloPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // timer1
            // 
            this.timer1.Interval = 2000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // btnRutTien
            // 
            this.btnRutTien.Location = new System.Drawing.Point(3, 198);
            this.btnRutTien.Name = "btnRutTien";
            this.btnRutTien.Size = new System.Drawing.Size(142, 50);
            this.btnRutTien.TabIndex = 0;
            this.btnRutTien.Text = "Rút tiền";
            this.btnRutTien.UseVisualStyleBackColor = true;
            this.btnRutTien.Click += new System.EventHandler(this.btnRutTien_Click);
            // 
            // btnVanTinTaiKhoan
            // 
            this.btnVanTinTaiKhoan.Location = new System.Drawing.Point(3, 254);
            this.btnVanTinTaiKhoan.Name = "btnVanTinTaiKhoan";
            this.btnVanTinTaiKhoan.Size = new System.Drawing.Size(142, 50);
            this.btnVanTinTaiKhoan.TabIndex = 0;
            this.btnVanTinTaiKhoan.Text = "Vấn tin tài khoản";
            this.btnVanTinTaiKhoan.UseVisualStyleBackColor = true;
            this.btnVanTinTaiKhoan.Click += new System.EventHandler(this.btnVanTinTaiKhoan_Click);
            // 
            // btnChuyenKhoan
            // 
            this.btnChuyenKhoan.Location = new System.Drawing.Point(3, 310);
            this.btnChuyenKhoan.Name = "btnChuyenKhoan";
            this.btnChuyenKhoan.Size = new System.Drawing.Size(142, 50);
            this.btnChuyenKhoan.TabIndex = 0;
            this.btnChuyenKhoan.Text = "Chuyển khoản";
            this.btnChuyenKhoan.UseVisualStyleBackColor = true;
            this.btnChuyenKhoan.Click += new System.EventHandler(this.btnChuyenKhoan_Click);
            // 
            // btnXemLichSu
            // 
            this.btnXemLichSu.Location = new System.Drawing.Point(504, 198);
            this.btnXemLichSu.Name = "btnXemLichSu";
            this.btnXemLichSu.Size = new System.Drawing.Size(142, 50);
            this.btnXemLichSu.TabIndex = 0;
            this.btnXemLichSu.Text = "Xem lịch sử giao dịch";
            this.btnXemLichSu.UseVisualStyleBackColor = true;
            this.btnXemLichSu.Click += new System.EventHandler(this.btnXemLichSu_Click);
            // 
            // btnDoiMaPin
            // 
            this.btnDoiMaPin.Location = new System.Drawing.Point(504, 254);
            this.btnDoiMaPin.Name = "btnDoiMaPin";
            this.btnDoiMaPin.Size = new System.Drawing.Size(142, 50);
            this.btnDoiMaPin.TabIndex = 0;
            this.btnDoiMaPin.Text = "Đổi mã pin";
            this.btnDoiMaPin.UseVisualStyleBackColor = true;
            this.btnDoiMaPin.Click += new System.EventHandler(this.btnDoiMaPin_Click);
            // 
            // button7
            // 
            this.button7.Location = new System.Drawing.Point(504, 310);
            this.button7.Name = "button7";
            this.button7.Size = new System.Drawing.Size(142, 50);
            this.button7.TabIndex = 0;
            this.button7.Text = "Thoát";
            this.button7.UseVisualStyleBackColor = true;
            this.button7.Click += new System.EventHandler(this.button7_Click);
            // 
            // helloPanel
            // 
            this.helloPanel.Controls.Add(this.label2);
            this.helloPanel.Controls.Add(this.label1);
            this.helloPanel.Location = new System.Drawing.Point(124, 24);
            this.helloPanel.Name = "helloPanel";
            this.helloPanel.Size = new System.Drawing.Size(386, 105);
            this.helloPanel.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label2.Location = new System.Drawing.Point(3, 47);
            this.label2.MaximumSize = new System.Drawing.Size(380, 0);
            this.label2.MinimumSize = new System.Drawing.Size(380, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(380, 36);
            this.label2.TabIndex = 0;
            this.label2.Text = "Để thực hiện giao dịch với máy ATM\r\nHãy chọn các chức năng bên dưới.";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Roboto Medium", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label1.Location = new System.Drawing.Point(3, 10);
            this.label1.MaximumSize = new System.Drawing.Size(380, 0);
            this.label1.MinimumSize = new System.Drawing.Size(380, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(380, 21);
            this.label1.TabIndex = 0;
            this.label1.Text = "Xin chào....";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // MainUC
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::M_ATM.Properties.Resources._1892015_154119938_BIDV;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.Controls.Add(this.helloPanel);
            this.Controls.Add(this.button7);
            this.Controls.Add(this.btnChuyenKhoan);
            this.Controls.Add(this.btnDoiMaPin);
            this.Controls.Add(this.btnVanTinTaiKhoan);
            this.Controls.Add(this.btnXemLichSu);
            this.Controls.Add(this.btnRutTien);
            this.Font = new System.Drawing.Font("Roboto", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "MainUC";
            this.Size = new System.Drawing.Size(649, 374);
            this.Load += new System.EventHandler(this.MainUC_Load);
            this.helloPanel.ResumeLayout(false);
            this.helloPanel.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Button btnRutTien;
        private System.Windows.Forms.Button btnVanTinTaiKhoan;
        private System.Windows.Forms.Button btnChuyenKhoan;
        private System.Windows.Forms.Button btnXemLichSu;
        private System.Windows.Forms.Button btnDoiMaPin;
        private System.Windows.Forms.Button button7;
        private System.Windows.Forms.Panel helloPanel;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
    }
}
