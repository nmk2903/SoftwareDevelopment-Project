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

namespace GUI
{
    public partial class frmMain : Form
    {
        NguoiDung_BUL nguoiDungBUL = new NguoiDung_BUL();

        public frmMain()
        {
            InitializeComponent();
        }

        private void frmMenu_Load(object sender, EventArgs e)
        {
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.MinimumSize = new System.Drawing.Size(1125, 750);
            this.MaximumSize = new System.Drawing.Size(1125, 750);
            pnMenu.Size = new Size(this.Size.Width * 70 / 100, this.Size.Height * 70 / 100);
            mnMenu.ForeColor = Color.FromArgb(0, 160, 250);
            panel_control.Location = new Point(
            this.ClientSize.Width / 10 - panel_control.Size.Width / 10,
            this.ClientSize.Height / 100 * 43 - panel_control.Size.Height / 100 * 43);
            panel_control.Anchor = AnchorStyles.None;
            panel_control.Size = new Size(this.Size.Width * 93 / 100, this.Size.Height * 70 / 100);
            //frmDangNhap formDangNhap = new frmDangNhap() { Dock = DockStyle.Fill, TopLevel = false, TopMost = true };
            //panel_control.Controls.Add(formDangNhap);
            //formDangNhap.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            //formDangNhap.Dock = DockStyle.Fill;
            //formDangNhap.Show();
            //foreach (ToolStripItem item in this.mnMenu.Items)
            //{
            //    if (item.Text != "Tài Khoản" && item.Text != "Đăng Nhập")
            //    {
            //        item.Enabled = false;
            //    }
            //}
            //đăngNhậpToolStripMenuItem.Enabled = true;
            //đăngXuấtToolStripMenuItem.Enabled = false;
            //đổiMậtKhẩuToolStripMenuItem.Enabled = false;
        }

        //private void đăngNhậpToolStripMenuItem_Click(object sender, EventArgs e)
        //{
        //    panel_control.Controls.Clear();
        //    frmDangNhap formDangNhap = new frmDangNhap() { Dock = DockStyle.Fill, TopLevel = false, TopMost = true };
        //    panel_control.Controls.Add(formDangNhap);
        //    formDangNhap.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
        //    formDangNhap.Dock = DockStyle.Fill;
        //    formDangNhap.Show();
        //}

        private void đăngXuấtToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmDangNhap formDangNhap = new frmDangNhap();
            formDangNhap.Show();
            this.Close();
        }

        private void đổiMậtKhẩuToolStripMenuItem_Click(object sender, EventArgs e)
        {
            panel_control.Controls.Clear();
            frmDoiMatKhau formDoiMatKhau = new frmDoiMatKhau() { Dock = DockStyle.Fill, TopLevel = false, TopMost = true };
            panel_control.Controls.Add(formDoiMatKhau);
            formDoiMatKhau.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            formDoiMatKhau.Dock = DockStyle.Fill;
            formDoiMatKhau.Show();
        }

        private void nhânViênToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            panel_control.Controls.Clear();
            frmQLNhanVien formQLNV = new frmQLNhanVien() { Dock = DockStyle.Fill, TopLevel = false, TopMost = true };
            panel_control.Controls.Add(formQLNV);
            formQLNV.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            formQLNV.Dock = DockStyle.Fill;
            formQLNV.Show();
        }

        private void phòngBanToolStripMenuItem_Click(object sender, EventArgs e)
        {
            panel_control.Controls.Clear();
            frmQLPhongBan formQLPB = new frmQLPhongBan() { Dock = DockStyle.Fill, TopLevel = false, TopMost = true };
            panel_control.Controls.Add(formQLPB);
            formQLPB.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            formQLPB.Dock = DockStyle.Fill;
            formQLPB.Show();
        }

        private void bộPhậnToolStripMenuItem_Click(object sender, EventArgs e)
        {
            panel_control.Controls.Clear();
            frmQLBoPhan formQLBP = new frmQLBoPhan() { Dock = DockStyle.Fill, TopLevel = false, TopMost = true };
            panel_control.Controls.Add(formQLBP);
            formQLBP.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            formQLBP.Dock = DockStyle.Fill;
            formQLBP.Show();
        }

        private void bảngCôngToolStripMenuItem_Click(object sender, EventArgs e)
        {
            panel_control.Controls.Clear();
            frmQLBangCong formQLBP = new frmQLBangCong() { Dock = DockStyle.Fill, TopLevel = false, TopMost = true };
            panel_control.Controls.Add(formQLBP);
            formQLBP.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            formQLBP.Dock = DockStyle.Fill;
            formQLBP.Show();
        }

        private void chứcVụToolStripMenuItem_Click(object sender, EventArgs e)
        {
            panel_control.Controls.Clear();
            frmLuong formLuong = new frmLuong() { Dock = DockStyle.Fill, TopLevel = false, TopMost = true };
            panel_control.Controls.Add(formLuong);
            formLuong.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            formLuong.Dock = DockStyle.Fill;
            formLuong.Show();
        }

        private void trợGiúpToolStripMenuItem_Click(object sender, EventArgs e)
        {
            panel_control.Controls.Clear();
            frmTroGiup formTroGiup = new frmTroGiup() { Dock = DockStyle.Fill, TopLevel = false, TopMost = true };
            panel_control.Controls.Add(formTroGiup);
            formTroGiup.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            formTroGiup.Dock = DockStyle.Fill;
            formTroGiup.Show();
        }
    }
}
