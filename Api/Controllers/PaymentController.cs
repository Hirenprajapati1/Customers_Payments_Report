using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Customers_Payments_Report.ModelData.Models.common;
using Customers_Payments_Report.DataLogic.Entity;
using Customers_Payments_Report.DataLogic.Repository.Interface;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Customers_Payments_Report.BusinessLogic.Services;

namespace Customers_Payments_Report.Controllers
{
    [Authorize(AuthenticationSchemes = Microsoft.AspNetCore.Authentication.JwtBearer.JwtBearerDefaults.AuthenticationScheme)]
    [Route("api/[controller]")]
    [ApiController]
    [EnableCors("AllowMyOrigin")]

    public class PaymentController : ControllerBase
    {
        private readonly IPaymentServices _paymentServices;
        public PaymentController(IPaymentServices paymentServices)
        {
            _paymentServices = paymentServices;
        }


        [HttpGet("GetPayments")]
        public List<PaymentData> GetPayments()
        {
            return _paymentServices.GetPayments();
        }

        [HttpGet("ShowPaymentNo")]
        public List<PaymentData> ShowPaymentNo()
        {
            return _paymentServices.ShowPaymentNo();
        }

        [HttpGet("ShowPaymentNoByTable")]
        public List<PaymentData> ShowPaymentNoByTable()
        {
            return _paymentServices.ShowPaymentNoByTable();
        }

        [Authorize(Roles = "Admin")]
        [HttpPost("AddPayment")]
        public int AddPayment([FromBody] PaymentData PaymentModel)
        {
            return _paymentServices.AddPayment(PaymentModel);
        }

        [Authorize(Roles = "Admin")]
        [HttpPost("AddPaymentNoByUser")]
        public int AddPaymentNoByUser([FromBody] PaymentData PaymentModel)
        {
            return _paymentServices.AddPaymentNoByUser(PaymentModel);
        }

        [Authorize(Roles = "Admin")]
        [HttpGet("GetPaymentById/{id}")]
        public PaymentData GetPaymentById(string id)
        {
            return _paymentServices.GetPaymentById(id);
        }

        [Authorize(Roles = "Admin")]
        [HttpPost("UpdatePayment/{id}")]
        public int UpdatePayment([FromBody] PaymentData Editpay)
        {
            return _paymentServices.UpdatePayment(Editpay);
        }

        [Authorize(Roles = "Admin")]
        [HttpDelete("DeletePayment/{id}")]
        public int DeletePayment(string id)
        {
            return _paymentServices.DeletePayment(id);
        }

        [HttpGet("GetInvoiceNoByCustomerNo/{no}")]
        public List<InvoiceData> GetInvoiceNoByCustomerNo(string no)
        {
            return _paymentServices.GetInvoiceNoByCustomerNo(no);
        }

        [HttpGet("GetInvoiceDetailsByNo/{no}")]
        public List<Invoice2Data> GetInvoiceDetailsByNo(string no)
        {
            return _paymentServices.GetInvoiceDetailsByNo(no);
        }

        [HttpGet("GetCustNoByInvNo/{no}")]
        public List<CustomerData> GetCustNoByInvNo(string no)
        {
            return _paymentServices.GetCustNoByInvNo(no);
        }

    }
}