using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Customers_Payments_Report.Repository.Interface;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Customers_Payments_Report.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [EnableCors("AllowMyOrigin")]

    public class ReportController : ControllerBase
    {
        private readonly IReportRepository _reportRepository;
        public ReportController(IReportRepository reportRepository)
        {
            _reportRepository = reportRepository;
        }


        [HttpGet("GetReport")]
        public List<Models.common.ReportData> GetReport()
        {
            return _reportRepository.GetReport();
        }


    }
}