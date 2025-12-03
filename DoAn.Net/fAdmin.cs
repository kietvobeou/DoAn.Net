using DoAn.Net.QuanLyQuanCafeTableAdapters;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using System.Text;
using System.Threading.Tasks;

namespace DoAn.Net
{
    public partial class fAdmin : Form
    {
        private BindingSource dsMonAn = new BindingSource();
        private BindingSource dsTaiKhoan = new BindingSource();
        private BindingSource dsDanhMuc = new BindingSource();
        private BindingSource dsBan = new BindingSource();
        private DBTaiKhoan taiKhoanDB = new DBTaiKhoan();
        private DBMonAn monAnDB = new DBMonAn();
        private DBDanhMuc danhMucDB = new DBDanhMuc();
        private DBHoaDon hoaDonDB = new DBHoaDon();
        private DBReport baoCaoDB = new DBReport();
        private DBBan banDB = new DBBan();
        public TaiKhoan taiKhoanDangNhap;
        private bool dangThemMon = false;
        private bool dangThemTaiKhoan = false;
        private bool dangThemDanhMuc = false;
        private bool dangThemBan = false;

        public fAdmin()
        {
            InitializeComponent();
            GanCacSuKien();
            TaiDuLieu();
        }

        private void GanCacSuKien()
        {
            this.btnThem.Click += this.btnThem_Click;
            this.btnSua.Click += this.btnSua_Click;
            this.btnXoa.Click += this.btnXoa_Click;
            this.btnLuu.Click += this.btnLuu_Click;
            this.btnTim.Click += this.btnTim_Click;
            this.txtID.TextChanged += this.txtID_TextChanged;
            this.dgvThucAn.SelectionChanged += this.dgvThucAn_SelectionChanged;
            this.btnThem3.Click += this.btnThem3_Click;
            this.btnXoa3.Click += this.btnXoa3_Click;
            this.btnSua3.Click += this.btnSua3_Click;
            this.btnLuuAccount.Click += this.btnLuuAccount_Click;
            this.btnResetPassword.Click += this.btnResetPassword_Click;
            this.btnThem1.Click += this.btnThem1_Click;
            this.btnXoa1.Click += this.btnXoa1_Click;
            this.btnSua1.Click += this.btnSua1_Click;
            this.btnLuu1.Click += this.btnLuu1_Click;
            this.btnThem2.Click += this.btnThem2_Click;
            this.btnXoa2.Click += this.btnXoa2_Click;
            this.btnSua2.Click += this.btnSua2_Click;
            this.btnLuu2.Click += this.btnLuu2_Click;
            this.btnThongKe.Click += this.btnThongKe_Click;
            this.btnFirstBillPage.Click += this.btnFirstBillPage_Click;
            this.btnPrevioursBillPage.Click += this.btnPreviousBillPage_Click;
            this.btnNextBillPage.Click += this.btnNextBillPage_Click;
            this.btnLastBillPage.Click += this.btnLastBillPage_Click;
            this.btnViewReport.Click += this.btnViewReport_Click;
            this.btnToday.Click += this.btnToday_Click;
            this.btnThisMonth.Click += this.btnThisMonth_Click;
            this.btnLastMonth.Click += this.btnLastMonth_Click;
            this.btnExportExcel.Click += this.btnExportExcel_Click;
            this.Load += this.fAdmin_Load;
            this.dgvAccount.SelectionChanged += this.dgvAccount_SelectionChanged;
            this.dgvDoanhMuc.SelectionChanged += this.dgvDoanhMuc_SelectionChanged;
            this.dgvBan.SelectionChanged += this.dgvBan_SelectionChanged;
            this.txbPageBill.TextChanged += this.txbPageBill_TextChanged;
        }

        #region Các phương thức

