using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAO
{
    public static class DataProvider
    {
        public static string strKetNoi = "Data Source=.;Initial Catalog=QuanLyPMBanSach;Integrated Security=True";

        public static SqlConnection TaoKetNoi()
        {
            try
            {
                return new SqlConnection(strKetNoi);
            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi kết nối đến cơ sở dữ liệu: " + ex.Message);
            }
        }

        public static SqlDataReader TruyVan(string query, SqlConnection strKetNoi)
        {
            try
            {
                return new SqlCommand(query, strKetNoi).ExecuteReader();
            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi truy vấn: " + ex.Message);
            }
        }

        public static int ThucThi(string query, SqlConnection strKetNoi)
        {
            try
            {
                return new SqlCommand(query, strKetNoi).ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi thực thi: " + ex.Message);
            }
        }

        public static SqlDataReader ExcuteProcedure(string procedureName, SqlConnection strKetNoi, SqlParameter[] parameters)
        {
            try
            {
                SqlCommand cmd = new SqlCommand(procedureName, strKetNoi);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                if (parameters != null)
                {
                    cmd.Parameters.AddRange(parameters);
                }
                return cmd.ExecuteReader();
            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi thực thi thủ tục: " + ex.Message);
            }
        }

        public static int ExcuteProcedureNonQuery(string procedureName, SqlConnection strKetNoi, SqlParameter[] parameters)
        {
            try
            {
                SqlCommand cmd = new SqlCommand(procedureName, strKetNoi);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                if (parameters != null)
                {
                    cmd.Parameters.AddRange(parameters);
                }
                return cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi thực thi thủ tục: " + ex.Message);
            }
        }

        public static int ExcuteProcedureScalar(string procedureName, SqlConnection strKetNoi, SqlParameter[] parameters)
        {
            try
            {
                SqlCommand cmd = new SqlCommand(procedureName, strKetNoi);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                if (parameters != null)
                {
                    cmd.Parameters.AddRange(parameters);
                }
                return Convert.ToInt32(cmd.ExecuteScalar());
            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi thực thi thủ tục: " + ex.Message);
            }
        }
    }
}
