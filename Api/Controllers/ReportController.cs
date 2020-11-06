using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Customers_Payments_Report.ModelData.Models.common;
using Customers_Payments_Report.DataLogic.Repository.Interface;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Customers_Payments_Report.Controllers
{
//    [Authorize(AuthenticationSchemes = Microsoft.AspNetCore.Authentication.JwtBearer.JwtBearerDefaults.AuthenticationScheme)]
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

        [HttpGet("GetChartDataSales")]
        public List<ChartSalesData> GetChartDataSales()
        {
            return _reportRepository.GetChartDataSales();
        }

        [HttpGet("GetChartDataSalesMonthly")]
        public List<ChartSalesData> GetChartDataSalesMonthly()
        {
            return _reportRepository.GetChartDataSalesMonthly();
        }

        [HttpGet("GetChartPaymentCollection")]
        public List<ChartPaymentCollectionData> GetChartPaymentCollection()
        {
            return _reportRepository.GetChartPaymentCollection();
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



        [HttpGet("GetAdminByID/{name}")]
        public AdminData GetAdminByID(string name)
        {
            return _reportRepository.GetAdminByID(name);

        }
        [HttpPost("UpdateAdmin")]
        public int UpdateAdmin([FromBody] AdminData EditAdm)
        {
            return _reportRepository.UpdateAdmin(EditAdm);
        }



    }
}