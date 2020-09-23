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
                        if (Pay != null)
                        {
                            Payment1 = new PaymentData();
                            //          Payment1.Paymentid = Pay.Paymentid;
                            Payment1.PaymentNo = Pay.PaymentNo;
                            Payment1.InvoiceNo = Pay.InvoiceNo;
                            Payment1.PaymentDate = Pay.PaymentDate;
                            Payment1.PaymentAmount = Pay.PaymentAmount;

                            var inv = dBContext.Invoice.FirstOrDefault(x => x.InvoiceNo == Pay.InvoiceNo);
                            if (inv != null)
                            {
                                var Cust = dBContext.Customer.FirstOrDefault(x => x.CustomerNo == inv.CustomerNo);
                                if (Cust != null)
                                {
                                    Payment1.CustomerName = Cust.CustomerName;
                                }
                            }
                            Payments.Add(Payment1);

                        }


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
        string str;
        #region ShowPaymentNo
        public List<PaymentData> ShowPaymentNo()
        {
            List<PaymentData> Invoices = new List<PaymentData>();
            List<PaymentData> Invoices1 = new List<PaymentData>();
            using (var dBContext = new CustomersDatabaseContext())
            {

                //GetPaymentNO
                PaymentData Payment1;
                foreach (var pay in dBContext.Payment.ToList())
                {
                    Payment1 = new PaymentData();
                    Payment1.PaymentNo = pay.PaymentNo;
                    Invoices.Add(Payment1);
                }

                //     foreach (var Cust1 in dBContext.Customer.ToList())
                {
                    string s = "0";
                    int number = Convert.ToInt32(s);
                    number += 1;
                    str = "P" + number.ToString("D5");
                    X:
                    bool No = Invoices.Any(x => x.PaymentNo == str);
                    if (No == true)
                    {
                        //   str = str.Substring(1);
                        number += 1;
                        str = "P" + number.ToString("D5");
                        goto X;

                    }
                }

                PaymentData Payment2;
                    Payment2 = new PaymentData();
                    Payment2.PaymentNo = str;
                    Invoices1.Add(Payment2);
                return Invoices1;

            }
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
                    //GetPayment
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
                    if (PaymentModel.PaymentNo == null)
                    {
                        ShowPaymentNo();
                        PaymentModel.PaymentNo = str;
                    }

                    PaymentEntity.PaymentNo = PaymentModel.PaymentNo;
                    PaymentEntity.InvoiceNo = PaymentModel.InvoiceNo;
                    PaymentEntity.PaymentAmount = PaymentModel.PaymentAmount;
                    if (PaymentModel.PaymentDate == DateTime.MinValue)
                    {
                        PaymentEntity.PaymentDate = DateTime.UtcNow;
                    }
                    else
                    {
                        PaymentEntity.PaymentDate = PaymentModel.PaymentDate;
                    }
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

        public PaymentData GetPaymentById(string no)
        {
            PaymentData PaymentDatas = new PaymentData();
            try
            {
                using (var dBContext = new CustomersDatabaseContext())
                {
                    //GetEmployee
                    var pay = dBContext.Payment.Where(x => x.PaymentNo == no).SingleOrDefault();
                    if (pay != null)
                    {
                        //             PaymentDatas.Paymentid = pay.Paymentid;
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

        #region UpdatePayment

        public int UpdatePayment(PaymentData Editpay)
        {
            List<PaymentData> Payments = new List<PaymentData>();
            int returnVal = 0;
            try
            {
                using (var dBContext1 = new CustomersDatabaseContext())
                {
                    //GetPayment
                    //PaymentData Payment1;
                    //foreach (var Pay in dBContext1.Payment.ToList())
                    //{
                    //    Payment1 = new PaymentData();
                    //    Payment1.PaymentNo = Pay.PaymentNo;
                    //    //invoice1.InvoiceAmount = inv.InvoiceAmount;
                    //    //invoice1.CustomerNo = inv.CustomerNo;
                    //    //invoice1.InvoiceDate = inv.InvoiceDate;
                    //    //invoice1.PaymentDueDate = inv.PaymentDueDate;
                    //    Payments.Add(Payment1);
                    //}

                    Payment PaymentEntity = new Payment();
                    PaymentEntity = dBContext1.Payment.FirstOrDefault(x => x.PaymentNo == Editpay.PaymentNo);
                    if (PaymentEntity != null)
                    {
                        PaymentEntity.PaymentNo = Editpay.PaymentNo;
                        PaymentEntity.InvoiceNo = Editpay.InvoiceNo;
                        PaymentEntity.PaymentAmount = Editpay.PaymentAmount;
                        //if(Editpay.PaymentDate == DateTime.MinValue)
                        //{
                        //    PaymentEntity.PaymentDate = DateTime.UtcNow;
                        //}
                        //else
                        //{ 
                        PaymentEntity.PaymentDate = Editpay.PaymentDate;
                        //}
                        dBContext1.Payment.Update(PaymentEntity);
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

        #region DeletePayment

        public int DeletePayment(string no)
        {
            int returnVal = 0;
            try
            {
                using (var dBContext1 = new CustomersDatabaseContext())
                {
                    Payment paymentEntity = new Payment();
                    paymentEntity = dBContext1.Payment.FirstOrDefault(x => x.PaymentNo == no);
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
