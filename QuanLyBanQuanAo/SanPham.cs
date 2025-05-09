using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.IO;

namespace QuanLyBanQuanAo
{
    public partial class SanPham : Form
    {
        private string connectionString = "Data Source=HUNGUTC\\SQLEXPRESS;Initial Catalog=QuanLyQuanAo;Integrated Security=True;";
        private string selectedImagePath = string.Empty;

        public SanPham()
        {
            InitializeComponent();
            LoadData();
            txt_soluongton.KeyPress += Txt_soluongton_KeyPress;
            dgv_bangquanly.AllowUserToAddRows = false;
            dgv_bangquanly.CellClick += dgv_bangquanly_CellClick;
            dgv_bangquanly.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }

        private void LoadData()
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                SqlDataAdapter da = new SqlDataAdapter("SELECT * FROM SanPham", conn);
                DataTable dt = new DataTable();
                da.Fill(dt);
                dgv_bangquanly.DataSource = dt;
            }
        }

        private void btn_chonanhsanpham_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.bmp";
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                selectedImagePath = ofd.FileName;
                pic_anhsanpham.Image = Image.FromFile(selectedImagePath);
            }
        }

        private void Txt_soluongton_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Chỉ cho nhập số và phím điều khiển
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void btn_them_Click(object sender, EventArgs e)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                string sql = "INSERT INTO SanPham (TenSanPham, MoTa, Gia, SoLuongTon, KichCo, MauSac, Anhsanpham) VALUES (@TenSanPham, @MoTa, @Gia, @SoLuongTon, @KichCo, @MauSac, @Anhsanpham)";
                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@TenSanPham", txt_tensanpham.Text);
                    cmd.Parameters.AddWithValue("@MoTa", txt_mota.Text);
                    cmd.Parameters.AddWithValue("@Gia", decimal.TryParse(txt_gia.Text, out decimal gia) ? gia : 0);
                    cmd.Parameters.AddWithValue("@SoLuongTon", int.TryParse(txt_soluongton.Text, out int slt) ? slt : 0);
                    cmd.Parameters.AddWithValue("@KichCo", txt_kichco.Text);
                    cmd.Parameters.AddWithValue("@MauSac", txt_mausac.Text);
                    cmd.Parameters.AddWithValue("@Anhsanpham", Path.GetFileName(selectedImagePath));
                    cmd.ExecuteNonQuery();
                }
            }
            LoadData();
            MessageBox.Show("Thêm sản phẩm thành công!");
        }

        private void btn_sua_Click(object sender, EventArgs e)
        {
            if (dgv_bangquanly.CurrentRow != null)
            {
                int maSanPham = Convert.ToInt32(dgv_bangquanly.CurrentRow.Cells["MaSanPham"].Value);
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    string sql = "UPDATE SanPham SET TenSanPham=@TenSanPham, MoTa=@MoTa, Gia=@Gia, SoLuongTon=@SoLuongTon, KichCo=@KichCo, MauSac=@MauSac, Anhsanpham=@Anhsanpham WHERE MaSanPham=@MaSanPham";
                    using (SqlCommand cmd = new SqlCommand(sql, conn))
                    {
                        cmd.Parameters.AddWithValue("@TenSanPham", txt_tensanpham.Text);
                        cmd.Parameters.AddWithValue("@MoTa", txt_mota.Text);
                        cmd.Parameters.AddWithValue("@Gia", decimal.TryParse(txt_gia.Text, out decimal gia) ? gia : 0);
                        cmd.Parameters.AddWithValue("@SoLuongTon", int.TryParse(txt_soluongton.Text, out int slt) ? slt : 0);
                        cmd.Parameters.AddWithValue("@KichCo", txt_kichco.Text);
                        cmd.Parameters.AddWithValue("@MauSac", txt_mausac.Text);
                        cmd.Parameters.AddWithValue("@Anhsanpham", Path.GetFileName(selectedImagePath));
                        cmd.Parameters.AddWithValue("@MaSanPham", maSanPham);
                        cmd.ExecuteNonQuery();
                    }
                }
                LoadData();
                MessageBox.Show("Sửa sản phẩm thành công!");
            }
        }

        private void btn_xoa_Click(object sender, EventArgs e)
        {
            if (dgv_bangquanly.CurrentRow != null)
            {
                DialogResult result = MessageBox.Show("Bạn có chắc chắn muốn xóa sản phẩm này không?", "Xác nhận xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (result == DialogResult.Yes)
                {
                    int maSanPham = Convert.ToInt32(dgv_bangquanly.CurrentRow.Cells["MaSanPham"].Value);
                    using (SqlConnection conn = new SqlConnection(connectionString))
                    {
                        conn.Open();
                        string sql = "DELETE FROM SanPham WHERE MaSanPham=@MaSanPham";
                        using (SqlCommand cmd = new SqlCommand(sql, conn))
                        {
                            cmd.Parameters.AddWithValue("@MaSanPham", maSanPham);
                            cmd.ExecuteNonQuery();
                        }
                    }
                    LoadData();
                    MessageBox.Show("Xóa sản phẩm thành công!");
                }
            }
        }

        private void txt_timkiemtheoten_TextChanged(object sender, EventArgs e)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                string sql = "SELECT * FROM SanPham WHERE TenSanPham LIKE @TenSanPham";
                using (SqlDataAdapter da = new SqlDataAdapter(sql, conn))
                {
                    da.SelectCommand.Parameters.AddWithValue("@TenSanPham", "%" + txt_timkiemtheoten.Text + "%");
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    dgv_bangquanly.DataSource = dt;
                }
            }
        }

        private void dgv_bangquanly_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dgv_bangquanly.Rows[e.RowIndex];
                txt_masanpham.Text = row.Cells["MaSanPham"].Value?.ToString() ?? string.Empty;
                txt_tensanpham.Text = row.Cells["TenSanPham"].Value?.ToString() ?? string.Empty;
                txt_mota.Text = row.Cells["MoTa"].Value?.ToString() ?? string.Empty;
                txt_gia.Text = row.Cells["Gia"].Value?.ToString() ?? string.Empty;
                txt_soluongton.Text = row.Cells["SoLuongTon"].Value?.ToString() ?? string.Empty;
                txt_kichco.Text = row.Cells["KichCo"].Value?.ToString() ?? string.Empty;
                txt_mausac.Text = row.Cells["MauSac"].Value?.ToString() ?? string.Empty;
                string img = row.Cells["Anhsanpham"].Value?.ToString() ?? string.Empty;
                if (!string.IsNullOrEmpty(img) && File.Exists(img))
                {
                    pic_anhsanpham.Image = Image.FromFile(img);
                }
                else
                {
                    pic_anhsanpham.Image = null;
                }
            }
        }

        private void pic_anhsanpham_Click(object sender, EventArgs e) { }
        private void txt_masanpham_TextChanged(object sender, EventArgs e) { }
        private void txt_tensanpham_TextChanged(object sender, EventArgs e) { }
        private void txt_mota_TextChanged(object sender, EventArgs e) { }
        private void txt_gia_TextChanged(object sender, EventArgs e) { }
        private void txt_soluongton_TextChanged(object sender, EventArgs e) { }
        private void txt_kichco_TextChanged(object sender, EventArgs e) { }
        private void txt_mausac_TextChanged(object sender, EventArgs e) { }
        private void date_ngaythem_ValueChanged(object sender, EventArgs e) { }
        private void dgv_bangquanly_CellContentClick(object sender, DataGridViewCellEventArgs e) { }
        private void btn_thoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void pic_timkiem_Click(object sender, EventArgs e) { }
    }
}
