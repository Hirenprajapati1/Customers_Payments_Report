using Customers_Payments_Report.Models.common;
using Customers_Payments_Report.Models.Entity;
using Customers_Payments_Report.Repository.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;

namespace Customers_Payments_Report.Repository.Class
{
    public class ReportRepository : IReportRepository
    {

        #region DashBord Data
        public List<Dashboarddata> GetDashbordData()
        {
            List<Dashboarddata> DashBordDetails = new List<Dashboarddata>();
            try
            {
                using (var dBContext = new CustomersDatabaseContext())
                {
                    Dashboarddata dashboard1 = new Dashboarddata();
                    dashboard1.TotelCustomer = dBContext.Customer.Count();
                    dashboard1.TotelInvoices = dBContext.Invoice.Count();
                    dashboard1.TotelPayments = dBContext.Payment.Count();
                    DateTime Today = DateTime.Today;
                    var Month = (Today.Month);
                    var Year = (Today.Year);
              
                    {
                        //dashboard1.CustomerMonthly = 0;
                        //dashboard1.CustomerYaerly = 0;
                        //dashboard1.SalesMonthly = 0;
                        //dashboard1.SalesYearly = 0;
                        //dashboard1.TotelSeles = 0;
                        //dashboard1.PaymentCollestionsYearly = 0;
                        //dashboard1.PaymentCollestionsMonthly = 0;
                        //dashboard1.TotelPaymentCollestions = 0;
                    }
                    //dashboard1.CustomerMonthly = dBContext.Customer.Where(x => x.CreatedDate.Month == Month && x.CreatedDate.Year == Year).Count(x => x.CustomerNo);
          
                    foreach (var Cu in dBContext.Customer.ToList())
                    {
                        if (Cu.CreatedDate != null)
                        {
                            if (Cu.CreatedDate.Year == Year)
                            {
                                dashboard1.CustomerYaerly += 1;

                                if (Cu.CreatedDate.Month == Month)
                                {
                                    dashboard1.CustomerMonthly += 1;
                                }
                            }
                        }
                    }

                    foreach (var inv in dBContext.Invoice.ToList())
                    {
                        if (inv.InvoiceDate.Year == Year)
                        {
                            dashboard1.SalesYearly += inv.InvoiceAmount;
                            dashboard1.InvoiceYearly += 1;
                            if (inv.InvoiceDate.Month == Month)
                            {
                                dashboard1.SalesMonthly += inv.InvoiceAmount;
                                dashboard1.InvoiceMonthly += 1;
                            }
                        }
                        dashboard1.TotelSeles += inv.InvoiceAmount;
                    }

                    foreach (var Pay in dBContext.Payment.ToList())
                    {
                        if (Pay.PaymentDate.Year == Year)
                        {
                            dashboard1.PaymentCollestionsYearly += Pay.PaymentAmount;
                            dashboard1.PaymentsYearly += 1;
                            if (Pay.PaymentDate.Month == Month)
                            {
                                dashboard1.PaymentCollestionsMonthly += Pay.PaymentAmount;
                                dashboard1.PaymentsMonthly += 1;
                            }
                        }
                        
                        dashboard1.TotelPaymentCollestions += Pay.PaymentAmount;
                    }

                    dashboard1.CustomerMonthlyGroth = (dashboard1.CustomerMonthly / dashboard1.TotelCustomer) * 100;
                    dashboard1.CustomerYearlyGroth = (dashboard1.CustomerYaerly / dashboard1.TotelCustomer) * 100;

                    dashboard1.SalesMonthlyGroth =Convert.ToInt32(( dashboard1.SalesMonthly / dashboard1.TotelSeles)*100);
                    dashboard1.SalesYearlyGroth = Convert.ToInt32((dashboard1.SalesYearly / dashboard1.TotelSeles)*100);

                    dashboard1.PaymentCollestionsMonthlyGroth =Convert.ToInt32 ((dashboard1.PaymentCollestionsMonthly / dashboard1.TotelPaymentCollestions) * 100);
                    dashboard1.PaymentCollestionsYearlyGroth = Convert.ToInt32((dashboard1.PaymentCollestionsYearly / dashboard1.TotelPaymentCollestions) * 100);

                    DashBordDetails.Add(dashboard1);
                }
            }
            catch (Exception)
            {

                throw;
            }
            return DashBordDetails;
        }
        #endregion

        #region GetReport1

        public List<ReportData1> GetReport1()
        {
            List<ReportData1> Reports = new List<ReportData1>();
            try
            {
                using (var dBContext = new CustomersDatabaseContext())
                {
                    ReportData1 Report1;
                    foreach (var Cu in dBContext.Customer.ToList())
                    {

                        Report1 = new ReportData1();
                        Report1.CustomerNo = Cu.CustomerNo;
                        Report1.CustomerName = Cu.CustomerName;
                        var Inv = dBContext.Invoice.FirstOrDefault(x => x.CustomerNo == Cu.CustomerNo);
                        if (Inv != null)
                        {
                            Report1.TotelInvoiceAmount = dBContext.Invoice.Where(x => x.CustomerNo == Inv.CustomerNo).Sum(x => x.InvoiceAmount);
                            var pay = dBContext.Payment.FirstOrDefault(x => x.InvoiceNo == Inv.InvoiceNo);
                            if (pay != null)
                            {
                                //Report1.TotelPaymentAmount = dBContext.Payment.Where(x => Inv.InvoiceNo == pay.InvoiceNo).Sum(x => x.PaymentAmount);
                                Report1.TotelPaymentAmount = 0;
                            }
                        }
                        Reports.Add(Report1);


                        foreach (var pay in dBContext.Payment.ToList())
                        {
                            Report1 = new ReportData1();

                            var inv = dBContext.Invoice.FirstOrDefault(x => x.InvoiceNo == pay.InvoiceNo);
                            if (inv != null)
                            {
                                Report1 = new ReportData1();
                                var cust = dBContext.Customer.FirstOrDefault(x => x.CustomerNo == inv.CustomerNo);
                                //  Report1.TotelPaymentAmount=
                            }
                            Boolean b = false;

                            foreach (var a in Reports)
                            {
                                //if (a.Year == Report1.Year && a.Month == Report1.Month && a.CustomerNo == Report1.CustomerNo)
                                if (a.CustomerNo == Report1.CustomerNo)
                                {
                                    //   a.PaymentCollection = a.PaymentCollection + dBContext.Pyment.FirstOrDefault(x => x.InvoiceNo == Inv.InvoiceNo).PaymentAmount;
                                    if (pay != null)
                                    {
                                        a.TotelPaymentAmount = pay.PaymentAmount + a.TotelPaymentAmount;
                                    }
                                    b = true;

                                }
                            }
                            if (b == false)
                            {
                                // Report1.PaymentCollection = dBContext.Pyment.FirstOrDefault(x => x.InvoiceNo == Inv.InvoiceNo).PaymentAmount;
                                if (pay != null)
                                {
                                    Report1.TotelPaymentAmount = pay.PaymentAmount;
                                }
                                Reports.Add(Report1);
                            }


                        }


                    }
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return Reports;
        }
        #endregion

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
