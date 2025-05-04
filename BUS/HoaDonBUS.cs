using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAO;
using DTO;

namespace BUS
{
    public class HoaDonBUS
    {
        public List<HoaDonDTO> LayDanhSachHoaDon(int maHD = -1, int maNV = -1, int maKH = -1)
        {
            HoaDonDAO hoaDonDAO = new HoaDonDAO();
            return hoaDonDAO.LayDanhSachHoaDon(maHD, maNV, maKH);
        }

        public int ThemHoaDon(HoaDonDTO hoaDon)
        {
            HoaDonDAO hoaDonDAO = new HoaDonDAO();
            return hoaDonDAO.ThemHoaDon(hoaDon);
        }

        public HoaDonDTO LayHoaDonVuaTao()
        {
            HoaDonDAO hoaDonDAO = new HoaDonDAO();
            return hoaDonDAO.LayHoaDonVuaTao();
        }
    }
}
