using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAO
{
    public class NguoiDung_DAO
    {
        private string maNhanVien, maPhong, taiKhoan, matKhau;
        private int quyenTruyCap;
        public NguoiDung_DAO() { }
        public NguoiDung_DAO(string maNhanVien, string maPhong)
        {
            this.MaNhanVien = maNhanVien;
            this.MaPhong = maPhong;
            this.TaiKhoan = maPhong.Trim() + "_" + maNhanVien.Trim();
            this.MatKhau = "1";
            this.QuyenTruyCap = 1;
        }

        public string MaNhanVien { get => maNhanVien; set => maNhanVien = value; }
        public string MaPhong
        {
            get => maPhong;
            set
            {
                maPhong = value;
                this.TaiKhoan = maPhong.Trim() + "_" + MaNhanVien.Trim();
            }
        }
        public string TaiKhoan { get => taiKhoan; set => taiKhoan = value; }
        public string MatKhau { get => matKhau; set => matKhau = value; }
        public int QuyenTruyCap { get => quyenTruyCap; set => quyenTruyCap = value; }
    }
}
