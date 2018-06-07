namespace M_ATM.UC.UC2
{
    partial class Final_UC
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
            this.btnExit = new System.Windows.Forms.Button();
            this.btn500 = new System.Windows.Forms.Button();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.helloPanel = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.helloPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnExit
            // 
            this.btnExit.Font = new System.Drawing.Font("Roboto", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnExit.Location = new System.Drawing.Point(475, 303);
            this.btnExit.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(170, 50);
            this.btnExit.TabIndex = 5;
            this.btnExit.Text = "Thoát";
            this.btnExit.UseVisualStyleBackColor = true;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // btn500
            // 
            this.btn500.Font = new System.Drawing.Font("Roboto", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn500.Location = new System.Drawing.Point(475, 247);
            this.btn500.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.btn500.Name = "btn500";
            this.btn500.Size = new System.Drawing.Size(170, 50);
            this.btn500.TabIndex = 6;
            this.btn500.Text = "Tiếp tục giao dịch";
            this.btn500.UseVisualStyleBackColor = true;
            this.btn500.Click += new System.EventHandler(this.btn500_Click);
            // 
            // timer1
            // 
            this.timer1.Interval = 2000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // helloPanel
            // 
            this.helloPanel.Controls.Add(this.label1);
            this.helloPanel.Location = new System.Drawing.Point(137, 44);
            this.helloPanel.Name = "helloPanel";
            this.helloPanel.Size = new System.Drawing.Size(386, 105);
            this.helloPanel.TabIndex = 7;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label1.Location = new System.Drawing.Point(3, 1);
            this.label1.MaximumSize = new System.Drawing.Size(380, 0);
            this.label1.MinimumSize = new System.Drawing.Size(380, 100);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(380, 100);
            this.label1.TabIndex = 0;
            this.label1.Text = "Giao dịch thành công. Vui lòng kiểm tra khe rút tiền\r\nvà nhận lại hóa đơn";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // Final_UC
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.helloPanel);
            this.Controls.Add(this.btnExit);
            this.Controls.Add(this.btn500);
            this.Font = new System.Drawing.Font("Roboto", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "Final_UC";
            this.Size = new System.Drawing.Size(649, 374);
            this.Load += new System.EventHandler(this.Final_UC_Load);
            this.helloPanel.ResumeLayout(false);
            this.helloPanel.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.Button btn500;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Panel helloPanel;
        private System.Windows.Forms.Label label1;
    }
}
