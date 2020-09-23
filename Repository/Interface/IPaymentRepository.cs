﻿using Customers_Payments_Report.Models.common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Customers_Payments_Report.Repository.Interface
{
    public interface IPaymentRepository
    {
        public List<PaymentData> GetPayments();
        public List<PaymentData> ShowPaymentNo();
        public int AddPayment(PaymentData PaymentModel, string PaymentNo);
        public PaymentData GetPaymentById(string no);
        public int UpdatePayment(PaymentData Editpay);
        public int DeletePayment(string no);
    }
}
