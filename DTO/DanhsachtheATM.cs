using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class DanhsachtheATM
    {
        public string SoTheATM { get; set; }

        public int MaPin { get; set; }

        public string TrangThaiThe { get; set; }

        public string Mataikhoan { get; set; }

        public DateTime NgayCapThe { get; set; }

        public DateTime NgayHetHan { get; set; }

        public int SoLanNhapPin { get; set; }
    }
}
