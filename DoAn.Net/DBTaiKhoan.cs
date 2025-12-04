using DoAn.Net.QuanLyQuanCafeTableAdapters;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Security.Cryptography;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace DoAn.Net
{
    public class DBTaiKhoan
    {
        private TaiKhoanTableAdapter daTaiKhoan;

        public DBTaiKhoan()
        {
            daTaiKhoan = new TaiKhoanTableAdapter();
        }

        public bool UpdateAccount(string userName, string displayName, string passWord, string newPass)
        {
            try
            {
                var data = daTaiKhoan.GetData();
                var account = data.FirstOrDefault(acc =>
                    acc.UserName == userName && acc.PassWord == passWord);
                if (account != null)
                {
                    account.DisplayName = displayName;
                    account.PassWord = newPass;
                    daTaiKhoan.Update(account);
                    return true;
                }
                return false;
            }
            catch
            {
                return false;
            }
        }

        public TaiKhoan GetAccountByUserName(string userName)
        {
            var data = daTaiKhoan.GetData();
            var row = data.FirstOrDefault(acc => acc.UserName == userName);

            if (row == null) return null;

            return new TaiKhoan(row);
        }

        public bool Login(string userName, string passWord)
        {
            try
            {
                var data = daTaiKhoan.GetData();
                var account = data.FirstOrDefault(acc =>
                    acc.UserName == userName && acc.PassWord == passWord);
                return account != null;
            }
            catch
            {
                return false;
            }
        }

        public DataTable LayDSTK()
        {
            return daTaiKhoan.GetData();
        }

        public bool ThemTK(string userName, string displayName, int type)
        {
            try
            {
                daTaiKhoan.Insert(userName, displayName, "0", type);
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool CapNhatTK(string userName, string displayName, int type)
        {
            try
            {
                var data = daTaiKhoan.GetData();
                var account = data.FirstOrDefault(acc => acc.UserName == userName);

                if (account != null)
                {
                    daTaiKhoan.UpdateQuery(displayName, type, userName);
                    return true;
                }
                return false;
            }
            catch
            {
                return false;
            }
        }
        public bool XoaTK(string userName)
        {
            try
            {
                var data = daTaiKhoan.GetData();
                var account = data.FirstOrDefault(acc => acc.UserName == userName);

                if (account != null)
                {
                    account.Delete();
                    daTaiKhoan.Update(data);
                    return true;
                }
                return false;
            }
            catch
            {
                return false;
            }
        }

        public bool ResetPassword(string userName)
        {
            try
            {
                var data = daTaiKhoan.GetData();
                var account = data.FirstOrDefault(acc => acc.UserName == userName);

                if (account != null)
                {
                    account.PassWord = "0";
                    daTaiKhoan.Update(account);
                    return true;
                }
                return false;
            }
            catch
            {
                return false;
            }
        }
        public TaiKhoan GetAccountByID(string userName)
        {
            try
            {
                var data = daTaiKhoan.GetData();
                var row = data.FirstOrDefault(acc => acc.UserName == userName);

                if (row != null)
                {
                    return new TaiKhoan()
                    {
                        UserName = row.UserName,
                        DisplayName = row.DisplayName,
                        Type = row.Type
                    };
                }
                return null;
            }
            catch
            {
                return null;
            }
        }
        public bool IsAccountExists(string userName)
        {
            try
            {
                var data = daTaiKhoan.GetData();
                return data.Any(acc => acc.UserName == userName);
            }
            catch
            {
                return false;
            }
        }
    }
}
