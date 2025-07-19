using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace final_test
{
    public partial class ql_nhap_hang : Form
    {
        public ql_nhap_hang()
        {
            InitializeComponent();
        }
        private string coneetionString = System.Configuration.ConfigurationManager.ConnectionStrings["MyDB"].ConnectionString;

        private void them_btn_Click(object sender, EventArgs e)
        {
            using (SqlConnection them = new SqlConnection(coneetionString))
            {
                them.Open();
                string query = @"INSERT INTO ChiTietNhap
                    (MaSanPham, MaNhaCungCap, MaNhanVien, NgayNhap, SoLuongNhap, DonGiaNhap)
                    VALUES (@MaSanPham, @MaNhaCungCap, @MaNhanVien, @NgayNhap, @SoLuongNhap, @DonGiaNhap)";

                using (SqlCommand cmd = new SqlCommand(query, them))
                {
                    cmd.Parameters.AddWithValue("@MaSanPham", guna2ComboBox3.SelectedValue);
                    cmd.Parameters.AddWithValue("@MaNhaCungCap", guna2ComboBox1.SelectedValue);
                    cmd.Parameters.AddWithValue("@MaNhanVien", gioi_tinh_cb.SelectedValue);
                    cmd.Parameters.AddWithValue("@NgayNhap", hsd_dt.Value); // hoặc DateTime.Parse(txtNgayNhap.Text)
                    cmd.Parameters.AddWithValue("@SoLuongNhap", gia_nmr.Value);
                    cmd.Parameters.AddWithValue("@DonGiaNhap", guna2NumericUpDown1.Value);

                    int rowsAffected = cmd.ExecuteNonQuery();
                    if (rowsAffected > 0)
                    {
                        MessageBox.Show("Thêm chi tiết nhập hàng thành công!", "Thông báo");
                    }
                    else
                    {
                        MessageBox.Show("Thêm thất bại!", "Lỗi");
                    }

                }
                loadnhaphang();
            }
        }

        private void ql_nhap_hang_Load(object sender, EventArgs e)
        {
            loadnhaphang();
            sanpham();
            nhanvien();
            ncc();
            loadComboBoxFilterNCC();

        }
        private void loadnhaphang()
        {
            using (SqlConnection load = new SqlConnection(coneetionString))
            {
                load.Open();
                string query = @"
       SELECT 
    cn.MaChiTietNhap, 
    sp.TenSanPham,
    sp.MaSanPham,                
    ncc.TenNhaCungCap,
    ncc.MaNhaCungCap,            
    nv.HoTen AS NhanVienNhap,
    nv.MaNhanVien,               
    cn.NgayNhap, 
    cn.SoLuongNhap, 
    cn.DonGiaNhap

        FROM ChiTietNhap cn
        JOIN SanPham sp ON cn.MaSanPham = sp.MaSanPham
        JOIN NhaCungCap ncc ON cn.MaNhaCungCap = ncc.MaNhaCungCap
        JOIN NhanVien nv ON cn.MaNhanVien = nv.MaNhanVien";

                using (SqlCommand cmd = new SqlCommand(query, load))
                {
                    SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    adapter.Fill(dt);
                    DGVNhaphang.DataSource = dt;
                }
            }
        }
        private void sanpham()
        {
            string query = "SELECT MaSanPham FROM SanPham";
            SqlDataAdapter adapter = new SqlDataAdapter(query, coneetionString);
            DataTable dt = new DataTable();
            adapter.Fill(dt);

            guna2ComboBox3.DataSource = dt;
            guna2ComboBox3.DisplayMember = "MaSanPham";  // Hiển thị tên
            guna2ComboBox3.ValueMember = "MaSanPham";     // Lưu mã

        }
        private void ncc()
        {
            string queryNCC = "SELECT MaNhaCungCap FROM NhaCungCap";
            SqlDataAdapter adapterNCC = new SqlDataAdapter(queryNCC, coneetionString);
            DataTable dtNCC = new DataTable();
            adapterNCC.Fill(dtNCC);

            guna2ComboBox1.DataSource = dtNCC;
            guna2ComboBox1.DisplayMember = "MaNhaCungCap";   // Hiển thị tên
            guna2ComboBox1.ValueMember = "MaNhaCungCap";      // Lưu mã

        }
        private void nhanvien()
        {
            string queryNV = "SELECT MaNhanVien FROM NhanVien";
            SqlDataAdapter adapterNV = new SqlDataAdapter(queryNV, coneetionString);
            DataTable dtNV = new DataTable();
            adapterNV.Fill(dtNV);

            gioi_tinh_cb.DataSource = dtNV;
            gioi_tinh_cb.DisplayMember = "MaNhanVien";         // Hiển thị họ tên
            gioi_tinh_cb.ValueMember = "MaNhanVien";      // Lưu mã nhân viên

        }

        private void sua_btn_Click(object sender, EventArgs e)
        {
            if (DGVNhaphang.SelectedRows.Count > 0)
            {
                string maChiTietNhap = DGVNhaphang.SelectedRows[0].Cells["MaChiTietNhap"].Value.ToString();

                using (SqlConnection cn = new SqlConnection(coneetionString))
                {
                    cn.Open();
                    string query = @"UPDATE ChiTietNhap SET 
                                MaSanPham = @MaSanPham, 
                                MaNhaCungCap = @MaNhaCungCap,
                                MaNhanVien = @MaNhanVien,
                                NgayNhap = @NgayNhap,
                                SoLuongNhap = @SoLuongNhap,
                                DonGiaNhap = @DonGiaNhap
                             WHERE MaChiTietNhap = @MaChiTietNhap";

                    using (SqlCommand cmd = new SqlCommand(query, cn))
                    {
                        cmd.Parameters.AddWithValue("@MaSanPham", guna2ComboBox3.SelectedValue);
                        cmd.Parameters.AddWithValue("@MaNhaCungCap", guna2ComboBox1.SelectedValue);
                        cmd.Parameters.AddWithValue("@MaNhanVien", gioi_tinh_cb.SelectedValue);
                        cmd.Parameters.AddWithValue("@NgayNhap", hsd_dt.Value);
                        cmd.Parameters.AddWithValue("@SoLuongNhap", gia_nmr.Value);
                        cmd.Parameters.AddWithValue("@DonGiaNhap", guna2NumericUpDown1.Value);
                        cmd.Parameters.AddWithValue("@MaChiTietNhap", maChiTietNhap);

                        int rows = cmd.ExecuteNonQuery();
                        MessageBox.Show(rows > 0 ? "Cập nhật thành công!" : "Cập nhật thất bại!");
                    }
                }

                loadnhaphang();
            }
            else
            {
                MessageBox.Show("Vui lòng chọn dòng cần sửa!");
            }
        }

        private void xoa_btn_Click(object sender, EventArgs e)
        {
            if (DGVNhaphang.SelectedRows.Count > 0)
            {
                string maChiTietNhap = DGVNhaphang.SelectedRows[0].Cells["MaChiTietNhap"].Value.ToString();

                DialogResult result = MessageBox.Show("Bạn có chắc chắn muốn xóa không?", "Xác nhận", MessageBoxButtons.YesNo);
                if (result == DialogResult.Yes)
                {
                    using (SqlConnection cn = new SqlConnection(coneetionString))
                    {
                        cn.Open();
                        string query = "DELETE FROM ChiTietNhap WHERE MaChiTietNhap = @MaChiTietNhap";
                        using (SqlCommand cmd = new SqlCommand(query, cn))
                        {
                            cmd.Parameters.AddWithValue("@MaChiTietNhap", maChiTietNhap);
                            int rows = cmd.ExecuteNonQuery();
                            MessageBox.Show(rows > 0 ? "Xóa thành công!" : "Xóa thất bại!");
                        }
                    }

                    loadnhaphang();
                }
            }
            else
            {
                MessageBox.Show("Vui lòng chọn dòng cần xóa!");
            }


        }

        private void guna2TextBox1_TextChanged(object sender, EventArgs e)
        {
            using (SqlConnection cn = new SqlConnection(coneetionString))
            {
                cn.Open();
                string query = @"
            SELECT 
                cn.MaChiTietNhap, 
                sp.TenSanPham,
                ncc.TenNhaCungCap, 
                nv.HoTen AS NhanVienNhap,
                cn.NgayNhap, 
                cn.SoLuongNhap, 
                cn.DonGiaNhap
            FROM ChiTietNhap cn
            JOIN SanPham sp ON cn.MaSanPham = sp.MaSanPham
            JOIN NhaCungCap ncc ON cn.MaNhaCungCap = ncc.MaNhaCungCap
            JOIN NhanVien nv ON cn.MaNhanVien = nv.MaNhanVien
            WHERE sp.TenSanPham LIKE @ten";

                using (SqlCommand cmd = new SqlCommand(query, cn))
                {
                    cmd.Parameters.AddWithValue("@ten", "%" + guna2TextBox1.Text + "%");

                    SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    adapter.Fill(dt);
                    DGVNhaphang.DataSource = dt;
                }
            }
        }

        private void DGVNhaphang_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = DGVNhaphang.Rows[e.RowIndex];
                guna2ComboBox3.SelectedValue = row.Cells["MaSanPham"].Value;
                guna2ComboBox1.SelectedValue = row.Cells["MaNhaCungCap"].Value;
                gioi_tinh_cb.SelectedValue = row.Cells["MaNhanVien"].Value;

                hsd_dt.Value = Convert.ToDateTime(row.Cells["NgayNhap"].Value);
                gia_nmr.Value = Convert.ToDecimal(row.Cells["SoLuongNhap"].Value);
                guna2NumericUpDown1.Maximum = 10000000000000;
                guna2NumericUpDown1.Value = Convert.ToDecimal(row.Cells["DonGiaNhap"].Value);

            }

        }

        private void guna2ComboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbnncc.SelectedValue == DBNull.Value)
            {
                loadnhaphang();
                return;
            }

            using (SqlConnection cn = new SqlConnection(coneetionString))
            {
                cn.Open();
                string query = @"
    SELECT 
        cn.MaChiTietNhap,
        sp.TenSanPham,
        sp.MaSanPham,
        ncc.TenNhaCungCap,
        ncc.MaNhaCungCap,
        nv.HoTen AS NhanVienNhap,
        nv.MaNhanVien,
        cn.NgayNhap,
        cn.SoLuongNhap,
        cn.DonGiaNhap
    FROM ChiTietNhap cn
    JOIN SanPham sp ON cn.MaSanPham = sp.MaSanPham
    JOIN NhaCungCap ncc ON cn.MaNhaCungCap = ncc.MaNhaCungCap
    JOIN NhanVien nv ON cn.MaNhanVien = nv.MaNhanVien
    WHERE cn.MaNhaCungCap = @maNCC";



                using (SqlCommand cmd = new SqlCommand(query, cn))
                {
                    cmd.Parameters.AddWithValue("@maNCC", cbnncc.SelectedValue);

                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    da.Fill(dt);

                    DGVNhaphang.DataSource = dt;
                }
            }

        }

        
        private void loadComboBoxFilterNCC()
        {
            using (SqlConnection cn = new SqlConnection(coneetionString))
            {
                cn.Open();
                string query = "SELECT MaNhaCungCap FROM NhaCungCap";
                SqlDataAdapter da = new SqlDataAdapter(query, cn);
                DataTable dt = new DataTable();
                da.Fill(dt);

                DataRow dr = dt.NewRow();
                dr["MaNhaCungCap"] = DBNull.Value;
                dt.Rows.InsertAt(dr, 0);

                cbnncc.DisplayMember = "MaNhaCungCap";
                cbnncc.ValueMember = "MaNhaCungCap";
                dt.NewRow();
                cbnncc.DataSource = dt;
            }

        }
    }
}
