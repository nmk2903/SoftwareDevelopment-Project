using BUL;
using DAO;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Office.Interop.Excel;
using app = Microsoft.Office.Interop.Excel.Application;

namespace GUI
{
    public partial class frmQLNhanVien : Form
    {
        NhanVien_BUL nhanVienBUL = new NhanVien_BUL();
        PhongBan_BUL phongBanBUL = new PhongBan_BUL();
        ChucVu_BUL chucVuBUL = new ChucVu_BUL();
        NguoiDung_BUL nguoiDungBUL = new NguoiDung_BUL();
        BangCong_BUL bangCongBUL = new BangCong_BUL();

        public frmQLNhanVien()
        {
            InitializeComponent();
        }

        private void frmQLNhanVien_Load(object sender, EventArgs e)
        {
            //this.MinimumSize = new System.Drawing.Size(this.Size.Width, this.Size.Height);
            //this.MaximumSize = new System.Drawing.Size(this.Size.Width, this.Size.Height);
            System.Data.DataTable dsnv = phongBanBUL.layDuLieuTuBang();
            for (int i = 0; i < dsnv.Rows.Count; i++)
            {
                cboMaPhong.Items.Add(dsnv.Rows[i][0].ToString());
            }
            System.Data.DataTable dscv = chucVuBUL.layDuLieuTuBang();
            for (int i = 0; i < dscv.Rows.Count; i++)
            {
                cboChucVu.Items.Add(dscv.Rows[i][1].ToString());
            }
            cboSapXep.Items.AddRange(new string[] { "Tên nhân viên", "Mã nhân viên", "Chức vụ" });
            cboTimKiem.Items.AddRange(new string[] { "Tên nhân viên", "Chức vụ" });
            txtTimKiem.Enabled = false;
            disableTextBox();
            loadDataGridView();
        }

        private void loadDataGridView()
        {
            dgvQLNhanVien.DataSource = nhanVienBUL.layDuLieuTuBang();
        }

        private void btnMoi_Click(object sender, EventArgs e)
        {
            clearAll();
            loadDataGridView();
        }

        private void clearAll()
        {
            txtMaNV.Clear();
            txtHoTen.Clear();
            cboChucVu.SelectedIndex = -1;
            cboMaPhong.SelectedIndex = -1;
            cboGioiTinh.SelectedIndex = -1;
            txtCCCD.Clear();
            txtSDT.Clear();
            txtLuongCB.Clear();
        }

        private void disableTextBox()
        {
            txtMaNV.Enabled = false;
            txtHoTen.Enabled = false;
            cboGioiTinh.Enabled = false;
            dtpNgaySinh.Enabled = false;
            txtCCCD.Enabled = false;
            txtSDT.Enabled = false;
            cboChucVu.Enabled = false;
            cboMaPhong.Enabled = false;
        }

        private void enableTextBox()
        {
            txtMaNV.Enabled = true;
            txtHoTen.Enabled = true;
            cboGioiTinh.Enabled = true;
            dtpNgaySinh.Enabled = true;
            txtCCCD.Enabled = true;
            txtSDT.Enabled = true;
            cboChucVu.Enabled = true;
            cboMaPhong.Enabled = true;
        }

        private void txtSDT_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

