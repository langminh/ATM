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

namespace M_ATM.UC.UC2
{
    public partial class Final_UC : UserControl
    {
        public delegate void ClickToFinish(bool isContinue);
        public event ClickToFinish click_Finish;

        private DanhsachKhachHang kh;
        private Danhsachtaikhoan tk;
        public Final_UC(Danhsachtaikhoan tk, DanhsachKhachHang kh)
        {
            InitializeComponent();
            this.kh = kh;
            this.tk = tk;
        }

        private void Final_UC_Load(object sender, EventArgs e)
        {
            helloPanel.BackColor = Color.FromArgb(255, 255, 204, 55);
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

        private void btn500_Click(object sender, EventArgs e)
        {
            if(click_Finish != null)
            {
                click_Finish(true);
            }
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            click_Finish(false);
        }
    }
}
