using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Customers_Payments_Report.ModelData.Models.common
{
    public class CustomerData
    {
     //   public int Customerid { get; set; }
        public string CustomerNo { get; set; }
        public string CustomerName { get; set; }
        public string CreatedBy { get; set; }
        public DateTime? CreatedDate { get; set; }
        public string ModifyBy { get; set; }
        public DateTime? ModifyDate { get; set; }
    }
}
