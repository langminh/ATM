using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


using DTO;
using System.Reflection;

namespace M_ATM.UC.UC2
{
    public partial class WithDraw : UserControl
    {
        public delegate void SetMoneyToDraw(string money);
        public event SetMoneyToDraw SetMoney;

        private Danhsachtaikhoan tk;
        private DanhsachKhachHang kh;

        public WithDraw(Danhsachtaikhoan tk, DanhsachKhachHang kh)
        {
            InitializeComponent();
            this.tk = tk;
            this.kh = kh;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
        }

        private void WithDraw_Load(object sender, EventArgs e)
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

        private void button1_Click(object sender, EventArgs e)
        {
            if(SetMoney != null)
            {
                SetMoney(button1.Text);
            }
        }

        private void btn500_Click(object sender, EventArgs e)
        {
            if (SetMoney != null)
            {
                SetMoney(btn500.Text);
            }
        }

        private void btn1000_Click(object sender, EventArgs e)
        {
            if (SetMoney != null)
            {
                SetMoney(btn1000.Text);
            }
        }

        private void btn1500_Click(object sender, EventArgs e)
        {
            if (SetMoney != null)
            {
                SetMoney(btn1500.Text);
            }
        }

        private void btn2000_Click(object sender, EventArgs e)
        {
            if (SetMoney != null)
            {
                SetMoney(btn2000.Text);
            }
        }

        private void btnOther_Click(object sender, EventArgs e)
        {
            if (SetMoney != null)
            {
                SetMoney("none");
            }
        }
    }
}
