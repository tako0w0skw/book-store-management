using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class HoaDonDTO
    {
        public int MaHD { get; set; }
        public double TamTinh { get; set; }
        public double PhiVanChuyen { get; set; }
        public double TongTien { get; set; }
        public string PT_ThanhToan { get; set; }
        public string PT_GiaoHang { get; set; }
        public string SDT { get; set; }
        public string TrangThai { get; set; }
        public int MaKH { get; set; }
        public string MaKM { get; set; }
        public int MaNV { get; set; }
        public DateTime NgayLapHD { get; set; }

    }
}
