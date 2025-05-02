using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class KhuyenMaiDTO
    {
        public string MaKM { get; set; }
        public string TenMa { get; set; }
        public string LoaiGiam { get; set; }
        public double MucGiam { get; set; }
        public int SoLuong { get; set; }
        public int LuotSuDung { get; set; }
        public DateTime NgayBatDau { get; set; }
        public DateTime NgayKetThuc { get; set; }
        public string TrangThai { get; set; }
        public int MaNV { get; set; }
    }
}
