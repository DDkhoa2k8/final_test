using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace final_test
{
    public partial class bao_cao : Form
    {
        public bao_cao()
        {
            InitializeComponent();
        }

        private void ThongKeHoaDon()
        {
            string connectionString = System.Configuration.ConfigurationManager.ConnectionStrings["MyDb"].ToString();
            DateTime tuNgay = hsd_dt.Value.Date;
            DateTime denNgay = hsd_dd.Value.Date;

            string query = @"SELECT MaHoaDon, NgayLap, MaNhanVien, TongTien, Thue, ChietKhau, KhuyenMai, TrangThai
                             FROM HoaDon
                             WHERE NgayLap BETWEEN @TuNgay AND @DenNgay";

            using (SqlConnection conn = new SqlConnection(connectionString))
            using (SqlCommand cmd = new SqlCommand(query, conn))
            {
                cmd.Parameters.AddWithValue("@TuNgay", tuNgay);
                cmd.Parameters.AddWithValue("@DenNgay", denNgay);

                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                adapter.Fill(dt);

                dgvBaoCao.DataSource = dt;
            }
        }

        private void btnThongKe_Click_1(object sender, EventArgs e)
        {
            ThongKeHoaDon();
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void bao_cao_Load(object sender, EventArgs e)
        {

        }
    }
}