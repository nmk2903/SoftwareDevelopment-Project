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
    public class BoPhan_DAL
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

        public bool themBoPhan(BoPhan_DAO boPhan)
        {
            int result = -1;
            SqlCommand sqlcmd = new SqlCommand("sp_themBoPhan", xldl.SqlCon);
            sqlcmd.CommandType = CommandType.StoredProcedure;
            sqlcmd.Parameters.AddWithValue("@maBoPhan", boPhan.MaBoPhan);
            sqlcmd.Parameters.AddWithValue("@tenBoPhan", boPhan.TenBoPhan);

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

        public bool xoaBoPhan(string maBoPhan)
        {
            int result = -1;
            SqlCommand sqlcmd = new SqlCommand("sp_xoaBoPhan", xldl.SqlCon);
            sqlcmd.CommandType = CommandType.StoredProcedure;
            sqlcmd.Parameters.AddWithValue("@maBoPhan", maBoPhan);

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

        public bool suaBoPhan(BoPhan_DAO boPhan)
        {
            int result = -1;
            SqlCommand sqlcmd = new SqlCommand("sp_suaBoPhan", xldl.SqlCon);
            sqlcmd.CommandType = CommandType.StoredProcedure;
            sqlcmd.Parameters.AddWithValue("@maBoPhan", boPhan.MaBoPhan);
            sqlcmd.Parameters.AddWithValue("@tenBoPhan", boPhan.TenBoPhan);

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
    }
}
