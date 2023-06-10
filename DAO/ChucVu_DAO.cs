using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAO
{
    public class ChucVu_DAO
    {
        private string maChucVu, tenChucVu;
        double luongCoBan;

        public ChucVu_DAO()
        {

        }

        public ChucVu_DAO(string maChucVu, string tenChucVu, double luongCoBan)
        {
            this.maChucVu = maChucVu;
            this.tenChucVu = tenChucVu;
            this.luongCoBan = luongCoBan;
        }

        public string MaChucVu { get => maChucVu; set => maChucVu = value; }
        public string TenChucVu { get => tenChucVu; set => tenChucVu = value; }
        public double LuongCoBan { get => luongCoBan; set => luongCoBan = value; }
    }
}
