using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAO;
using DTO;

namespace BUS
{
    public class KhachHangBUS
    {
        public List<KhachHangDTO> LayDanhSachKhachHang(int maKH = -1)
        {
            KhachHangDAO khachHangDAO = new KhachHangDAO();
            return khachHangDAO.LayDanhSachKhachHang(maKH);
        }

        public int ThemKhachHang(KhachHangDTO kh)
        {
            KhachHangDAO khachHangDAO = new KhachHangDAO();
            return khachHangDAO.ThemKhachHang(kh);
        }

        public int CapNhatKhachHang(KhachHangDTO kh)
        {
            KhachHangDAO khachHangDAO = new KhachHangDAO();
            return khachHangDAO.CapNhatKhachHang(kh);
        }

        public int XoaKhachHang(int maKH)
        {
            KhachHangDAO khachHangDAO = new KhachHangDAO();
            return khachHangDAO.XoaKhachHang(maKH);
        }
    }
}
