using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAO;
using DTO;

namespace BUS
{
    public class TacGiaBUS
    {
        public List<TacGiaDTO> LayDanhSachTacGia(int maTG = -1)
        {
            TacGiaDAO tacGiaDAO = new TacGiaDAO();
            return tacGiaDAO.LayDanhSachTacGia(maTG);
        }
    }
}
