using Customers_Payments_Report.DataLogic.Repository.Interface;
using Customers_Payments_Report.ModelData.Models.common;
using System;
using System.Collections.Generic;
using System.Text;

namespace Customers_Payments_Report.BusinessLogic.Services.Concrete
{
    public class ReportServices : IReportServices
    {
        private readonly IReportRepository _reportRepository;
        public ReportServices(IReportRepository reportRepository)
        {
            _reportRepository = reportRepository;
        }
        public AdminData GetAdminByID(string name)
        {
            return _reportRepository.GetAdminByID(name);
        }

        public List<ChartSalesData> GetChartDataSales()
        {
            return _reportRepository.GetChartDataSales();
        }

        public List<ChartSalesData> GetChartDataSalesMonthly()
        {
            return _reportRepository.GetChartDataSalesMonthly();
        }

        public List<ChartPaymentCollectionData> GetChartPaymentCollection()
        {
            return _reportRepository.GetChartPaymentCollection();
        }

        public List<Dashboarddata> GetDashbordData()
        {
            return _reportRepository.GetDashbordData();
        }

        public List<ReportData> GetReport()
        {
            return _reportRepository.GetReport();
        }

        public List<ReportData1> GetReport1()
        {
            return _reportRepository.GetReport1();
        }

        public int UpdateAdmin(AdminData EditAdm)
        {
            return _reportRepository.UpdateAdmin(EditAdm);
        }
    }
}
