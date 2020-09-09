using Customers_Payments_Report.Models.common;
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
                    PaymentData Payment1;
                    foreach (var Pay in dBContext.Payment.ToList())
                    {
                        var inv = dBContext.Invoice.FirstOrDefault(x => x.InvoiceNo == Pay.InvoiceNo);

                        var Cust = dBContext.Customer.FirstOrDefault(x => x.CustomerNo == inv.CustomerNo);

                        Payment1 = new PaymentData();
                        Payment1.Paymentid = Pay.Paymentid;
                        Payment1.PaymentNo = Pay.PaymentNo;
                        Payment1.InvoiceNo = Pay.InvoiceNo;
                        if (Cust != null)
                        {
                            Payment1.CustomerName = Cust.CustomerName;
                        }
                        Payment1.PaymentDate = Pay.PaymentDate;
                        Payment1.PaymentAmount = Pay.PaymentAmount;

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

        #region GetPaymentById

        public PaymentData GetPaymentById(int id)
        {
            PaymentData PaymentDatas = new PaymentData();
            try
            {
                using (var dBContext = new CustomersDatabaseContext())
                {
                    //GetEmployee
                    var pay = dBContext.Payment.Where(x => x.Paymentid == id).SingleOrDefault();
                    if (pay != null)
                    {
                        PaymentDatas.Paymentid = pay.Paymentid;
                        PaymentDatas.PaymentNo = pay.PaymentNo;
                        PaymentDatas.InvoiceNo = pay.InvoiceNo;
                        PaymentDatas.PaymentDate = pay.PaymentDate;
                        PaymentDatas.PaymentAmount = pay.PaymentAmount;
                    }
                    return PaymentDatas;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw;
            }

        }


        #endregion

        #region DeletePayment

        public int DeletePayment(int Id)
        {
            int returnVal = 0;
            try
            {
                using (var dBContext1 = new CustomersDatabaseContext())
                {
                    Payment paymentEntity = new Payment();
                    paymentEntity = dBContext1.Payment.FirstOrDefault(x => x.Paymentid == Id);
                    if (paymentEntity != null)
                    {
                        dBContext1.Payment.Remove(paymentEntity);
                    }
                    returnVal = dBContext1.SaveChanges();
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