        private void txtCCCD_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            if (btnThem.Text == "Thêm")
            {
                clearAll();
                btnThem.Text = "Lưu";
                btnXoa.Enabled = false;
                btnSua.Enabled = false;
                enableTextBox();
            }
            else
            {
                string maNV, maPhong, chucVu, hoTen, gioiTinh, cccd, sdt;
                if (txtMaNV.Text == "")
                {
                    MessageBox.Show("Mã nhân viên rỗng", "Nhân viên", MessageBoxButtons.OK);
                    return;
                }
                else { maNV = txtMaNV.Text; }
                if (cboMaPhong.SelectedIndex == -1)
                {
                    MessageBox.Show("Chưa chọn mã phòng", "Nhân viên", MessageBoxButtons.OK);
                    return;
                }
                else { maPhong = cboMaPhong.SelectedItem.ToString(); }
                if (cboChucVu.SelectedIndex == -1)
                {
                    MessageBox.Show("Chưa chọn chức vụ", "Nhân viên", MessageBoxButtons.OK);
                    return;
                }
                else { chucVu = cboChucVu.SelectedItem.ToString(); }
                string maChucVu = chucVuBUL.timMaChucVu(chucVu);
                if (txtHoTen.Text == "")
                {
                    MessageBox.Show("Tên nhân viên rỗng", "Nhân viên", MessageBoxButtons.OK);
                    return;
                }
                else { hoTen = txtHoTen.Text; }
                if (cboGioiTinh.SelectedIndex == -1)
                {
                    MessageBox.Show("Chưa chọn giới tính", "Nhân viên", MessageBoxButtons.OK);
                    return;
                }
                else { gioiTinh = cboGioiTinh.SelectedItem.ToString(); }
                try
                {
                    DateTime.ParseExact(dtpNgaySinh.Value.ToShortDateString(), "M/d/yyyy", null);
                }
                catch
                {
                    return;
                }
                DateTime ngaySinh = DateTime.ParseExact(dtpNgaySinh.Value.ToShortDateString(), "M/d/yyyy", null);
                if (txtCCCD.Text == "" || txtCCCD.Text.Length != 12)
                {
                    MessageBox.Show("Căn cước công dân phải đủ 12 số", "Nhân viên", MessageBoxButtons.OK);
                    return;
                }
                else { cccd = txtCCCD.Text; }
                if (txtSDT.Text == "" || txtSDT.Text.Length < 10 || txtSDT.Text.Length > 12)
                {
                    MessageBox.Show("Số điện thoại phải đủ 10 - 12 số", "Nhân viên", MessageBoxButtons.OK);
                    return;
                }
                else { sdt = txtSDT.Text; }
                NhanVien_DAO item = new NhanVien_DAO(maNV, maPhong, maChucVu, hoTen, ngaySinh, gioiTinh, cccd, sdt);
                if (nhanVienBUL.themNhanVien(item))
                {
                    nguoiDungBUL.themNguoiDung(new NguoiDung_DAO(maNV, maPhong));
                    MessageBox.Show("Thêm thành công", "Nhân viên", MessageBoxButtons.OK);
                    clearAll();
                }
                else
                {
                    MessageBox.Show("Thêm không thành công", "Nhân viên", MessageBoxButtons.OK);
                }
                btnThem.Text = "Thêm";
                btnXoa.Enabled = true;
                btnSua.Enabled = true;
                disableTextBox();
                loadDataGridView();
            }
        }

