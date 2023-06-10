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
    public class BoPhan_BUL
    {
        BoPhan_DAL boPhanDAL = new BoPhan_DAL();

        public DataTable layDuLieuTuBang()
        {
            return boPhanDAL.layDuLieuTuBang("BoPhan");
        }

        public bool themBoPhan(BoPhan_DAO BoPhan)
        {
            return boPhanDAL.themBoPhan(BoPhan);
        }

        public bool xoaBoPhan(string maBoPhan)
        {
            return boPhanDAL.xoaBoPhan(maBoPhan);
        }

        public bool suaBoPhan(BoPhan_DAO BoPhan)
        {
            return boPhanDAL.suaBoPhan(BoPhan);
        }
    }
}
