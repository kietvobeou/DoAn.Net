using DoAn.Net.QuanLyQuanCafeTableAdapters;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DoAn.Net
{
    public class DBHoaDon
    {
        private HoaDonTableAdapter daBill;

        public DBHoaDon()
        {
            daBill = new HoaDonTableAdapter();
        }
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

        public bool SwitchTable(int idBill, int idTableDich)
        {
            try
            {
                int rowsAffected = daBill.UpdateBill(idTableDich, idBill);
                return rowsAffected > 0;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi chuyển bàn: " + ex.Message);
                return false;
            }
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
