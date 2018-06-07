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

namespace M_ATM.UC
{
    public partial class MainUC : UserControl
    {
        private DanhsachKhachHang kh;
        private Danhsachtaikhoan tk;

        public delegate void ButtonRuttien();
        public event ButtonRuttien rutten;
        public delegate void ButtonCheckBalance();
        public event ButtonCheckBalance checkBalance;
        public delegate void ButtonHistory();
        public event ButtonHistory history;
        public delegate void ButtonChangePIN();
        public event ButtonChangePIN changePIN;
        public delegate void ButtonTranfer();
        public event ButtonTranfer cardTranfer;
        public delegate void ExitApp();
        public event ExitApp exit;

        public MainUC(Danhsachtaikhoan tk, DanhsachKhachHang kh)
        {
            InitializeComponent();

            this.kh = kh;
            this.tk = tk;

            helloPanel.BackColor = Color.FromArgb(255, 255, 204, 55);
        }

        private void MainUC_Load(object sender, EventArgs e)
        {
            var images = typeof(Properties.Resources)
               .GetProperties(BindingFlags.Static | BindingFlags.NonPublic |
                                                    BindingFlags.Public)
               .Where(p => p.PropertyType == typeof(Bitmap))
               .Select(x => new { Name = x.Name, Image = x.GetValue(null, null) })
               .ToList();
            Random r = new Random();
            int i = r.Next(0, images.Count - 1);

            this.BackgroundImage = (Image)images[i].Image;

            label1.Text = "Xin chào " + kh.Tenkhachhang;

            timer1.Start();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
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

        private void btnRutTien_Click(object sender, EventArgs e)
        {
            if (rutten != null)
            {
                rutten();
            }
        }

        private void btnVanTinTaiKhoan_Click(object sender, EventArgs e)
        {
            if (checkBalance != null)
            {
                checkBalance();
            }
        }

        private void btnXemLichSu_Click(object sender, EventArgs e)
        {
            if(history != null)
            {
                history();
            }
        }

        private void btnDoiMaPin_Click(object sender, EventArgs e)
        {
            if(changePIN != null)
            {
                changePIN();
            }
        }

        private void btnChuyenKhoan_Click(object sender, EventArgs e)
        {
            if(cardTranfer != null)
            {
                cardTranfer();
            }
        }

        private void button7_Click(object sender, EventArgs e)
        {
            if(exit != null)
            {
                exit();
            }
        }
    }
}
