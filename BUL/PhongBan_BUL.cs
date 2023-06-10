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
    public class PhongBan_BUL
    {
        PhongBan_DAL phongBanDAL = new PhongBan_DAL();

        public DataTable layDuLieuTuBang()
        {
            return phongBanDAL.layDuLieuTuBang("PhongBan");
        }

        public bool themPhongBan(PhongBan_DAO PhongBan)
        {
            return phongBanDAL.themPhongBan(PhongBan);
        }

        public bool xoaPhongBan(string maPhong)
        {
            return phongBanDAL.xoaPhongBan(maPhong);
        }

        public bool suaPhongBan(PhongBan_DAO PhongBan)
        {
            return phongBanDAL.suaPhongBan(PhongBan);
        }

        public DataTable timKiemPhongBan(string noiDung, string tieuChi)
        {
            return phongBanDAL.timKiemPhongBan(noiDung, tieuChi);
        }
    }
}
