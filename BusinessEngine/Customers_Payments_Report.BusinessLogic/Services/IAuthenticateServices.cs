using Customers_Payments_Report.ModelData.Models.common;
using System;
using System.Collections.Generic;
using System.Text;

namespace Customers_Payments_Report.BusinessLogic.Services
{
    public interface IAuthenticateServices
    {
        AdminData Authenticate(AdminData Model);
        int AddAdmin(AdminData AdminModel);
        List<AdminData> GetAdmins();
    }
}
