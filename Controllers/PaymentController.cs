using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Customers_Payments_Report.Models.common;
using Customers_Payments_Report.Models.Entity;
using Customers_Payments_Report.Repository.Interface;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Customers_Payments_Report.Controllers
{
    [Authorize(AuthenticationSchemes = Microsoft.AspNetCore.Authentication.JwtBearer.JwtBearerDefaults.AuthenticationScheme)]
    [Route("api/[controller]")]
    [ApiController]
    [EnableCors("AllowMyOrigin")]

    public class PaymentController : ControllerBase
    {
        private readonly IPaymentRepository _paymentRepository;
        public PaymentController(IPaymentRepository paymentRepository)
        {
            _paymentRepository = paymentRepository;
        }


        [HttpGet("GetPayments")]
        public List<PaymentData> GetPayments()
        {
            return _paymentRepository.GetPayments();
        }

        [HttpGet("ShowPaymentNo")]
        public List<PaymentData> ShowPaymentNo()
        {
            return _paymentRepository.ShowPaymentNo();
        }

        [HttpGet("ShowPaymentNoByTable")]
        public List<PaymentData> ShowPaymentNoByTable()
        {
            return _paymentRepository.ShowPaymentNoByTable();
        }


        [HttpPost("AddPayment")]
        public int AddPayment([FromBody] PaymentData PaymentModel)
        {
            return _paymentRepository.AddPayment(PaymentModel);
        }


        [HttpPost("AddPaymentNoByUser")]
        public int AddPaymentNoByUser([FromBody] PaymentData PaymentModel)
        {
            return _paymentRepository.AddPaymentNoByUser(PaymentModel);
        }
        [HttpGet("GetPaymentById/{id}")]
        public PaymentData GetPaymentById(string id)
        {
            return _paymentRepository.GetPaymentById(id);
        }
        [HttpPost("UpdatePayment/{id}")]
        public int UpdatePayment([FromBody] PaymentData Editpay)
        {
            return _paymentRepository.UpdatePayment(Editpay);
        }


        [HttpDelete("DeletePayment/{id}")]
        public int DeletePayment(string id)
        {
            return _paymentRepository.DeletePayment(id);
        }

        [HttpGet("GetInvoiceNoByCustomerNo/{no}")]
        public List<InvoiceData> GetInvoiceNoByCustomerNo(string no)
        {
            return _paymentRepository.GetInvoiceNoByCustomerNo(no);
        }

        [HttpGet("GetInvoiceDetailsByNo/{no}")]
        public List<Invoice2Data> GetInvoiceDetailsByNo(string no)
        {
            return _paymentRepository.GetInvoiceDetailsByNo(no);
        }

        [HttpGet("GetCustNoByInvNo/{no}")]
        public List<CustomerData> GetCustNoByInvNo(string no)
        {
            return _paymentRepository.GetCustNoByInvNo(no);
        }

    }
}