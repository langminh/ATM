using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ATM
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            for (int i = 0; i < 12; i++)
            {
                if (i == 10)
                {
                    mainBtn.Controls.Add(InitButton(i, "0"));
                }
                else if (i == 9)
                {
                    mainBtn.Controls.Add(InitButton(i, "*"));
                }
                else if (i == 11)
                {
                    mainBtn.Controls.Add(InitButton(i, "#"));
                }
                else
                {
                    mainBtn.Controls.Add(InitButton(i, i.ToString()));
                }
            }
        }

        private Button InitButton(int n, string name)
        {
            Button b = new Button();
            b.Name = n.ToString();
            b.Width = 62;
            b.Height = 62;
            b.Text = name;
            b.Click += B_Click;
            return b;
        }

        private void B_Click(object sender, EventArgs e)
        {
            Button b = (Button)sender;
            MessageBox.Show(b.Name.ToString());
        }
    }
}
