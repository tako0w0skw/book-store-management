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
