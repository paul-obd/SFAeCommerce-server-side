using Microsoft.EntityFrameworkCore;
using SFAeCommerce.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SFAeCommerce.services
{
    public class CompanyInfo : ICompanyInfo
    {
        private readonly SFADB_ECOMMERCEContext _dbContext;

        public CompanyInfo(SFADB_ECOMMERCEContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<Models.CompanyInfo> getCompanyInfo()
        {
            var companyInfo = await _dbContext.CompanyInfos.FirstOrDefaultAsync();
            return companyInfo;
        }
    }
}
