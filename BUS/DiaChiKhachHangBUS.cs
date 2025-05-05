using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;
using DAO;

namespace BUS
{
    public class DiaChiKhachHangBUS
    {
        private DiaChiKhachHangDAO diaChiKHDAO = new DiaChiKhachHangDAO();

        public List<DiaChiKhachHangDTO> LayDanhSachDiaChi(int? maDiaChi = null, int? maKH = null)
        {
            try
            {
                return diaChiKHDAO.LayDanhSachDiaChi(maDiaChi, maKH);
            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi khi lấy danh sách địa chỉ: " + ex.Message);
            }
        }

        public int ThemDiaChi(DiaChiKhachHangDTO dc)
        {
            if (string.IsNullOrWhiteSpace(dc.DiaChi))
                throw new Exception("Địa chỉ không được để trống");

            return diaChiKHDAO.ThemDiaChi(dc);
        }

        public int CapNhatDiaChi(DiaChiKhachHangDTO dc)
        {
            if (string.IsNullOrWhiteSpace(dc.DiaChi))
                throw new Exception("Địa chỉ không được để trống");

            return diaChiKHDAO.CapNhatDiaChi(dc);
        }

        public int XoaDiaChi(int maDiaChi)
        {
            return diaChiKHDAO.XoaDiaChi(maDiaChi);
        }
    }
}
