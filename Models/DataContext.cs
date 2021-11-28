using System.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LAB05.Models
{
    public class DataContext
    {
        public string ConnectionString { get; set; }
        public DataContext(string connectionString)
        {
            this.ConnectionString = connectionString;
        }
        private SqlConnection GetConnection()
        {
            return new SqlConnection(ConnectionString);
        }

        public int sqlInsertCanHo(CanHoModel canho)
        {
            using(SqlConnection conn = GetConnection())
            {
                conn.Open();
                var str = "insert into CANHO values (@macanho, @tenchuho)";
                SqlCommand cmd = new SqlCommand(str, conn);
                cmd.Parameters.AddWithValue("macanho", canho.MaCanHo);
                cmd.Parameters.AddWithValue("tenchuho", canho.TenChuHo);
                return (cmd.ExecuteNonQuery());
            }
        }

        /* -----------------------------
         *  SQL TABLE QUANLYNHANVIEN
         *--------------------------------*/
        public List<NhanVienModel> sqlListNhanVien()
        {
            List<NhanVienModel> list = new List<NhanVienModel>();
            using (SqlConnection conn = GetConnection())
            {
                conn.Open();
                string str = @"SELECT * FROM NHANVIEN";
                SqlCommand cmd = new SqlCommand(str, conn);
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        list.Add(new NhanVienModel()
                        {
                            MaNhanVien = reader["manhanvien"].ToString(),
                            TenNhanVien = reader["tennhanvien"].ToString(),
                            SoDienThoai = reader["sodienthoai"].ToString(),
                            GioiTinh = Convert.ToBoolean(reader["gioitinh"])
                        });
                    }
                    reader.Close();
                }
                conn.Close();
            }
            return list;
        }
        public List<object> sqlListByTimeNhanVien(int soLan)
        {
            List<object> list = new List<object>();
            using (SqlConnection conn = GetConnection())
            {
                conn.Open();
                string str = @"select nv.manhanvien, nv.sodienthoai, count(*) AS SoLan
                                from nhanvien nv join nv_bt on nv.manhanvien = nv_bt.manhanvien 
                                group by nv.manhanvien, nv.sodienthoai
                                having count(*) >= @SoLanInput";
                SqlCommand cmd = new SqlCommand(str, conn);
                cmd.Parameters.AddWithValue("SoLanInput", soLan);
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        list.Add(new
                        {
                            MaNV = reader["manhanvien"].ToString(),
                            SoDT = reader["sodienthoai"].ToString(),
                            SoLan = Convert.ToInt32(reader["SoLan"])
                        });
                    }
                    reader.Close();
                }
                conn.Close();
            }
            return list;
        }
    }
}
