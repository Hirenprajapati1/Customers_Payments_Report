using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Customers_Payments_Report.ModelData.Models.common;
using Customers_Payments_Report.DataLogic.Repository.Interface;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Authorization;
using Customers_Payments_Report.BusinessLogic.Services;

namespace Customers_Payments_Report.Controllers
{
    [Authorize(AuthenticationSchemes = Microsoft.AspNetCore.Authentication.JwtBearer.JwtBearerDefaults.AuthenticationScheme)]
    [Route("api/[controller]")]
    [ApiController]
    [EnableCors("AllowMyOrigin")]

    public class DefaultController : ControllerBase
    {
        private readonly IGetDataServices _GetDataServices;
        public DefaultController(IGetDataServices GetDataServices)
        {
            _GetDataServices = GetDataServices;
        }

        [HttpGet("GetReportCallaction")]
        public List<ReportData> GetReportCallaction()
        {
            return _GetDataServices.GetReportCallaction();
        }

        #region Report


        [HttpGet("GetReportPay")]
        public List<ReportData> GetReportPay()
        {
            return _GetDataServices.GetReportPay();
        }

        #endregion

        //[HttpGet("GetReport")]
        //public List<Models.common.Report> GetReport()
        //{
        //    return _GetDataRepository.GetReport();
        //}

        //[HttpGet("GetReportData")]
        //public List<Models.common.CustomerReport> GetReportData()
        //{
        //    return _GetDataRepository.GetReportData();
        //}


        #region ListData
     
        [HttpGet("GetCustomers")]
        public List<CustomerData> GetEmployees()
        {
            return _GetDataServices.GetCustomers();
        }

        [HttpGet("GetInvoices")]
        public List<InvoiceData> GetInvoices()
        {
            return _GetDataServices.GetInvoices();
        }


        [HttpGet("GetPayments")]
        public List<PaymentData> GetPayments()
        {
            return _GetDataServices.GetPayments();
        }
        #endregion
        

    }
}