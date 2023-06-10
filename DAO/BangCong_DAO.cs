using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAO
{
    public class BangCong_DAO
    {
        private string maNhanVien, ghiChu;
        private int thang, nam, soNgayLam, soGioLamThem;

        public BangCong_DAO()
        {

        }

        public BangCong_DAO(string maNhanVien, string ghiChu, int thang, int nam, int soNgayLam, int soGioLamThem)
        {
            this.maNhanVien = maNhanVien;
            this.ghiChu = ghiChu;
            this.thang = thang;
            this.nam = nam;
            this.soNgayLam = soNgayLam;
            this.soGioLamThem = soGioLamThem;
        }

        public string MaNhanVien { get => maNhanVien; set => maNhanVien = value; }
        public string GhiChu { get => ghiChu; set => ghiChu = value; }
        public int Thang { get => thang; set => thang = value; }
        public int Nam { get => nam; set => nam = value; }
        public int SoNgayLam { get => soNgayLam; set => soNgayLam = value; }
        public int SoGioLamThem { get => soGioLamThem; set => soGioLamThem = value; }
    }
}
