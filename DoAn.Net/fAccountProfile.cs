using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DoAn.Net
{
    public partial class fAccountProfile : Form
    {
        private TaiKhoan loginAccount;
        DBTaiKhoan dbTaiKhoan = new DBTaiKhoan();

        public TaiKhoan LoginAccount
        {
            get { return loginAccount; }
            set { loginAccount = value; ChangeAccount(loginAccount); }
        }

        public fAccountProfile()
        {
            InitializeComponent();
            this.btnExit.Click += BtnExit_Click;
            this.btnUpdate.Click += BtnUpdate_Click;
            txtPassWord.Enter += (s, e) => txtPassWord.SelectAll();
            txtNewPass.Enter += (s, e) => txtNewPass.SelectAll();
            txtReEnterPass.Enter += (s, e) => txtReEnterPass.SelectAll();
        }

        private void BtnUpdate_Click(object sender, EventArgs e)
        {
            UpdateAccountInfo();
        }

        private void BtnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        void ChangeAccount(TaiKhoan acc)
        {
            if (acc != null)
            {
                txtUserName.Text = acc.UserName;
                txtDisplayName.Text = acc.DisplayName;
                txtPassWord.Text = "";
                txtNewPass.Text = "";
                txtReEnterPass.Text = "";
                txtPassWord.Focus();
            }
        }

        void UpdateAccountInfo()
        {
            string displayName = txtDisplayName.Text.Trim();
            string password = txtPassWord.Text;
            string newpass = txtNewPass.Text;
            string reenterPass = txtReEnterPass.Text;
            string userName = txtUserName.Text;
            if (string.IsNullOrEmpty(displayName))
            {
                MessageBox.Show("Vui lòng nhập tên hiển thị!", "Thông báo",
                              MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtDisplayName.Focus();
                return;
            }

            if (string.IsNullOrEmpty(password))
            {
                MessageBox.Show("Vui lòng nhập mật khẩu hiện tại!", "Thông báo",
                              MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtPassWord.Focus();
                return;
            }

            if (!string.IsNullOrEmpty(newpass) && !newpass.Equals(reenterPass))
            {
                MessageBox.Show("Mật khẩu mới và nhập lại mật khẩu không khớp!",
                              "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtNewPass.Focus();
                txtNewPass.SelectAll();
                return;
            }
            if (dbTaiKhoan.UpdateAccount(userName, displayName, password, newpass))
            {
                MessageBox.Show("Cập nhật thông tin thành công!", "Thông báo",
                              MessageBoxButtons.OK, MessageBoxIcon.Information);
                TaiKhoan updatedAccount = dbTaiKhoan.GetAccountByUserName(userName);
                if (updateAccount != null && updatedAccount != null)
                {
                    updateAccount(this, new AccountEvent(updatedAccount));
                }
                if (updatedAccount != null)
                {
                    txtDisplayName.Text = updatedAccount.DisplayName;
                }
                txtPassWord.Text = "";
                txtNewPass.Text = "";
                txtReEnterPass.Text = "";
                txtPassWord.Focus();
            }
            else
            {
                MessageBox.Show("Cập nhật không thành công!\nVui lòng kiểm tra lại mật khẩu hiện tại.",
                              "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtPassWord.Focus();
                txtPassWord.SelectAll();
            }
        }

        private event EventHandler<AccountEvent> updateAccount;
        public event EventHandler<AccountEvent> UpdateAccount
        {
            add { updateAccount += value; }
            remove { updateAccount -= value; }
        }
        private void fAccountProfile_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                UpdateAccountInfo();
            }
            else if (e.KeyCode == Keys.Escape)
            {
                this.Close();
            }
        }
    }

    public class AccountEvent : EventArgs
    {
        private TaiKhoan acc;

        public TaiKhoan Acc
        {
            get { return acc; }
            set { acc = value; }
        }

        public AccountEvent(TaiKhoan acc)
        {
            this.Acc = acc;
        }
    }
}