using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Office.Interop.Excel;
using app = Microsoft.Office.Interop.Excel.Application;
using System.Windows.Forms;
using BUL;
using DAO;


namespace GUI

{
    public partial class frmQLBangCong : Form
    {
        BangCong_BUL bangCong = new BangCong_BUL();
        NhanVien_BUL nhanVien = new NhanVien_BUL();
        public frmQLBangCong()
        {
            InitializeComponent();
            dtpNam.Format = DateTimePickerFormat.Custom;
            dtpNam.CustomFormat = "MM/yyyy";
        }

        private void frmQLBangCong_Load(object sender, EventArgs e)
        {
            disableTextBox();
            dgvBangCong.DataSource = bangCong.layDuLieuTuBang();
            System.Data.DataTable dscv = nhanVien.layDuLieuTuBang();
            for (int i = 0; i < dscv.Rows.Count; i++)
            {
                cboMaNhanVien.Items.Add(dscv.Rows[i][0].ToString());
            }
        }
        private void clearAll()
        {
            cboMaNhanVien.SelectedIndex = -1;
            txtGhiChu.Clear();
            txtSoGioLamThem.Text = "";
        }

        private void disableTextBox()
        {
            txtSoNgayLam.Enabled = false;
            txtSoGioLamThem.Enabled = false;
            cboMaNhanVien.Enabled = false;
            dtpNam.Enabled = false;
            txtGhiChu.Enabled = false;
            btnXoa.Enabled = false;
        }

