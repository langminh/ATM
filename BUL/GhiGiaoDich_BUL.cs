using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using DTO;
using DAL;

namespace BUL
{
    public class GhiGiaoDich_BUL
    {
        private static GhiGiaoDich_BUL instance;

        public static GhiGiaoDich_BUL Instance
        {
            get { if (instance == null) instance = new GhiGiaoDich_BUL(); return GhiGiaoDich_BUL.instance; }
            private set { instance = value; }
        }

        public int TaoMoiBanGhi(GhiGiaoDich ghi)
        {
            string logID = DataProvider.Instance.GetValueFunction("select  dbo.fn_GetLog()");
            ghi.MaBanghiLog = logID;
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
           ( @malogID , @ngayGD , @soTien , @moTa , @maATMNhan , @maThe , @maLog , @maATM_ )";
            return DataProvider.Instance.ExcuteNonQuery(query, new object[] { ghi.MaBanghiLog, ghi.Ngaygiaodich,
                ghi.KhoanTienGD, ghi.MoTaGD, ghi.SotheATMnhanTien, ghi.SoTheATM, ghi.Malog, ghi.MaATM});
        }
    }
}
