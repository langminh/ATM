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
using BUL;

namespace M_ATM.UC.UC4
{
    public partial class ViewHistory : UserControl
    {
        public delegate void Continue_Click(bool isContinue);
        public event Continue_Click click;

        private DanhsachKhachHang kh;
        private Danhsachtaikhoan tk;
        private string mathe;
        private string maATM;
        public ViewHistory(Danhsachtaikhoan tk, DanhsachKhachHang kh, string mathe, string maATM)
        {
            InitializeComponent();
            this.kh = kh;
            this.tk = tk;
            this.mathe = mathe;
            this.maATM = maATM;
        }

        private void ViewHistory_Load(object sender, EventArgs e)
        {

            label1.Text = string.Format("Thông tin:\r\n-Chủ tài khoản: {0}", kh.Tenkhachhang);
            dataGridView1.DataSource = LichSuGiaoDich_BUL.Instance.LayMauBanGhi(mathe);
            dataGridView1.Columns[0].Visible = false;
            dataGridView1.ChinhTieuDeDataGridView(new string[] { "", "Ngày giao dịch", "Khoản tiền", "Mô tả giao dịch", "Tên giao dịch" });
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if(dataGridView1.SelectedRows.Count > 0)
            {
                DataGridViewRow row = dataGridView1.SelectedRows[0];
                string a = row.Cells[0].Value.ToString();
                Temp temp = new Temp();
                ViewModel model = LichSuGiaoDich_BUL.Instance.LayThongTinBanGhi(a);
                temp.TenKH = kh.Tenkhachhang;
                temp.KhoantTienGD = model.KhoanTienGiaoDich;
                temp.LoaiGD = model.LoaiGD;
                temp.MaTheNhanTien = model.MaTheATMNhan;
                temp.NgayGD = model.NgayGiaoDich;
                temp.tenChiNhanh = model.TenChiNhanh;
                temp.ViTri = model.ViTri;
                new Popup(temp).ShowDialog();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (click != null)
            {
                click(true);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (click != null)
            {
                click(false);
            }
        }
    }
}
