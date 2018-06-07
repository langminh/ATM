namespace M_ATM.UC.UC2
{
    partial class BeingFinal_UC
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
            this.button7 = new System.Windows.Forms.Button();
            this.button6 = new System.Windows.Forms.Button();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.SuspendLayout();
            // 
            // button7
            // 
            this.button7.Font = new System.Drawing.Font("Roboto", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button7.Location = new System.Drawing.Point(475, 313);
            this.button7.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.button7.Name = "button7";
            this.button7.Size = new System.Drawing.Size(170, 50);
            this.button7.TabIndex = 4;
            this.button7.Text = "In hóa đơn";
            this.button7.UseVisualStyleBackColor = true;
            // 
            // button6
            // 
            this.button6.Font = new System.Drawing.Font("Roboto", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button6.Location = new System.Drawing.Point(475, 257);
            this.button6.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.button6.Name = "button6";
            this.button6.Size = new System.Drawing.Size(170, 50);
            this.button6.TabIndex = 5;
            this.button6.Text = "Không in hóa đơn";
            this.button6.UseVisualStyleBackColor = true;
            // 
            // timer1
            // 
            this.timer1.Interval = 2000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // BeingFinal_UC
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.Controls.Add(this.button7);
            this.Controls.Add(this.button6);
            this.Font = new System.Drawing.Font("Roboto", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "BeingFinal_UC";
            this.Size = new System.Drawing.Size(649, 374);
            this.Load += new System.EventHandler(this.Final_UC_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button button7;
        private System.Windows.Forms.Button button6;
        private System.Windows.Forms.Timer timer1;
    }
}
