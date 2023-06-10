using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using DAO;

namespace BUL
{
    public class NguoiDung_BUL
    {
        NguoiDung_DAL nguoiDungDAL = new NguoiDung_DAL();

        public DataTable layDuLieuTuBang()
        {
            return nguoiDungDAL.layDuLieuTuBang("NguoiDung");
        }

        public bool themNguoiDung(NguoiDung_DAO nguoiDung)
        {
            return nguoiDungDAL.themNguoiDung(nguoiDung);
        }

        public bool xoaNguoiDung(string maNhanVien)
        {
            return nguoiDungDAL.xoaNguoiDung(maNhanVien);
        }

        public bool suaNguoiDung(NguoiDung_DAO nguoiDung)
        {
            return nguoiDungDAL.suaNguoiDung(nguoiDung);
        }

        public bool kiemTraTaiKhoan(string taiKhoan, string matKhau)
        {
            return nguoiDungDAL.kiemTraTaiKhoan(taiKhoan, matKhau);
        }

        public bool doiMatKhau(string maNV, string taiKhoan, string matKhau)
        {
            return nguoiDungDAL.doiMatKhau(maNV, taiKhoan, matKhau);
        }

        public NguoiDung_DAO timNguoiDung(string maNV)
        {
            return nguoiDungDAL.timNguoiDung(maNV);
        }
    }
}
