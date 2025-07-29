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
    public partial class ql_san_pham : Form
    {
        private int slcRow = -1;
        private string connectionString = System.Configuration.ConfigurationManager.ConnectionStrings["MyDB"].ConnectionString;
        private SqlConnection con;

        private void loadDT(String k)
        {
            con.Open();

            string query = "SELECT TenSanPham, MaSanPham, DonViTinh, DonGia, HanSuDung, SoLuongTon, dm.TenDanhMuc + '(' + CAST(dm.MaDanhMuc as VARCHAR) + ')' as 'MaDanhMuc' FROM SanPham sp " +
                           "inner join danhMuc dm " +
                           "on dm.maDanhMuc = sp.maDanhMuc " +
                           "WHERE MaSanPham LIKE @keyword OR TenSanPham LIKE @keyword";
            SqlCommand cmd = new SqlCommand(query, con);
            cmd.Parameters.AddWithValue("@keyword", "%" + k + "%");
            SqlDataReader reader = cmd.ExecuteReader();

            DataTable dt = new DataTable();
            dt.Load(reader);

            dtsp.DataSource = dt;
            con.Close();
        }
        private void loadDM()
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                con.Open();

                string sql = @"SELECT
                                        TenDanhMuc + '(' + CAST(MaDanhMuc AS NVARCHAR) + ')' AS TenHienThi 
                                FROM DanhMuc";

                SqlCommand cmd = new SqlCommand(sql, con);
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    cbDanhMuc.Items.Add(reader["TenHienThi"].ToString());
                }
            }
            con.Close();
        }

        public ql_san_pham()
        {
            InitializeComponent();
            con = new SqlConnection(connectionString);
            //Setup dataGridView
            dtsp.Columns.Add(new DataGridViewTextBoxColumn()
            {
                Name = "TenSanPham",
                HeaderText = "Tên sản phẩm",
                DataPropertyName = "TenSanPham"
            });
            dtsp.Columns.Add(new DataGridViewTextBoxColumn()
            {
                Name = "MaSanPham",
                HeaderText = "Mã sản phẩm",
                DataPropertyName = "MaSanPham"
            });
            dtsp.Columns.Add(new DataGridViewTextBoxColumn()
            {
                Name = "DonViTinh",
                HeaderText = "Đơn vị tính",
                DataPropertyName = "DonViTinh"
            });
            dtsp.Columns.Add(new DataGridViewTextBoxColumn()
            {
                Name = "DonGia",
                HeaderText = "Đơn giá",
                DataPropertyName = "DonGia"
            });
            dtsp.Columns.Add(new DataGridViewTextBoxColumn()
            {
                Name = "HanSuDung",
                HeaderText = "Hạn sử dụng",
                DataPropertyName = "HanSuDung"
            });
            dtsp.Columns.Add(new DataGridViewTextBoxColumn()
            {
                Name = "SoluongTon",
                HeaderText = "Số lượng tồn",
                DataPropertyName = "SoluongTon"
            });
            dtsp.Columns.Add(new DataGridViewTextBoxColumn()
            {
                Name = "MaDanhMuc",
                HeaderText = "Danh mục",
                DataPropertyName = "MaDanhMuc"
            });

            loadDT("");
        }

        private void tableLayoutPanel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void ql_san_pham_Load(object sender, EventArgs e)
        {
            loadDM();
        }

        private void dtsp_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.RowIndex < dtsp.RowCount)
            {
                slcRow = e.RowIndex;
                DataGridViewRow row = dtsp.Rows[slcRow];
                ma_sp_tb.Text = row.Cells["MaSanPham"].Value.ToString();
                ten_sp_tb.Text = row.Cells["TenSanPham"].Value.ToString();
                gia_nmr.Value = Convert.ToDecimal(row.Cells["DonGia"].Value);
                dvt_tb.Text = row.Cells["DonViTinh"].Value.ToString();
                hsd_dt.Value = Convert.ToDateTime(row.Cells["HanSuDung"].Value.ToString());
                soLuongTon_num.Value = Convert.ToInt32(row.Cells["SoLuongTon"].Value.ToString());
                cbDanhMuc.Text = row.Cells["MaDanhMuc"].Value.ToString();
            } else
            {
                slcRow = -1;
            }
        }

        private void tim_tb_TextChanged(object sender, EventArgs e)
        {
            loadDT(tim_tb.Text);
        }

        private void them_btn_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(ma_sp_tb.Text) || string.IsNullOrWhiteSpace(ten_sp_tb.Text) || cbDanhMuc.SelectedItem == null)
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin.");
                return;
            }

            string maSP = ma_sp_tb.Text.Trim();
            string tenSP = ten_sp_tb.Text.Trim();
            string dvt = dvt_tb.Text.Trim();
            decimal donGia = gia_nmr.Value;
            DateTime hsd = hsd_dt.Value;
            int soLuong = (int)soLuongTon_num.Value;

            int maDanhMuc = int.Parse(cbDanhMuc.SelectedItem.ToString().Split('(')[1].Replace(')', '\0'));

            using (SqlConnection con = new SqlConnection(connectionString))
            {
                con.Open();
                string insertQuery = @"INSERT INTO SanPham 
            (TenSanPham, DonViTinh, DonGia, HanSuDung, SoLuongTon, MaDanhMuc)
            VALUES
            (@TenSP, @DonViTinh, @DonGia, @HanSuDung, @SoLuongTon, @MaDanhMuc)";

                SqlCommand cmd = new SqlCommand(insertQuery, con);
                cmd.Parameters.AddWithValue("@TenSP", tenSP);
                cmd.Parameters.AddWithValue("@DonViTinh", dvt);
                cmd.Parameters.AddWithValue("@DonGia", donGia);
                cmd.Parameters.AddWithValue("@HanSuDung", hsd);
                cmd.Parameters.AddWithValue("@SoLuongTon", soLuong);
                cmd.Parameters.AddWithValue("@MaDanhMuc", maDanhMuc);

                try
                {
                    int rows = cmd.ExecuteNonQuery();
                    if (rows > 0)
                    {
                        MessageBox.Show("Đã thêm sản phẩm thành công.");
                        loadDT("");
                    }
                    else
                    {
                        MessageBox.Show("Thêm sản phẩm thất bại.");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi khi thêm: " + ex.Message);
                }
            }
        }

        private void sua_btn_Click(object sender, EventArgs e)
        {
            if (slcRow == -1)
            {
                MessageBox.Show("Vui lòng chọn sản phẩm cần sửa.");
                return;
            }

            string maSP = ma_sp_tb.Text.Trim();  // KHÔNG đổi mã
            string tenSP = ten_sp_tb.Text.Trim();
            string dvt = dvt_tb.Text.Trim();
            decimal donGia = gia_nmr.Value;
            DateTime hsd = hsd_dt.Value;
            int soLuong = (int)soLuongTon_num.Value;

            // Tách MaDanhMuc từ cb
            string selected = cbDanhMuc.SelectedItem.ToString();
            int viTriMoNgoac = selected.LastIndexOf('(');
            int viTriDongNgoac = selected.LastIndexOf(')');
            string maDM_str = selected.Substring(viTriMoNgoac + 1, viTriDongNgoac - viTriMoNgoac - 1);
            int maDanhMuc = int.Parse(maDM_str);

            using (SqlConnection con = new SqlConnection(connectionString))
            {
                con.Open();
                string updateQuery = @"UPDATE SanPham 
            SET TenSanPham = @TenSP, DonViTinh = @DonViTinh, DonGia = @DonGia, 
                HanSuDung = @HanSuDung, SoLuongTon = @SoLuongTon, MaDanhMuc = @MaDanhMuc
            WHERE MaSanPham = @MaSP";

                SqlCommand cmd = new SqlCommand(updateQuery, con);
                cmd.Parameters.AddWithValue("@TenSP", tenSP);
                cmd.Parameters.AddWithValue("@DonViTinh", dvt);
                cmd.Parameters.AddWithValue("@DonGia", donGia);
                cmd.Parameters.AddWithValue("@HanSuDung", hsd);
                cmd.Parameters.AddWithValue("@SoLuongTon", soLuong);
                cmd.Parameters.AddWithValue("@MaDanhMuc", maDanhMuc);
                cmd.Parameters.AddWithValue("@MaSP", maSP);

                try
                {
                    int rows = cmd.ExecuteNonQuery();
                    if (rows > 0)
                    {
                        MessageBox.Show("Cập nhật thành công.");
                        loadDT("");
                    }
                    else
                    {
                        MessageBox.Show("Không tìm thấy sản phẩm để cập nhật.");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi khi sửa: " + ex.Message);
                }
            }
        }

        private void xoa_btn_Click(object sender, EventArgs e)
        {
            if (slcRow == -1)
            {
                MessageBox.Show("Vui lòng chọn sản phẩm cần xoá.");
                return;
            }

            string maSP = ma_sp_tb.Text.Trim();

            var result = MessageBox.Show("Bạn có chắc muốn xoá sản phẩm này?", "Xác nhận", MessageBoxButtons.YesNo);
            if (result != DialogResult.Yes) return;

            using (SqlConnection con = new SqlConnection(connectionString))
            {
                con.Open();
                string deleteQuery = "DELETE FROM SanPham WHERE MaSanPham = @MaSP";
                SqlCommand cmd = new SqlCommand(deleteQuery, con);
                cmd.Parameters.AddWithValue("@MaSP", maSP);

                try
                {
                    int rows = cmd.ExecuteNonQuery();
                    if (rows > 0)
                    {
                        MessageBox.Show("Đã xoá sản phẩm.");
                        loadDT("");
                        slcRow = -1;
                    }
                    else
                    {
                        MessageBox.Show("Không tìm thấy sản phẩm để xoá.");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi khi xoá: " + ex.Message);
                }
            }
        }
    }
}
