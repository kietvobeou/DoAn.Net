using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Windows.Forms;

namespace DoAn.Net
{
    public partial class fTableManager : Form
    {
        private DBBan dbBan = new DBBan();
        private DBDanhMuc dbDanhMuc = new DBDanhMuc();
        private DBMonAn dbMonAn = new DBMonAn();
        private DBHoaDon dbHoaDon = new DBHoaDon();
        private DBChiTietHoaDon dbChiTietHoaDon = new DBChiTietHoaDon();

        private TaiKhoan loginAccount;

        // Biến lưu bàn đang thao tác. Mặc định là null.
        private Ban _currentTable = null;

        public TaiKhoan LoginAccount
        {
            get { return loginAccount; }
            set { loginAccount = value; ChangeAccount(loginAccount.Type); }
        }

        public fTableManager(TaiKhoan acc)
        {
            InitializeComponent();
            this.LoginAccount = acc;

            LoadTable();
            LoadCategory();
            LoadComboboxTable(cbSwitchTable);
        }

        #region Methods

        void ChangeAccount(int type)
        {
            // Nếu type == 1 (Staff) thì Visible = true (Hiện)
            // Nếu type == 0 (Guest) thì Visible = false (Ẩn)
            adminToolStripMenuItem.Visible = (type == 1);
            thongTinTKToolStripMenuItem.Text = "Thông tin tài khoản (" + LoginAccount.DisplayName + ")";
        }

        void LoadCategory()
        {
            cbCategory.DataSource = dbDanhMuc.GetListCategory();
            cbCategory.DisplayMember = "Name";
            cbCategory.ValueMember = "ID";
        }

        void LoadFoodListByCategoryID(int id)
        {
            cbFood.DataSource = dbMonAn.GetFoodByCategoryID(id);
            cbFood.DisplayMember = "Name";
            cbFood.ValueMember = "ID";
        }

        void LoadTable()
        {
            flpTable.Controls.Clear();
            List<Ban> tableList = dbBan.LoadTableList();

            foreach (Ban item in tableList)
            {
                Button btn = new Button() { Width = DBBan.TableWidth, Height = DBBan.TableHeight };
                btn.Text = item.Name + Environment.NewLine + item.Status;
                btn.Click += Btn_Click;
                btn.Tag = item;

                switch (item.Status)
                {
                    case "Trống":
                        btn.BackColor = Color.LimeGreen;
                        break;
                    default:
                        btn.BackColor = Color.IndianRed; 
                        btn.ForeColor = Color.White;  
                        break;
                }
                flpTable.Controls.Add(btn);
            }
        }

        void LoadComboboxTable(ComboBox cb)
        {
            cb.DataSource = dbBan.LoadTableList();
            cb.DisplayMember = "Name";
            cb.ValueMember = "ID";
        }

        void ShowBill(int id)
        {
            lsvBill.Items.Clear();
            List<DoAn.Net.Menu> listBillInfo = dbHoaDon.GetListMenuByTable(id);

            float totalPrice = 0;

            foreach (DoAn.Net.Menu item in listBillInfo)
            {
                ListViewItem lsvItem = new ListViewItem(item.FoodName.ToString());
                lsvItem.SubItems.Add(item.Count.ToString());
                lsvItem.SubItems.Add(item.Price.ToString("N0"));
                lsvItem.SubItems.Add(item.TotalPrice.ToString("N0"));

                totalPrice += item.TotalPrice;
                lsvBill.Items.Add(lsvItem);
            }

            CultureInfo culture = new CultureInfo("vi-VN");
            txbTotalPrice.Text = totalPrice.ToString("c", culture);
        }

        #endregion

        #region Events

        private void Btn_Click(object sender, EventArgs e)
        {
            // Lấy thông tin bàn vừa click
            _currentTable = (sender as Button).Tag as Ban;

            // Hiển thị hóa đơn của bàn đó
            ShowBill(_currentTable.ID);

            // Đồng bộ ComboBox hiển thị đúng bàn vừa chọn
            
            if (cbSwitchTable.Items.Count > 0)
            {
                cbSwitchTable.SelectedValue = _currentTable.ID;
            }
        }

        private void cbCategory_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbCategory.SelectedItem == null) return;

