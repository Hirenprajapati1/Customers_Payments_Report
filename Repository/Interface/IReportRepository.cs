﻿using Customers_Payments_Report.Models.common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Customers_Payments_Report.Repository.Interface
{
    public interface IReportRepository
    {
        public List<ReportData> GetReport();
        public List<ReportData1> GetReport1();



    }
}
