using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Customers_Payments_Report.Models.common
{
    public class ChartData
    {
        [DisplayFormat(DataFormatString = "{0:MM/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime? MonthYear { get; set; }
        public int Month { get; set; }
        public int Year { get; set; }
        public Decimal Sales { get; set; }
        public Decimal Payment { get; set; }
    }
}
