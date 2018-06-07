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

namespace M_ATM.UC.UC3
{
    public partial class CheckBanlance : UserControl
    {
        public delegate void Continue_Click(bool isContinue);
        public event Continue_Click click;

        private DanhsachKhachHang kh;
        private Danhsachtaikhoan tk;

        private string the;
        private string maATM;
        public CheckBanlance(Danhsachtaikhoan tk, DanhsachKhachHang kh, string the, string maATM)
        {
            InitializeComponent();
            this.kh = kh;
            this.tk = tk;
            this.the = the;
            this.maATM = maATM;
        }

        public void loadData(Danhsachtaikhoan tk, DanhsachKhachHang kh, string the, string maATM)
        {
            this.kh = kh;
            this.tk = tk;
            this.the = the;
            this.maATM = maATM;

            string t = string.Format("Thông tin:\r\n-Chủ tài khoản: {0}\r\n- Số dư trong tài khoản: {1}", kh.Tenkhachhang, tk.SoTienConLaiTrongTK.ToString("c"));
            label1.Text = t;
        }

        private void CheckBanlance_Load(object sender, EventArgs e)
        {
            helloPanel.BackColor = Color.FromArgb(255, 255, 204, 55);
            GhiGiaoDich ghi = new GhiGiaoDich();
            ghi.Ngaygiaodich = DateTime.Now;
            ghi.MoTaGD = "Vấn tin tài khoản";
            ghi.SoTheATM = the;
            ghi.MaATM = maATM;
            ghi.Malog = "Log03";
            ghi.SotheATMnhanTien = "";

            GhiGiaoDich_BUL.Instance.TaoMoiBanGhi(ghi);

            string t = string.Format("Thông tin:\r\n-Chủ tài khoản: {0}\r\n- Số dư trong tài khoản: {1}", kh.Tenkhachhang, tk.SoTienConLaiTrongTK.ToString("c"));
            label1.Text = t;

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
            if(click != null)
            {
                click(true);
            }
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            if (click != null)
            {
                click(false);
            }
        }
    }
}
