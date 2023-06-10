using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAO
{
    public class PhongBan_DAO
    {
        private string maPhong, tenPhong, maBoPhan;

        public PhongBan_DAO()
        {

        }

        public PhongBan_DAO(string maPhong, string tenPhong, string maBoPhan)
        {
            this.maPhong = maPhong;
            this.tenPhong = tenPhong;
            this.maBoPhan = maBoPhan;
        }

        public string MaPhong { get => maPhong; set => maPhong = value; }
        public string TenPhong { get => tenPhong; set => tenPhong = value; }
        public string MaBoPhan { get => maBoPhan; set => maBoPhan = value; }
    }
}
