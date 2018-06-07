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
    public class ATM_BUL
    {
        private static ATM_BUL instance;

        public static ATM_BUL Instance
        {
            get { if (instance == null) instance = new ATM_BUL(); return ATM_BUL.instance; }
            private set { instance = value; }
        }

        public ATM LayThongTinMayATM(string maATM)
        {
            ATM atm = new ATM();
            string query = @"SELECT [MaATM]
      ,[TenChiNhanh]
      ,[ViTriATM]
  FROM [M_ATM].[dbo].[ATM] where MaATM = @ma";
            DataTable dt = DataProvider.Instance.ExcuteQuery(query, new object[] { maATM });
            if(dt.Rows.Count > 0)
            {
                atm.MaATM = dt.Rows[0][0].ToString();
                atm.TenChiNhanh = dt.Rows[0][1].ToString();
                atm.ViTriATM = dt.Rows[0][2].ToString();
            }
            return atm;
        }
    }
}
