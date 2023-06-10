using BUL;
using DAO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ProgressBar;

namespace GUI
{
    public partial class frmDoiMatKhau : Form
    {
        NguoiDung_BUL nguoiDungBUL = new NguoiDung_BUL();
        public static NguoiDung_DAO nguoiDungDAO = new NguoiDung_DAO();

        public frmDoiMatKhau()
        {
            InitializeComponent();
            nguoiDungDAO = nguoiDungBUL.timNguoiDung(nguoiDungDAO.MaNhanVien);
            if (nguoiDungDAO != null)
            {
                txtMaNV.Text = nguoiDungDAO.MaNhanVien;
                txtTaiKhoan.Text = nguoiDungDAO.TaiKhoan;
            }
            txtMatKhauCu.UseSystemPasswordChar = true;
            txtMatKhauMoi.UseSystemPasswordChar = true;
            txtNhapLaiMatKhau.UseSystemPasswordChar = true;
        }

        private void btnHoanTat_Click(object sender, EventArgs e)
        {
            string maNV = txtMaNV.Text;
            string taiKhoan = txtTaiKhoan.Text;
            string matKhauCu = txtMatKhauCu.Text;
            string matKhauMoi = txtMatKhauMoi.Text;
            string nhapLai = txtNhapLaiMatKhau.Text;
            if (nguoiDungDAO != null)
            {
                if (matKhauCu != nguoiDungDAO.MatKhau)
                {
                    lblThongBaoLoi.Visible = true;
                    lblThongBaoLoi.Text = "Mật khẩu cũ không chính xác";
                    txtMatKhauCu.Focus();
                    return;
                }
                else if (matKhauMoi == "")
                {
                    lblThongBaoLoi.Visible = true;
                    lblThongBaoLoi.Text = "Mật khẩu mới không đưược rỗng!";
                    txtMatKhauMoi.Focus();
                    return;
                }
                else if (matKhauMoi != nhapLai)
                {
                    lblThongBaoLoi.Visible = true;
                    lblThongBaoLoi.Text = "Mật khẩu nhập lại không chính xác";
                    txtNhapLaiMatKhau.Focus();
                    return;
                }
                else if (nguoiDungBUL.doiMatKhau(maNV, taiKhoan, matKhauMoi))
                {
                    MessageBox.Show("Đổi mật khẩu thành công.");
                    nguoiDungDAO.MatKhau = matKhauMoi;
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Đổi mật khẩu thất bại.");
                }
            }
        }

        private void btnNhapLai_Click(object sender, EventArgs e)
        {
            txtMatKhauCu.Clear();
            txtMatKhauMoi.Clear();
            txtNhapLaiMatKhau.Clear();
            txtMatKhauCu.Focus();
        }

        private void btnHuyBo_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
