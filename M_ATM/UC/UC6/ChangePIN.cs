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

using DTO;
using BUL;

namespace M_ATM.UC.UC6
{
    public partial class ChangePIN : UserControl
    {
        public delegate void ChangePassOk(bool isContinue);
        public event ChangePassOk ok;

        private string the;
        private string maATM;
        private MainForm main;
        public ChangePIN(string the, string maATM, MainForm main)
        {
            InitializeComponent();
            this.the = the;
            this.maATM = maATM;
            this.main = main;
        }

        private void ChangePIN_Load(object sender, EventArgs e)
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

        private void btn500_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(textBox1.Text))
            {
                if (!string.IsNullOrEmpty(textBox2.Text))
                {
                    if (textBox1.Text.Equals(textBox2.Text))
                    {
                        int pin = 0;
                        if(int.TryParse(textBox1.Text, out pin))
                        {
                            if (DanhSachTheATM_BUL.Instance.DoiMaPIN(the, pin) > 0)
                            {
                                GhiGiaoDich ghi = new GhiGiaoDich();
                                ghi.Ngaygiaodich = DateTime.Now;
                                ghi.MoTaGD = "Đổi mã pin";
                                ghi.SoTheATM = the;
                                ghi.MaATM = maATM;
                                ghi.Malog = "Log05";
                                ghi.SotheATMnhanTien = "";

                                GhiGiaoDich_BUL.Instance.TaoMoiBanGhi(ghi);

                                if (ok != null)
                                {
                                    ok(true);
                                }
                            }
                            else
                            {
                                MessageBox.Show("Đã xảy ra lỗi trong quá trình xử lý.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                        }
                        else
                        {
                            MessageBox.Show("Mã PIN là 1 dãy ít nhất 4 số.", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }

                    }
                    else
                    {
                        MessageBox.Show("Mật khẩu không trùng khớp.", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
                else
                {
                    MessageBox.Show("Hãy nhập lại mật khẩu.", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            else
            {
                MessageBox.Show("Mật khẩu không được để trống.", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            if (ok != null)
            {
                ok(false);
            }
        }
    }
}
