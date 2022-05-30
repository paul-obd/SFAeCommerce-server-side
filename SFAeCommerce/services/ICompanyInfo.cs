using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SFAeCommerce.Models;

namespace SFAeCommerce.services
{
    public interface ICompanyInfo
    {

        Task<Models.CompanyInfo> getCompanyInfo();
    }
}
