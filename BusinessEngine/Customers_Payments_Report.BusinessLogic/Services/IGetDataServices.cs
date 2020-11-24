using Customers_Payments_Report.ModelData.Models.common;
using System;
using System.Collections.Generic;
using System.Text;

namespace Customers_Payments_Report.BusinessLogic.Services
{
    public interface IGetDataServices
    {

        public List<ReportData> GetReportCallaction();

        #region Report
        //public List<Models.common.Report> GetReport();
        public List<ReportData> GetReportPay();
        //public List<Models.common.CustomerReport> GetReportData();


        #endregion

        #region ListData
        public List<CustomerData> GetCustomers();
        public List<InvoiceData> GetInvoices();
        public List<PaymentData> GetPayments();

        #endregion
    }
}
