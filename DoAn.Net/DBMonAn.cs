using DoAn.Net.QuanLyQuanCafeTableAdapters;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoAn.Net
{
    public class DBMonAn
    {
        private MonAnTableAdapter daFood;

        public DBMonAn()
        {
            daFood = new MonAnTableAdapter();
        }
        public DataTable GetListFood()
        {
            try
            {
                return daFood.GetData();
            }
            catch
            {
                return new DataTable();
            }
        }

        public DataTable SearchFoodByName(string name)
        {
            try
            {
                return daFood.SearchFoodByName(name);
            }
            catch
            {
                return new DataTable();
            }
        }

        public bool InsertFood(string name, int categoryID, float price)
        {
            try
            {
                daFood.Insert(name, categoryID, price);
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool UpdateFood(int id, string name, int categoryID, float price)
        {
            try
            {
                int result = daFood.UpdateFood(name, categoryID, price, id);
                return result > 0;
            }
            catch
            {
                return false;
            }
        }

        public bool DeleteFood(int id)
        {
            try
            {
                int result = daFood.Delete1(id);
                return result > 0;
            }
            catch
            {
                return false;
            }
        }
        public List<MonAn> GetFoodByCategoryID(int id)
        {
            List<MonAn> list = new List<MonAn>();

            try
            {
                var data = daFood.GetDataByCategoryID(id);

                foreach (var item in data)
                {
                    MonAn food = new MonAn
                    {
                        ID = item.id,
                        Name = item.name,
                        CategoryID = item.idCategory,
                        Price = (float)item.price
                    };
                    list.Add(food);
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi khi lấy món ăn theo danh mục: " + ex.Message);
            }

            return list;
        }
        public bool IsCategoryInUse(int categoryID)
        {
            try
            {
                int? count = (int)daFood.CountFoodByCategory(categoryID);
                return count.HasValue && count.Value > 0;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Lỗi khi kiểm tra danh mục: " + ex.Message);
                return true;
            }
        }
    }
}
