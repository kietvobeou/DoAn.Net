using DoAn.Net.QuanLyQuanCafeTableAdapters;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DoAn.Net
{
    public class DBReport
    {
        private ReportTableAdapter daReport;

        public DBReport()
        {
            daReport = new ReportTableAdapter();
        }

        public DataTable GetBillReport(DateTime startDate, DateTime endDate)
        {
            try
            {
                return daReport.GetDataByDateForReport(startDate, endDate);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message);
                return new DataTable();
            }
        }
    }
}
