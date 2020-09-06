﻿using Customers_Payments_Report.Models.common;
using Customers_Payments_Report.Models.Entity;
using Customers_Payments_Report.Repository.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Customers_Payments_Report.Repository.Class
{
    public class PaymentRepository : IPaymentRepository
    {
        #region ListPayments
        public List<PaymentData> GetPayments()
        {
            List<PaymentData> Payments = new List<PaymentData>();
            try
            {
                using (var dBContext = new CustomersDatabaseContext())
                {
                    //GetEmployee
                    PaymentData Payment1;
                    foreach (var Pay in dBContext.Payment.ToList())
                    {
                        var inv = dBContext.Invoice.FirstOrDefault(x => x.InvoiceNo == Pay.InvoiceNo);

                        var Cust = dBContext.Customer.FirstOrDefault(x => x.CustomerNo == inv.CustomerNo);

                        Payment1 = new PaymentData();
                        Payment1.PaymentNo = Pay.PaymentNo;
                        Payment1.InvoiceNo = Pay.InvoiceNo;
                        if(Cust != null)
                        {
                            Payment1.CustomerName = Cust.CustomerName;
                        }
                        Payment1.PaymentDate = Pay.PaymentDate;
                        Payment1.PaymentAmount = Pay.PaymentAmount;

                        //employee1.DesignationName = dBContext.TblDesignation.FirstOrDefault(x => x.DesignationId == emp.Designation).DesignationName;

                        Payments.Add(Payment1);

                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                //throw;
            }
            return Payments;
        }
        #endregion

        #region AddPayment
        public int AddPayment(PaymentData PaymentModel, string PaymentNo)
        {
            int returnVal = 0;
            List<PaymentData> invoices = new List<PaymentData>();
            try
            {
                using (var dBContext = new CustomersDatabaseContext())
                {
                    //GetEmployee
                    PaymentData Payment1;
                    foreach (var pay in dBContext.Payment.ToList())
                    {
                        Payment1 = new PaymentData();
                        Payment1.PaymentNo = pay.PaymentNo;
                        invoices.Add(Payment1);
                    }
                    Payment PaymentEntity;
                    //Add Invoice
                    PaymentEntity = new Payment();
                    PaymentEntity.PaymentNo = PaymentModel.PaymentNo;
                    PaymentEntity.InvoiceNo = PaymentModel.InvoiceNo;
                    PaymentEntity.PaymentAmount = PaymentModel.PaymentAmount;
                    PaymentEntity.PaymentDate = DateTime.UtcNow;
                    PaymentNo = PaymentEntity.PaymentNo;

                    bool PaymentNoxist = invoices.Any(x => x.PaymentNo == PaymentNo);
                    if (PaymentNoxist == true)
                    {
                        returnVal = -1;
                    }
                    else
                    {
                        dBContext.Payment.Add(PaymentEntity);
                        returnVal = dBContext.SaveChanges();
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                //throw;
            }
            return returnVal;
        }

        #endregion


    }
}
