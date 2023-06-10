using DAO;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DAL
{
    public class PhongBan_DAL
    {
        XuLyDuLieu xldl = new XuLyDuLieu();

        public DataTable layDuLieuTuBang(string tenBang)
        {
            try
            {
                DataTable dt = new DataTable();
                SqlCommand sqlcmd = new SqlCommand("sp_layDuLieuTuBang", xldl.SqlCon);
                sqlcmd.CommandType = CommandType.StoredProcedure;
                sqlcmd.Parameters.AddWithValue("@tenBang", tenBang);
                SqlDataAdapter sqlAdap = new SqlDataAdapter(sqlcmd);
                sqlAdap.Fill(dt);
                return dt;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public bool themPhongBan(PhongBan_DAO phongBan)
        {
            int result = -1;
            SqlCommand sqlcmd = new SqlCommand("sp_themPhongBan", xldl.SqlCon);
            sqlcmd.CommandType = CommandType.StoredProcedure;
            sqlcmd.Parameters.AddWithValue("@maPhong", phongBan.MaPhong);
            sqlcmd.Parameters.AddWithValue("@tenPhong", phongBan.TenPhong);
            sqlcmd.Parameters.AddWithValue("@maBoPhan", phongBan.MaBoPhan);

            try
            {
                if (sqlcmd.ExecuteNonQuery() >= 0)
                {
                    result = 0;
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Lỗi kết nối");
            }
            return result == 0;
        }

        public bool xoaPhongBan(string maPhong)
        {
            int result = -1;
            SqlCommand sqlcmd = new SqlCommand("sp_xoaPhongBan", xldl.SqlCon);
            sqlcmd.CommandType = CommandType.StoredProcedure;
            sqlcmd.Parameters.AddWithValue("@maPhong", maPhong);

            try
            {
                if (sqlcmd.ExecuteNonQuery() >= 0)
                {
                    result = 0;
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Lỗi kết nối");
            }
            return result == 0;
        }

        public bool suaPhongBan(PhongBan_DAO phongBan)
        {
            int result = -1;
            SqlCommand sqlcmd = new SqlCommand("sp_suaPhongBan", xldl.SqlCon);
            sqlcmd.CommandType = CommandType.StoredProcedure;
            sqlcmd.Parameters.AddWithValue("@maPhong", phongBan.MaPhong);
            sqlcmd.Parameters.AddWithValue("@tenPhong", phongBan.TenPhong);
            sqlcmd.Parameters.AddWithValue("@maBoPhan", phongBan.MaBoPhan);

            try
            {
                if (sqlcmd.ExecuteNonQuery() >= 0)
                {
                    result = 0;
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Lỗi kết nối");
            }
            return result == 0;
        }

        public DataTable timKiemPhongBan(string noiDung, string tieuChi)
        {
            try
            {
                if (tieuChi == "Mã phòng")
                {
                    DataTable dt = new DataTable();
                    SqlCommand sqlcmd = new SqlCommand("sp_timKiemPhongBanTheoMaPhong", xldl.SqlCon);
                    sqlcmd.CommandType = CommandType.StoredProcedure;
                    sqlcmd.Parameters.AddWithValue("@maPhong", noiDung);
                    SqlDataAdapter sqlAdap = new SqlDataAdapter(sqlcmd);
                    sqlAdap.Fill(dt);
                    return dt;
                }
                else if (tieuChi == "Tên phòng")
                {
                    DataTable dt = new DataTable();
                    SqlCommand sqlcmd = new SqlCommand("sp_timKiemPhongBanTheoTen", xldl.SqlCon);
                    sqlcmd.CommandType = CommandType.StoredProcedure;
                    sqlcmd.Parameters.AddWithValue("@tenPhong", noiDung);
                    SqlDataAdapter sqlAdap = new SqlDataAdapter(sqlcmd);
                    sqlAdap.Fill(dt);
                    return dt;
                }
                else if (tieuChi == "Mã bộ phận")
                {
                    DataTable dt = new DataTable();
                    SqlCommand sqlcmd = new SqlCommand("sp_timKiemPhongBanTheoMaBoPhan", xldl.SqlCon);
                    sqlcmd.CommandType = CommandType.StoredProcedure;
                    sqlcmd.Parameters.AddWithValue("@maBoPhan", noiDung);
                    SqlDataAdapter sqlAdap = new SqlDataAdapter(sqlcmd);
                    sqlAdap.Fill(dt);
                    return dt;
                }
            }
            catch (Exception)
            {
                throw;
            }
            return null;
        }
    }
}
