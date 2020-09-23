using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Customers_Payments_Report.Models;
using Customers_Payments_Report.Repository;
using Microsoft.AspNetCore.Cors;
using Customers_Payments_Report.Repository.Interface;
using Microsoft.AspNetCore.Authorization;

namespace Customers_Payments_Report.Controllers
{
    [Authorize(AuthenticationSchemes = Microsoft.AspNetCore.Authentication.JwtBearer.JwtBearerDefaults.AuthenticationScheme)]
    [Route("api/[controller]")]
    [ApiController]
    [EnableCors("AllowMyOrigin")]

    public class DefaultController : ControllerBase
    {
        private readonly IGetData _GetDataRepository;
        public DefaultController(IGetData GetDataRepository)
        {
            _GetDataRepository = GetDataRepository;
        }

        [HttpGet("GetReportCallaction")]
        public List<Models.common.ReportData> GetReportCallaction()
        {
            return _GetDataRepository.GetReportCallaction();
        }

        #region Report


        [HttpGet("GetReportPay")]
        public List<Models.common.ReportData> GetReportPay()
        {
            return _GetDataRepository.GetReportPay();
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
        public List<Models.common.CustomerData> GetEmployees()
        {
            return _GetDataRepository.GetCustomers();
        }

        [HttpGet("GetInvoices")]
        public List<Models.common.InvoiceData> GetInvoices()
        {
            return _GetDataRepository.GetInvoices();
        }


        [HttpGet("GetPayments")]
        public List<Models.common.PaymentData> GetPayments()
        {
            return _GetDataRepository.GetPayments();
        }
        #endregion
        

    }
}