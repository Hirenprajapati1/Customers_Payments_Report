using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Customers_Payments_Report.ModelData.Models.common;
//using Customers_Payments_Report.Models.Entity;
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

    public class InvoiceController : ControllerBase
    {
        private readonly IInvoiceServices _invoiceServices;
        public InvoiceController(IInvoiceServices invoiceRepository)
        {
            _invoiceServices = invoiceRepository;
        }

        [HttpGet("GetInvoices")]
        public List<InvoiceData> GetInvoices()
        {
            return _invoiceServices.GetInvoices();
        }

        [HttpGet("ShowInvoiceNo")]
        public List<InvoiceData> ShowInvoiceNo()
        {
            return _invoiceServices.ShowInvoiceNo();
        }


        [HttpPost("AddInvoice")]
        public int AddInvoice([FromBody] InvoiceData InvoiceModel, string InvoiceNo)
        {
            return _invoiceServices.AddInvoice(InvoiceModel, InvoiceNo);
        }

        [HttpPost("AddInvoiceNoByUser")]
        public int AddInvoiceNoByUser([FromBody] InvoiceData InvoiceModel)
        {
            return _invoiceServices.AddInvoiceNoByUser(InvoiceModel);
        }

        [Authorize(Roles = "Admin")]
        [HttpGet("GetInvoiceById/{id}")]
        public InvoiceData GetInvoiceById(string id)
        {
            return _invoiceServices.GetInvoiceById(id);
        }

        [Authorize(Roles = "Admin")]
        [HttpPost("UpdateInvoice/{id}")]
        public int UpdateCustomer([FromBody] InvoiceData EditInv)
        {
            return _invoiceServices.UpdateInvoice(EditInv);
        }

        [Authorize(Roles = "Admin")]
        [HttpDelete("DeleteInvoice/{id}")]
        public int DeleteInvoice(string id)
        {
            return _invoiceServices.DeleteInvoice(id);
        }

        [Authorize(Roles = "Admin")]
        [HttpPost("ListPaymentDelete/{Inv_NO}")]
        public List<PaymentData> ListPaymentDelete(string Inv_NO)
        {
            return _invoiceServices.ListPaymentDelete(Inv_NO) ;
        }

        [Authorize(Roles = "Admin")]
        [HttpPost("DeletePaymentByInvoiceNo/{id}")]
        public int DeletePaymentByInvoiceNo(string id)
        {
            return _invoiceServices.DeletePaymentByInvoiceNo(id);
        }
        [HttpGet("ShowInvoiceNoByTable")]
        public List<InvoiceData> ShowInvoiceNoByTable()
        {
            return _invoiceServices.ShowInvoiceNoByTable();
        }



    }
}