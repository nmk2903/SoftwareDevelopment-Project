using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DAL
{
    public class XuLyDuLieu
    {
        private string conStr = "Data Source=.;Initial Catalog=QuanLyNhanVien;Integrated Security=True";
        private SqlConnection sqlCon = new SqlConnection();
        private static int count = 0;

        public XuLyDuLieu()
        {
            sqlCon.ConnectionString = conStr;
            try
            {

                if (sqlCon != null && sqlCon.State == ConnectionState.Closed)
                {
                    sqlCon.Open();
                }
                if (count == 0)
                {
                    MessageBox.Show("Kết nối thành công", "Kết nối CSDL", MessageBoxButtons.OK);
                    count++;
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Kết nối thất bại", "Kết nối CSDL", MessageBoxButtons.OK);
            }
        }

        public SqlConnection SqlCon { get => sqlCon; }
    }
}
