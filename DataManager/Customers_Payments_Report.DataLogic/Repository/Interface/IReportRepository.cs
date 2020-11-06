using Customers_Payments_Report.ModelData.Models.common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Customers_Payments_Report.DataLogic.Repository.Interface
{
    public interface IReportRepository
    {
        public List<ReportData> GetReport();
        public List<ReportData1> GetReport1();
        public List<Dashboarddata> GetDashbordData();
        public List<ChartSalesData> GetChartDataSales();
        public List<ChartPaymentCollectionData> GetChartPaymentCollection();
        AdminData GetAdminByID(string name);
        public int UpdateAdmin(AdminData EditAdm);
        public List<ChartSalesData> GetChartDataSalesMonthly();
    }
}
