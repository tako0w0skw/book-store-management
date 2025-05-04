using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;
using DAO;

namespace BUS
{
    public class ChiTietHoaDonBUS
    {
        public List<ChiTietHoaDonDTO> LayDanhSachChiTietHoaDon(int maHD = -1)
        {
            ChiTietHoaDonDAO chiTietHoaDonDAO = new ChiTietHoaDonDAO();
            return chiTietHoaDonDAO.LayDanhSachChiTietHoaDon(maHD);
        }

        public int ThemChiTietHoaDon(ChiTietHoaDonDTO chiTietHoaDon)
        {
            ChiTietHoaDonDAO chiTietHoaDonDAO = new ChiTietHoaDonDAO();
            return chiTietHoaDonDAO.ThemChiTietHoaDon(chiTietHoaDon);
        }
    }
}
