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
using Customers_Payments_Report.BusinessLogic.Services;

namespace Customers_Payments_Report.Controllers
{
//    [Authorize(AuthenticationSchemes = Microsoft.AspNetCore.Authentication.JwtBearer.JwtBearerDefaults.AuthenticationScheme)]
    [Route("api/[controller]")]
    [ApiController]
    [EnableCors("AllowMyOrigin")]

    public class ReportController : ControllerBase
    {
        private readonly IReportServices _reportServices;
        public ReportController(IReportServices reportServices)
        {
            _reportServices = reportServices;
        }


        [HttpGet("GetDashbordData")]
        public List<Dashboarddata> GetDashbordData()
        {
            return _reportServices.GetDashbordData();
        }

        [HttpGet("GetChartDataSales")]
        public List<ChartSalesData> GetChartDataSales()
        {
            return _reportServices.GetChartDataSales();
        }

        [HttpGet("GetChartDataSalesMonthly")]
        public List<ChartSalesData> GetChartDataSalesMonthly()
        {
            return _reportServices.GetChartDataSalesMonthly();
        }

        [HttpGet("GetChartPaymentCollection")]
        public List<ChartPaymentCollectionData> GetChartPaymentCollection()
        {
            return _reportServices.GetChartPaymentCollection();
        }





        [HttpGet("GetReport")]
        public List<ReportData> GetReport()
        {
            return _reportServices.GetReport();
        }


        [HttpGet("GetReport1")]
        public List<ReportData1> GetReport1()
        {
            return _reportServices.GetReport1();
        }



        [HttpGet("GetAdminByID/{name}")]
        public AdminData GetAdminByID(string name)
        {
            return _reportServices.GetAdminByID(name);

        }
        [HttpPost("UpdateAdmin")]
        public int UpdateAdmin([FromBody] AdminData EditAdm)
        {
            return _reportServices.UpdateAdmin(EditAdm);
        }



    }
}