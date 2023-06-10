using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAO
{
    public class BoPhan_DAO
    {
        private string maBoPhan, tenBoPhan;

        public BoPhan_DAO()
        {

        }

        public BoPhan_DAO(string maBoPhan, string tenBoPhan)
        {
            this.maBoPhan = maBoPhan;
            this.tenBoPhan = tenBoPhan;
        }

        public string MaBoPhan { get => maBoPhan; set => maBoPhan = value; }
        public string TenBoPhan { get => tenBoPhan; set => tenBoPhan = value; }
    }
}
