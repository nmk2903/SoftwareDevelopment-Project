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
    public class NhanVien_BUL
    {
        NhanVien_DAL nhanVienDAL = new NhanVien_DAL();

        public DataTable layDuLieuTuBang()
        {
            return nhanVienDAL.layDuLieuTuBang("NhanVien");
        }

        public bool themNhanVien(NhanVien_DAO NhanVien)
        {
            return nhanVienDAL.themNhanVien(NhanVien);
        }

        public bool xoaNhanVien(string maNhanVien)
        {
            return nhanVienDAL.xoaNhanVien(maNhanVien);
        }

        public bool suaNhanVien(NhanVien_DAO NhanVien)
        {
            return nhanVienDAL.suaNhanVien(NhanVien);
        }

        public DataTable timKiemNhanVien(string noiDung, string tieuChi)
        {
            return nhanVienDAL.timKiemNhanVien(noiDung, tieuChi);
        }
    }
}
