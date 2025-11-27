using DoAn.Net.QuanLyQuanCafeTableAdapters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoAn.Net
{
    public class DBBan
    {
        private BanTableAdapter daTable;

        public DBBan()
        {
            daTable = new BanTableAdapter();
        }

        public static int TableWidth = 90;
        public static int TableHeight = 90;

        public void SwitchTable(int id1, int id2)
        {
            try
            {
                daTable.SwitchTable(id1, id2);
            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi khi chuyển bàn: " + ex.Message);
            }
        }

        public List<Ban> LoadTableList()
        {
            List<Ban> tableList = new List<Ban>();

            try
            {
                var data = daTable.GetTableList();

                foreach (var item in data)
                {
                    Ban table = new Ban
                    {
                        ID = item.id,
                        Name = item.name,
                        Status = item.status
                    };
                    tableList.Add(table);
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi khi tải danh sách bàn: " + ex.Message);
            }

            return tableList;
        }

        public bool UpdateTableStatus(int tableID, string status)
        {
            try
            {
                int result = daTable.UpdateTableStatus(status, tableID);
                return result > 0;
            }
            catch
            {
                return false;
            }
        }

        public Ban GetTableByID(int tableID)
        {
            try
            {
                var data = daTable.GetDataByID(tableID);
                if (data.Count > 0)
                {
                    var item = data[0];
                    return new Ban
                    {
                        ID = item.id,
                        Name = item.name,
                        Status = item.status
                    };
                }
                return null;
            }
            catch
            {
                return null;
            }
        }
    }
}
