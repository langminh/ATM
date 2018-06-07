using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using DAL;
using DTO;

namespace BUL
{
    public class KhachHang_BUL
    {
        private static KhachHang_BUL instance;

        public static KhachHang_BUL Instance
        {
            get { if (instance == null) instance = new KhachHang_BUL(); return KhachHang_BUL.instance; }
            private set { instance = value; }
        }

        public DanhsachKhachHang LayThongTinKhachHang(string maKhachHang)
        {
            DanhsachKhachHang kh = new DanhsachKhachHang();
            string query = @"select [Makhachhang]
      ,[Tenkhachhang]
      ,[Sodienthoai]
      ,[Email]
      ,[DiaChi]
  FROM [M_ATM].[dbo].[DanhsachKhachHang] where Makhachhang = @makh";
            DataTable dt = DataProvider.Instance.ExcuteQuery(query, new object[] { maKhachHang });
            if(dt.Rows.Count > 0)
            {
                kh.Makhachhang = dt.Rows[0][0].ToString();
                kh.Tenkhachhang = dt.Rows[0][1].ToString();
                kh.Sodienthoai = int.Parse(dt.Rows[0][2].ToString());
                kh.Email = dt.Rows[0][3].ToString();
                kh.DiaChi = dt.Rows[0][4].ToString();
            }
            return kh;
        }
    }
}
