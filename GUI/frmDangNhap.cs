using BUL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Tab;

namespace GUI
{
    public partial class frmDangNhap : Form
    {
        NguoiDung_BUL nguoiDungBUL = new NguoiDung_BUL();

        public frmDangNhap()
        {
            InitializeComponent();
        }

        private void frmDangNhap_Load(object sender, EventArgs e)
        {
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.MaximizeBox = false;
            lblSaiDangNhap.Visible = false;
            txtMatKhau.UseSystemPasswordChar = true;
        }

        private void btnDangNhap_Click(object sender, EventArgs e)
        {
            string taiKhoan;
            string matKhau;
            if (txtTaiKhoan.Text == "")
            {
                lblSaiDangNhap.Text = "Tên tài khoản rỗng";
                lblSaiDangNhap.Visible = true;
                return;
            }
            else
            {
                if (txtMatKhau.Text == "")
                {
                    lblSaiDangNhap.Text = "Mật khẩu rỗng";
                    lblSaiDangNhap.Visible = true;
                    return;
                }
                else
                {
                    matKhau = txtMatKhau.Text;
                    taiKhoan = txtTaiKhoan.Text;
                    bool check = nguoiDungBUL.kiemTraTaiKhoan(taiKhoan, matKhau);
                    if (check == true)
                    {
                        string maNV = taiKhoan.Split('_')[1];
                        frmDoiMatKhau.nguoiDungDAO.MaNhanVien = maNV;
                        frmDoiMatKhau.nguoiDungDAO.TaiKhoan = taiKhoan;
                        frmDoiMatKhau.nguoiDungDAO.MatKhau = matKhau;
                        frmMain formMain = new frmMain();
                        this.Hide();
                        formMain.Show();

                    }
                    else
                    {
                        lblSaiDangNhap.Text = "Sai tài khoản hoặc mật khẩu";
                        lblSaiDangNhap.Visible = true;
                    }
                }
            }
        }

        private void txtMatKhau_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == Convert.ToChar(Keys.Enter))
            {
                btnDangNhap.PerformClick();
            }
        }

        private void txtTaiKhoan_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == Convert.ToChar(Keys.Enter))
            {
                btnDangNhap.PerformClick();
            }
        }
    }
}
