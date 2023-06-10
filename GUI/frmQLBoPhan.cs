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

namespace GUI
{
    public partial class frmQLBoPhan : Form
    {
        BoPhan_BUL boPhanBUL = new BoPhan_BUL();

        public frmQLBoPhan()
        {
            InitializeComponent();
        }

        private void frmQLBoPhan_Load(object sender, EventArgs e)
        {
            this.MaximizeBox = false;
            disableTextBox();
            loadDataGridView();
        }

        private void loadDataGridView()
        {
            dgvQLBoPhan.DataSource = boPhanBUL.layDuLieuTuBang();
        }

        private void clearAll()
        {
            txtMaBoPhan.Clear();
            txtTenBoPhan.Clear();
        }

        private void disableTextBox()
        {
            txtMaBoPhan.Enabled = false;
            txtTenBoPhan.Enabled = false;
        }

        private void enableTextBox()
        {
            txtMaBoPhan.Enabled = true;
            txtTenBoPhan.Enabled = true;
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
                    string maBoPhan, tenBoPhan;
                    if (txtMaBoPhan.Text == "")
                    {
                        MessageBox.Show("Mã bộ phận rỗng", "Bộ phận", MessageBoxButtons.OK);
                        return;
                    }
                    else { maBoPhan = txtMaBoPhan.Text; }
                    if (txtTenBoPhan.Text == "")
                    {
                        MessageBox.Show("Tên bộ phận rỗng", "Bộ phận", MessageBoxButtons.OK);
                        return;
                    }
                    else { tenBoPhan = txtTenBoPhan.Text; }
                    BoPhan_DAO item = new BoPhan_DAO(maBoPhan, tenBoPhan);
                    if (boPhanBUL.themBoPhan(item))
                    {
                        MessageBox.Show("Thêm thành công", "Bộ phận", MessageBoxButtons.OK);
                        clearAll();
                    }
                    else
                    {
                        MessageBox.Show("Thêm không thành công", "Bộ phận", MessageBoxButtons.OK);
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
                string maBoPhan = txtMaBoPhan.Text;
                DialogResult temp = MessageBox.Show($"Bạn có muốn xóa mã bộ phận '{maBoPhan}' hay không?", "Bộ phận", MessageBoxButtons.YesNo);
                if (temp == DialogResult.Yes)
                {
                    if (boPhanBUL.xoaBoPhan(maBoPhan))
                    {
                        MessageBox.Show("Xóa thành công", "Bộ phận", MessageBoxButtons.OK);
                        clearAll();
                    }
                    else
                    {
                        MessageBox.Show("Xóa không thành công", "Bộ phận", MessageBoxButtons.OK);
                    }
                }
                btnXoa.Text = "Xóa";
                btnThem.Enabled = true;
                disableTextBox();
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
                    btnThem.Enabled = false;
                    btnXoa.Enabled = false;
                    MessageBox.Show("Hãy sửa thông tin dữ liệu:");
                    enableTextBox();
                    txtMaBoPhan.Enabled = false;
                }
                else
                {
                    string maBoPhan, tenBoPhan;
                    if (txtMaBoPhan.Text == "")
                    {
                        MessageBox.Show("Mã bộ phận rỗng", "Bộ phận", MessageBoxButtons.OK);
                        return;
                    }
                    else { maBoPhan = txtMaBoPhan.Text; }
                    if (txtTenBoPhan.Text == "")
                    {
                        MessageBox.Show("Tên bộ phận rỗng", "Bộ phận", MessageBoxButtons.OK);
                        return;
                    }
                    else { tenBoPhan = txtTenBoPhan.Text; }
                    BoPhan_DAO item = new BoPhan_DAO(maBoPhan, tenBoPhan);
                    if (boPhanBUL.suaBoPhan(item))
                    {
                        MessageBox.Show("Sửa thành công", "Bộ phận", MessageBoxButtons.OK);
                        clearAll();
                    }
                    else
                    {
                        MessageBox.Show("Sửa không thành công", "Bộ phận", MessageBoxButtons.OK);
                    }
                    btnSua.Text = "Sửa";
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

        private void btnMoi_Click(object sender, EventArgs e)
        {
            clearAll();
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dgvQLBoPhan_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            dgvQLBoPhan.Rows[e.RowIndex].Selected = true;
            txtMaBoPhan.Text = dgvQLBoPhan.Rows[e.RowIndex].Cells[0].Value.ToString().Trim();
            txtTenBoPhan.Text = dgvQLBoPhan.Rows[e.RowIndex].Cells[1].Value.ToString().Trim();
            btnSua.Enabled = true;
            btnXoa.Enabled = true;
        }
    }
}
