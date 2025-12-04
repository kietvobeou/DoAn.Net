using DoAn.Net.QuanLyQuanCafeTableAdapters;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoAn.Net
{
    public class DBHoaDon
    {
        private HoaDonTableAdapter daBill;

        public DBHoaDon()
        {
            daBill = new HoaDonTableAdapter();
        }

        // --- Lấy danh sách món ăn theo bàn ---
        //public List<Menu> GetListMenuByTable(int idTable)
        //{
        //    List<Menu> listMenu = new List<Menu>();

        //    // Lấy chuỗi kết nối từ Project Settings
        //    string connectionString = Properties.Settings.Default.QuanLyQuanCafeConnectionString;

        //    // Câu lệnh SQL gọi Stored Procedure: USP_GetListMenuByTable
        //    // Query này nối 3 bảng: ChiTietHoaDon, HoaDon, MonAn
        //    string query = "EXEC USP_GetListMenuByTable @idTable";

        //    try
        //    {
        //        using (SqlConnection connection = new SqlConnection(connectionString))
        //        {
        //            connection.Open();
        //            SqlCommand command = new SqlCommand(query, connection);
        //            command.Parameters.AddWithValue("@idTable", idTable);

        //            SqlDataAdapter adapter = new SqlDataAdapter(command);
        //            DataTable data = new DataTable();
        //            adapter.Fill(data);

        //            foreach (DataRow item in data.Rows)
        //            {
        //                Menu menu = new Menu(item);
        //                listMenu.Add(menu);
        //            }
        //        }
        //    }
        //    catch { }

        //    return listMenu;
        //}

        //public DataTable GetListMenuByTable(int idTable)
        //{
        //    string connectionString = Properties.Settings.Default.QuanLyQuanCafeConnectionString;
        //    string query = "EXEC USP_GetListMenuByTable @idTable";

        //    using (SqlConnection connection = new SqlConnection(connectionString))
        //    {
        //        connection.Open();
        //        SqlCommand command = new SqlCommand(query, connection);
        //        command.Parameters.AddWithValue("@idTable", idTable);

        //        SqlDataAdapter adapter = new SqlDataAdapter(command);
        //        DataTable data = new DataTable();
        //        adapter.Fill(data);

        //        return data; // Trả về DataTable
        //    }
        //}
        public DataTable GetListMenuByTable(int idTable)
        {
            DataTable data = new DataTable();

            try
            {
                string connectionString = Properties.Settings.Default.QuanLyQuanCafeConnectionString;
                SqlConnection connection = new SqlConnection(connectionString);
                string query = "EXEC USP_GetListMenuByTable @idTable";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@idTable", idTable);
                connection.Open();

                SqlDataAdapter adapter = new SqlDataAdapter(command);
                adapter.Fill(data);
                connection.Close();
            }
            catch
            {
                
            }      
            return data;
        }


        public DataTable GetBillListByDate(DateTime checkIn, DateTime checkOut)
        {
            try
            {
                return daBill.GetBillListByDate(checkIn, checkOut);
            }
            catch
            {
                return new DataTable();
            }
        }

        public DataTable GetBillListByDateAndPage(DateTime checkIn, DateTime checkOut, int pageNum)
        {
            try
            {
                return daBill.GetBillListByDateAndPage(checkIn, checkOut, pageNum);
            }
            catch
            {
                return new DataTable();
            }
        }

        public int GetNumBillListByDate(DateTime checkIn, DateTime checkOut)
        {
            try
            {
                var result = daBill.GetNumBillByDate(checkIn, checkOut);
                return Convert.ToInt32(result);
            }
            catch
            {
                return 0;
            }
        }

        public int GetUncheckBillIDByTableID(int tableID)
        {
            try
            {
                var data = daBill.GetDataByTableIDAndStatus(tableID, 0);
                if (data.Count > 0)
                {
                    return data[0].id;
                }
                return -1;
            }
            catch
            {
                return -1;
            }
        }

        public void CheckOut(int billID, int discount, float totalPrice)
        {
            try
            {
                daBill.UpdateBillCheckOut(discount, totalPrice, billID);
            }
            catch
            {
            }
        }

        public void InsertBill(int tableID)
        {
            try
            {
                daBill.InsertBill(tableID);
            }
            catch
            {
            }
        }

        public int GetMaxIDBill()
        {
            try
            {
                var result = daBill.GetMaxBillID();
                return result ?? 1;
            }
            catch
            {
                return 1;
            }
        }
    }
}
