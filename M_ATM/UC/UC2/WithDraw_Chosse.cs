using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Reflection;

namespace M_ATM.UC.UC2
{
    public partial class WithDraw_Chosse : UserControl
    {
        public delegate void ChooseOk(bool isContinue, double soTien);
        public event ChooseOk ok;

        private MainForm main;
        public WithDraw_Chosse(MainForm main)
        {
            InitializeComponent();
            this.main = main;
            main.delete_Text += Main_delete_Text;
            main.btnChange += Main_btnChange;
            main.btn_ok += Main_btn_ok;
        }

        private void Main_btn_ok()
        {
            if (!string.IsNullOrEmpty(textBox1.Text))
            {
                double soTien = 0;
                if (double.TryParse(textBox1.Text, out soTien))
                {
                    if (soTien > 50000)
                    {
                        if (ok != null)
                        {
                            ok(true, soTien);
                        }
                    }
                    else
                    {
                        MessageBox.Show("Số tiền nhập vào quá nhỏ(số tiền phải lớn hơn hoặc bằng 50.000)");
                    }
                }
            }
        }

        private void Main_btnChange(string name)
        {
            textBox1.Text += name;
        }

        private void Main_delete_Text()
        {
            if (textBox1.TextLength > 0)
            {
                textBox1.Text = textBox1.Text.Remove(textBox1.TextLength - 1, 1);
            }
        }

        private void WithDraw_Chosse_Load(object sender, EventArgs e)
        {
            panel1.BackColor = Color.FromArgb(255, 255, 204, 55);
            var images = typeof(Properties.Resources)
                  .GetProperties(BindingFlags.Static | BindingFlags.NonPublic |
                                                       BindingFlags.Public)
                  .Where(p => p.PropertyType == typeof(Bitmap))
                  .Select(x => new { Name = x.Name, Image = x.GetValue(null, null) })
                  .ToList();

            Random r = new Random();
            int i = r.Next(0, images.Count - 1);

            this.BackgroundImage = (Image)images[i].Image;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
        }

        private void btnOk_Click_1(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(textBox1.Text))
            {
                double soTien = 0;
                if (double.TryParse(textBox1.Text, out soTien))
                {
                    if (soTien > 50000)
                    {
                        if (ok != null)
                        {
                            ok(true, soTien);
                        }
                    }
                    else
                    {
                        MessageBox.Show("Số tiền nhập vào quá nhỏ(số tiền phải lớn hơn hoặc bằng 50.000)");
                    }
                }
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            if (ok != null)
            {
                ok(false, -1);
            }
        }
    }
}
