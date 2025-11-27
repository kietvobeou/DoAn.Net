using DoAn.Net.QuanLyQuanCafeTableAdapters;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoAn.Net
{
    public class DBChiTietHoaDon
    {
        private ChiTietHoaDonTableAdapter dbChiTiet;

        public DBChiTietHoaDon()
        {
            dbChiTiet = new ChiTietHoaDonTableAdapter();
        }

        public void DeleteBillInfoByFoodID(int id)
        {
            try
            {
                dbChiTiet.DeleteByFoodID(id);
            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi khi xóa BillInfo: " + ex.Message);
            }
        }

        public List<ChiTietHoaDon> GetListChiTietHoaDon(int id)
        {
            List<ChiTietHoaDon> listChiTietHoaDon = new List<ChiTietHoaDon>();

            try
            {
                var data = dbChiTiet.GetDataByBillID(id);

                foreach (var item in data)
                {
                    ChiTietHoaDon info = new ChiTietHoaDon
                    {
                        ID = item.id,
                        BillID = item.idBill,
                        FoodID = item.idFood,
                        Count = item.count
                    };
                    listChiTietHoaDon.Add(info);
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi khi lấy danh sách ChiTietHoaDon: " + ex.Message);
            }

            return listChiTietHoaDon;
        }

        public void InsertBillInfo(int idBill, int idFood, int count)
        {
            try
            {
                dbChiTiet.InsertBillInfo(idBill, idFood, count);
            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi khi thêm Chi Tiết Hóa Đơn: " + ex.Message);
            }
        }

        public DataTable GetBillInfoDataTable(int id)
        {
            try
            {
                return dbChiTiet.GetDataByBillID(id);
            }
            catch
            {
                return new DataTable();
            }
        }
    }
}
