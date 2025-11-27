using DoAn.Net.QuanLyQuanCafeTableAdapters;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoAn.Net
{
    public class DBDanhMuc
    {
        private DanhMucTableAdapter daCategory;

        public DBDanhMuc()
        {
            daCategory = new DanhMucTableAdapter();
        }

        public DataTable GetListCategory()
        {
            try
            {
                return daCategory.GetData();
            }
            catch
            {
                return new DataTable();
            }
        }

        public DanhMuc GetCategoryByID(int id)
        {
            try
            {
                var data = daCategory.GetDataByID(id);
                if (data.Count > 0)
                {
                    var item = data[0];
                    return new DanhMuc
                    {
                        ID = item.id,
                        Name = item.name
                    };
                }
                return null;
            }
            catch
            {
                return null;
            }
        }

        public bool InsertCategory(string name)
        {
            try
            {
                daCategory.Insert(name);
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool UpdateCategory(int id, string name)
        {
            try
            {
                int result = daCategory.UpdateCategory(name, id);
                return result > 0;
            }
            catch
            {
                return false;
            }
        }

        public bool DeleteCategory(int id)
        {
            try
            {
                int result = daCategory.Delete1(id);
                return result > 0;
            }
            catch
            {
                return false;
            }
        }
    }
}
