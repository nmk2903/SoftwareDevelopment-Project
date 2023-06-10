using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAO;
using System.Windows.Forms;

namespace DAL
{
    public class NhanVien_DAL
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

        public bool themNhanVien(NhanVien_DAO nhanVien)
        {
            int result = -1;
            SqlCommand sqlcmd = new SqlCommand("sp_themNhanVien", xldl.SqlCon);
            sqlcmd.CommandType = CommandType.StoredProcedure;
            sqlcmd.Parameters.AddWithValue("@maNhanVien", nhanVien.MaNhanVien);
            sqlcmd.Parameters.AddWithValue("@maPhong", nhanVien.MaPhong);
            sqlcmd.Parameters.AddWithValue("@maChucVu", nhanVien.MaChucVu);
            sqlcmd.Parameters.AddWithValue("@hoTen", nhanVien.HoTen);
            sqlcmd.Parameters.AddWithValue("@ngaySinh", nhanVien.NgaySinh);
            sqlcmd.Parameters.AddWithValue("@gioiTinh", nhanVien.GioiTinh);
            sqlcmd.Parameters.AddWithValue("@CCCD", nhanVien.CCCD);
            sqlcmd.Parameters.AddWithValue("@soDienThoai", nhanVien.SoDienThoai);

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

        public bool xoaNhanVien(string maNhanVien)
        {
            int result = -1;
            SqlCommand sqlcmd = new SqlCommand("sp_xoaNhanVien", xldl.SqlCon);
            sqlcmd.CommandType = CommandType.StoredProcedure;
            sqlcmd.Parameters.AddWithValue("@maNhanVien", maNhanVien);

            try
            {
                if (sqlcmd.ExecuteNonQuery() >= 0)
                {
                    result = 0;
                }
            }
            catch (Exception e)
            {
                MessageBox.Show("Lỗi kết nối" + e);
            }
            return result == 0;
        }


        public bool suaNhanVien(NhanVien_DAO nhanVien)
        {
            int result = -1;
            SqlCommand sqlcmd = new SqlCommand("sp_suaNhanVien", xldl.SqlCon);
            sqlcmd.CommandType = CommandType.StoredProcedure;
            sqlcmd.Parameters.AddWithValue("@maNhanVien", nhanVien.MaNhanVien);
            sqlcmd.Parameters.AddWithValue("@maPhong", nhanVien.MaPhong);
            sqlcmd.Parameters.AddWithValue("@maChucVu", nhanVien.MaChucVu);
            sqlcmd.Parameters.AddWithValue("@hoTen", nhanVien.HoTen);
            sqlcmd.Parameters.AddWithValue("@ngaySinh", nhanVien.NgaySinh);
            sqlcmd.Parameters.AddWithValue("@gioiTinh", nhanVien.GioiTinh);
            sqlcmd.Parameters.AddWithValue("@CCCD", nhanVien.CCCD);
            sqlcmd.Parameters.AddWithValue("@soDienThoai", nhanVien.SoDienThoai);

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

        public DataTable timKiemNhanVien(string noiDung, string tieuChi)
        {
            try
            {
                if (tieuChi == "Tên nhân viên")
                {
                    DataTable dt = new DataTable();
                    SqlCommand sqlcmd = new SqlCommand("sp_timKiemNhanVienTheoTen", xldl.SqlCon);
                    sqlcmd.CommandType = CommandType.StoredProcedure;
                    sqlcmd.Parameters.AddWithValue("@hoTen", noiDung);
                    SqlDataAdapter sqlAdap = new SqlDataAdapter(sqlcmd);
                    sqlAdap.Fill(dt);
                    return dt;
                }
                else if (tieuChi == "Chức vụ")
                {
                    DataTable dt = new DataTable();
                    SqlCommand sqlcmd = new SqlCommand("sp_timKiemNhanVienTheoChucVu", xldl.SqlCon);
                    sqlcmd.CommandType = CommandType.StoredProcedure;
                    sqlcmd.Parameters.AddWithValue("@maChucVu", noiDung);
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
