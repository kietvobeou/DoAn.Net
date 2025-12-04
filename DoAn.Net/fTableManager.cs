using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing; 
using System.Windows.Forms;

namespace DoAn.Net
{
    public partial class fTableManager : Form
    {
        DBBan dbBan = new DBBan();
        DBDanhMuc dbDanhMuc = new DBDanhMuc();
        DBMonAn dbMonAn = new DBMonAn();
        DBHoaDon dbHoaDon = new DBHoaDon();
        DBChiTietHoaDon dbChiTiet = new DBChiTietHoaDon();
        Ban banHienTai = null;
        float tongTien = 0;

        public TaiKhoan LoginAccount;

        public fTableManager(TaiKhoan acc)
        {
            InitializeComponent();
            this.LoginAccount = acc;
            if (acc.Type == 1)
            {
                adminToolStripMenuItem.Enabled = true;
            }
            else
            {
                adminToolStripMenuItem.Enabled = false;
            }
            thongTinTKToolStripMenuItem.Text = "Thông tin: " + acc.DisplayName;
            LoadDanhSachBan();
            LoadDanhMuc();
        }
        void LoadDanhSachBan()
        {
            flpTable.Controls.Clear();

           
            List<Ban> listBan = dbBan.LoadTableList();

            foreach (Ban ban in listBan)
            {
                Button btn = new Button();
                btn.Width = DBBan.TableWidth;
                btn.Height = DBBan.TableHeight;
                btn.Text = ban.Name + "\n" + ban.Status;
                btn.Tag = ban;
                btn.Click += Btn_Click;

                if (ban.Status == "Trống")
                {
                    btn.BackColor = Color.LimeGreen;
                }
                else
                {
                    btn.BackColor = Color.IndianRed;
                    btn.ForeColor = Color.White;
                }

                flpTable.Controls.Add(btn);
            }
            cbSwitchTable.DataSource = listBan;
            cbSwitchTable.DisplayMember = "Name";
            cbSwitchTable.ValueMember = "ID";
        }

        void LoadDanhMuc()
        {
            cbCategory.DataSource = dbDanhMuc.GetListCategory();
            cbCategory.DisplayMember = "Name";
            cbCategory.ValueMember = "ID";
        }

        void LoadMonAnTheoDanhMuc(int idDanhMuc)
        {
            cbFood.DataSource = dbMonAn.GetFoodByCategoryID(idDanhMuc);
            cbFood.DisplayMember = "Name";
            cbFood.ValueMember = "ID";
        }
        void ShowHoaDon(int idBan)
        {
            lsvBill.Items.Clear();
            tongTien = 0;

            DataTable data = dbHoaDon.GetListMenuByTable(idBan);

            foreach (DataRow row in data.Rows)
            {
               
                string tenMon = row["FoodName"].ToString();
                int soLuong = (int)row["Count"];
                float donGia = Convert.ToSingle(row["Price"]);
                float thanhTien = Convert.ToSingle(row["TotalPrice"]);

               
                ListViewItem item = new ListViewItem(tenMon);
                item.SubItems.Add(soLuong.ToString());
                item.SubItems.Add(donGia.ToString("N0"));
                item.SubItems.Add(thanhTien.ToString("N0"));

                lsvBill.Items.Add(item);
                tongTien += thanhTien;
            }
            txbTotalPrice.Text = tongTien.ToString("N0") + " VNĐ";
        }
        private void Btn_Click(object sender, EventArgs e)
        {
            Button btn = sender as Button;
            banHienTai = btn.Tag as Ban;

            ShowHoaDon(banHienTai.ID);
            cbSwitchTable.SelectedValue = banHienTai.ID;
        }

        private void cbCategory_SelectedIndexChanged(object sender, EventArgs e)
        {
            ComboBox cb = sender as ComboBox;

            if (cb.SelectedItem == null) return;
            if (cb.SelectedValue is int)
            {
                int id = (int)cb.SelectedValue;
                LoadMonAnTheoDanhMuc(id);
            }
        }

        private void btnAddFood_Click(object sender, EventArgs e)
        {
            if (banHienTai == null)
            {
                MessageBox.Show("Vui lòng chọn bàn trước!");
                return;
            }

            int idBill = dbHoaDon.GetUncheckBillIDByTableID(banHienTai.ID);
            int idFood = (int)cbFood.SelectedValue;
            int count = (int)nmFoodCount.Value;

            if (idBill == -1) 
            {
                dbHoaDon.InsertBill(banHienTai.ID);
                dbBan.UpdateTableStatus(banHienTai.ID, "Có người");

                int maxBillID = dbHoaDon.GetMaxIDBill();
                dbChiTiet.InsertBillInfo(maxBillID, idFood, count);
            }
            else 
            {
                dbChiTiet.InsertBillInfo(idBill, idFood, count);
            }

            ShowHoaDon(banHienTai.ID);
            LoadDanhSachBan();
        }

        private void btnCheckOut_Click(object sender, EventArgs e)
        {
            if (banHienTai == null) return;

            int idBill = dbHoaDon.GetUncheckBillIDByTableID(banHienTai.ID);

            if (idBill != -1) 
            {
                int giamGia = (int)nmDisCount.Value;
                float tienCuoiCung = tongTien - (tongTien / 100 * giamGia);
                string thongBao = string.Format("Bạn có chắc thanh toán cho {0}?\nTổng tiền: {1}", banHienTai.Name, tienCuoiCung.ToString("N0"));
                if (MessageBox.Show(thongBao, "Thông báo", MessageBoxButtons.OKCancel) == DialogResult.OK)
                {
                    dbHoaDon.CheckOut(idBill, giamGia, tienCuoiCung);
                    dbBan.UpdateTableStatus(banHienTai.ID, "Trống");

                    ShowHoaDon(banHienTai.ID);
                    LoadDanhSachBan();
                }
            }
        }

      
        
        private void btnSwitchTable_Click(object sender, EventArgs e)
        {
           
            if (cbSwitchTable.SelectedValue == null) return;
     
            int idBanMuonXem = (int)cbSwitchTable.SelectedValue;
            Ban banMoi = dbBan.GetTableByID(idBanMuonXem); 
            if (banMoi != null)
            {
                banHienTai = banMoi;
                ShowHoaDon(banHienTai.ID);            
                MessageBox.Show("Đang xem " + banHienTai.Name); 
            }
        }

        private void adminToolStripMenuItem_Click(object sender, EventArgs e)
        {
            fAdmin f = new fAdmin();
            f.loginTaiKhoan = LoginAccount;
            f.ShowDialog();
            LoadDanhMuc();
            if (banHienTai != null) ShowHoaDon(banHienTai.ID);
        }

        private void thongTinCaNhanToolStripMenuItem_Click(object sender, EventArgs e)
        {
            fAccountProfile f = new fAccountProfile();
            f.LoginAccount = LoginAccount;
            f.ShowDialog();
            thongTinTKToolStripMenuItem.Text = "Thông tin: " + LoginAccount.DisplayName;
        }

        private void dangXuatToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

    }
}