using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace DAL
{
	public class Luong_DAL
	{
		XuLyDuLieu xldl = new XuLyDuLieu();
		public DataTable luongCoBan()
		{
			try
			{
				DataTable dt = new DataTable();
				SqlCommand sqlcmd = new SqlCommand("sp_luongCoBan", xldl.SqlCon);
				sqlcmd.CommandType = CommandType.StoredProcedure;
				SqlDataAdapter sqlAdap = new SqlDataAdapter(sqlcmd);
				sqlAdap.Fill(dt);
				return dt;
			}
			catch (Exception)
			{
				throw;
			}
		}
		public DataTable chiTietLuong()
		{
			try
			{
				DataTable dt = new DataTable();
				SqlCommand sqlcmd = new SqlCommand("sp_bangLuongChiTiet", xldl.SqlCon);
				sqlcmd.CommandType = CommandType.StoredProcedure;
				SqlDataAdapter sqlAdap = new SqlDataAdapter(sqlcmd);
				sqlAdap.Fill(dt);
				return dt;
			}
			catch (Exception)
			{
				throw;
			}
		}
		public DataTable timKiemTheoMucLuong(int mucLuong)
		{
			try
			{
				DataTable dt = new DataTable();
				SqlCommand sqlcmd = new SqlCommand("sp_lietKeTheoMucLuong", xldl.SqlCon);
				sqlcmd.CommandType = CommandType.StoredProcedure;
				sqlcmd.Parameters.AddWithValue("@mucLuong", mucLuong);
				SqlDataAdapter sqlAdap = new SqlDataAdapter(sqlcmd);
				sqlAdap.Fill(dt);
				return dt;
			}
			catch (Exception)
			{
				throw;
			}
		}
		public DataTable timKiemTheoMucLuongNhoHon(int mucLuong)
		{
			try
			{
				DataTable dt = new DataTable();
				SqlCommand sqlcmd = new SqlCommand("sp_lietKeTheoMucLuongNhoHon", xldl.SqlCon);
				sqlcmd.CommandType = CommandType.StoredProcedure;
				sqlcmd.Parameters.AddWithValue("@mucLuong", mucLuong);
				SqlDataAdapter sqlAdap = new SqlDataAdapter(sqlcmd);
				sqlAdap.Fill(dt);
				return dt;
			}
			catch (Exception)
			{
				throw;
			}
		}
		public DataTable tinhTongLuong()
		{
			try
			{
				DataTable dt = new DataTable();
				SqlCommand sqlcmd = new SqlCommand("sp_tinhTongLuong", xldl.SqlCon);
				sqlcmd.CommandType = CommandType.StoredProcedure;
				SqlDataAdapter sqlAdap = new SqlDataAdapter(sqlcmd);
				sqlAdap.Fill(dt);
				return dt;
			}
			catch (Exception)
			{
				throw;
			}
		}
	}
}
