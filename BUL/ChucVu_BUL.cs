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
    public class ChucVu_BUL
    {
        ChucVu_DAL chucVuDAL = new ChucVu_DAL();

        public DataTable layDuLieuTuBang()
        {
            return chucVuDAL.layDuLieuTuBang("ChucVu");
        }

        public bool themChucVu(ChucVu_DAO ChucVu)
        {
            return chucVuDAL.themChucVu(ChucVu);
        }

        public bool xoaChucVu(string maChucVu)
        {
            return chucVuDAL.xoaChucVu(maChucVu);
        }

        public bool suaChucVu(ChucVu_DAO ChucVu)
        {
            return chucVuDAL.suaChucVu(ChucVu);
        }

        public double timLuongCoBan(string tenChucVu)
        {
            return chucVuDAL.timLuongCoBan(tenChucVu);
        }

        public string timMaChucVu(string tenChucVu)
        {
            return chucVuDAL.timMaChuVu(tenChucVu);
        }

        public string timTenChucVu(string maChucVu)
        {
            return chucVuDAL.timTenChucVu(maChucVu);
        }
    }
}
