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
    public class BangCong_DAL
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

        public bool themBangCong(BangCong_DAO bangCong)
        {
            int result = -1;
            SqlCommand sqlcmd = new SqlCommand("sp_themBangCong", xldl.SqlCon);
            sqlcmd.CommandType = CommandType.StoredProcedure;
            sqlcmd.Parameters.AddWithValue("@maNhanVien", bangCong.MaNhanVien);
            sqlcmd.Parameters.AddWithValue("@thang", bangCong.Thang);
            sqlcmd.Parameters.AddWithValue("@nam", bangCong.Nam);
            sqlcmd.Parameters.AddWithValue("@soNgayLam", bangCong.SoNgayLam);
            sqlcmd.Parameters.AddWithValue("@soGioLamThem", bangCong.SoGioLamThem);
            sqlcmd.Parameters.AddWithValue("@ghiChu", bangCong.GhiChu);

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

        public bool xoaTatCaBangCong(string maNhanVien)
        {
            int result = -1;
            SqlCommand sqlcmd = new SqlCommand("sp_xoaTatCaBangCong", xldl.SqlCon);
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

        public bool xoaBangCong(string maNhanVien, int thang, int nam)
        {
            int result = -1;
            SqlCommand sqlcmd = new SqlCommand("sp_xoaBangCong", xldl.SqlCon);
            sqlcmd.CommandType = CommandType.StoredProcedure;
            sqlcmd.Parameters.AddWithValue("@maNhanVien", maNhanVien);
            sqlcmd.Parameters.AddWithValue("@thang", thang);
            sqlcmd.Parameters.AddWithValue("@nam", nam);

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

        public bool suaBangCong(BangCong_DAO bangCong)
        {
            int result = -1;
            SqlCommand sqlcmd = new SqlCommand("sp_suaBangCong", xldl.SqlCon);
            sqlcmd.CommandType = CommandType.StoredProcedure;
            sqlcmd.Parameters.AddWithValue("@maNhanVien", bangCong.MaNhanVien);
            sqlcmd.Parameters.AddWithValue("@thang", bangCong.Thang);
            sqlcmd.Parameters.AddWithValue("@nam", bangCong.Nam);
            sqlcmd.Parameters.AddWithValue("@soNgayLam", bangCong.SoNgayLam);
            sqlcmd.Parameters.AddWithValue("@soGioLamThem", bangCong.SoGioLamThem);
            sqlcmd.Parameters.AddWithValue("@ghiChu", bangCong.GhiChu);

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

        public BangCong_DAO timBangCong(string maNV)
        {
            try
            {
                DataTable dt = new DataTable();
                SqlCommand sqlcmd = new SqlCommand("sp_timBangCong", xldl.SqlCon);
                sqlcmd.CommandType = CommandType.StoredProcedure;
                sqlcmd.Parameters.AddWithValue("@maNhanVien", maNV);
                SqlDataAdapter sqlAdap = new SqlDataAdapter(sqlcmd);
                sqlAdap.Fill(dt);
                BangCong_DAO bangCongDAO = new BangCong_DAO();
                bangCongDAO.MaNhanVien = maNV;
                bangCongDAO.Thang = int.Parse(dt.Rows[0][1].ToString().Trim());
                bangCongDAO.Nam = int.Parse(dt.Rows[0][2].ToString().Trim());
                bangCongDAO.SoNgayLam = int.Parse(dt.Rows[0][3].ToString().Trim());
                bangCongDAO.SoGioLamThem = int.Parse(dt.Rows[0][4].ToString().Trim());
                return bangCongDAO;
            }
            catch (Exception)
            {
                return null;
                throw;
            }
        }
    }
}
