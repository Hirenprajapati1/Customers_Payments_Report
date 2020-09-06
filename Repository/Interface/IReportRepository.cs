using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Customers_Payments_Report.Repository.Interface
{
    public interface IReportRepository
    {
        public List<Models.common.ReportData> GetReport();

    }
}
