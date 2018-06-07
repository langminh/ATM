using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class ConfigDTO
    {
        public string MaConfig { get; set; }

        public DateTime ngaycapnhap { get; set; }

        public decimal? SoTienRutToiThieu { get; set; }

        public decimal? SoTienRutTrongNgay { get; set; }

        public int SoBanghi { get; set; }
    }
}
