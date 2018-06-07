namespace M_ATM.UC.UC2
{
    partial class WithDraw
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
            this.btn2000 = new System.Windows.Forms.Button();
            this.btn1000 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.btn500 = new System.Windows.Forms.Button();
            this.btn1500 = new System.Windows.Forms.Button();
            this.btnOther = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // timer1
            // 
            this.timer1.Interval = 2000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // btn2000
            // 
            this.btn2000.Font = new System.Drawing.Font("Roboto", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn2000.Location = new System.Drawing.Point(4, 313);
            this.btn2000.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.btn2000.Name = "btn2000";
            this.btn2000.Size = new System.Drawing.Size(170, 50);
            this.btn2000.TabIndex = 2;
            this.btn2000.Text = "2.000.000";
            this.btn2000.UseVisualStyleBackColor = true;
            this.btn2000.Click += new System.EventHandler(this.btn2000_Click);
            // 
            // btn1000
            // 
            this.btn1000.Font = new System.Drawing.Font("Roboto", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn1000.Location = new System.Drawing.Point(4, 257);
            this.btn1000.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.btn1000.Name = "btn1000";
            this.btn1000.Size = new System.Drawing.Size(170, 50);
            this.btn1000.TabIndex = 3;
            this.btn1000.Text = "1.000.000";
            this.btn1000.UseVisualStyleBackColor = true;
            this.btn1000.Click += new System.EventHandler(this.btn1000_Click);
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("Roboto", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.Location = new System.Drawing.Point(4, 201);
            this.button1.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(170, 50);
            this.button1.TabIndex = 4;
            this.button1.Text = "200.000";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // btn500
            // 
            this.btn500.Font = new System.Drawing.Font("Roboto", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn500.Location = new System.Drawing.Point(475, 201);
            this.btn500.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.btn500.Name = "btn500";
            this.btn500.Size = new System.Drawing.Size(170, 50);
            this.btn500.TabIndex = 4;
            this.btn500.Text = "500.000";
            this.btn500.UseVisualStyleBackColor = true;
            this.btn500.Click += new System.EventHandler(this.btn500_Click);
            // 
            // btn1500
            // 
            this.btn1500.Font = new System.Drawing.Font("Roboto", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn1500.Location = new System.Drawing.Point(475, 257);
            this.btn1500.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.btn1500.Name = "btn1500";
            this.btn1500.Size = new System.Drawing.Size(170, 50);
            this.btn1500.TabIndex = 3;
            this.btn1500.Text = "1.500.000";
            this.btn1500.UseVisualStyleBackColor = true;
            this.btn1500.Click += new System.EventHandler(this.btn1500_Click);
            // 
            // btnOther
            // 
            this.btnOther.Font = new System.Drawing.Font("Roboto", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnOther.Location = new System.Drawing.Point(475, 313);
            this.btnOther.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.btnOther.Name = "btnOther";
            this.btnOther.Size = new System.Drawing.Size(170, 50);
            this.btnOther.TabIndex = 2;
            this.btnOther.Text = "Nhập vào số khác";
            this.btnOther.UseVisualStyleBackColor = true;
            this.btnOther.Click += new System.EventHandler(this.btnOther_Click);
            // 
            // WithDraw
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.BackgroundImage = global::M_ATM.Properties.Resources._2582015_81733335_BIDV;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.Controls.Add(this.btnOther);
            this.Controls.Add(this.btn2000);
            this.Controls.Add(this.btn1500);
            this.Controls.Add(this.btn1000);
            this.Controls.Add(this.btn500);
            this.Controls.Add(this.button1);
            this.Font = new System.Drawing.Font("Roboto", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.Name = "WithDraw";
            this.Size = new System.Drawing.Size(649, 374);
            this.Load += new System.EventHandler(this.WithDraw_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Button btn2000;
        private System.Windows.Forms.Button btn1000;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button btn500;
        private System.Windows.Forms.Button btn1500;
        private System.Windows.Forms.Button btnOther;
    }
}
