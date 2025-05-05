using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class DiaChiKhachHangDTO
    {
        public int MaDiaChi { get; set; }
        public int? MaKH { get; set; }
        public string DiaChi { get; set; }

        public DiaChiKhachHangDTO() { }

        public DiaChiKhachHangDTO(int maDiaChi, int? maKH, string diaChi)
        {
            MaDiaChi = maDiaChi;
            MaKH = maKH;
            DiaChi = diaChi;
        }
    }
}
