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
        public int ThemChiTietHoaDon(ChiTietHoaDonDTO chiTietHoaDon)
        {
            ChiTietHoaDonDAO chiTietHoaDonDAO = new ChiTietHoaDonDAO();
            return chiTietHoaDonDAO.ThemChiTietHoaDon(chiTietHoaDon);
        }
    }
}
