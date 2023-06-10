using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BUL;
using DAO;
using Microsoft.Office.Interop.Excel;
using app = Microsoft.Office.Interop.Excel.Application;
namespace GUI
{
    public partial class frmLuong : Form
    {
        NhanVien_BUL nhanVienBUL = new NhanVien_BUL();
        PhongBan_BUL phongBanBUL = new PhongBan_BUL();
        ChucVu_BUL chucVuBUL = new ChucVu_BUL();
        NguoiDung_BUL nguoiDungBUL = new NguoiDung_BUL();
        Luong_BUL luong = new Luong_BUL();
        public frmLuong()
        {
            InitializeComponent();
        }

        private void frmLuong_Load(object sender, EventArgs e)
        {
            dgvLuong.DataSource = nhanVienBUL.layDuLieuTuBang();
            cboTieuChi.Items.AddRange(new string[] { "Chi tiết lương của từng nhân viên", "Lương cơ bản của từng nhân viên", "Xem nhân viên có mức lương >=", "Xem nhân viên có mức lương =<", "Tổng lương của tất cả nhân viên" });
        }

        private void cboTieuChi_SelectedIndexChanged(object sender, EventArgs e)
        {

            btnSearch.Enabled = true;
            int t = cboTieuChi.SelectedIndex;
            switch (t)
            {
                case 0:
                    txtValue.Enabled = false;
                    break;
                case 1:
                    txtValue.Enabled = false;
                    break;
                case 2:
                    txtValue.Enabled = true;
                    break;
                case 3:
                    txtValue.Enabled = true;
                    break;
                case 4:
                    txtValue.Enabled = false;
                    break;
                default:
                    break;
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            string value = txtValue.Text;
            int t = cboTieuChi.SelectedIndex;
            switch (t)
            {
                case 0:
                    txtValue.Clear();
                    dgvLuong.DataSource = luong.chiTietLuong();
                    break;
                case 1:
                    txtValue.Clear();
                    dgvLuong.DataSource = luong.LuongCoBan();
                    break;
                case 2:
                    if (value == "" || int.Parse(value) <= 0)
                    {
                        MessageBox.Show("Phải nhập số lớn hơn 0", "Lương");
                    }
                    else
                    {
                        dgvLuong.DataSource = luong.timKiemTheoMucLuong(int.Parse(txtValue.Text));
                    }
                    break;
                case 3:
                    if (value == "" || int.Parse(value) <= 0)
                    {
                        MessageBox.Show("Phải nhập số lớn hơn 0", "Lương");
                    }
                    else
                    {
                        dgvLuong.DataSource = luong.timKiemTheoMucLuongNhoHon(int.Parse(txtValue.Text));
                    }
                    break;
                case 4:
                    txtValue.Clear();
                    dgvLuong.DataSource = luong.tinhTongLuong();
                    break;
                default:
                    break;
            }
        }

        private void txtValue_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

        private void btnXuatFile_Click(object sender, EventArgs e)
        {
            exPortExcel(dgvLuong, @"D:\", $"File luong");
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