        private void cboChucVu_SelectedIndexChanged(object sender, EventArgs e)
        {
            string tenChucVu = cboChucVu.Text;
            double luongCoBan = chucVuBUL.timLuongCoBan(tenChucVu);
            if (luongCoBan != 0)
            {
                txtLuongCB.Text = luongCoBan.ToString();
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            btnThem.Enabled = false;
            btnSua.Enabled = false;

            string maPhong = cboMaPhong.Text;
            string maNV = txtMaNV.Text;
            DialogResult temp = MessageBox.Show($"Bạn có muốn xóa nhân viên có mã '{maNV}' hay không?", "Bộ phận", MessageBoxButtons.YesNo);
            if (temp == DialogResult.Yes)
            {
                BangCong_DAO bangCong = bangCongBUL.timBangCong(maNV);
                NguoiDung_DAO nguoiDung =  nguoiDungBUL.timNguoiDung(maNV);
                nguoiDungBUL.xoaNguoiDung(maNV);
                bangCongBUL.xoaTatCaBangCong(maNV);
                if (nhanVienBUL.xoaNhanVien(maNV))
                {
                    MessageBox.Show($"Xóa thành công nhân viên có mã '{maNV}'", "Nhân viên", MessageBoxButtons.OK);
                    clearAll();
                }
                else
                {
                    bangCongBUL.themBangCong(bangCong);
                    nguoiDungBUL.themNguoiDung(nguoiDung);
                    MessageBox.Show("Xóa không thành công", "Nhân viên", MessageBoxButtons.OK);
                }
                btnThem.Enabled = true;
                disableTextBox();
                loadDataGridView();
            }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            if (btnSua.Text == "Sửa")
            {
                btnSua.Text = "Lưu";
                btnThem.Enabled = false;
                btnXoa.Enabled = false;
                MessageBox.Show("Hãy điền thông tin cần sửa");
                enableTextBox();
                txtMaNV.Enabled = false;
            }
            else
            {
                string maNV = txtMaNV.Text;
                string maPhong, chucVu, hoTen, gioiTinh, cccd, sdt;
                if (cboMaPhong.SelectedIndex == -1)
                {
                    MessageBox.Show("Chưa chọn mã phòng", "Nhân viên", MessageBoxButtons.OK);
                    return;
                }
                else { maPhong = cboMaPhong.SelectedItem.ToString(); }
                if (cboChucVu.SelectedIndex == -1)
                {
                    MessageBox.Show("Chưa chọn chức vụ", "Nhân viên", MessageBoxButtons.OK);
                    return;
                }
                else { chucVu = cboChucVu.SelectedItem.ToString(); }
                string maChucVu = chucVuBUL.timMaChucVu(chucVu);
                if (txtHoTen.Text == "")
                {
                    MessageBox.Show("Tên nhân viên rỗng", "Nhân viên", MessageBoxButtons.OK);
                    return;
                }
                else { hoTen = txtHoTen.Text; }
                if (cboGioiTinh.SelectedIndex == -1)
                {
                    MessageBox.Show("Chưa chọn giới tính", "Nhân viên", MessageBoxButtons.OK);
                    return;
                }
                else { gioiTinh = cboGioiTinh.SelectedItem.ToString(); }
                try
                {
                    DateTime.ParseExact(dtpNgaySinh.Value.ToShortDateString(), "M/d/yyyy", null);
                }
                catch
                {
                    return;
                }
                DateTime ngaySinh = DateTime.ParseExact(dtpNgaySinh.Value.ToShortDateString(), "M/d/yyyy", null);
                if (txtCCCD.Text == "" || txtCCCD.Text.Length != 12)
                {
                    MessageBox.Show("Căn cước công dân phải đủ 12 số", "Nhân viên", MessageBoxButtons.OK);
                    return;
                }
                else { cccd = txtCCCD.Text; }
                if (txtSDT.Text == "" || txtSDT.Text.Length < 10 || txtSDT.Text.Length > 12)
                {
                    MessageBox.Show("Số điện thoại phải đủ 10 - 12 số", "Nhân viên", MessageBoxButtons.OK);
                    return;
                }
                else { sdt = txtSDT.Text; }
                NguoiDung_DAO nguoiDung = nguoiDungBUL.timNguoiDung(maNV);
                NhanVien_DAO item = new NhanVien_DAO(maNV, maPhong, maChucVu, hoTen, ngaySinh, gioiTinh, cccd, sdt);
                if (nhanVienBUL.suaNhanVien(item))
                {
                    nguoiDung.MaPhong = maPhong;
                    nguoiDungBUL.suaNguoiDung(nguoiDung);
                    MessageBox.Show("Sửa thành công", "Nhân viên", MessageBoxButtons.OK);
                    clearAll();
                }
                else
                {
                    MessageBox.Show("Sửa không thành công", "Nhân viên", MessageBoxButtons.OK);
                }
                btnSua.Text = "Sửa";
                btnSua.Enabled = false;
                btnThem.Enabled = true;
                disableTextBox();
                loadDataGridView();
            }
        }

        private void dgvQLNhanVien_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            dgvQLNhanVien.Rows[e.RowIndex].Selected = true;
            txtMaNV.Text = dgvQLNhanVien.Rows[e.RowIndex].Cells[0].Value.ToString().Trim();
            for (int i = 0; i < cboMaPhong.Items.Count; i++)
            {
                if (cboMaPhong.Items[i].ToString().Trim() == dgvQLNhanVien.Rows[e.RowIndex].Cells[1].Value.ToString().Trim())
                {
                    cboMaPhong.SelectedIndex = i;
                }
            }
            for (int i = 0; i < cboChucVu.Items.Count; i++)
            {
                if (cboChucVu.Items[i].ToString().Trim() == chucVuBUL.timTenChucVu(dgvQLNhanVien.Rows[e.RowIndex].Cells[2].Value.ToString()).Trim())
                {
                    cboChucVu.SelectedIndex = i;
                }
            }
            txtHoTen.Text = dgvQLNhanVien.Rows[e.RowIndex].Cells[3].Value.ToString().Trim();
            DateTime dt = (DateTime)dgvQLNhanVien.Rows[e.RowIndex].Cells[4].Value;
            dtpNgaySinh.Text = dt.ToShortDateString().Trim();
            cboGioiTinh.Text = dgvQLNhanVien.Rows[e.RowIndex].Cells[5].Value.ToString().Trim();
            txtCCCD.Text = dgvQLNhanVien.Rows[e.RowIndex].Cells[6].Value.ToString().Trim();
            txtSDT.Text = dgvQLNhanVien.Rows[e.RowIndex].Cells[7].Value.ToString().Trim();
            btnXoa.Enabled = true;
            btnSua.Enabled = true;
        }

