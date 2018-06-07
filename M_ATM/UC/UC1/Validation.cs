using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


using BUL;
using DTO;
using System.Reflection;

namespace M_ATM.UC.UC1
{
    public partial class Validation : UserControl
    {
        private bool IsVisible = false;

        public delegate void LoginSuccessfully(bool isSuccess, DanhsachtheATM ds, string mathe);
        public event LoginSuccessfully login;

        public delegate void CancelLogin();
        public event CancelLogin cancel;

        private MainForm main;
        private DanhsachtheATM ds;
        public Validation(MainForm main)
        {
            InitializeComponent();
            this.main = main;
            ds = new DanhsachtheATM();
            main.exit += Main_exit;
            main.btnChange += Main_btnChange;
            main.delete_Text += Main_delete_Text;
        }

        private void Main_exit()
        {
            ResetData();
        }

        private void Main_delete_Text()
        {
            if (!IsVisible)
            {
                if (textBox1.TextLength > 0)
                {
                    textBox1.Text = textBox1.Text.Remove(textBox1.TextLength - 1, 1);
                }
            }
            else
            {
                if (textBox2.TextLength > 0)
                {
                    textBox2.Text = textBox2.Text.Remove(textBox2.TextLength - 1, 1);
                }
            }
        }

        private void Main_btnChange(string name)
        {
            if (!IsVisible)
            {
                textBox1.Text += name;
            }
            else
            {
                textBox2.Text += name;
            }
        }


        /// <summary>
        /// Kiểm tra đăng nhập trên UC
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnOk_Click(object sender, EventArgs e)
        {

            
            if (!IsVisible)
            {
                if (DanhSachTheATM_BUL.Instance.KiemTraThongTin(textBox1.Text, out ds))
                {
                    IsVisible = true;
                    Cardpanel.Visible = false;
                    PassPanel.Visible = true;
                }
                else
                {
                    lbThongBao.Visible = true;
                    lbThongBao.Text = "Mã thẻ không tồn tại trong hệ thống.";
                }
            }
            else
            {
                if (ds != null)
                {
                    if (int.Parse(textBox2.Text) == ds.MaPin)
                    {
                        if (login != null)
                        {
                            login(true, ds, textBox1.Text);
                        }
                    }
                    else
                    {
                        lbThongBao.Visible = true;
                        lbThongBao.Text = "Mật khẩu không chính xác.";
                    }
                }
                else
                {
                    lbThongBao.Visible = true;
                    lbThongBao.Text = "Đã có lỗi xảy ra trong quá trình xử lý. Vui lòng thử lại sau";
                }
            }
        }

        public void ResetData()
        {
            textBox1.Text = string.Empty;
            textBox2.Text = string.Empty;
            Cardpanel.Visible = true;
            PassPanel.Visible = false;
            ds = null;
            IsVisible = false;
        }

        private void Validation_Load(object sender, EventArgs e)
        {
            PassPanel.BackColor = Color.FromArgb(255, 255, 204, 55);
            Cardpanel.BackColor = Color.FromArgb(255, 255, 204, 55);
            var images = typeof(Properties.Resources)
                  .GetProperties(BindingFlags.Static | BindingFlags.NonPublic |
                                                       BindingFlags.Public)
                  .Where(p => p.PropertyType == typeof(Bitmap))
                  .Select(x => new { Name = x.Name, Image = x.GetValue(null, null) })
                  .ToList();

            Random r = new Random();
            int i = r.Next(0, images.Count - 1);

            this.BackgroundImage = (Image)images[i].Image;

            Cardpanel.Visible = true;
            PassPanel.Visible = false;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            if(cancel != null)
            {
                cancel();
            }
        }
    }
}
