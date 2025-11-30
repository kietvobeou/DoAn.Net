using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Principal;
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
            txtUserName.Text = LoginAccount.UserName;
            txtDisplayName.Text = LoginAccount.DisplayName;
        }
        void UpdateAccountInfo()
        {
            string displayName = txtDisplayName.Text;
            string password = txtPassWord.Text;
            string newpass = txtNewPass.Text;
            string reenterPass = txtReEnterPass.Text;
            string userName = txtUserName.Text;

            if (!newpass.Equals(reenterPass))
            {
                MessageBox.Show("Vui lòng nhập lại mật khẩu đúng với mật khẩu mới!");
            }
            else
            {
                if (dbTaiKhoan.UpdateAccount(userName, displayName, password, newpass))
                {
                    MessageBox.Show("Cập nhật thành công");
                    if (updateAccount != null)
                        updateAccount(this, new AccountEvent(dbTaiKhoan.GetAccountByUserName(userName)));
                }
                else
                {
                    MessageBox.Show("Vui lòng điền đúng mật khấu");
                }
            }
        }
        private event EventHandler<AccountEvent> updateAccount;
        public event EventHandler<AccountEvent> UpdateAccount
        {
            add { updateAccount += value; }
            remove { updateAccount -= value; }
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
