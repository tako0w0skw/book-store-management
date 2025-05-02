using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace DTO
{
    public class SachDTO
    {
        public int MaSach { get; set; }
        public string HinhAnh { get; set; }
        public string TenSach { get; set; }
        public double Gia { get; set; }
        public int SoLuongTon { get; set; }
        public string NhaXuatBan { get; set; }
        public string MoTa { get; set; }
        public int SoTrang { get; set; }
        public DateTime NgayPhatHanh { get; set; }
        public string DichGia { get; set; }
        public string MaKM { get; set; }
        public string TrangThai { get; set; }
    }
}
