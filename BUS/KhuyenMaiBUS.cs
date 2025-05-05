using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAO;
using DTO;

namespace BUS
{
    public class KhuyenMaiBUS
    {
        private KhuyenMaiDAO khuyenMaiDAO = new KhuyenMaiDAO();

        public List<KhuyenMaiDTO> LayDanhSachKhuyenMai(string maKM = null, int maNV = -1, string loaiGiam = null)
        {
            KhuyenMaiDAO khuyenMaiDAO = new KhuyenMaiDAO();
            return khuyenMaiDAO.LayDanhSachKhuyenMai(maKM, maNV, loaiGiam);
        }

        public int ThemKhuyenMai(KhuyenMaiDTO km)
        {
            // Validate dữ liệu
            if (string.IsNullOrWhiteSpace(km.MaKM))
                throw new Exception("Mã khuyến mãi không được để trống");

            if (string.IsNullOrWhiteSpace(km.TenMa))
                throw new Exception("Tên mã không được để trống");

            if (km.NgayKetThuc < DateTime.Today)
                throw new Exception("Ngày kết thúc không được nhỏ hơn ngày hiện tại");

            return khuyenMaiDAO.ThemKhuyenMai(km);
        }

        public int CapNhatKhuyenMai(KhuyenMaiDTO km)
        {
            // Validate dữ liệu
            if (string.IsNullOrWhiteSpace(km.TenMa))
                throw new Exception("Tên mã không được để trống");

            if (km.NgayKetThuc < DateTime.Today)
                throw new Exception("Ngày kết thúc không được nhỏ hơn ngày hiện tại");

            return khuyenMaiDAO.CapNhatKhuyenMai(km);
        }

        public int XoaKhuyenMai(string maKM)
        {
            return khuyenMaiDAO.XoaKhuyenMai(maKM);
        }
    }
}
