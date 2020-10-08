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

    public class InvoiceController : ControllerBase
    {
        private readonly IInvoiceRepository _invoiceRepository;
        public InvoiceController(IInvoiceRepository invoiceRepository)
        {
            _invoiceRepository = invoiceRepository;
        }


        [HttpGet("GetInvoices")]
        public List<InvoiceData> GetInvoices()
        {
            return _invoiceRepository.GetInvoices();
        }

        [HttpGet("ShowInvoiceNo")]
        public List<InvoiceData> ShowInvoiceNo()
        {
            return _invoiceRepository.ShowInvoiceNo();
        }

        [HttpPost("AddInvoice")]
        public int AddInvoice([FromBody] InvoiceData InvoiceModel, string InvoiceNo)
        {
            return _invoiceRepository.AddInvoice(InvoiceModel, InvoiceNo);
        }

        [HttpPost("AddInvoiceNoByUser")]
        public int AddInvoiceNoByUser([FromBody] InvoiceData InvoiceModel)
        {
            return _invoiceRepository.AddInvoiceNoByUser(InvoiceModel);
        }


        [HttpGet("GetInvoiceById/{id}")]
        public InvoiceData GetInvoiceById(string id)
        {
            return _invoiceRepository.GetInvoiceById(id);
        }
     
        [HttpPost("UpdateInvoice/{id}")]
        public int UpdateCustomer([FromBody] InvoiceData EditInv)
        {
            return _invoiceRepository.UpdateInvoice(EditInv);
        }


        [HttpDelete("DeleteInvoice/{id}")]
        public int DeleteInvoice(string id)
        {
            return _invoiceRepository.DeleteInvoice(id);
        }

        [HttpPost("ListPaymentDelete/{Inv_NO}")]
        public List<PaymentData> ListPaymentDelete(string Inv_NO)
        {
            return _invoiceRepository.ListPaymentDelete(Inv_NO) ;
        }

        [HttpPost("DeletePaymentByInvoiceNo/{id}")]
        public int DeletePaymentByInvoiceNo(string id)
        {
            return _invoiceRepository.DeletePaymentByInvoiceNo(id);
        }
        [HttpGet("ShowInvoiceNoByTable")]
        public List<InvoiceData> ShowInvoiceNoByTable()
        {
            return _invoiceRepository.ShowInvoiceNoByTable();
        }



    }
}