        private void enableTextBox()
        {
            txtSoNgayLam.Enabled = true;
            txtSoGioLamThem.Enabled = true;
            cboMaNhanVien.Enabled = true;
            dtpNam.Enabled = true;
            txtGhiChu.Enabled = true;
        }
        private void loadDataGridView()
        {
            dgvBangCong.DataSource = bangCong.layDuLieuTuBang();
        }
        private void btnThem_Click(object sender, EventArgs e)
        {

            try
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
                    string maNV;
                    int soGioLamThem, soNgayLam;
                    string ghiChu = txtGhiChu.Text;
                    if (cboMaNhanVien.SelectedIndex == -1)
                    {
                        MessageBox.Show("Chưa chọn mã nhân viên", "Nhân viên", MessageBoxButtons.OK);
                        return;
                    }
                    else { maNV = cboMaNhanVien.SelectedItem.ToString(); }
                    if (txtSoGioLamThem.Text == "" || int.Parse(txtSoGioLamThem.Text) < 0 || int.Parse(txtSoGioLamThem.Text) > 100)
                    {
                        MessageBox.Show("Sai dữ liệu giờ làm thêm", "Giờ làm thêm", MessageBoxButtons.OK);
                        return;
                    }
                    else { soGioLamThem = int.Parse(txtSoGioLamThem.Text); }
                    if (txtSoNgayLam.Text == "" || int.Parse(txtSoNgayLam.Text) < 0 || int.Parse(txtSoNgayLam.Text) > 26)
                    {
                        MessageBox.Show("Sai dữ liệu số ngày làm", "Số ngày làm", MessageBoxButtons.OK);
                        return;
                    }
                    else { soNgayLam = int.Parse(txtSoNgayLam.Text); }
                    DateTime ngaySinh = DateTime.ParseExact(dtpNam.Text, "MM/yyyy", null);
                    int nam = int.Parse(ngaySinh.ToString("yyyy"));
                    int thang = int.Parse(ngaySinh.ToString("MM"));
                    BangCong_DAO item = new BangCong_DAO(maNV, ghiChu, thang, nam, soNgayLam, soGioLamThem);
                    if (bangCong.themBangCong(item))
                    {
                        MessageBox.Show("Thêm thành công", "Bảng công", MessageBoxButtons.OK);
                        clearAll();
                    }
                    else
                    {
                        MessageBox.Show("Thêm không thành công", "Bảng công", MessageBoxButtons.OK);
                    }
                    btnThem.Text = "Thêm";
                    btnXoa.Enabled = true;
                    btnSua.Enabled = false;
                    disableTextBox();
                    loadDataGridView();
                }
            }
            catch
            {
                return;
            }
        }

        private void txtSoNgayLam_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtSoNgayLam_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

        private void txtSoGioLamThem_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtSoGioLamThem_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            try
            {
                string maNhanVien = cboMaNhanVien.SelectedItem.ToString();
                DateTime ngaySinh = DateTime.ParseExact(dtpNam.Text, "MM/yyyy", null);
                int nam = int.Parse(ngaySinh.ToString("yyyy"));
                int thang = int.Parse(ngaySinh.ToString("MM"));

                DialogResult temp = MessageBox.Show($"Bạn có muốn xóa ngày công của nhân viên {maNhanVien}, trong tháng {thang}/{nam} hay không", "Bảng công", MessageBoxButtons.YesNo);
                if (temp == DialogResult.Yes)
                {
                    bangCong.xoaBangCong(maNhanVien, thang, nam);
                    MessageBox.Show("Xóa thành công", "Bảng công", MessageBoxButtons.OK);
                }
                clearAll();
                btnThem.Enabled = true;
                btnSua.Enabled = false;
                disableTextBox();
                btnThem.Enabled = true;
                loadDataGridView();
            }
            catch
            {
                return;
            }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            try
            {
                if (btnSua.Text == "Sửa")
                {
                    btnSua.Text = "Lưu";
                    btnXoa.Enabled = false;
                    btnThem.Enabled = false;
                    enableTextBox();
                    dtpNam.Enabled = false;
                    cboMaNhanVien.Enabled = false;
                    txtSoGioLamThem.Text = "";
                    txtGhiChu.Text = "";
                    txtSoNgayLam.Text = "";
                }
                else
                {
                    string maNV;
                    int soGioLamThem, soNgayLam;
                    string ghiChu = txtGhiChu.Text;
                    if (cboMaNhanVien.SelectedIndex == -1)
                    {
                        MessageBox.Show("Chưa chọn mã nhân viên", "Nhân viên", MessageBoxButtons.OK);
                        return;
                    }
                    else { maNV = cboMaNhanVien.SelectedItem.ToString(); }
                    if (txtSoGioLamThem.Text == "" || int.Parse(txtSoGioLamThem.Text) < 0 || int.Parse(txtSoGioLamThem.Text) > 100)
                    {
                        MessageBox.Show("Sai dữ liệu giờ làm thêm", "Giờ làm thêm", MessageBoxButtons.OK);
                        return;
                    }
                    else { soGioLamThem = int.Parse(txtSoGioLamThem.Text); }
                    if (txtSoNgayLam.Text == "" || int.Parse(txtSoNgayLam.Text) < 0 || int.Parse(txtSoNgayLam.Text) > 26)
                    {
                        MessageBox.Show("Sai dữ liệu số ngày làm", "Số ngày làm", MessageBoxButtons.OK);
                        return;
                    }
                    else { soNgayLam = int.Parse(txtSoNgayLam.Text); }
                    DateTime ngaySinh = DateTime.ParseExact(dtpNam.Text, "MM/yyyy", null);
                    int nam = int.Parse(ngaySinh.ToString("yyyy"));
                    int thang = int.Parse(ngaySinh.ToString("MM"));
                    BangCong_DAO item = new BangCong_DAO(maNV, ghiChu, thang, nam, soNgayLam, soGioLamThem);
                    if (bangCong.suaBangCong(item))
                    {
                        MessageBox.Show("Sửa thành công", "Bảng công", MessageBoxButtons.OK);
                        clearAll();
                    }
                    else
                    {
                        MessageBox.Show("Sửa không thành công", "Bảng công", MessageBoxButtons.OK);
                    }
                    btnSua.Text = "Sửa";
                    btnXoa.Enabled = true;
                    btnSua.Enabled = false;
                    disableTextBox();
                    btnThem.Enabled = true;
                    loadDataGridView();
                }
            }
            catch
            {
                return;
            }
        }

        private void btnMoi_Click(object sender, EventArgs e)
        {
            clearAll();
            loadDataGridView();
            btnThem.Enabled = true;
            btnSua.Enabled = false;
            btnXoa.Enabled = false;
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dgvBangCong_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                dgvBangCong.Rows[e.RowIndex].Selected = true;
                for (int i = 0; i < cboMaNhanVien.Items.Count; i++)
                {
                    if (cboMaNhanVien.Items[i].ToString().Trim() == dgvBangCong.Rows[e.RowIndex].Cells[0].Value.ToString().Trim())
                    {
                        cboMaNhanVien.SelectedIndex = i;
                    }
                }
                int thang = int.Parse(dgvBangCong.Rows[e.RowIndex].Cells[1].Value.ToString().Trim());
                int nam = int.Parse(dgvBangCong.Rows[e.RowIndex].Cells[2].Value.ToString().Trim());
                DateTime temp = new DateTime(nam, thang, 1);
                dtpNam.Value = temp;
                txtSoNgayLam.Text = dgvBangCong.Rows[e.RowIndex].Cells[3].Value.ToString().Trim();
                txtSoGioLamThem.Text = dgvBangCong.Rows[e.RowIndex].Cells[4].Value.ToString().Trim();
                txtGhiChu.Text = dgvBangCong.Rows[e.RowIndex].Cells[5].Value.ToString().Trim();
                btnSua.Enabled = true;
                btnXoa.Enabled = true;
                txtSoNgayLam.Enabled = true;
                txtGhiChu.Enabled = true;
                txtSoGioLamThem.Enabled = true;
                btnThem.Enabled = false;
            }
            catch
            {
                return;
            }
        }

        private void btnXuatFile_Click(object sender, EventArgs e)
        {
            exPortExcel(dgvBangCong, @"D:\", $"File bang cong");
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
