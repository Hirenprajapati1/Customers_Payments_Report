using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Customers_Payments_Report.Models.common;
using Customers_Payments_Report.Repository.Interface;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Customers_Payments_Report.Controllers
{
   // [Authorize(AuthenticationSchemes = Microsoft.AspNetCore.Authentication.JwtBearer.JwtBearerDefaults.AuthenticationScheme)]
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


        [HttpGet("GetDashbordData")]
        public List<Dashboarddata> GetDashbordData()
        {
            return _reportRepository.GetDashbordData();
        }

        [HttpGet("GetReport")]
        public List<ReportData> GetReport()
        {
            return _reportRepository.GetReport();
        }


        [HttpGet("GetReport1")]
        public List<ReportData1> GetReport1()
        {
            return _reportRepository.GetReport1();
        }


    }
}