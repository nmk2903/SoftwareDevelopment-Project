using DAL;
using DAO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace BUL
{
	public class Luong_BUL
	{
		Luong_DAL luong = new Luong_DAL();
		public DataTable LuongCoBan()
		{
			return luong.luongCoBan();
		}
		public DataTable chiTietLuong()
		{
			return luong.chiTietLuong();
		}
		public DataTable timKiemTheoMucLuong(int mucLuong)
		{
			return luong.timKiemTheoMucLuong(mucLuong);
		}
		public DataTable timKiemTheoMucLuongNhoHon(int mucLuong)
		{
			return luong.timKiemTheoMucLuongNhoHon(mucLuong);
		}
		public DataTable tinhTongLuong()
		{
			return luong.tinhTongLuong();
		}
	}
}
