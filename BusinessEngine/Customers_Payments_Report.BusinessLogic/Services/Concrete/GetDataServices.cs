using Customers_Payments_Report.DataLogic.Repository.Interface;
using Customers_Payments_Report.ModelData.Models.common;
using System;
using System.Collections.Generic;
using System.Text;

namespace Customers_Payments_Report.BusinessLogic.Services.Concrete
{
    public class GetDataServices : IGetDataServices
    {
        private readonly IGetData _GetData;
        public GetDataServices(IGetData GetData)
        {
            _GetData = GetData;
        }
        public List<CustomerData> GetCustomers()
        {
            return _GetData.GetCustomers();
        }

        public List<InvoiceData> GetInvoices()
        {
            return _GetData.GetInvoices();
        }

        public List<PaymentData> GetPayments()
        {
            return _GetData.GetPayments();
        }

        public List<ReportData> GetReportCallaction()
        {
            return _GetData.GetReportCallaction();
        }

        public List<ReportData> GetReportPay()
        {
            return _GetData.GetReportPay();
        }
    }
}
