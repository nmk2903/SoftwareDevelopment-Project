using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DAO;

namespace DAL
{
    public class NguoiDung_DAL
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

        public bool themNguoiDung(NguoiDung_DAO nguoiDung)
        {
            int result = -1;
            SqlCommand sqlcmd = new SqlCommand("sp_themNguoiDung", xldl.SqlCon);
            sqlcmd.CommandType = CommandType.StoredProcedure;
            sqlcmd.Parameters.AddWithValue("@maNhanVien", nguoiDung.MaNhanVien);
            sqlcmd.Parameters.AddWithValue("@maPhong", nguoiDung.MaPhong);
            sqlcmd.Parameters.AddWithValue("@taiKhoan", nguoiDung.TaiKhoan);
            sqlcmd.Parameters.AddWithValue("@matKhau", nguoiDung.MatKhau);
            sqlcmd.Parameters.AddWithValue("@quyenTruyCap", nguoiDung.QuyenTruyCap);

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

        public bool xoaNguoiDung(string maNhanVien)
        {
            int result = -1;
            SqlCommand sqlcmd = new SqlCommand("sp_xoaNguoiDung", xldl.SqlCon);
            sqlcmd.CommandType = CommandType.StoredProcedure;
            sqlcmd.Parameters.AddWithValue("@maNhanVien", maNhanVien);

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

        public bool suaNguoiDung(NguoiDung_DAO nguoiDung)
        {
            int result = -1;
            SqlCommand sqlcmd = new SqlCommand("sp_suaNguoiDung", xldl.SqlCon);
            sqlcmd.CommandType = CommandType.StoredProcedure;
            sqlcmd.Parameters.AddWithValue("@maNhanVien", nguoiDung.MaNhanVien);
            sqlcmd.Parameters.AddWithValue("@maPhong", nguoiDung.MaPhong);
            sqlcmd.Parameters.AddWithValue("@taiKhoan", nguoiDung.TaiKhoan);
            sqlcmd.Parameters.AddWithValue("@matKhau", nguoiDung.MatKhau);
            sqlcmd.Parameters.AddWithValue("@quyenTruyCap", nguoiDung.QuyenTruyCap);

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

        public bool kiemTraTaiKhoan(string taiKhoan, string matKhau)
        {
            int result = -1;
            SqlCommand sqlcmd = new SqlCommand("sp_kiemTraTaiKhoan", xldl.SqlCon);
            sqlcmd.CommandType = CommandType.StoredProcedure;
            sqlcmd.Parameters.AddWithValue("@taiKhoan", taiKhoan);
            sqlcmd.Parameters.AddWithValue("@matKhau", matKhau);

            try
            {
                SqlDataReader rd = sqlcmd.ExecuteReader();
                if (rd.HasRows)
                {
                    MessageBox.Show("Đăng nhập thành công", "Đăng nhập", MessageBoxButtons.OK);
                    result = 0;
                }
                rd.Close();
            }
            catch (Exception e)
            {
                MessageBox.Show("Lỗi kết nối" + e);
            }
            return result == 0;
        }

        public bool doiMatKhau(string maNV, string taiKhoan, string matKhau)
        {
            int result = -1;
            SqlCommand sqlcmd = new SqlCommand("sp_doiMatKhau", xldl.SqlCon);
            sqlcmd.CommandType = CommandType.StoredProcedure;
            sqlcmd.Parameters.AddWithValue("@maNhanVien", maNV);
            sqlcmd.Parameters.AddWithValue("@taiKhoan", taiKhoan);
            sqlcmd.Parameters.AddWithValue("@matKhau", matKhau);

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

        public NguoiDung_DAO timNguoiDung(string maNV)
        {
            try
            {
                DataTable dt = new DataTable();
                SqlCommand sqlcmd = new SqlCommand("sp_timNguoiDung", xldl.SqlCon);
                sqlcmd.CommandType = CommandType.StoredProcedure;
                sqlcmd.Parameters.AddWithValue("@maNhanVien", maNV);
                SqlDataAdapter sqlAdap = new SqlDataAdapter(sqlcmd);
                sqlAdap.Fill(dt);
                NguoiDung_DAO nguoiDungDAO = new NguoiDung_DAO();
                nguoiDungDAO.MaNhanVien = maNV;
                nguoiDungDAO.MaPhong = dt.Rows[0][1].ToString().Trim();
                nguoiDungDAO.TaiKhoan = dt.Rows[0][2].ToString().Trim();
                nguoiDungDAO.MatKhau = dt.Rows[0][3].ToString().Trim();
                nguoiDungDAO.QuyenTruyCap = int.Parse(dt.Rows[0][4].ToString().Trim());
                return nguoiDungDAO;
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