        private void TaiDuLieu()
        {
            try
            {
                TaiDanhSachMonAn();
                TaiTaiKhoan();
                TaiDanhSachDanhMuc();
                TaiDanhSachBan();
                TaiThoiGianChoBill();
                TaiHoaDonTheoNgay(dtpBatDau.Value, dtpKetThuc.Value);
                TaiDanhMucVaoCombobox(cboDoanhMuc);
                dgvThucAn.DataSource = dsMonAn;
                dgvAccount.DataSource = dsTaiKhoan;
                dgvDoanhMuc.DataSource = dsDanhMuc;
                dgvBan.DataSource = dsBan;
                GanBindingMonAn();
                GanBindingTaiKhoan();
                GanBindingDanhMuc();
                GanBindingBan();
                dgvThucAn.ClearSelection();
                dgvAccount.ClearSelection();
                dgvDoanhMuc.ClearSelection();
                dgvBan.ClearSelection();
                TatBatDieuKhienMonAn(false);
                TatBatDieuKhienTaiKhoan(false);
                TatBatDieuKhienDanhMuc(false);
                TatBatDieuKhienBan(false);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Bị lỗi khi tải dữ liệu: " + ex.Message, "Lỗi",
                               MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void GanBindingMonAn()
        {
            txtTenMon.DataBindings.Clear();
            txtID.DataBindings.Clear();
            nmGia.DataBindings.Clear();

            txtTenMon.DataBindings.Add(new Binding("Text", dgvThucAn.DataSource, "Name"));
            txtID.DataBindings.Add(new Binding("Text", dgvThucAn.DataSource, "ID"));
            nmGia.DataBindings.Add(new Binding("Value", dgvThucAn.DataSource, "Price"));
        }

        private void GanBindingTaiKhoan()
        {
            txtTenTK.DataBindings.Clear();
            txtTenHienThi.DataBindings.Clear();
            nmrLoai.DataBindings.Clear();

            txtTenTK.DataBindings.Add(new Binding("Text", dgvAccount.DataSource, "UserName"));
            txtTenHienThi.DataBindings.Add(new Binding("Text", dgvAccount.DataSource, "DisplayName"));
            nmrLoai.DataBindings.Add(new Binding("Value", dgvAccount.DataSource, "Type"));
        }

        private void GanBindingDanhMuc()
        {
            txtMaDoanhMuc.DataBindings.Clear();
            txtTenDoanhMuc.DataBindings.Clear();

            txtMaDoanhMuc.DataBindings.Add(new Binding("Text", dgvDoanhMuc.DataSource, "ID"));
            txtTenDoanhMuc.DataBindings.Add(new Binding("Text", dgvDoanhMuc.DataSource, "Name"));
        }

        private void GanBindingBan()
        {
            txtIDTable.DataBindings.Clear();
            txtTenBan.DataBindings.Clear();
            txtTrangThai.DataBindings.Clear();

            txtIDTable.DataBindings.Add(new Binding("Text", dgvBan.DataSource, "Id"));
            txtTenBan.DataBindings.Add(new Binding("Text", dgvBan.DataSource, "Name"));
            txtTrangThai.DataBindings.Add(new Binding("Text", dgvBan.DataSource, "Status"));
        }

        private void TatBatDieuKhienMonAn(bool bat)
        {
            txtTenMon.Enabled = bat;
            nmGia.Enabled = bat;
            cboDoanhMuc.Enabled = bat;
            btnLuu.Enabled = bat;

            btnSua.Enabled = !bat;
            btnXoa.Enabled = !bat;
            btnThem.Enabled = !bat;

            txtID.Enabled = false;
        }

        private void TatBatDieuKhienTaiKhoan(bool bat)
        {
            txtTenTK.Enabled = bat;
            txtTenHienThi.Enabled = bat;
            nmrLoai.Enabled = bat;
            btnLuuAccount.Enabled = bat;

            btnSua3.Enabled = !bat;
            btnXoa3.Enabled = !bat;
            btnThem3.Enabled = !bat;
            btnResetPassword.Enabled = !bat;
        }

        private void TatBatDieuKhienDanhMuc(bool bat)
        {
            txtTenDoanhMuc.Enabled = bat;
            btnLuu1.Enabled = bat;

            btnSua1.Enabled = !bat;
            btnXoa1.Enabled = !bat;
            btnThem1.Enabled = !bat;

            txtMaDoanhMuc.Enabled = false;
        }

        private void TatBatDieuKhienBan(bool bat)
        {
            txtTenBan.Enabled = bat;
            txtTrangThai.Enabled = bat;
            btnLuu2.Enabled = bat;

            btnSua2.Enabled = !bat;
            btnXoa2.Enabled = !bat;
            btnThem2.Enabled = !bat;

            txtIDTable.Enabled = false;
        }

        private void XoaDuLieuMonAn()
        {
            txtTenMon.Text = "";
            txtID.Text = "";
            nmGia.Value = 0;
            cboDoanhMuc.SelectedIndex = -1;
        }

        private void XoaDuLieuTaiKhoan()
        {
            txtTenTK.Text = "";
            txtTenHienThi.Text = "";
            nmrLoai.Value = 0;
        }

        private void XoaDuLieuDanhMuc()
        {
            txtMaDoanhMuc.Text = "";
            txtTenDoanhMuc.Text = "";
        }

        private void XoaDuLieuBan()
        {
            txtIDTable.Text = "";
            txtTenBan.Text = "";
            txtTrangThai.Text = "";
        }

        private void TaiTaiKhoan()
        {
            try
            {
                dsTaiKhoan.DataSource = taiKhoanDB.LayDSTK();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi tải tài khoản: " + ex.Message);
            }
        }

        private void TaiDanhSachDanhMuc()
        {
            try
            {
                dsDanhMuc.DataSource = danhMucDB.GetListCategory();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi tải danh mục: " + ex.Message);
            }
        }

        private void TaiDanhSachBan()
        {
            try
            {
                dsBan.DataSource = banDB.LoadTableList();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi tải bàn: " + ex.Message);
            }
        }

        private void TaiThoiGianChoBill()
        {
            DateTime homNay = DateTime.Now;
            dtpBatDau.Value = new DateTime(homNay.Year, homNay.Month, 1);
            dtpKetThuc.Value = dtpBatDau.Value.AddMonths(1).AddDays(-1);
        }

        private void TaiHoaDonTheoNgay(DateTime ngayBatDau, DateTime ngayKetThuc)
        {
            try
            {
                dgvBill.DataSource = hoaDonDB.GetBillListByDate(ngayBatDau, ngayKetThuc);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi tải hóa đơn: " + ex.Message);
            }
        }

        private void TaiDanhMucVaoCombobox(ComboBox cb)
        {
            try
            {
                cb.DataSource = dsDanhMuc.DataSource;
                cb.DisplayMember = "Name";
                cb.ValueMember = "ID";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi tải danh mục vào combobox: " + ex.Message);
            }
        }

        private void TaiDanhSachMonAn()
        {
            try
            {
                dsMonAn.DataSource = monAnDB.GetListFood();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi tải món ăn: " + ex.Message);
            }
        }

        private bool ThemBanVaoCSDL(string ten, string trangThai)
        {
            try
            {
                var adapter = new BanTableAdapter();
                adapter.Insert(ten, trangThai);
                return true;
            }
            catch
            {
                return false;
            }
        }

        private bool SuaBanTrongCSDL(int id, string ten, string trangThai)
        {
            try
            {
                var adapter = new BanTableAdapter();
                int ketQua = adapter.UpdateTable(ten, trangThai, id);
                return ketQua > 0;
            }
            catch
            {
                return false;
            }
        }

        private bool XoaBanKhoiCSDL(int id)
        {
            try
            {
                var adapter = new BanTableAdapter();
                int ketQua = adapter.DeleteTable(id);
                return ketQua > 0;
            }
            catch
            {
                return false;
            }
        }
        private void btnThem_Click(object sender, EventArgs e)
        {
            dangThemMon = true;
            XoaDuLieuMonAn();
            TatBatDieuKhienMonAn(true);
            txtTenMon.Focus();
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtID.Text))
            {
                MessageBox.Show("Chưa chọn món ăn nào để sửa");
                return;
            }

            dangThemMon = false;
            TatBatDieuKhienMonAn(true);
            txtTenMon.Focus();
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            try
            {
                if (dangThemMon)
                {
                    string ten = txtTenMon.Text;
                    int maDanhMuc = (cboDoanhMuc.SelectedValue != null) ? (int)cboDoanhMuc.SelectedValue : 0;
                    float gia = (float)nmGia.Value;

                    if (string.IsNullOrEmpty(ten))
                    {
                        MessageBox.Show("Chưa nhập tên món");
                        return;
                    }

                    if (maDanhMuc == 0)
                    {
                        MessageBox.Show("Chưa chọn danh mục");
                        return;
                    }

                    if (monAnDB.InsertFood(ten, maDanhMuc, gia))
                    {
                        MessageBox.Show("Đã thêm món thành công");
                        TaiDanhSachMonAn();
                        TatBatDieuKhienMonAn(false);
                        dangThemMon = false;
                        XoaDuLieuMonAn();
                    }
                    else
                    {
                        MessageBox.Show("Thêm món không thành công");
                    }
                }
                else
                {
                    if (string.IsNullOrEmpty(txtID.Text))
                    {
                        MessageBox.Show("Chưa chọn món ăn nào để sửa");
                        return;
                    }

                    string ten = txtTenMon.Text;
                    int maDanhMuc = (cboDoanhMuc.SelectedValue != null) ? (int)cboDoanhMuc.SelectedValue : 0;
                    float gia = (float)nmGia.Value;
                    int id = Convert.ToInt32(txtID.Text);

                    if (string.IsNullOrEmpty(ten))
                    {
                        MessageBox.Show("Chưa nhập tên món");
                        return;
                    }

                    if (maDanhMuc == 0)
                    {
                        MessageBox.Show("Chưa chọn danh mục");
                        return;
                    }

                    if (monAnDB.UpdateFood(id, ten, maDanhMuc, gia))
                    {
                        MessageBox.Show("Đã sửa món thành công");
                        TaiDanhSachMonAn();
                        TatBatDieuKhienMonAn(false);
                    }
                    else
                    {
                        MessageBox.Show("Sửa món không thành công");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi lưu món: " + ex.Message);
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(txtID.Text))
                {
                    MessageBox.Show("Chưa chọn món ăn nào để xóa");
                    return;
                }

                int id = Convert.ToInt32(txtID.Text);

                if (MessageBox.Show("Bạn có chắc muốn xóa món này không?", "Xác nhận",
                    MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    if (monAnDB.DeleteFood(id))
                    {
                        MessageBox.Show("Đã xóa món thành công");
                        TaiDanhSachMonAn();
                        XoaDuLieuMonAn();
                    }
                    else
                    {
                        MessageBox.Show("Xóa món không thành công");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi xóa món: " + ex.Message);
            }
        }

        private void btnTim_Click(object sender, EventArgs e)
        {
            try
            {
                string tenCanTim = txtSearchFood.Text;
                dsMonAn.DataSource = monAnDB.SearchFoodByName(tenCanTim);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tìm món ăn: " + ex.Message);
            }
        }

        private void txtID_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (dgvThucAn.SelectedCells.Count > 0 && dgvThucAn.CurrentRow != null && !dangThemMon)
                {
                    if (dgvThucAn.CurrentRow.Cells["IdCategory"]?.Value != null)
                    {
                        int maDanhMuc = (int)dgvThucAn.CurrentRow.Cells["IdCategory"].Value;
                        var danhMuc = danhMucDB.GetCategoryByID(maDanhMuc);
                        if (danhMuc != null)
                        {
                            cboDoanhMuc.SelectedValue = danhMuc.ID;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Lỗi cập nhật combobox: " + ex.Message);
            }
        }
        private void btnThem3_Click(object sender, EventArgs e)
        {
            dangThemTaiKhoan = true;
            XoaDuLieuTaiKhoan();
            TatBatDieuKhienTaiKhoan(true);
            txtTenTK.Focus();
        }

        private void btnSua3_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtTenTK.Text))
            {
                MessageBox.Show("Chưa chọn tài khoản nào để sửa");
                return;
            }

            dangThemTaiKhoan = false;
            TatBatDieuKhienTaiKhoan(true);
            txtTenHienThi.Focus();
        }

        private void btnLuuAccount_Click(object sender, EventArgs e)
        {
            try
            {
                if (dangThemTaiKhoan)
                {
                    string tenDangNhap = txtTenTK.Text;
                    string tenHienThi = txtTenHienThi.Text;
                    int loai = (int)nmrLoai.Value;

                    if (string.IsNullOrEmpty(tenDangNhap))
                    {
                        MessageBox.Show("Chưa nhập tên tài khoản");
                        return;
                    }

                    if (string.IsNullOrEmpty(tenHienThi))
                    {
                        MessageBox.Show("Chưa nhập tên hiển thị");
                        return;
                    }

                    if (taiKhoanDB.ThemTK(tenDangNhap, tenHienThi, loai))
                    {
                        MessageBox.Show("Đã thêm tài khoản thành công");
                        TaiTaiKhoan();
                        TatBatDieuKhienTaiKhoan(false);
                        dangThemTaiKhoan = false;
                        XoaDuLieuTaiKhoan();
                    }
                    else
                    {
                        MessageBox.Show("Thêm tài khoản không thành công");
                    }
                }
                else
                {
                    if (string.IsNullOrEmpty(txtTenTK.Text))
                    {
                        MessageBox.Show("Chưa chọn tài khoản nào để sửa");
                        return;
                    }

                    string tenDangNhap = txtTenTK.Text;
                    string tenHienThi = txtTenHienThi.Text;
                    int loai = (int)nmrLoai.Value;

                    if (string.IsNullOrEmpty(tenHienThi))
                    {
                        MessageBox.Show("Chưa nhập tên hiển thị");
                        return;
                    }

                    if (taiKhoanDB.CapNhatTK(tenDangNhap, tenHienThi, loai))
                    {
                        MessageBox.Show("Đã cập nhật tài khoản thành công");
                        TaiTaiKhoan();
                        TatBatDieuKhienTaiKhoan(false);
                    }
                    else
                    {
                        MessageBox.Show("Cập nhật tài khoản không thành công");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi lưu tài khoản: " + ex.Message);
            }
        }

        private void btnXoa3_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(txtTenTK.Text))
                {
                    MessageBox.Show("Chưa chọn tài khoản nào để xóa");
                    return;
                }

                string tenDangNhap = txtTenTK.Text;

                if (taiKhoanDangNhap.UserName.Equals(tenDangNhap))
                {
                    MessageBox.Show("Không thể xóa tài khoản đang đăng nhập");
                    return;
                }

                if (MessageBox.Show("Bạn có chắc muốn xóa tài khoản này không?", "Xác nhận",
                    MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    if (taiKhoanDB.XoaTK(tenDangNhap))
                    {
                        MessageBox.Show("Đã xóa tài khoản thành công");
                        TaiTaiKhoan();
                        XoaDuLieuTaiKhoan();
                    }
                    else
                    {
                        MessageBox.Show("Xóa tài khoản không thành công");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi xóa tài khoản: " + ex.Message);
            }
        }

        private void btnResetPassword_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(txtTenTK.Text))
                {
                    MessageBox.Show("Chưa chọn tài khoản nào để reset mật khẩu");
                    return;
                }

                string tenDangNhap = txtTenTK.Text;
                DialogResult xacNhan = MessageBox.Show(
                    $"Bạn có chắc muốn reset mật khẩu cho tài khoản '{tenDangNhap}'?\nMật khẩu sẽ được đặt lại là '123456'",
                    "Xác nhận Reset Mật khẩu",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question);

                if (xacNhan == DialogResult.Yes)
                {
                    if (taiKhoanDB.ResetPassword(tenDangNhap))
                    {
                        MessageBox.Show($"Đã reset mật khẩu thành công!\nTài khoản: {tenDangNhap}\nMật khẩu mới: 123456",
                                      "Thành công",
                                      MessageBoxButtons.OK,
                                      MessageBoxIcon.Information);
                        TaiTaiKhoan();
                    }
                    else
                    {
                        MessageBox.Show("Reset mật khẩu không thành công", "Lỗi",
                                      MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi reset mật khẩu: {ex.Message}", "Lỗi",
                               MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        #endregion
        private void btnThem1_Click(object sender, EventArgs e)
        {
            dangThemDanhMuc = true;
            XoaDuLieuDanhMuc();
            TatBatDieuKhienDanhMuc(true);
            txtTenDoanhMuc.Focus();
        }

        private void btnSua1_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtMaDoanhMuc.Text))
            {
                MessageBox.Show("Chưa chọn danh mục nào để sửa");
                return;
            }

            dangThemDanhMuc = false;
            TatBatDieuKhienDanhMuc(true);
            txtTenDoanhMuc.Focus();
        }

        private void btnLuu1_Click(object sender, EventArgs e)
        {
            try
            {
                if (dangThemDanhMuc)
                {
                    string ten = txtTenDoanhMuc.Text;

                    if (string.IsNullOrEmpty(ten))
                    {
                        MessageBox.Show("Chưa nhập tên danh mục");
                        return;
                    }

                    if (danhMucDB.InsertCategory(ten))
                    {
                        MessageBox.Show("Đã thêm danh mục thành công");
                        TaiDanhSachDanhMuc();
                        TaiDanhMucVaoCombobox(cboDoanhMuc);
                        TatBatDieuKhienDanhMuc(false);
                        dangThemDanhMuc = false;
                        XoaDuLieuDanhMuc();
                    }
                    else
                    {
                        MessageBox.Show("Thêm danh mục không thành công");
                    }
                }
                else
                {
                    if (string.IsNullOrEmpty(txtMaDoanhMuc.Text))
                    {
                        MessageBox.Show("Chưa chọn danh mục nào để sửa");
                        return;
                    }

                    string ten = txtTenDoanhMuc.Text;
                    int id = Convert.ToInt32(txtMaDoanhMuc.Text);

                    if (string.IsNullOrEmpty(ten))
                    {
                        MessageBox.Show("Chưa nhập tên danh mục");
                        return;
                    }

                    if (danhMucDB.UpdateCategory(id, ten))
                    {
                        MessageBox.Show("Đã cập nhật danh mục thành công");
                        TaiDanhSachDanhMuc();
                        TaiDanhMucVaoCombobox(cboDoanhMuc);
                        TatBatDieuKhienDanhMuc(false);
                    }
                    else
                    {
                        MessageBox.Show("Cập nhật danh mục không thành công");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi lưu danh mục: " + ex.Message);
            }
        }

        private void btnXoa1_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(txtMaDoanhMuc.Text))
                {
                    MessageBox.Show("Chưa chọn danh mục nào để xóa");
                    return;
                }

                int id = Convert.ToInt32(txtMaDoanhMuc.Text);

                if (monAnDB.IsCategoryInUse(id))
                {
                    MessageBox.Show("Không thể xóa danh mục này vì có món ăn đang sử dụng", "Lỗi",
                                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                if (MessageBox.Show("Bạn có chắc muốn xóa danh mục này không?", "Xác nhận",
                    MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    if (danhMucDB.DeleteCategory(id))
                    {
                        MessageBox.Show("Đã xóa danh mục thành công");
                        TaiDanhSachDanhMuc();
                        TaiDanhMucVaoCombobox(cboDoanhMuc);
                        XoaDuLieuDanhMuc();
                    }
                    else
                    {
                        MessageBox.Show("Xóa danh mục không thành công");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi xóa danh mục: " + ex.Message);
            }
        }
        private void btnThem2_Click(object sender, EventArgs e)
        {
            dangThemBan = true;
            XoaDuLieuBan();
            TatBatDieuKhienBan(true);
            txtTenBan.Focus();
        }

        private void btnSua2_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtIDTable.Text))
            {
                MessageBox.Show("Chưa chọn bàn nào để sửa");
                return;
            }

            dangThemBan = false;
            TatBatDieuKhienBan(true);
            txtTenBan.Focus();
        }

        private void btnLuu2_Click(object sender, EventArgs e)
        {
            try
            {
                if (dangThemBan)
                {
                    string ten = txtTenBan.Text;
                    string trangThai = txtTrangThai.Text;

                    if (string.IsNullOrEmpty(ten))
                    {
                        MessageBox.Show("Chưa nhập tên bàn");
                        return;
                    }

                    if (string.IsNullOrEmpty(trangThai))
                    {
                        MessageBox.Show("Chưa nhập trạng thái");
                        return;
                    }

                    if (ThemBanVaoCSDL(ten, trangThai))
                    {
                        MessageBox.Show("Đã thêm bàn thành công");
                        TaiDanhSachBan();
                        TatBatDieuKhienBan(false);
                        dangThemBan = false;
                        XoaDuLieuBan();
                    }
                    else
                    {
                        MessageBox.Show("Thêm bàn không thành công");
                    }
                }
                else
                {
                    if (string.IsNullOrEmpty(txtIDTable.Text))
                    {
                        MessageBox.Show("Chưa chọn bàn nào để sửa");
                        return;
                    }

                    string ten = txtTenBan.Text;
                    string trangThai = txtTrangThai.Text;
                    int id = Convert.ToInt32(txtIDTable.Text);

                    if (string.IsNullOrEmpty(ten))
                    {
                        MessageBox.Show("Chưa nhập tên bàn");
                        return;
                    }

                    if (string.IsNullOrEmpty(trangThai))
                    {
                        MessageBox.Show("Chưa nhập trạng thái");
                        return;
                    }

                    if (SuaBanTrongCSDL(id, ten, trangThai))
                    {
                        MessageBox.Show("Đã cập nhật bàn thành công");
                        TaiDanhSachBan();
                        TatBatDieuKhienBan(false);
                    }
                    else
                    {
                        MessageBox.Show("Cập nhật bàn không thành công");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi lưu bàn: " + ex.Message);
            }
        }

        private void btnXoa2_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(txtIDTable.Text))
                {
                    MessageBox.Show("Chưa chọn bàn nào để xóa");
                    return;
                }

                int id = Convert.ToInt32(txtIDTable.Text);

                if (MessageBox.Show("Bạn có chắc muốn xóa bàn này không?", "Xác nhận",
                    MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    if (XoaBanKhoiCSDL(id))
                    {
                        MessageBox.Show("Đã xóa bàn thành công");
                        TaiDanhSachBan();
                        XoaDuLieuBan();
                    }
                    else
                    {
                        MessageBox.Show("Xóa bàn không thành công");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi xóa bàn: " + ex.Message);
            }
        }
        private void btnThongKe_Click(object sender, EventArgs e)
        {
            TaiHoaDonTheoNgay(dtpBatDau.Value, dtpKetThuc.Value);
        }

        private void btnFirstBillPage_Click(object sender, EventArgs e)
        {
            txbPageBill.Text = "1";
        }

        private void btnLastBillPage_Click(object sender, EventArgs e)
        {
            try
            {
                int tongSoHD = hoaDonDB.GetNumBillListByDate(dtpBatDau.Value, dtpKetThuc.Value);
                int trangCuoi = tongSoHD / 10;

                if (tongSoHD % 10 != 0)
                    trangCuoi++;

                txbPageBill.Text = trangCuoi.ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi chuyển đến trang cuối: " + ex.Message);
            }
        }

        private void txbPageBill_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (!string.IsNullOrEmpty(txbPageBill.Text))
                {
                    int trang = Convert.ToInt32(txbPageBill.Text);
                    dgvBill.DataSource = hoaDonDB.GetBillListByDateAndPage(dtpBatDau.Value, dtpKetThuc.Value, trang);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi chuyển trang: " + ex.Message);
            }
        }

        private void btnPreviousBillPage_Click(object sender, EventArgs e)
        {
            try
            {
                if (!string.IsNullOrEmpty(txbPageBill.Text))
                {
                    int trang = Convert.ToInt32(txbPageBill.Text);
                    if (trang > 1)
                        trang--;

                    txbPageBill.Text = trang.ToString();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi chuyển trang: " + ex.Message);
            }
        }

        private void btnNextBillPage_Click(object sender, EventArgs e)
        {
            try
            {
                if (!string.IsNullOrEmpty(txbPageBill.Text))
                {
                    int trang = Convert.ToInt32(txbPageBill.Text);
                    int tongSoHD = hoaDonDB.GetNumBillListByDate(dtpBatDau.Value, dtpKetThuc.Value);

                    if (trang < tongSoHD)
                        trang++;

                    txbPageBill.Text = trang.ToString();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi chuyển trang: " + ex.Message);
            }
        }
        private void btnViewReport_Click(object sender, EventArgs e)
        {
            TaiDuLieuBaoCao(dtpFromReport.Value, dtpToReport.Value);
        }

        private void btnToday_Click(object sender, EventArgs e)
        {
            DateTime homNay = DateTime.Now;
            dtpFromReport.Value = homNay;
            dtpToReport.Value = homNay;
            TaiDuLieuBaoCao(homNay, homNay);
        }

        private void btnThisMonth_Click(object sender, EventArgs e)
        {
            DateTime ngayDauThang = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1);
            DateTime homNay = DateTime.Now;
            dtpFromReport.Value = ngayDauThang;
            dtpToReport.Value = homNay;
            TaiDuLieuBaoCao(ngayDauThang, homNay);
        }

        private void btnLastMonth_Click(object sender, EventArgs e)
        {
            DateTime ngayDauThangTruoc = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1).AddMonths(-1);
            DateTime ngayCuoiThangTruoc = ngayDauThangTruoc.AddMonths(1).AddDays(-1);
            dtpFromReport.Value = ngayDauThangTruoc;
            dtpToReport.Value = ngayCuoiThangTruoc;
            TaiDuLieuBaoCao(ngayDauThangTruoc, ngayCuoiThangTruoc);
        }

        private void btnExportExcel_Click(object sender, EventArgs e)
        {
            XuatExcel(dtgvReport);
        }

        private void TaiDuLieuBaoCao(DateTime tuNgay, DateTime denNgay)
        {
            try
            {
                DataTable duLieuBaoCao = baoCaoDB.GetBillReport(tuNgay, denNgay);
                dtgvReport.DataSource = duLieuBaoCao;

                decimal tongDoanhThu = 0;
                int tongHoaDon = duLieuBaoCao.Rows.Count;

                foreach (DataRow dong in duLieuBaoCao.Rows)
                {
                    tongDoanhThu += Convert.ToDecimal(dong["FinalPrice"]);
                }

                decimal trungBinhHD = tongHoaDon > 0 ? tongDoanhThu / tongHoaDon : 0;

                txtTotalBills.Text = $"{tongHoaDon}";
                txtTotalRevenue.Text = $"{tongDoanhThu:N0} VND";
                txtAverageBill.Text = $"{trungBinhHD:N0} VND";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi tải báo cáo: " + ex.Message);
            }
        }

        private void XuatExcel(DataGridView bangDuLieu)
        {
            SaveFileDialog luuFile = new SaveFileDialog();
            luuFile.Filter = "Excel Files|*.xlsx";
            luuFile.Title = "Lưu báo cáo";

            if (luuFile.ShowDialog() == DialogResult.OK)
            {
                using (var ghi = new System.IO.StreamWriter(luuFile.FileName, false, System.Text.Encoding.UTF8))
                {
                    var tieuDe = new List<string>();
                    foreach (DataGridViewColumn cot in bangDuLieu.Columns)
                    {
                        tieuDe.Add(cot.HeaderText);
                    }
                    ghi.WriteLine(string.Join(",", tieuDe));
                    foreach (DataGridViewRow dong in bangDuLieu.Rows)
                    {
                        if (!dong.IsNewRow)
                        {
                            var o = new List<string>();
                            foreach (DataGridViewCell cell in dong.Cells)
                            {
                                o.Add(cell.Value?.ToString() ?? "");
                            }
                            ghi.WriteLine(string.Join(",", o));
                        }
                    }
                }
                MessageBox.Show("Xuất báo cáo thành công!");
            }
        }
        private void fAdmin_Load(object sender, EventArgs e)
        {
            try
            {
                TaiDuLieu();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Có lỗi xảy ra khi tải dữ liệu.", "Lỗi",
                               MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dgvThucAn_SelectionChanged(object sender, EventArgs e)
        {
            try
            {
                if (dgvThucAn.SelectedRows.Count > 0 && !dangThemMon)
                {
                    DataGridViewRow dongDaChon = dgvThucAn.SelectedRows[0];
                    txtID.Text = dongDaChon.Cells["ID"].Value?.ToString() ?? "";
                    txtTenMon.Text = dongDaChon.Cells["Name"].Value?.ToString() ?? "";

                    if (dongDaChon.Cells["Price"].Value != null)
                    {
                        nmGia.Value = Convert.ToDecimal(dongDaChon.Cells["Price"].Value);
                    }

                    if (dongDaChon.Cells["IdCategory"]?.Value != null)
                    {
                        int maDanhMuc = (int)dongDaChon.Cells["IdCategory"].Value;
                        cboDoanhMuc.SelectedValue = maDanhMuc;
                    }

                    TatBatDieuKhienMonAn(false);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Lỗi khi chọn dòng: " + ex.Message);
            }
        }

        private void dgvAccount_SelectionChanged(object sender, EventArgs e)
        {
            try
            {
                if (dgvAccount.SelectedRows.Count > 0 && !dangThemTaiKhoan)
                {
                    DataGridViewRow dongDaChon = dgvAccount.SelectedRows[0];
                    txtTenTK.Text = dongDaChon.Cells["UserName"].Value?.ToString() ?? "";
                    txtTenHienThi.Text = dongDaChon.Cells["DisplayName"].Value?.ToString() ?? "";

                    if (dongDaChon.Cells["Type"].Value != null)
                    {
                        nmrLoai.Value = Convert.ToDecimal(dongDaChon.Cells["Type"].Value);
                    }

                    TatBatDieuKhienTaiKhoan(false);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Lỗi khi chọn dòng tài khoản: " + ex.Message);
            }
        }

        private void dgvDoanhMuc_SelectionChanged(object sender, EventArgs e)
        {
            try
            {
                if (dgvDoanhMuc.SelectedRows.Count > 0 && !dangThemDanhMuc)
                {
                    DataGridViewRow dongDaChon = dgvDoanhMuc.SelectedRows[0];
                    txtMaDoanhMuc.Text = dongDaChon.Cells["ID"].Value?.ToString() ?? "";
                    txtTenDoanhMuc.Text = dongDaChon.Cells["Name"].Value?.ToString() ?? "";

                    TatBatDieuKhienDanhMuc(false);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Lỗi khi chọn dòng danh mục: " + ex.Message);
            }
        }

        private void dgvBan_SelectionChanged(object sender, EventArgs e)
        {
            try
            {
                if (dgvBan.SelectedRows.Count > 0 && !dangThemBan)
                {
                    DataGridViewRow dongDaChon = dgvBan.SelectedRows[0];
                    txtIDTable.Text = dongDaChon.Cells["id"].Value?.ToString() ?? "";
                    txtTenBan.Text = dongDaChon.Cells["name"].Value?.ToString() ?? "";
                    txtTrangThai.Text = dongDaChon.Cells["status"].Value?.ToString() ?? "";

                    TatBatDieuKhienBan(false);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Lỗi khi chọn dòng bàn: " + ex.Message);
            }
        }
    }
}