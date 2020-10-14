using System;
using System.Collections.Generic;

namespace Customers_Payments_Report.Models.Entity
{
    public partial class Admin
    {
        public string Name { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Gender { get; set; }
        public string Region { get; set; }
        public string Email { get; set; }
        public string ContactNo { get; set; }
        public string Password { get; set; }
        public DateTime? CreatedDate { get; set; }
        public DateTime? ModifyDate { get; set; }
    }
}
