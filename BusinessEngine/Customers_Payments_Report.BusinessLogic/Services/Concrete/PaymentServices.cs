using Customers_Payments_Report.DataLogic.Repository.Interface;
using Customers_Payments_Report.ModelData.Models.common;
using System;
using System.Collections.Generic;
using System.Text;

namespace Customers_Payments_Report.BusinessLogic.Services.Concrete
{
    public class PaymentServices : IPaymentServices
    {
        private readonly IPaymentRepository _paymentRepository;
        public PaymentServices(IPaymentRepository paymentRepository)
        {
            _paymentRepository = paymentRepository;
        }

        public int AddPayment(PaymentData PaymentModel)
        {
            return _paymentRepository.AddPayment(PaymentModel);
        }

        public int AddPaymentNoByUser(PaymentData PaymentModel)
        {
            return _paymentRepository.AddPaymentNoByUser(PaymentModel);
        }

        public int DeletePayment(string no)
        {
            return _paymentRepository.DeletePayment(no);
        }

        public List<CustomerData> GetCustNoByInvNo(string no)
        {
            return _paymentRepository.GetCustNoByInvNo(no);
        }

        public List<Invoice2Data> GetInvoiceDetailsByNo(string no)
        {
            return _paymentRepository.GetInvoiceDetailsByNo(no);
        }

        public List<InvoiceData> GetInvoiceNoByCustomerNo(string no)
        {
            return _paymentRepository.GetInvoiceNoByCustomerNo(no);
        }

        public PaymentData GetPaymentById(string no)
        {
            return _paymentRepository.GetPaymentById(no);
        }

        public List<PaymentData> GetPayments()
        {
            return _paymentRepository.GetPayments();
        }

        public List<PaymentData> ShowPaymentNo()
        {
            return _paymentRepository.ShowPaymentNo();
        }

        public List<PaymentData> ShowPaymentNoByTable()
        {
            return _paymentRepository.ShowPaymentNoByTable();
        }

        public int UpdatePayment(PaymentData Editpay)
        {
            return _paymentRepository.UpdatePayment(Editpay);
        }
    }
}
