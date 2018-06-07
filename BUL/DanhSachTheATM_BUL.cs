
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
    public class DanhSachTheATM_BUL
    {
        private static DanhSachTheATM_BUL instance;

        public static DanhSachTheATM_BUL Instance
        {
            get { if (instance == null) instance = new DanhSachTheATM_BUL(); return DanhSachTheATM_BUL.instance; }
            private set { instance = value; }
        }

        public DanhsachtheATM LayThongTin(string maTaiKhoan)
        {
            string query = @"SELECT [SoTheATM]
      ,[MaPin]
      ,[TrangThaiThe]
      ,[Mataikhoan]
      ,[NgayCapThe]
      ,[NgayHetHan]
      ,[SoLanNhapPin]
  FROM [M_ATM].[dbo].[DanhsachtheATM] where Mataikhoan = @mathe ";
            try
            {
                DataTable dt = DataProvider.Instance.ExcuteQuery(query, new object[] { maTaiKhoan });
                if (dt.Rows.Count > 0)
                {
                    return LayThongTinThe(dt);
                }
                else
                {
                    return null;
                }
            }
            catch { return null; }
        }

        public int DoiMaPIN(string mathe, int matkhau)
        {
            string query = @"UPDATE [dbo].[DanhsachtheATM] SET [MaPin] = @matkhau WHERE [SoTheATM] = @sothe ";
            return DataProvider.Instance.ExcuteNonQuery(query, new object[] { matkhau, mathe });
        }

        public bool KiemTraThongTin(string MaThe, out DanhsachtheATM _obj)
        {
            string query = @"select [SoTheATM]
      ,[MaPin]
      ,[TrangThaiThe]
      ,[Mataikhoan]
      ,[NgayCapThe]
      ,[NgayHetHan]
      ,[SoLanNhapPin] from DanhsachtheATM where SoTheATM = @mathe";
            DataTable dt = DataProvider.Instance.ExcuteQuery(query, new object[] { MaThe });
            if(dt.Rows.Count > 0)
            {
                _obj = LayThongTinThe(dt);
                return true;
            }
            else
            {
                _obj = null;
                return false;
            }
        }

        public DanhsachtheATM LayThongTinThe(DataTable dt)
        {
            DanhsachtheATM ds = new DanhsachtheATM();
            ds.SoTheATM = dt.Rows[0][0].ToString();
            ds.MaPin = int.Parse(dt.Rows[0][1].ToString());
            ds.TrangThaiThe = dt.Rows[0][2].ToString();
            ds.Mataikhoan = dt.Rows[0][3].ToString();
            ds.NgayCapThe = DateTime.Parse(dt.Rows[0][4].ToString());
            ds.NgayHetHan = DateTime.Parse(dt.Rows[0][5].ToString());
            ds.SoLanNhapPin = int.Parse(dt.Rows[0][6].ToString());
            return ds;
        }

    }
}
