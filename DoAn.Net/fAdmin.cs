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
using System.Linq;
using System.Windows.Forms;

namespace DoAn.Net
{
    public partial class fAdmin : Form
    {
        private BindingSource foodList = new BindingSource();
        private BindingSource accountList = new BindingSource();
        private BindingSource categoryList = new BindingSource();
        private DBTaiKhoan dbTaiKhoan = new DBTaiKhoan();
        private DBMonAn dbMonAn = new DBMonAn();
        private DBDanhMuc dbDanhMuc = new DBDanhMuc();
        private DBHoaDon dbHoaDon = new DBHoaDon();
        private DBReport dbReport = new DBReport();
        public TaiKhoan loginTaiKhoan;

        public fAdmin()
        {
            InitializeComponent();
            GanSuKien();
            LoadData();
        }

        private void GanSuKien()
        {
            this.btnThongKe.Click += new System.EventHandler(this.btnViewBill_Click);
            this.btnFirstBillPage.Click += new System.EventHandler(this.btnFirstBillPage_Click);
            this.btnPrevioursBillPage.Click += new System.EventHandler(this.btnPreviousBillPage_Click);
            this.btnNextBillPage.Click += new System.EventHandler(this.btnNextBillPage_Click);
            this.btnLastBillPage.Click += new System.EventHandler(this.btnLastBillPage_Click);
            this.txbPageBill.TextChanged += new System.EventHandler(this.txbPageBill_TextChanged);
            this.btnThem.Click += new System.EventHandler(this.btnAddFood_Click);
            this.btnSua.Click += new System.EventHandler(this.btnEditFood_Click);
            this.btnXoa.Click += new System.EventHandler(this.btnDeleteFood_Click);
            this.btnXem.Click += new System.EventHandler(this.btnShowFood_Click);
            this.btnTim.Click += new System.EventHandler(this.btnSearchFood_Click);
            this.txtID.TextChanged += new System.EventHandler(this.txbFoodID_TextChanged);
            this.dgvThucAn.SelectionChanged += new System.EventHandler(this.dgvThucAn_SelectionChanged);
            this.btnThem3.Click += new System.EventHandler(this.btnAddAccount_Click);
            this.btnXoa3.Click += new System.EventHandler(this.btnDeleteAccount_Click);
            this.btnSua3.Click += new System.EventHandler(this.btnEditAccount_Click);
            this.btnResetPassword.Click += new System.EventHandler(this.btnResetPassword_Click);
            this.btnViewReport.Click += new System.EventHandler(this.btnViewReport_Click);
            this.btnToday.Click += new System.EventHandler(this.btnToday_Click);
            this.btnThisMonth.Click += new System.EventHandler(this.btnThisMonth_Click);
            this.btnLastMonth.Click += new System.EventHandler(this.btnLastMonth_Click);
            this.btnExportExcel.Click += new System.EventHandler(this.btnExportExcel_Click);
            this.Load += new System.EventHandler(this.fAdmin_Load);
            this.dgvAccount.SelectionChanged += new System.EventHandler(this.dgvAccount_SelectionChanged);
        }

        #region methods

