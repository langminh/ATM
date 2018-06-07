using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;



namespace M_ATM.UC.UC4
{
    public partial class Popup : Form
    {
        private Temp temp;
        public Popup(Temp temp)
        {
            InitializeComponent();
            this.temp = temp;
        }

        private void Popup_Load(object sender, EventArgs e)
        {
            string a = string.Format("Thông tin: \r\n- Chủ tài khoản: {0} \r\n\r\nThông tin giao dịch:\r\n-Ngày giao dịch: {1}\r\n-Khoản  tiền giao dịch: {2}\r\n-Mã thẻ ATM nhận tiền: {3}\r\n-Loại giao dịch: {4}\r\n\r\nThông tin về ATM:\r\n-Tên chi nhánh: {5}\r\n-Vị trí: {6}",
                temp.TenKH, temp.NgayGD.ToString("dd/MM/yyyy"), temp.KhoantTienGD, temp.MaTheNhanTien, temp.LoaiGD, temp.tenChiNhanh, temp.ViTri);
            label2.Text = a;
        }
    }
}
