using Customers_Payments_Report.ModelData.Models.common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Customers_Payments_Report.DataLogic.Repository.Interface
{
    public interface IAuthenticateRepository
    {
        AdminData Authenticate(AdminData Model);
        int AddAdmin(AdminData AdminModel);
        List<AdminData> GetAdmins();
    
    }
}
