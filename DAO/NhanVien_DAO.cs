using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAO
{
    public class NhanVien_DAO
    {
        private string maNhanVien, maPhong, maChucVu, hoTen, gioiTinh, cCCD, soDienThoai;
        private DateTime ngaySinh;

        public NhanVien_DAO()
        {

        }

        public NhanVien_DAO(string maNhanVien, string maPhong, string maChucVu, string hoTen, DateTime ngaySinh, string gioiTinh, string cCCD, string soDienThoai)
        {
            this.MaNhanVien = maNhanVien;
            this.MaPhong = maPhong;
            this.MaChucVu = maChucVu;
            this.HoTen = hoTen;
            this.NgaySinh = ngaySinh;
            this.GioiTinh = gioiTinh;
            this.CCCD = cCCD;
            this.SoDienThoai = soDienThoai;
        }

        public string MaNhanVien { get => maNhanVien; set => maNhanVien = value; }
        public string MaPhong { get => maPhong; set => maPhong = value; }
        public string MaChucVu { get => maChucVu; set => maChucVu = value; }
        public string HoTen { get => hoTen; set => hoTen = value; }
        public DateTime NgaySinh { get => ngaySinh; set => ngaySinh = value; }
        public string GioiTinh { get => gioiTinh; set => gioiTinh = value; }
        public string CCCD { get => cCCD; set => cCCD = value; }
        public string SoDienThoai { get => soDienThoai; set => soDienThoai = value; }
    }
}
