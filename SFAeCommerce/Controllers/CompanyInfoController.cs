using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SFAeCommerce.services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SFAeCommerce.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CompanyInfoController : ControllerBase
    {
        private readonly ICompanyInfo _companyInfo;

        public CompanyInfoController(ICompanyInfo companyInfo)
        {
            _companyInfo = companyInfo;
        }

        [HttpGet]
        [Route("company-info")]
        public async Task<IActionResult> getCompanyInfo()
        {
            try
            {
                var companyInfo = await _companyInfo.getCompanyInfo();
                return Ok(companyInfo);

            }
            catch (Exception e)
            {

                return StatusCode(500, $"Internal Server error {e.Message}");
            }
        }

    }
}
