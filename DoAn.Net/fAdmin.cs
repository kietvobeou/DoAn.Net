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
        private BindingSource foodList = new BindingSource();
        private BindingSource accountList = new BindingSource();
        private BindingSource categoryList = new BindingSource();
        private BindingSource tableList = new BindingSource();
        private DBTaiKhoan dbTaiKhoan = new DBTaiKhoan();
        private DBMonAn dbMonAn = new DBMonAn();
        private DBDanhMuc dbDanhMuc = new DBDanhMuc();
        private DBHoaDon dbHoaDon = new DBHoaDon();
        private DBReport dbReport = new DBReport();
        private DBBan dbBan = new DBBan();
        public TaiKhoan loginTaiKhoan;
        private bool isAddingFood = false;
        private bool isAddingAccount = false;
        private bool isAddingCategory = false;
        private bool isAddingTable = false;

        public fAdmin()
        {
            InitializeComponent();
            GanSuKien();
            LoadData();
        }

        private void GanSuKien()
        {
            // Gán sự kiện theo đúng tên của controls
            this.btnThongKe.Click += new System.EventHandler(this.btnThongKe_Click);
            this.btnFirstBillPage.Click += new System.EventHandler(this.btnFirstBillPage_Click);
            this.btnPrevioursBillPage.Click += new System.EventHandler(this.btnPreviousBillPage_Click);
            this.btnNextBillPage.Click += new System.EventHandler(this.btnNextBillPage_Click);
            this.btnLastBillPage.Click += new System.EventHandler(this.btnLastBillPage_Click);
            this.txbPageBill.TextChanged += new System.EventHandler(this.txbPageBill_TextChanged);
            this.btnThem.Click += new System.EventHandler(this.btnThem_Click);
            this.btnSua.Click += new System.EventHandler(this.btnSua_Click);
            this.btnXoa.Click += new System.EventHandler(this.btnXoa_Click);
            this.btnLuu.Click += new System.EventHandler(this.btnLuu_Click);
            this.btnTim.Click += new System.EventHandler(this.btnTim_Click);
            this.txtID.TextChanged += new System.EventHandler(this.txtID_TextChanged);
            this.dgvThucAn.SelectionChanged += new System.EventHandler(this.dgvThucAn_SelectionChanged);
            this.btnThem3.Click += new System.EventHandler(this.btnThem3_Click);
            this.btnXoa3.Click += new System.EventHandler(this.btnXoa3_Click);
            this.btnSua3.Click += new System.EventHandler(this.btnSua3_Click);
            this.btnLuuAccount.Click += new System.EventHandler(this.btnLuuAccount_Click);
            this.btnResetPassword.Click += new System.EventHandler(this.btnResetPassword_Click);
            this.btnViewReport.Click += new System.EventHandler(this.btnViewReport_Click);
            this.btnToday.Click += new System.EventHandler(this.btnToday_Click);
            this.btnThisMonth.Click += new System.EventHandler(this.btnThisMonth_Click);
            this.btnLastMonth.Click += new System.EventHandler(this.btnLastMonth_Click);
            this.btnExportExcel.Click += new System.EventHandler(this.btnExportExcel_Click);
            this.Load += new System.EventHandler(this.fAdmin_Load);
            this.dgvAccount.SelectionChanged += new System.EventHandler(this.dgvAccount_SelectionChanged);
            this.btnThem1.Click += new System.EventHandler(this.btnThem1_Click);
            this.btnXoa1.Click += new System.EventHandler(this.btnXoa1_Click);
            this.btnSua1.Click += new System.EventHandler(this.btnSua1_Click);
            this.btnLuu1.Click += new System.EventHandler(this.btnLuu1_Click);
            this.dgvDoanhMuc.SelectionChanged += new System.EventHandler(this.dgvDoanhMuc_SelectionChanged);
            this.btnThem2.Click += new System.EventHandler(this.btnThem2_Click);
            this.btnXoa2.Click += new System.EventHandler(this.btnXoa2_Click);
            this.btnSua2.Click += new System.EventHandler(this.btnSua2_Click);
            this.btnLuu2.Click += new System.EventHandler(this.btnLuu2_Click);
            this.dgvBan.SelectionChanged += new System.EventHandler(this.dgvBan_SelectionChanged);
            this.btnResetPassword.Click += new System.EventHandler(this.btnResetPassword_Click);
        }

        #region methods

        private void LoadData()
        {
            try
            {
                LoadListFood();
                LoadAccount();
                LoadListCategory();
                LoadListTable();
                LoadDateTimePickerBill();
                LoadListBillByDate(dtpBatDau.Value, dtpKetThuc.Value);
                LoadCategoryIntoCombobox(cboDoanhMuc);
                dgvThucAn.DataSource = foodList;
                dgvAccount.DataSource = accountList;
                dgvDoanhMuc.DataSource = categoryList;
                dgvBan.DataSource = tableList;
                DataBindingsMonAn();
                DataBindingsAccount();
                DataBindingsCategory();
                DataBindingsTable();
                dgvThucAn.ClearSelection();
                dgvAccount.ClearSelection();
                dgvDoanhMuc.ClearSelection();
                dgvBan.ClearSelection();
                SetFoodControlsEnabled(false);
                SetAccountControlsEnabled(false);
                SetCategoryControlsEnabled(false);
                SetTableControlsEnabled(false);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi trong LoadData: {ex.Message}", "Lỗi",
                               MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void DataBindingsMonAn()
        {
            txtTenMon.DataBindings.Clear();
            txtID.DataBindings.Clear();
            nmGia.DataBindings.Clear();
            txtTenMon.DataBindings.Add(new Binding("Text", dgvThucAn.DataSource, "Name", true, DataSourceUpdateMode.Never));
            txtID.DataBindings.Add(new Binding("Text", dgvThucAn.DataSource, "ID", true, DataSourceUpdateMode.Never));
            nmGia.DataBindings.Add(new Binding("Value", dgvThucAn.DataSource, "Price", true, DataSourceUpdateMode.Never));
        }

        private void DataBindingsAccount()
        {
            txtTenTK.DataBindings.Clear();
            txtTenHienThi.DataBindings.Clear();
            nmrLoai.DataBindings.Clear();
            txtTenTK.DataBindings.Add(new Binding("Text", dgvAccount.DataSource, "UserName", true, DataSourceUpdateMode.Never));
            txtTenHienThi.DataBindings.Add(new Binding("Text", dgvAccount.DataSource, "DisplayName", true, DataSourceUpdateMode.Never));
            nmrLoai.DataBindings.Add(new Binding("Value", dgvAccount.DataSource, "Type", true, DataSourceUpdateMode.Never));
        }

        private void DataBindingsCategory()
        {
            txtMaDoanhMuc.DataBindings.Clear();
            txtTenDoanhMuc.DataBindings.Clear();
            txtMaDoanhMuc.DataBindings.Add(new Binding("Text", dgvDoanhMuc.DataSource, "ID", true, DataSourceUpdateMode.Never));
            txtTenDoanhMuc.DataBindings.Add(new Binding("Text", dgvDoanhMuc.DataSource, "Name", true, DataSourceUpdateMode.Never));
        }

        private void DataBindingsTable()
        {
            txtIDTable.DataBindings.Clear();
            txtTenBan.DataBindings.Clear();
            txtTrangThai.DataBindings.Clear();
            txtIDTable.DataBindings.Add(new Binding("Text", dgvBan.DataSource, "Id", true, DataSourceUpdateMode.Never));
            txtTenBan.DataBindings.Add(new Binding("Text", dgvBan.DataSource, "Name", true, DataSourceUpdateMode.Never));
            txtTrangThai.DataBindings.Add(new Binding("Text", dgvBan.DataSource, "Status", true, DataSourceUpdateMode.Never));
        }

        private void SetFoodControlsEnabled(bool enabled)
        {
            txtTenMon.Enabled = enabled;
            nmGia.Enabled = enabled;
            cboDoanhMuc.Enabled = enabled;
            btnLuu.Enabled = enabled;
            btnSua.Enabled = !enabled;
            btnXoa.Enabled = !enabled;
            btnThem.Enabled = !enabled;
            txtID.Enabled = false;
        }

        private void SetAccountControlsEnabled(bool enabled)
        {
            txtTenTK.Enabled = enabled;
            txtTenHienThi.Enabled = enabled;
            nmrLoai.Enabled = enabled;
            btnLuuAccount.Enabled = enabled;
            btnSua3.Enabled = !enabled;
            btnXoa3.Enabled = !enabled;
            btnThem3.Enabled = !enabled;
            btnResetPassword.Enabled = !enabled;
        }

        private void SetCategoryControlsEnabled(bool enabled)
        {
            txtTenDoanhMuc.Enabled = enabled;
            btnLuu1.Enabled = enabled;
            btnSua1.Enabled = !enabled;
            btnXoa1.Enabled = !enabled;
            btnThem1.Enabled = !enabled;
            txtMaDoanhMuc.Enabled = false;
        }

        private void SetTableControlsEnabled(bool enabled)
        {
            txtTenBan.Enabled = enabled;
            txtTrangThai.Enabled = enabled;
            btnLuu2.Enabled = enabled;
            btnSua2.Enabled = !enabled;
            btnXoa2.Enabled = !enabled;
            btnThem2.Enabled = !enabled;
            txtIDTable.Enabled = false;
        }

        private void ClearFoodControls()
        {
            txtTenMon.Text = "";
            txtID.Text = "";
            nmGia.Value = 0;
            cboDoanhMuc.SelectedIndex = -1;
        }

        private void ClearAccountControls()
        {
            txtTenTK.Text = "";
            txtTenHienThi.Text = "";
            nmrLoai.Value = 0;
        }

        private void ClearCategoryControls()
        {
            txtMaDoanhMuc.Text = "";
            txtTenDoanhMuc.Text = "";
        }

        private void ClearTableControls()
        {
            txtIDTable.Text = "";
            txtTenBan.Text = "";
            txtTrangThai.Text = "";
        }

        private void LoadAccount()
        {
            try
            {
                accountList.DataSource = dbTaiKhoan.LayDSTK();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tải tài khoản: " + ex.Message);
            }
        }

        private void LoadListCategory()
        {
            try
            {
                categoryList.DataSource = dbDanhMuc.GetListCategory();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tải danh mục: " + ex.Message);
            }
        }

        private void LoadListTable()
        {
            try
            {
                tableList.DataSource = dbBan.LoadTableList();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tải bàn: " + ex.Message);
            }
        }

        private void LoadDateTimePickerBill()
        {
            DateTime today = DateTime.Now;
            dtpBatDau.Value = new DateTime(today.Year, today.Month, 1);
            dtpKetThuc.Value = dtpBatDau.Value.AddMonths(1).AddDays(-1);
        }

        private void LoadListBillByDate(DateTime checkIn, DateTime checkOut)
        {
            try
            {
                dgvBill.DataSource = dbHoaDon.GetBillListByDate(checkIn, checkOut);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tải hóa đơn: " + ex.Message);
            }
        }

        private void LoadCategoryIntoCombobox(ComboBox cb)
        {
            try
            {
                categoryList.DataSource = dbDanhMuc.GetListCategory();
                cb.DataSource = categoryList;
                cb.DisplayMember = "Name";
                cb.ValueMember = "ID";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tải danh mục: " + ex.Message);
            }
        }

        private void LoadListFood()
        {
            try
            {
                foodList.DataSource = dbMonAn.GetListFood();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tải món ăn: " + ex.Message);
            }
        }

        private bool InsertTableToDatabase(string name, string status)
        {
            try
            {
                var adapter = new BanTableAdapter();
                adapter.Insert(name, status);
                return true;
            }
            catch
            {
                return false;
            }
        }

        private bool UpdateTableInDatabase(int id, string name, string status)
        {
            try
            {
                var adapter = new BanTableAdapter();
                int result = adapter.UpdateTable(name, status, id);
                return result > 0;
            }
            catch
            {
                return false;
            }
        }

        private bool DeleteTableFromDatabase(int id)
        {
            try
            {
                var adapter = new BanTableAdapter();
                int result = adapter.DeleteTable(id);
                return result > 0;
            }
            catch
            {
                return false;
            }
        }

        #endregion

        #region events - Food
        private void btnThem_Click(object sender, EventArgs e)
        {
            isAddingFood = true;
            ClearFoodControls();
            SetFoodControlsEnabled(true);
            txtTenMon.Focus();
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtID.Text))
            {
                MessageBox.Show("Vui lòng chọn món ăn cần sửa");
                return;
            }

            isAddingFood = false;
            SetFoodControlsEnabled(true);
            txtTenMon.Focus();
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            try
            {
                if (isAddingFood)
                {
                    string name = txtTenMon.Text;
                    int categoryID = (cboDoanhMuc.SelectedValue != null) ? (int)cboDoanhMuc.SelectedValue : 0;
                    float price = (float)nmGia.Value;

                    if (string.IsNullOrEmpty(name))
                    {
                        MessageBox.Show("Vui lòng nhập tên món");
                        return;
                    }

                    if (categoryID == 0)
                    {
                        MessageBox.Show("Vui lòng chọn danh mục");
                        return;
                    }

                    if (dbMonAn.InsertFood(name, categoryID, price))
                    {
                        MessageBox.Show("Thêm món thành công");
                        LoadListFood();
                        SetFoodControlsEnabled(false);
                        isAddingFood = false;
                        ClearFoodControls();
                    }
                    else
                    {
                        MessageBox.Show("Có lỗi khi thêm thức ăn");
                    }
                }
                else
                {
                    if (string.IsNullOrEmpty(txtID.Text))
                    {
                        MessageBox.Show("Vui lòng chọn món ăn cần sửa");
                        return;
                    }

                    string name = txtTenMon.Text;
                    int categoryID = (cboDoanhMuc.SelectedValue != null) ? (int)cboDoanhMuc.SelectedValue : 0;
                    float price = (float)nmGia.Value;
                    int id = Convert.ToInt32(txtID.Text);

                    if (string.IsNullOrEmpty(name))
                    {
                        MessageBox.Show("Vui lòng nhập tên món");
                        return;
                    }

                    if (categoryID == 0)
                    {
                        MessageBox.Show("Vui lòng chọn danh mục");
                        return;
                    }

                    if (dbMonAn.UpdateFood(id, name, categoryID, price))
                    {
                        MessageBox.Show("Sửa món thành công");
                        LoadListFood();
                        SetFoodControlsEnabled(false);
                    }
                    else
                    {
                        MessageBox.Show("Có lỗi khi sửa thức ăn");
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
                    MessageBox.Show("Vui lòng chọn món ăn cần xóa");
                    return;
                }

                int id = Convert.ToInt32(txtID.Text);

                if (MessageBox.Show("Bạn có chắc chắn muốn xóa món này?", "Xác nhận",
                    MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    if (dbMonAn.DeleteFood(id))
                    {
                        MessageBox.Show("Xóa món thành công");
                        LoadListFood();
                        ClearFoodControls();
                    }
                    else
                    {
                        MessageBox.Show("Có lỗi khi xóa thức ăn");
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
                string searchName = txtSearchFood.Text;
                foodList.DataSource = dbMonAn.SearchFoodByName(searchName);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tìm kiếm món ăn: " + ex.Message);
            }
        }

        private void txtID_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (dgvThucAn.SelectedCells.Count > 0 && dgvThucAn.CurrentRow != null && !isAddingFood)
                {
                    if (dgvThucAn.CurrentRow.Cells["IdCategory"]?.Value != null)
                    {
                        int categoryID = (int)dgvThucAn.CurrentRow.Cells["IdCategory"].Value;
                        var category = dbDanhMuc.GetCategoryByID(categoryID);
                        if (category != null)
                        {
                            cboDoanhMuc.SelectedValue = category.ID;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Lỗi khi cập nhật combobox: " + ex.Message);
            }
        }
        #endregion

        #region events - Account
        private void btnThem3_Click(object sender, EventArgs e)
        {
            isAddingAccount = true;
            ClearAccountControls();
            SetAccountControlsEnabled(true);
            txtTenTK.Focus();
        }

        private void btnSua3_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtTenTK.Text))
            {
                MessageBox.Show("Vui lòng chọn tài khoản cần sửa");
                return;
            }

            isAddingAccount = false;
            SetAccountControlsEnabled(true);
            txtTenHienThi.Focus();
        }

        private void btnLuuAccount_Click(object sender, EventArgs e)
        {
            try
            {
                if (isAddingAccount)
                {
                    string userName = txtTenTK.Text;
                    string displayName = txtTenHienThi.Text;
                    int type = (int)nmrLoai.Value;

                    if (string.IsNullOrEmpty(userName))
                    {
                        MessageBox.Show("Vui lòng nhập tên tài khoản");
                        return;
                    }

                    if (string.IsNullOrEmpty(displayName))
                    {
                        MessageBox.Show("Vui lòng nhập tên hiển thị");
                        return;
                    }

                    if (dbTaiKhoan.ThemTK(userName, displayName, type))
                    {
                        MessageBox.Show("Thêm tài khoản thành công");
                        LoadAccount();
                        SetAccountControlsEnabled(false);
                        isAddingAccount = false;
                        ClearAccountControls();
                    }
                    else
                    {
                        MessageBox.Show("Thêm tài khoản thất bại");
                    }
                }
                else
                {
                    if (string.IsNullOrEmpty(txtTenTK.Text))
                    {
                        MessageBox.Show("Vui lòng chọn tài khoản cần sửa");
                        return;
                    }

                    string userName = txtTenTK.Text;
                    string displayName = txtTenHienThi.Text;
                    int type = (int)nmrLoai.Value;

                    if (string.IsNullOrEmpty(displayName))
                    {
                        MessageBox.Show("Vui lòng nhập tên hiển thị");
                        return;
                    }

                    if (dbTaiKhoan.CapNhatTK(userName, displayName, type))
                    {
                        MessageBox.Show("Cập nhật tài khoản thành công");
                        LoadAccount();
                        SetAccountControlsEnabled(false);
                    }
                    else
                    {
                        MessageBox.Show("Cập nhật tài khoản thất bại");
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
                    MessageBox.Show("Vui lòng chọn tài khoản cần xóa");
                    return;
                }

                string userName = txtTenTK.Text;

                if (loginTaiKhoan.UserName.Equals(userName))
                {
                    MessageBox.Show("Vui lòng đừng xóa chính bạn chứ");
                    return;
                }

                if (MessageBox.Show("Bạn có chắc chắn muốn xóa tài khoản này?", "Xác nhận",
                    MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    if (dbTaiKhoan.XoaTK(userName))
                    {
                        MessageBox.Show("Xóa tài khoản thành công");
                        LoadAccount();
                        ClearAccountControls();
                    }
                    else
                    {
                        MessageBox.Show("Xóa tài khoản thất bại");
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
                    MessageBox.Show("Vui lòng chọn tài khoản cần reset mật khẩu");
                    return;
                }

                string userName = txtTenTK.Text;
                DialogResult dialogResult = MessageBox.Show(
                    $"Bạn có chắc chắn muốn reset mật khẩu cho tài khoản '{userName}'?\nMật khẩu sẽ được đặt về mặc định là '123456'",
                    "Xác nhận Reset Mật khẩu",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question);

                if (dialogResult == DialogResult.Yes)
                {
                    if (dbTaiKhoan.ResetPassword(userName))
                    {
                        MessageBox.Show($"Reset mật khẩu thành công!\nTài khoản: {userName}\nMật khẩu mới: 123456",
                                      "Thành công",
                                      MessageBoxButtons.OK,
                                      MessageBoxIcon.Information);
                        dgvAccount.DataSource = dbTaiKhoan.LayDSTK();
                    }
                    else
                    {
                        MessageBox.Show("Reset mật khẩu thất bại. Vui lòng thử lại!", "Lỗi",
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

        #region events - Category
        private void btnThem1_Click(object sender, EventArgs e)
        {
            isAddingCategory = true;
            ClearCategoryControls();
            SetCategoryControlsEnabled(true);
            txtTenDoanhMuc.Focus();
        }

        private void btnSua1_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtMaDoanhMuc.Text))
            {
                MessageBox.Show("Vui lòng chọn danh mục cần sửa");
                return;
            }

            isAddingCategory = false;
            SetCategoryControlsEnabled(true);
            txtTenDoanhMuc.Focus();
        }

        private void btnLuu1_Click(object sender, EventArgs e)
        {
            try
            {
                if (isAddingCategory)
                {
                    string name = txtTenDoanhMuc.Text;

                    if (string.IsNullOrEmpty(name))
                    {
                        MessageBox.Show("Vui lòng nhập tên danh mục");
                        return;
                    }

                    if (dbDanhMuc.InsertCategory(name))
                    {
                        MessageBox.Show("Thêm danh mục thành công");
                        LoadListCategory();
                        LoadCategoryIntoCombobox(cboDoanhMuc);
                        SetCategoryControlsEnabled(false);
                        isAddingCategory = false;
                        ClearCategoryControls();
                    }
                    else
                    {
                        MessageBox.Show("Thêm danh mục thất bại");
                    }
                }
                else
                {
                    if (string.IsNullOrEmpty(txtMaDoanhMuc.Text))
                    {
                        MessageBox.Show("Vui lòng chọn danh mục cần sửa");
                        return;
                    }

                    string name = txtTenDoanhMuc.Text;
                    int id = Convert.ToInt32(txtMaDoanhMuc.Text);

                    if (string.IsNullOrEmpty(name))
                    {
                        MessageBox.Show("Vui lòng nhập tên danh mục");
                        return;
                    }

                    if (dbDanhMuc.UpdateCategory(id, name))
                    {
                        MessageBox.Show("Cập nhật danh mục thành công");
                        LoadListCategory();
                        LoadCategoryIntoCombobox(cboDoanhMuc);
                        SetCategoryControlsEnabled(false);
                    }
                    else
                    {
                        MessageBox.Show("Cập nhật danh mục thất bại");
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
                    MessageBox.Show("Vui lòng chọn danh mục cần xóa");
                    return;
                }
                int id = Convert.ToInt32(txtMaDoanhMuc.Text);
                if (dbMonAn.IsCategoryInUse(id))
                {
                    MessageBox.Show("Không thể xóa danh mục này vì có món ăn đang sử dụng", "Lỗi",
                                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                if (MessageBox.Show("Bạn có chắc chắn muốn xóa danh mục này?", "Xác nhận",
                    MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    if (dbDanhMuc.DeleteCategory(id))
                    {
                        MessageBox.Show("Xóa danh mục thành công");
                        LoadListCategory();
                        LoadCategoryIntoCombobox(cboDoanhMuc);
                        ClearCategoryControls();
                    }
                    else
                    {
                        MessageBox.Show("Xóa danh mục thất bại");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi xóa danh mục: " + ex.Message);
            }
        }
        #endregion

        #region events - Table
        private void btnThem2_Click(object sender, EventArgs e)
        {
            isAddingTable = true;
            ClearTableControls();
            SetTableControlsEnabled(true);
            txtTenBan.Focus();
        }

        private void btnSua2_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtIDTable.Text))
            {
                MessageBox.Show("Vui lòng chọn bàn cần sửa");
                return;
            }

            isAddingTable = false;
            SetTableControlsEnabled(true);
            txtTenBan.Focus();
        }

        private void btnLuu2_Click(object sender, EventArgs e)
        {
            try
            {
                if (isAddingTable)
                {
                    string name = txtTenBan.Text;
                    string status = txtTrangThai.Text;

                    if (string.IsNullOrEmpty(name))
                    {
                        MessageBox.Show("Vui lòng nhập tên bàn");
                        return;
                    }

                    if (string.IsNullOrEmpty(status))
                    {
                        MessageBox.Show("Vui lòng nhập trạng thái");
                        return;
                    }

                    if (InsertTableToDatabase(name, status))
                    {
                        MessageBox.Show("Thêm bàn thành công");
                        LoadListTable();
                        SetTableControlsEnabled(false);
                        isAddingTable = false;
                        ClearTableControls();
                    }
                    else
                    {
                        MessageBox.Show("Thêm bàn thất bại");
                    }
                }
                else
                {
                    if (string.IsNullOrEmpty(txtIDTable.Text))
                    {
                        MessageBox.Show("Vui lòng chọn bàn cần sửa");
                        return;
                    }

                    string name = txtTenBan.Text;
                    string status = txtTrangThai.Text;
                    int id = Convert.ToInt32(txtIDTable.Text);

                    if (string.IsNullOrEmpty(name))
                    {
                        MessageBox.Show("Vui lòng nhập tên bàn");
                        return;
                    }

                    if (string.IsNullOrEmpty(status))
                    {
                        MessageBox.Show("Vui lòng nhập trạng thái");
                        return;
                    }

                    if (UpdateTableInDatabase(id, name, status))
                    {
                        MessageBox.Show("Cập nhật bàn thành công");
                        LoadListTable();
                        SetTableControlsEnabled(false);
                    }
                    else
                    {
                        MessageBox.Show("Cập nhật bàn thất bại");
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
                    MessageBox.Show("Vui lòng chọn bàn cần xóa");
                    return;
                }
                int id = Convert.ToInt32(txtIDTable.Text);
                if (MessageBox.Show("Bạn có chắc chắn muốn xóa bàn này?", "Xác nhận",
                    MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    if (DeleteTableFromDatabase(id))
                    {
                        MessageBox.Show("Xóa bàn thành công");
                        LoadListTable();
                        ClearTableControls();
                    }
                    else
                    {
                        MessageBox.Show("Xóa bàn thất bại");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi xóa bàn: " + ex.Message);
            }
        }
        #endregion

        #region events - Bill
        private void btnThongKe_Click(object sender, EventArgs e)
        {
            LoadListBillByDate(dtpBatDau.Value, dtpKetThuc.Value);
        }

        private void btnFirstBillPage_Click(object sender, EventArgs e)
        {
            txbPageBill.Text = "1";
        }

        private void btnLastBillPage_Click(object sender, EventArgs e)
        {
            try
            {
                int sumRecord = dbHoaDon.GetNumBillListByDate(dtpBatDau.Value, dtpKetThuc.Value);
                int lastPage = sumRecord / 10;

                if (sumRecord % 10 != 0)
                    lastPage++;

                txbPageBill.Text = lastPage.ToString();
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
                    int page = Convert.ToInt32(txbPageBill.Text);
                    dgvBill.DataSource = dbHoaDon.GetBillListByDateAndPage(dtpBatDau.Value, dtpKetThuc.Value, page);
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
                    int page = Convert.ToInt32(txbPageBill.Text);
                    if (page > 1)
                        page--;

                    txbPageBill.Text = page.ToString();
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
                    int page = Convert.ToInt32(txbPageBill.Text);
                    int sumRecord = dbHoaDon.GetNumBillListByDate(dtpBatDau.Value, dtpKetThuc.Value);

                    if (page < sumRecord)
                        page++;

                    txbPageBill.Text = page.ToString();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi chuyển trang: " + ex.Message);
            }
        }
        #endregion

        #region events - Report
        private void btnViewReport_Click(object sender, EventArgs e)
        {
            LoadReportData(dtpFromReport.Value, dtpToReport.Value);
        }

        private void btnToday_Click(object sender, EventArgs e)
        {
            DateTime today = DateTime.Now;
            dtpFromReport.Value = today;
            dtpToReport.Value = today;
            LoadReportData(today, today);
        }

        private void btnThisMonth_Click(object sender, EventArgs e)
        {
            DateTime startDate = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1);
            DateTime endDate = DateTime.Now;
            dtpFromReport.Value = startDate;
            dtpToReport.Value = endDate;
            LoadReportData(startDate, endDate);
        }

        private void btnLastMonth_Click(object sender, EventArgs e)
        {
            DateTime startDate = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1).AddMonths(-1);
            DateTime endDate = startDate.AddMonths(1).AddDays(-1);
            dtpFromReport.Value = startDate;
            dtpToReport.Value = endDate;
            LoadReportData(startDate, endDate);
        }

        private void btnExportExcel_Click(object sender, EventArgs e)
        {
            ExportToExcel(dtgvReport);
        }

        private void LoadReportData(DateTime fromDate, DateTime toDate)
        {
            try
            {
                DataTable reportData = dbReport.GetBillReport(fromDate, toDate);
                dtgvReport.DataSource = reportData;
                decimal totalRevenue = 0;
                int totalBills = reportData.Rows.Count;

                foreach (DataRow row in reportData.Rows)
                {
                    totalRevenue += Convert.ToDecimal(row["FinalPrice"]);
                }
                decimal averageBill = totalBills > 0 ? totalRevenue / totalBills : 0;
                txtTotalBills.Text = $"{totalBills}";
                txtTotalRevenue.Text = $"{totalRevenue:N0} VND";
                txtAverageBill.Text = $"{averageBill:N0} VND";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi tải báo cáo: " + ex.Message);
            }
        }

        private void ExportToExcel(DataGridView dataGrid)
        {
            SaveFileDialog saveFile = new SaveFileDialog();
            saveFile.Filter = "Excel Files|*.xlsx";
            saveFile.Title = "Lưu báo cáo";

            if (saveFile.ShowDialog() == DialogResult.OK)
            {
                using (var writer = new System.IO.StreamWriter(saveFile.FileName, false, System.Text.Encoding.UTF8))
                {
                    var headers = new List<string>();
                    foreach (DataGridViewColumn col in dataGrid.Columns)
                    {
                        headers.Add(col.HeaderText);
                    }
                    writer.WriteLine(string.Join(",", headers));
                    foreach (DataGridViewRow row in dataGrid.Rows)
                    {
                        if (!row.IsNewRow)
                        {
                            var cells = new List<string>();
                            foreach (DataGridViewCell cell in row.Cells)
                            {
                                cells.Add(cell.Value?.ToString() ?? "");
                            }
                            writer.WriteLine(string.Join(",", cells));
                        }
                    }
                }
                MessageBox.Show("Xuất báo cáo thành công!");
            }
        }
        #endregion

        #region events - Form and GridView
        private void fAdmin_Load(object sender, EventArgs e)
        {
            try
            {
                LoadData();
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
                if (dgvThucAn.SelectedRows.Count > 0 && !isAddingFood)
                {
                    DataGridViewRow selectedRow = dgvThucAn.SelectedRows[0];
                    txtID.Text = selectedRow.Cells["ID"].Value?.ToString() ?? "";
                    txtTenMon.Text = selectedRow.Cells["Name"].Value?.ToString() ?? "";

                    if (selectedRow.Cells["Price"].Value != null)
                    {
                        nmGia.Value = Convert.ToDecimal(selectedRow.Cells["Price"].Value);
                    }

                    if (selectedRow.Cells["IdCategory"]?.Value != null)
                    {
                        int categoryID = (int)selectedRow.Cells["IdCategory"].Value;
                        cboDoanhMuc.SelectedValue = categoryID;
                    }
                    SetFoodControlsEnabled(false);
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
                if (dgvAccount.SelectedRows.Count > 0 && !isAddingAccount)
                {
                    DataGridViewRow selectedRow = dgvAccount.SelectedRows[0];
                    txtTenTK.Text = selectedRow.Cells["UserName"].Value?.ToString() ?? "";
                    txtTenHienThi.Text = selectedRow.Cells["DisplayName"].Value?.ToString() ?? "";

                    if (selectedRow.Cells["Type"].Value != null)
                    {
                        nmrLoai.Value = Convert.ToDecimal(selectedRow.Cells["Type"].Value);
                    }

                    SetAccountControlsEnabled(false);
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
                if (dgvDoanhMuc.SelectedRows.Count > 0 && !isAddingCategory)
                {
                    DataGridViewRow selectedRow = dgvDoanhMuc.SelectedRows[0];
                    txtMaDoanhMuc.Text = selectedRow.Cells["ID"].Value?.ToString() ?? "";
                    txtTenDoanhMuc.Text = selectedRow.Cells["Name"].Value?.ToString() ?? "";

                    SetCategoryControlsEnabled(false);
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
                if (dgvBan.SelectedRows.Count > 0 && !isAddingTable)
                {
                    DataGridViewRow selectedRow = dgvBan.SelectedRows[0];
                    txtIDTable.Text = selectedRow.Cells["id"].Value?.ToString() ?? "";
                    txtTenBan.Text = selectedRow.Cells["name"].Value?.ToString() ?? "";
                    txtTrangThai.Text = selectedRow.Cells["status"].Value?.ToString() ?? "";
                    SetTableControlsEnabled(false);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Lỗi khi chọn dòng bàn: " + ex.Message);
            }
        }
        #endregion
    }
}