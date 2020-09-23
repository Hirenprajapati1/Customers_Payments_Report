using Customers_Payments_Report.Models.common;
using Customers_Payments_Report.Models.Entity;
using Customers_Payments_Report.Repository.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Customers_Payments_Report.Repository.Class
{
    public class ReportRepository : IReportRepository
    {
        #region GetReport

        public List<ReportData> GetReport()
        {
            List<ReportData> Reports = new List<ReportData>();
            try
            {
                using (var dBContext = new CustomersDatabaseContext())
                {
                    Models.common.ReportData Report1;
                    int i = 0;
                    foreach (var Inv in dBContext.Invoice.ToList())
                    {
                        Report1 = new Models.common.ReportData();
                        var Cust = dBContext.Customer.FirstOrDefault(x => x.CustomerNo == Inv.CustomerNo);
                        Report1.DateOfMonthInvoice = new DateTime(Inv.InvoiceDate.Year, Inv.InvoiceDate.Month, 11);

                        Report1.DateOfMonth = Report1.DateOfMonthInvoice;

                        //Report1.MonthPayment = dBContext.Pyment.FirstOrDefault(x => x.InvoiceNo == Inv.InvoiceNo).PaymentDate;
                        if (Cust != null)
                        {
                            Report1.CustomerNo = Inv.CustomerNo;
                            Report1.CustomerName = Cust.CustomerName;
                        }
                        Report1.NoOfInvoices = 1;
                        //Report1.PaymentCollection = dBContext.Pyment.FirstOrDefault(x => x.InvoiceNo == Inv.InvoiceNo).PaymentAmount;
                        Boolean b = false;

                        foreach (var a in Reports)
                        {
                            //if (a.Year == Report1.Year && a.Month == Report1.Month && a.CustomerNo == Report1.CustomerNo)
                            if (a.DateOfMonthInvoice == Report1.DateOfMonthInvoice && a.CustomerNo == Report1.CustomerNo)
                            {
                                //   a.PaymentCollection = a.PaymentCollection + dBContext.Pyment.FirstOrDefault(x => x.InvoiceNo == Inv.InvoiceNo).PaymentAmount;
                                a.Sales = Inv.InvoiceAmount + a.Sales;
                                a.NoOfInvoices = a.NoOfInvoices + 1;
                                b = true;
                            }


                        }
                        if (b == false)
                        {
                            // Report1.PaymentCollection = dBContext.Pyment.FirstOrDefault(x => x.InvoiceNo == Inv.InvoiceNo).PaymentAmount;
                            Report1.Sales = Inv.InvoiceAmount;
                            i++;
                            Report1.No = i;
                            Reports.Add(Report1);
                        }

                    }
                    foreach (var PayInv in dBContext.Payment.ToList())
                    {
                        Report1 = new ReportData();


                        if (PayInv != null)
                        {
                            var inv = dBContext.Invoice.FirstOrDefault(x => x.InvoiceNo == PayInv.InvoiceNo);
                            Report1.DateOfMonthPay = new DateTime(PayInv.PaymentDate.Year, PayInv.PaymentDate.Month, 11);
                            Report1.DateOfMonth = Report1.DateOfMonthPay;

                            if (inv != null)
                            {
                                var Cust = dBContext.Customer.FirstOrDefault(x => x.CustomerNo == inv.CustomerNo);
                                if (Cust != null)
                                {

                                    Report1.CustomerNo = Cust.CustomerNo;
                                    Report1.CustomerName = Cust.CustomerName;
                                }
                            }
                        }
                        Boolean b = false;

                        foreach (var a in Reports)
                        {
                            //if (a.Year == Report1.Year && a.Month == Report1.Month && a.CustomerNo == Report1.CustomerNo)
                            if ((a.DateOfMonth == Report1.DateOfMonthPay || a.DateOfMonthPay == Report1.DateOfMonthPay) && a.CustomerNo == Report1.CustomerNo)
                            {
                                //   a.PaymentCollection = a.PaymentCollection + dBContext.Pyment.FirstOrDefault(x => x.InvoiceNo == Inv.InvoiceNo).PaymentAmount;
                                if (PayInv != null)
                                {
                                    a.PaymentCollection = PayInv.PaymentAmount + a.PaymentCollection;
                                }
                                b = true;
                            }
                        }
                        if (b == false)
                        {
                            // Report1.PaymentCollection = dBContext.Pyment.FirstOrDefault(x => x.InvoiceNo == Inv.InvoiceNo).PaymentAmount;
                            if (PayInv != null)
                            {
                                Report1.PaymentCollection = PayInv.PaymentAmount;
                            }
                            Reports.Add(Report1);
                        }


                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            Reports = Reports.OrderBy(e => e.DateOfMonth).ThenBy(e => e.CustomerName).ToList();
            return Reports;
        }

        #endregion

    }
}
