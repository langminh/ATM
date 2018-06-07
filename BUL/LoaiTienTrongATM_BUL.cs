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
    public class LoaiTienTrongATM_BUL
    {
        private static LoaiTienTrongATM_BUL instance;

        public static LoaiTienTrongATM_BUL Instance
        {
            get { if (instance == null) instance = new LoaiTienTrongATM_BUL(); return LoaiTienTrongATM_BUL.instance; }
            private set { instance = value; }
        }

        public List<LoaiTienTrongATM> DanhSachLoaiTien(string maATM)
        {
            List<LoaiTienTrongATM> list = new List<LoaiTienTrongATM>();
            string query = @"SELECT [MacuabanghiStock]
      ,[SoLuongMoiLoaiTien]
      ,[MaATM]
      ,[MaTien]
  FROM[M_ATM].[dbo].[LoaiTienTrongATM] where MaATM = @ma";
            DataTable dt = DataProvider.Instance.ExcuteQuery(query, new object[] { maATM });
            if(dt.Rows.Count > 0)
            {
                foreach(DataRow row in dt.Rows)
                {
                    LoaiTienTrongATM loai = LayLoaiTien(row);
                    list.Add(loai);
                }
            }
            return list;
        }

        public LoaiTienTrongATM LayLoaiTien(DataRow dr)
        {
            LoaiTienTrongATM loaiTien = new LoaiTienTrongATM();
            loaiTien.MacuabanghiStock = dr[0].ToString();
            loaiTien.SoLuongMoiLoaiTien = int.Parse(dr[1].ToString());
            loaiTien.MaATM = dr[2].ToString();
            loaiTien.MaTien = dr[3].ToString();
            return loaiTien;
        }

        public LoaiTien LayMenhGiaTien(string maTien)
        {
            LoaiTien tien = new LoaiTien();
            string query = @"SELECT [MaTien]
      ,[GiaTriTien]
  FROM [M_ATM].[dbo].[LoaiTien] where MaTien = @ma";
            DataTable dt = DataProvider.Instance.ExcuteQuery(query, new object[] { maTien });
            if(dt.Rows.Count> 0)
            {
                tien.MaTien = dt.Rows[0][0].ToString();
                tien.GiaTriTien = int.Parse(dt.Rows[0][1].ToString());
            }
            return tien;
        }
    }
}
