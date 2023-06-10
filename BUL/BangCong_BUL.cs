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
    public class BangCong_BUL
    {
        BangCong_DAL bangCongDAL = new BangCong_DAL();

        public DataTable layDuLieuTuBang()
        {
            return bangCongDAL.layDuLieuTuBang("BangCong");
        }

        public bool themBangCong(BangCong_DAO BangCong)
        {
            return bangCongDAL.themBangCong(BangCong);
        }

        public bool xoaTatCaBangCong(string maNhanVien)
        {
            return bangCongDAL.xoaTatCaBangCong(maNhanVien);
        }

        public bool xoaBangCong(string maNhanVien, int thang, int nam)
        {
            return bangCongDAL.xoaBangCong(maNhanVien, thang, nam);
        }

        public bool suaBangCong(BangCong_DAO BangCong)
        {
            return bangCongDAL.suaBangCong(BangCong);
        }

        public BangCong_DAO timBangCong(string maNV)
        {
            return bangCongDAL.timBangCong(maNV);
        }
    }
}
