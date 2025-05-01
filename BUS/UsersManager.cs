using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BUS
{
    public class UsersManager
    {
        public static Dictionary<string, string> Users = new Dictionary<string, string>()
        {
            {"admin", "123" } // tài khoản admin
        };

        public static bool KiemtraDangnhap(string username, string password)
        {
            return Users.ContainsKey(username) && Users[username] == password; // trả về true khi tồn tài username và pass tương ứng
        }

        public static bool KiemtraDangky(string username, string password)
        {
            if (Users.ContainsKey(username))
            {
                return false;
            }
            Users.Add(username, password); // thêm người dùng mới
            return true;
        }
    }
}
