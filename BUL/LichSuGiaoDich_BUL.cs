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
    public class LichSuGiaoDich_BUL
    {
        private static LichSuGiaoDich_BUL instance;

        public static LichSuGiaoDich_BUL Instance
        {
            get { if (instance == null) instance = new LichSuGiaoDich_BUL(); return LichSuGiaoDich_BUL.instance; }
            private set { instance = value; }
        }

        public DataTable LayMauBanGhi(string mathe)
        {
            string query = @"SELECT [MaBanghiLog]
      ,[Ngaygiaodich]
      ,[KhoanTienGD]
      ,[MoTaGD]
      ,LoaiLog.TenLog
  FROM [M_ATM].[dbo].[GhiGiaoDich] 
  inner join LoaiLog on LoaiLog.Malog = GhiGiaoDich.Malog inner join ATM on ATM.MaATM = GhiGiaoDich.MaATM
    where SoTheATM = @ma ";
            return DataProvider.Instance.ExcuteQuery(query, new object[] { mathe });
        }

        public ViewModel LayThongTinBanGhi(string maBanGhi)
        {
            ViewModel temp = new ViewModel();
            DataTable dt = LayLichSuGiaoDich(maBanGhi);
            if(dt.Rows.Count > 0)
            {
                temp.NgayGiaoDich = DateTime.Parse(dt.Rows[0][1].ToString());
                temp.KhoanTienGiaoDich = double.Parse(dt.Rows[0][2].ToString());
                temp.MaTheATMNhan = dt.Rows[0][4].ToString();
                temp.LoaiGD = dt.Rows[0][6].ToString();
                temp.TenChiNhanh = dt.Rows[0][7].ToString();
                temp.ViTri = dt.Rows[0][8].ToString();
            }
            return temp;
        }

        public DataTable LayLichSuGiaoDich(string malog)
        {
            string query = @"SELECT [MaBanghiLog]
      ,[Ngaygiaodich]
      ,[KhoanTienGD]
      ,[MoTaGD]
      ,[SotheATMnhanTien]
      ,[SoTheATM]
      ,LoaiLog.TenLog
      ,ATM.TenChiNhanh,
	  ATM.ViTriATM
  FROM [M_ATM].[dbo].[GhiGiaoDich] 
  inner join LoaiLog on LoaiLog.Malog = GhiGiaoDich.Malog inner join ATM on ATM.MaATM = GhiGiaoDich.MaATM
    where MaBanghiLog = @ma ";
            return DataProvider.Instance.ExcuteQuery(query, new object[] { malog });
        }

        public int GhiLog(GhiGiaoDich giaoDich)
        {
            string query = @"INSERT INTO [dbo].[GhiGiaoDich]
           ([MaBanghiLog]
           ,[Ngaygiaodich]
           ,[KhoanTienGD]
           ,[MoTaGD]
           ,[SotheATMnhanTien]
           ,[SoTheATM]
           ,[Malog]
           ,[MaATM])
     VALUES
           ( @mabangi 
            , @ngaygd 
           , @khoantien 
           , @mota 
           , @sothenhan 
           , @sothe 
           , @maLog 
           , @maatm )";
            return DataProvider.Instance.ExcuteNonQuery(query, new object[] { giaoDich.MaBanghiLog, giaoDich.Ngaygiaodich,
                giaoDich.KhoanTienGD, giaoDich.SotheATMnhanTien, giaoDich.SoTheATM, giaoDich.Malog, giaoDich.MaATM});

        }
    }
}
