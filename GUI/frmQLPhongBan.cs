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
using Microsoft.Office.Interop.Excel;
using app = Microsoft.Office.Interop.Excel.Application;

namespace GUI
{
    public partial class frmQLPhongBan : Form
    {
        PhongBan_BUL phongBanBUL = new PhongBan_BUL();
        BoPhan_BUL boPhanBUL = new BoPhan_BUL();
        public frmQLPhongBan()
        {
            InitializeComponent();
        }

        private void frmQLPhongBan_Load(object sender, EventArgs e)
        {
            System.Data.DataTable dsbp = boPhanBUL.layDuLieuTuBang();
            for (int i = 0; i < dsbp.Rows.Count; i++)
            {
                cboMaBoPhan.Items.Add(dsbp.Rows[i][0].ToString());
            }
            disableTextBox();
            loadDataGridView();
        }

        private void loadDataGridView()
        {
            dgvQLPhongBan.DataSource = phongBanBUL.layDuLieuTuBang();
        }

        private void disableTextBox()
        {
            txtMaPhong.Enabled = false;
            txtTenPhong.Enabled = false;
            cboMaBoPhan.Enabled = false;
        }

        private void enableTextBox()
        {
            txtMaPhong.Enabled = true;
            txtTenPhong.Enabled = true;
            cboMaBoPhan.Enabled = true;
        }

        private void btnMoi_Click(object sender, EventArgs e)
        {
            clearAll();
        }

        private void clearAll()
        {
            txtMaPhong.Clear();
            txtTenPhong.Clear();
            cboMaBoPhan.SelectedIndex = -1;
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
                    string maPhong, tenPhong, maBoPhan;
                    if (txtMaPhong.Text == "")
                    {
                        MessageBox.Show("Mã phòng rỗng", "Phòng ban", MessageBoxButtons.OK);
                        return;
                    }
                    else { maPhong = txtMaPhong.Text; }
                    if (txtTenPhong.Text == "")
                    {
                        MessageBox.Show("Tên phòng rỗng rỗng", "Phòng ban", MessageBoxButtons.OK);
                        return;
                    }
                    else { tenPhong = txtTenPhong.Text; }
                    if (cboMaBoPhan.SelectedIndex == -1)
                    {
                        MessageBox.Show("Chưa chọn mã bộ phận", "Phòng ban", MessageBoxButtons.OK);
                        return;
                    }
                    else
                    {
                        maBoPhan = cboMaBoPhan.SelectedItem.ToString();
                    }
                    PhongBan_DAO item = new PhongBan_DAO(maPhong, tenPhong, maBoPhan);
                    if (phongBanBUL.themPhongBan(item))
                    {
                        MessageBox.Show("Thêm thành công", "Phòng ban", MessageBoxButtons.OK);
                        clearAll();
                    }
                    else
                    {
                        MessageBox.Show("Thêm không thành công", "Phòng ban", MessageBoxButtons.OK);
                    }
                    btnThem.Text = "Thêm";
                    btnXoa.Enabled = true;
                    btnSua.Enabled = true;
                    disableTextBox();
                    loadDataGridView();
                }
            }
            catch
            {
                return;
            }

        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            try
            {
                btnThem.Enabled = false;
                btnSua.Enabled = false;

                string maPhong = txtMaPhong.Text;
                DialogResult temp = MessageBox.Show($"Bạn có muốn xóa phòng ban có mã '{maPhong}' hay không?", "Bộ phận", MessageBoxButtons.YesNo);
                if (temp == DialogResult.Yes)
                {
                    if (phongBanBUL.xoaPhongBan(maPhong))
                    {
                        MessageBox.Show("Xóa thành công", "Phòng ban", MessageBoxButtons.OK);
                        clearAll();
                    }
                    else
                    {
                        MessageBox.Show("Xóa không thành công", "Phòng ban", MessageBoxButtons.OK);
                    }

                    btnThem.Enabled = true;
                    disableTextBox();
                    loadDataGridView();
                }
            }
            catch
            {
                return;
            }
        }

        private void dgvQLPhongBan_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                dgvQLPhongBan.Rows[e.RowIndex].Selected = true;
                txtMaPhong.Text = dgvQLPhongBan.Rows[e.RowIndex].Cells[0].Value.ToString().Trim();
                for (int i = 0; i < cboMaBoPhan.Items.Count; i++)
                {
                    if (cboMaBoPhan.Items[i].ToString().Trim() == dgvQLPhongBan.Rows[e.RowIndex].Cells[2].Value.ToString().Trim())
                    {
                        cboMaBoPhan.SelectedIndex = i;
                    }
                }
                txtTenPhong.Text = dgvQLPhongBan.Rows[e.RowIndex].Cells[1].Value.ToString().Trim();
                btnSua.Enabled = true;
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
                    btnThem.Enabled = false;
                    btnXoa.Enabled = false;
                    MessageBox.Show("Hãy điền thông tin cần sửa");
                    enableTextBox();
                    txtMaPhong.Enabled = false;
                }
                else
                {
                    string maPhong = txtMaPhong.Text;
                    string tenPhong;
                    if (txtTenPhong.Text == "")
                    {
                        MessageBox.Show("Tên phòng rỗng rỗng", "Phòng ban", MessageBoxButtons.OK);
                        return;
                    }
                    else { tenPhong = txtTenPhong.Text; }
                    string maBoPhan = cboMaBoPhan.SelectedItem.ToString();
                    PhongBan_DAO item = new PhongBan_DAO(maPhong, tenPhong, maBoPhan);
                    if (phongBanBUL.suaPhongBan(item))
                    {
                        MessageBox.Show("Sửa thành công", "Phòng ban", MessageBoxButtons.OK);
                        clearAll();
                    }
                    else
                    {
                        MessageBox.Show("Sửa không thành công", "Phòng ban", MessageBoxButtons.OK);
                    }
                    btnSua.Text = "Sửa";
                    btnXoa.Enabled = true;
                    btnThem.Enabled = true;
                    disableTextBox();
                    loadDataGridView();
                }
            }
            catch
            {
                return;
            }

        }

        private void cboSapXep_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboSapXep.SelectedItem.ToString() == "Giảm dần")
            {
                dgvQLPhongBan.Sort(dgvQLPhongBan.Columns["maPhong"], ListSortDirection.Descending);
            }
            else
            {
                dgvQLPhongBan.Sort(dgvQLPhongBan.Columns["maPhong"], ListSortDirection.Ascending);
            }
        }

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            if (cboTimKiem.SelectedIndex == -1)
            {
                MessageBox.Show("Chọn tiêu chí để tìm kiếm", "Phòng ban", MessageBoxButtons.OK);
            }
            else
            {
                string tieuChi = "Mã phòng";
                switch (cboTimKiem.SelectedIndex)
                {
                    case 1:
                        tieuChi = "Tên phòng";
                        break;
                    case 2:
                        tieuChi = "Mã bộ phận";
                        break;
                }
                string noiDung = txtTimKiem.Text;
                dgvQLPhongBan.DataSource = phongBanBUL.timKiemPhongBan(noiDung, tieuChi);
            }
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void btnXuatFile_Click(object sender, EventArgs e)
        {
            exPortExcel(dgvQLPhongBan, @"D:\", "File phong ban");
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