        private void LoadData()
        {
            try
            {
                LoadListFood();
                LoadAccount();
                LoadDateTimePickerBill();
                LoadListBillByDate(dtpBatDau.Value, dtpKetThuc.Value);
                LoadCategoryIntoCombobox(cboDoanhMuc);
                dgvThucAn.DataSource = foodList;
                dgvAccount.DataSource = accountList;
                ClearFoodBindings();
                ClearAccountBindings();
                dgvThucAn.ClearSelection();
                dgvAccount.ClearSelection();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi trong LoadData: {ex.Message}", "Lỗi",
                               MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ClearFoodBindings()
        {
            txtTenMon.DataBindings.Clear();
            txtID.DataBindings.Clear();
            nmGia.DataBindings.Clear();
            txtTenMon.Text = "";
            txtID.Text = "";
            nmGia.Value = 0;
            cboDoanhMuc.SelectedIndex = -1;
        }

        private void ClearAccountBindings()
        {
            txtTenTK.DataBindings.Clear();
            txtTenHienThi.DataBindings.Clear();
            nmrLoai.DataBindings.Clear();
            txtTenTK.Text = "";
            txtTenHienThi.Text = "";
            nmrLoai.Value = 0;
        }

        private void AddAccountBinding()
        {
            txtTenTK.DataBindings.Clear();
            txtTenHienThi.DataBindings.Clear();
            nmrLoai.DataBindings.Clear();

            txtTenTK.DataBindings.Add(new Binding("Text", dgvAccount.DataSource, "UserName", true, DataSourceUpdateMode.Never));
            txtTenHienThi.DataBindings.Add(new Binding("Text", dgvAccount.DataSource, "DisplayName", true, DataSourceUpdateMode.Never));
            nmrLoai.DataBindings.Add(new Binding("Value", dgvAccount.DataSource, "Type", true, DataSourceUpdateMode.Never));
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

        private void AddFoodBinding()
        {
            txtTenMon.DataBindings.Clear();
            txtID.DataBindings.Clear();
            nmGia.DataBindings.Clear();

            txtTenMon.DataBindings.Add(new Binding("Text", dgvThucAn.DataSource, "Name", true, DataSourceUpdateMode.Never));
            txtID.DataBindings.Add(new Binding("Text", dgvThucAn.DataSource, "ID", true, DataSourceUpdateMode.Never));
            nmGia.DataBindings.Add(new Binding("Value", dgvThucAn.DataSource, "Price", true, DataSourceUpdateMode.Never));
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

        private void AddAccount(string userName, string displayName, int type)
        {
            try
            {
                if (dbTaiKhoan.ThemTK(userName, displayName, type))
                {
                    MessageBox.Show("Thêm tài khoản thành công");
                    LoadAccount();
                }
                else
                {
                    MessageBox.Show("Thêm tài khoản thất bại");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi thêm tài khoản: " + ex.Message);
            }
        }

        private void EditAccount(string userName, string displayName, int type)
        {
            try
            {
                if (dbTaiKhoan.CapNhatTK(userName, displayName, type))
                {
                    MessageBox.Show("Cập nhật tài khoản thành công");
                    LoadAccount();
                }
                else
                {
                    MessageBox.Show("Cập nhật tài khoản thất bại");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi cập nhật tài khoản: " + ex.Message);
            }
        }

        private void DeleteAccount(string userName)
        {
            try
            {
                if (loginTaiKhoan.UserName.Equals(userName))
                {
                    MessageBox.Show("Vui lòng đừng xóa chính bạn chứ");
                    return;
                }

                if (dbTaiKhoan.XoaTK(userName))
                {
                    MessageBox.Show("Xóa tài khoản thành công");
                    LoadAccount();
                }
                else
                {
                    MessageBox.Show("Xóa tài khoản thất bại");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi xóa tài khoản: " + ex.Message);
            }
        }

        private void ResetPass(string userName)
        {
            try
            {
                if (dbTaiKhoan.ResetPassword(userName))
                {
                    MessageBox.Show("Đặt lại mật khẩu thành công");
                }
                else
                {
                    MessageBox.Show("Đặt lại mật khẩu thất bại");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi đặt lại mật khẩu: " + ex.Message);
            }
        }
        #endregion

        #region events
        private void btnAddAccount_Click(object sender, EventArgs e)
        {
            string userName = txtTenTK.Text;
            string displayName = txtTenHienThi.Text;
            int type = (int)nmrLoai.Value;

            AddAccount(userName, displayName, type);
        }

        private void btnDeleteAccount_Click(object sender, EventArgs e)
        {
            string userName = txtTenTK.Text;
            DeleteAccount(userName);
        }

        private void btnEditAccount_Click(object sender, EventArgs e)
        {
            string userName = txtTenTK.Text;
            string displayName = txtTenHienThi.Text;
            int type = (int)nmrLoai.Value;

            EditAccount(userName, displayName, type);
        }

        private void btnResetPassword_Click(object sender, EventArgs e)
        {
            string userName = txtTenTK.Text;
            ResetPass(userName);
        }

        private void btnShowAccount_Click(object sender, EventArgs e)
        {
            LoadAccount();
        }

        private void btnSearchFood_Click(object sender, EventArgs e)
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

        private void txbFoodID_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (dgvThucAn.SelectedCells.Count > 0 && dgvThucAn.CurrentRow != null)
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

        private void btnAddFood_Click(object sender, EventArgs e)
        {
            try
            {
                string name = txtTenMon.Text;
                int categoryID = (int)cboDoanhMuc.SelectedValue;
                float price = (float)nmGia.Value;

                if (dbMonAn.InsertFood(name, categoryID, price))
                {
                    MessageBox.Show("Thêm món thành công");
                    LoadListFood();
                    ClearFoodBindings();
                    dgvThucAn.ClearSelection();
                }
                else
                {
                    MessageBox.Show("Có lỗi khi thêm thức ăn");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi thêm món: " + ex.Message);
            }
        }

        private void btnEditFood_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(txtID.Text))
                {
                    MessageBox.Show("Vui lòng chọn món ăn cần sửa");
                    return;
                }

                string name = txtTenMon.Text;
                int categoryID = (int)cboDoanhMuc.SelectedValue;
                float price = (float)nmGia.Value;
                int id = Convert.ToInt32(txtID.Text);

                if (dbMonAn.UpdateFood(id, name, categoryID, price))
                {
                    MessageBox.Show("Sửa món thành công");
                    LoadListFood();
                    ClearFoodBindings();
                    dgvThucAn.ClearSelection();
                }
                else
                {
                    MessageBox.Show("Có lỗi khi sửa thức ăn");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi sửa món: " + ex.Message);
            }
        }

        private void btnDeleteFood_Click(object sender, EventArgs e)
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
                        ClearFoodBindings();
                        dgvThucAn.ClearSelection();
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

        private void btnShowFood_Click(object sender, EventArgs e)
        {
            LoadListFood();
        }

        private void btnViewBill_Click(object sender, EventArgs e)
        {
            LoadListBillByDate(dtpBatDau.Value, dtpKetThuc.Value);
        }

        private event EventHandler insertFood;
        public event EventHandler InsertFood
        {
            add { insertFood += value; }
            remove { insertFood -= value; }
        }

        private event EventHandler deleteFood;
        public event EventHandler DeleteFood
        {
            add { deleteFood += value; }
            remove { deleteFood -= value; }
        }

        private event EventHandler updateFood;
        public event EventHandler UpdateFood
        {
            add { updateFood += value; }
            remove { updateFood -= value; }
        }
        #endregion

        #region Bill Pagination
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

        private void fAdmin_Load(object sender, EventArgs e)
        {
            try
            {
                LoadData();
                MessageBox.Show("Tải dữ liệu thành công!", "Thông báo",
                               MessageBoxButtons.OK, MessageBoxIcon.Information);
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
                if (dgvThucAn.SelectedRows.Count > 0)
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
                }
                else
                {
                    ClearFoodBindings();
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
                if (dgvAccount.SelectedRows.Count > 0)
                {
                    DataGridViewRow selectedRow = dgvAccount.SelectedRows[0];
                    txtTenTK.Text = selectedRow.Cells["UserName"].Value?.ToString() ?? "";
                    txtTenHienThi.Text = selectedRow.Cells["DisplayName"].Value?.ToString() ?? "";

                    if (selectedRow.Cells["Type"].Value != null)
                    {
                        nmrLoai.Value = Convert.ToDecimal(selectedRow.Cells["Type"].Value);
                    }
                }
                else
                {
                    ClearAccountBindings();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Lỗi khi chọn dòng tài khoản: " + ex.Message);
            }
        }


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
    }
}