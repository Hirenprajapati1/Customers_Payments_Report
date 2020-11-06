using Customers_Payments_Report.ModelData.Models.common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Customers_Payments_Report.DataLogic.Repository.Interface
{
    public interface IPaymentRepository
    {
        public List<PaymentData> GetPayments();
        public List<PaymentData> ShowPaymentNo();
        public List<PaymentData> ShowPaymentNoByTable();
        public int AddPayment(PaymentData PaymentModel);
        public int AddPaymentNoByUser(PaymentData PaymentModel);
        public PaymentData GetPaymentById(string no);
        public int UpdatePayment(PaymentData Editpay);
        public int DeletePayment(string no);
        public List<InvoiceData> GetInvoiceNoByCustomerNo(string no);
        public List<Invoice2Data> GetInvoiceDetailsByNo(string no);
        public List<CustomerData> GetCustNoByInvNo(string no);

    }
}
