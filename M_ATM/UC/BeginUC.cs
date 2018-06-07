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

namespace M_ATM.UC
{
    public partial class BeginUC : UserControl
    {
        public delegate void ClickToLogin();
        public event ClickToLogin click;

        public BeginUC()
        {
            InitializeComponent();
        }

        private void MainUC_Load(object sender, EventArgs e)
        {
            var images = typeof(Properties.Resources)
               .GetProperties(BindingFlags.Static | BindingFlags.NonPublic |
                                                    BindingFlags.Public)
               .Where(p => p.PropertyType == typeof(Bitmap))
               .Select(x => new { Name = x.Name, Image = x.GetValue(null, null) })
               .ToList();

            this.BackgroundImage = (Image)images[1].Image;
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

        private void MainUC_MouseClick(object sender, MouseEventArgs e)
        {
            if(click != null)
            {
                click();
            }
        }
    }
}
