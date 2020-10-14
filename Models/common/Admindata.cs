using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Customers_Payments_Report.Models.common
{
    public class AdminData
    {
        public string username { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Gender { get; set; }
        public string Region { get; set; }
        public string Email { get; set; }
        public string ContactNo { get; set; }
        public string Password { get; set; }
        public DateTime? CreatedDate { get; set; }
        public DateTime? ModifyDate { get; set; }
        public int UserId { get; set; }
        public string Token { get; set; }
    }
}
