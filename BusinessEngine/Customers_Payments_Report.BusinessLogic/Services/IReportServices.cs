using Customers_Payments_Report.ModelData.Models.common;
using System;
using System.Collections.Generic;
using System.Text;

namespace Customers_Payments_Report.BusinessLogic.Services
{
    public interface IReportServices
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