        private void cboSapXep_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboSapXep.Text == "Tên nhân viên")
            {
                dgvQLNhanVien.Sort(dgvQLNhanVien.Columns["hoTen"], ListSortDirection.Ascending);
            }
            if (cboSapXep.Text == "Mã nhân viên")
            {
                dgvQLNhanVien.Sort(dgvQLNhanVien.Columns["maNhanVien"], ListSortDirection.Ascending);
            }
            if (cboSapXep.Text == "Chức vụ")
            {
                dgvQLNhanVien.Sort(dgvQLNhanVien.Columns["maChucVu"], ListSortDirection.Ascending);
            }
        }

        private void cboTimKiem_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboTimKiem.SelectedIndex != -1)
            {
                txtTimKiem.Enabled = true;
            }
            else
            {
                txtTimKiem.Enabled = false;
            }
        }

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            if (cboTimKiem.SelectedIndex != -1)
            {
                if (String.IsNullOrEmpty(txtTimKiem.Text))
                {
                    MessageBox.Show("Hãy nhập nội dung tìm kiếm", "Tìm kiếm");
                    txtTimKiem.Focus();
                }
                else
                {
                    if (cboTimKiem.Text == "Tên nhân viên")
                    {
                        dgvQLNhanVien.DataSource = nhanVienBUL.timKiemNhanVien(txtTimKiem.Text, "Tên nhân viên");
                    }
                    else if (cboTimKiem.Text == "Chức vụ")
                    {
                        dgvQLNhanVien.DataSource = nhanVienBUL.timKiemNhanVien(txtTimKiem.Text, "Chức vụ");
                    }
                }
            }
            else
            {
                MessageBox.Show("Chưa chọn tiêu chí tìm kiếm", "Tìm kiếm");
                cboTimKiem.Focus();
            }
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            exPortExcel(dgvQLNhanVien, @"D:\", "file nhan vien");
        }
        private void exPortExcel(DataGridView d, string path, string tenTap)
        {
            try
            {
                app obj = new app();
                obj.Application.Workbooks.Add(Type.Missing);
                obj.Columns.ColumnWidth = 30;
                for (int i = 1; i < d.Columns.Count + 1; i++)
                {
                    obj.Cells[1, i] = d.Columns[i - 1].HeaderText;
                }
                for (int i = 0; i < d.Rows.Count; i++)
                {
                    for (int j = 0; j < d.Columns.Count; j++)
                    {
                        if (d.Rows[i].Cells[j].Value != null)
                        {
                            obj.Cells[i + 2, j + 1] = d.Rows[i].Cells[j].Value.ToString();
                        }
                    }
                }
                obj.ActiveWorkbook.SaveCopyAs(path + tenTap + ".xlsx");
                obj.ActiveWorkbook.Saved = true;
                MessageBox.Show("Xuất file thành công!", "Tìm kiếm");
            }
            catch
            {
                return;
            }
        }
    }
}
