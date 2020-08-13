using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Customers_Payments_Report.Models;
using Customers_Payments_Report.Repository;

namespace Customers_Payments_Report.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DefaultController : ControllerBase
    {
        private readonly IGetData _GetDataRepository;

        #region Report
        [HttpGet("GetReport")]
        public List<Models.common.Report> GetReport()
        {
            return _GetDataRepository.GetReport();
        }
        #endregion

        #region ListData
        public DefaultController(IGetData GetDataRepository)
        {
            _GetDataRepository = GetDataRepository;
        }

        [HttpGet("GetCustomers")]
        public List<Models.common.Customer> GetEmployees()
        {
            return _GetDataRepository.GetCustomers();
        }

        [HttpGet("GetInvoices")]
        public List<Models.common.Invoice> GetInvoices()
        {
            return _GetDataRepository.GetInvoices();
        }


        [HttpGet("GetPayments")]
        public List<Models.common.Pyment> GetPayments()
        {
            return _GetDataRepository.GetPayments();
        }
        #endregion
        

    }
}