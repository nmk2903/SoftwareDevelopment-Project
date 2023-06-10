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
    public class ChucVu_DAL
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

        public bool themChucVu(ChucVu_DAO ChucVu)
        {
            int result = -1;
            SqlCommand sqlcmd = new SqlCommand("sp_themChucVu", xldl.SqlCon);
            sqlcmd.CommandType = CommandType.StoredProcedure;
            sqlcmd.Parameters.AddWithValue("@maChucVu", ChucVu.MaChucVu);
            sqlcmd.Parameters.AddWithValue("@tenChucVu", ChucVu.TenChucVu);
            sqlcmd.Parameters.AddWithValue("@luongCoBan", ChucVu.LuongCoBan);

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

        public bool xoaChucVu(string maChucVu)
        {
            int result = -1;
            SqlCommand sqlcmd = new SqlCommand("sp_themChucVu", xldl.SqlCon);
            sqlcmd.CommandType = CommandType.StoredProcedure;
            sqlcmd.Parameters.AddWithValue("@maChucVu", maChucVu);

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

        public bool suaChucVu(ChucVu_DAO ChucVu)
        {
            int result = -1;
            SqlCommand sqlcmd = new SqlCommand("sp_suaChucVu", xldl.SqlCon);
            sqlcmd.CommandType = CommandType.StoredProcedure;
            sqlcmd.Parameters.AddWithValue("@tenChucVu", ChucVu.TenChucVu);
            sqlcmd.Parameters.AddWithValue("@maChucVu", ChucVu.MaChucVu);
            sqlcmd.Parameters.AddWithValue("@luongCoBan", ChucVu.LuongCoBan);

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

        public double timLuongCoBan(string tenChucVu)
        {
            try
            {
                DataTable dt = layDuLieuTuBang("ChucVu");
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    if (dt.Rows[i][1].ToString().Equals(tenChucVu))
                    {
                        return double.Parse(dt.Rows[i][2].ToString());
                    }
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Lỗi kết nối");
            }
            return 0;
        }

        public string timMaChuVu(string tenChucVu)
        {
            try
            {
                DataTable dt = layDuLieuTuBang("ChucVu");
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    if (dt.Rows[i][1].ToString().Equals(tenChucVu))
                    {
                        return dt.Rows[i][0].ToString();
                    }
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Lỗi kết nối");
            }
            return "";
        }

        public string timTenChucVu(string maChucVu)
        {
            try
            {
                DataTable dt = layDuLieuTuBang("ChucVu");
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    if (dt.Rows[i][0].ToString().Equals(maChucVu))
                    {
                        return dt.Rows[i][1].ToString();
                    }
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Lỗi kết nối");
            }
            return "";
        }
    }
}