            ComboBox cb = sender as ComboBox;
            if (cb.SelectedValue is int id)
            {
                LoadFoodListByCategoryID(id);
            }
        }

        private void btnAddFood_Click(object sender, EventArgs e)
        {
            if (_currentTable == null)
            {
                MessageBox.Show("Hãy chọn bàn trước khi thêm món!");
                return;
            }

            if (cbFood.SelectedItem == null)
            {
                MessageBox.Show("Chưa chọn món ăn!");
                return;
            }

            int idBill = dbHoaDon.GetUncheckBillIDByTableID(_currentTable.ID);
            int foodID = (int)cbFood.SelectedValue;
            int count = (int)nmFoodCount.Value;

            if (idBill == -1) 
            {
                dbHoaDon.InsertBill(_currentTable.ID);

                // --- CẬP NHẬT TRẠNG THÁI BÀN THÀNH CÓ NGƯỜI ---
                dbBan.UpdateTableStatus(_currentTable.ID, "Có người");

                idBill = dbHoaDon.GetMaxIDBill();
                dbChiTietHoaDon.InsertBillInfo(idBill, foodID, count);
            }
            else // Hóa đơn cũ
            {
                dbChiTietHoaDon.InsertBillInfo(idBill, foodID, count);
            }

            ShowBill(_currentTable.ID);
            LoadTable(); 
        }

        private void btnCheckOut_Click(object sender, EventArgs e)
        {
            if (_currentTable == null) return;

            int idBill = dbHoaDon.GetUncheckBillIDByTableID(_currentTable.ID);
            int discount = (int)nmDisCount.Value;

            // Xử lý chuỗi tiền tệ
            string priceString = txbTotalPrice.Text.Split(',')[0].Replace(".", "").Replace("₫", "").Trim();
            double totalPrice = 0;
            double.TryParse(priceString, out totalPrice);
            double finalTotalPrice = totalPrice - (totalPrice / 100) * discount;

            if (idBill != -1)
            {
                if (MessageBox.Show(string.Format("Thanh toán cho {0}\nTổng tiền: {1}", _currentTable.Name, finalTotalPrice.ToString("N0")), "Xác nhận", MessageBoxButtons.OKCancel) == System.Windows.Forms.DialogResult.OK)
                {
                    dbHoaDon.CheckOut(idBill, discount, (float)finalTotalPrice);

                    // --- CẬP NHẬT TRẠNG THÁI BÀN VỀ TRỐNG ---
                    dbBan.UpdateTableStatus(_currentTable.ID, "Trống");

                    ShowBill(_currentTable.ID);
                    LoadTable(); 
                }
            }
        }

        private void btnSwitchTable_Click(object sender, EventArgs e)
        {
            // Lấy ID bàn muốn xem từ ComboBox
            if (cbSwitchTable.SelectedValue == null) return;
            int idTableNew = (int)cbSwitchTable.SelectedValue;

            // Lấy thông tin đối tượng bàn mới từ CSDL
            Ban newTable = dbBan.GetTableByID(idTableNew);

            if (newTable != null)
            {
                // Cập nhật biến _currentTable sang bàn mới
                _currentTable = newTable;

                // Đồng bộ Tag
                lsvBill.Tag = _currentTable;

                // Hiển thị hóa đơn của bàn mới
                ShowBill(_currentTable.ID);

                // MessageBox.Show($"Đang xem hóa đơn của {newTable.Name}");
            }
        }

        // --- Các sự kiện Menu ---
        private void adminToolStripMenuItem_Click(object sender, EventArgs e)
        {
            fAdmin f = new fAdmin();
            f.loginTaiKhoan = LoginAccount;
            f.InsertFood += F_UpdateFood;
            f.DeleteFood += F_UpdateFood;
            f.UpdateFood += F_UpdateFood;
            f.ShowDialog();
        }

        void F_UpdateFood(object sender, EventArgs e)
        {
            if (cbCategory.SelectedValue is int id)
                LoadFoodListByCategoryID(id);
            if (_currentTable != null)
                ShowBill(_currentTable.ID);
        }

        private void dangXuatToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void thongTinCaNhanToolStripMenuItem_Click(object sender, EventArgs e)
        {
            fAccountProfile f = new fAccountProfile();
            f.LoginAccount = LoginAccount;
            f.UpdateAccount += F_UpdateAccount;
            f.ShowDialog();
        }

        void F_UpdateAccount(object sender, AccountEvent e)
        {
            thongTinTKToolStripMenuItem.Text = "Thông tin tài khoản (" + e.Acc.DisplayName + ")";
        }
        #endregion
    }
}