using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using DTO;
using DAL;
using System.Data;

namespace BUL
{
    public class DanhSachTaiKhoan_BUL
    {
        private static DanhSachTaiKhoan_BUL instance;

        public static DanhSachTaiKhoan_BUL Instance
        {
            get { if (instance == null) instance = new DanhSachTaiKhoan_BUL(); return DanhSachTaiKhoan_BUL.instance; }
            private set { instance = value; }
        }

        public int RutTien(string maTaiKhoan, double soTien)
        {
            string query = @"exec sb_UpdateMoney  @maTK , @slTien ";
            return DataProvider.Instance.ExcuteNonQuery(query, new object[] { maTaiKhoan, soTien });
        }

        public double SoTienCoTrongTaiKhoan(string maTaiKhoan)
        {
            double soTien = -1;
            string query = @"select SoTienConLaiTrongTK from Danhsachtaikhoan where Mataikhoan = @matk ";
            DataTable dt = DataProvider.Instance.ExcuteQuery(query, new object[] { maTaiKhoan });
            if(dt.Rows.Count > 0)
            {
                soTien = double.Parse(dt.Rows[0][0].ToString());
            }
            return soTien;
        }

        public int ChuyenKhoan(string maTKNhan, string maTKChuyen, double slTien)
        {
            string query = "exec sb_UpdateMoneyTranfer @maTKNhan , @maTKChuyen , @slTien ";
            return DataProvider.Instance.ExcuteNonQuery(query, new object[] { maTKNhan, maTKChuyen, slTien });
        }

        public bool KiemTraTaiKhoan(string MaTaiKhoan, out Danhsachtaikhoan tk)
        {
            string query = @" select [Mataikhoan]
      ,[Makhachhang]
      ,[MaMucThauChi]
      ,[MaGioiHanRut]
      ,[SoTienConLaiTrongTK]
  FROM [M_ATM].[dbo].[Danhsachtaikhoan] where Mataikhoan = @matk";
            DataTable dt = DataProvider.Instance.ExcuteQuery(query, new object[] { MaTaiKhoan });
            if (dt.Rows.Count > 0)
            {
                tk = new Danhsachtaikhoan();
                tk.Mataikhoan = dt.Rows[0][0].ToString();
                tk.Makhachhang = dt.Rows[0][1].ToString();
                tk.MaMucThauChi = dt.Rows[0][2].ToString();
                tk.MaGioiHanRut = dt.Rows[0][3].ToString();
                tk.SoTienConLaiTrongTK = decimal.Parse(dt.Rows[0][4].ToString());
                return true;
            }
            else
            {
                tk = null;
                return false;
            }
        }

        public Danhsachtaikhoan LayThongTinTaiKhoan(string MaTaiKhoan)
        {
            Danhsachtaikhoan tk = new Danhsachtaikhoan();
            string query = @" select [Mataikhoan]
      ,[Makhachhang]
      ,[MaMucThauChi]
      ,[MaGioiHanRut]
      ,[SoTienConLaiTrongTK]
  FROM [M_ATM].[dbo].[Danhsachtaikhoan] where Mataikhoan = @matk";
            DataTable dt = DataProvider.Instance.ExcuteQuery(query, new object[] { MaTaiKhoan });
            if (dt.Rows.Count > 0)
            {
                tk.Mataikhoan = dt.Rows[0][0].ToString();
                tk.Makhachhang = dt.Rows[0][1].ToString();
                tk.MaMucThauChi = dt.Rows[0][2].ToString();
                tk.MaGioiHanRut = dt.Rows[0][3].ToString();
                tk.SoTienConLaiTrongTK = decimal.Parse(dt.Rows[0][4].ToString());
            }
            return tk;
        }
    }
}
