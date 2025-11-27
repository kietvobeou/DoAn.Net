using DoAn.Net.QuanLyQuanCafeTableAdapters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoAn.Net
{
    public class DBMenu
    {
        private HoaDonTableAdapter daBill;

        public DBMenu()
        {
            daBill = new HoaDonTableAdapter();
        }
    }
}
