using DoAn.Net.QuanLyQuanCafeTableAdapters;
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
    public partial class fLogin : Form
    {
        DBTaiKhoan dbTaiKhoan = new DBTaiKhoan();
        public fLogin()
        {
            InitializeComponent();
            this.btnLogin.Click += BtnLogin_Click;
            this.btnExit.Click += BtnExit_Click;
            this.FormClosing += FLogin_FormClosing;
        }

        private void FLogin_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (MessageBox.Show("Bạn có thật sự muốn thoát chương trình?", "Thông báo", MessageBoxButtons.OKCancel) != System.Windows.Forms.DialogResult.OK)
            {
                e.Cancel = true;
            }
        }

        private void BtnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void BtnLogin_Click(object sender, EventArgs e)
        {
            string userName = txtUserName.Text.Trim();
            string passWord = txtPassWord.Text.Trim();

            if (Login(userName, passWord))
            {
                TaiKhoan loginAccount = dbTaiKhoan.GetAccountByUserName(userName);
                if (loginAccount.Type == 1) 
                {
                    fTableManager f = new fTableManager(loginAccount);
                    this.Hide();
                    f.ShowDialog();
                    this.Close();
                }
                else 
                {
                    fTableManager f = new fTableManager(loginAccount);
                    this.Hide();
                    f.ShowDialog();
                    this.Close();
                }
            }
            else
            {
                MessageBox.Show("Sai tên đăng nhập hoặc mật khẩu!",
                                "Thông báo",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Error);
            }
        }

        private bool Login(string userName, string passWord)
        {
            return dbTaiKhoan.Login(userName, passWord);
        }
    }
}