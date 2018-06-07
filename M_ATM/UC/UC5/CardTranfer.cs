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

namespace M_ATM.UC.UC5
{
    public partial class CardTranfer : UserControl
    {
        public delegate void Tranfer(bool isContinue);
        public event Tranfer tranfer;

        private DanhsachKhachHang kh;
        private Danhsachtaikhoan tk;
        private Danhsachtaikhoan tkNhan = null;

        private bool IsVisible = false;

        private string mathe;
        private string maATM;
        private MainForm main;
        public CardTranfer(Danhsachtaikhoan tk, DanhsachKhachHang kh, string mathe, string maATM, MainForm main)
        {
            InitializeComponent();
            this.tk = tk;
            this.kh = kh;
            this.mathe = mathe;
            this.maATM = maATM;
            this.main = main;
            main.btnChange += Main_btnChange;
            main.delete_Text += Main_delete_Text;
            main.btn_ok += Main_btn_ok;
        }

        private void Main_btn_ok()
        {
            SetData();
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

        private void CardTranfer_Load(object sender, EventArgs e)
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

        public void ResetData()
        {
            textBox1.Text = string.Empty;
            textBox2.Text = string.Empty;
            tkNhan = null;
            Cardpanel.Visible = true;
            PassPanel.Visible = false;
            IsVisible = false;
            btnOk.Text = "Kiểm tra";

        }

        void SetData()
        {
            if (Cardpanel.Visible)
            {
                if (!string.IsNullOrEmpty(textBox1.Text))
                {

                    if (DanhSachTaiKhoan_BUL.Instance.KiemTraTaiKhoan(textBox1.Text, out tkNhan))
                    {
                        IsVisible = true;
                        Cardpanel.Visible = false;
                        PassPanel.Visible = true;
                        btnOk.Text = "Chuyển tiền";
                    }
                    else
                    {
                        MessageBox.Show("Đã xảy ra lỗi trong quá trình xử lý.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    MessageBox.Show("Tài khoản không có trong hệ thống.", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            else
            {
                if (tkNhan != null)
                {
                    if (!string.IsNullOrEmpty(textBox2.Text))
                    {
                        double slTien = 0;
                        if (double.TryParse(textBox2.Text, out slTien))
                        {
                            if (DanhSachTaiKhoan_BUL.Instance.SoTienCoTrongTaiKhoan(tk.Mataikhoan) >= slTien)
                            {
                                //Cho phep chuyen khoan
                                if (DanhSachTaiKhoan_BUL.Instance.ChuyenKhoan(tkNhan.Mataikhoan, tk.Mataikhoan, slTien) > 0)
                                {

                                    GhiGiaoDich ghi = new GhiGiaoDich();
                                    ghi.Ngaygiaodich = DateTime.Now;
                                    ghi.MoTaGD = "Chuyển khoản";
                                    ghi.SoTheATM = mathe;
                                    ghi.MaATM = maATM;
                                    ghi.Malog = "Log02";
                                    ghi.SotheATMnhanTien = "";
                                    DanhsachtheATM ds = DanhSachTheATM_BUL.Instance.LayThongTin(tk.Mataikhoan);
                                    if (ds != null)
                                    {
                                        ghi.SotheATMnhanTien = ds.SoTheATM;
                                    }
                                    ghi.KhoanTienGD = slTien;

                                    GhiGiaoDich_BUL.Instance.TaoMoiBanGhi(ghi);
                                    ResetData();
                                    if (tranfer != null)
                                    {
                                        tranfer(true);
                                    }
                                }
                                else
                                {
                                    MessageBox.Show("Đã xảy ra lỗi trong quá trình xử lý.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                }
                            }
                            else
                            {
                                MessageBox.Show("Số tiền còn lại trong tài khoản không đủ để thực hiện giao dịch.", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            }
                        }
                        else
                        {
                            MessageBox.Show("Định dạng dữ liệu sai.", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                    }
                    else
                    {
                        MessageBox.Show("Không được để trống trường này.", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
            }
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            SetData();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            if(tranfer != null)
            {
                tranfer(false);
            }
        }
    }
}
