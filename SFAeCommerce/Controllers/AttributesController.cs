using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using SFAeCommerce.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace SFAeCommerce.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AttributesController : ControllerBase
    {
        private readonly SFADB_ECOMMERCEContext _dbContext;
        private readonly string dbConnection;

        public AttributesController(SFADB_ECOMMERCEContext dbContext, IConfiguration configuration)
        {
            _dbContext = dbContext;
            dbConnection = configuration.GetConnectionString("SFADB_ECOMMERCE");
        }

        [HttpGet]
        [Route("attributes")]
        public async Task<IActionResult> getAttributes()
        {
            try
            {
                var attributes = await _dbContext.Attributes.ToListAsync();
                return Ok(attributes);
            }
            catch (Exception e)
            {
                return StatusCode(500, "Something went wrong");
            }
        }


       
        

        [HttpGet]
        [Route("attribute-values/{attributeCode}")]
        public async Task<IActionResult> getAttributeValues([FromRoute]string attributeCode)
        {
            try
            {
             
                var attribueValues = await _dbContext.AttributeValues.Where(a=> a.AttributeCode == attributeCode).ToListAsync();
                return Ok(attribueValues);

            }
            catch (Exception e)
            {

                return StatusCode(500, "Something went wrong");
            }
        }

        [HttpGet]
        [Route("attribute-values")]
        public async Task<IActionResult> getAttrValues()
        {
            try
            {
                var attribueValues = await _dbContext.AttributeValues.ToListAsync();
                return Ok(attribueValues);
            }
            catch (Exception e)
            {

                return StatusCode(500, "Something went wrong");

            }
        }


        [HttpGet]
        [Route("attribute-value-entity/{attrValueCode}")]
        public async Task<IActionResult> getAttributeValueEntities([FromRoute]string attrValueCode, [FromQuery]int scrolledTimes, [FromQuery]int itemsNumber)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(dbConnection))
                {
                    using (SqlCommand cmd = new SqlCommand("getItemsByAttributeValuePagination", con))
                    {

                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@SCROLLEDTIMES", scrolledTimes);
                        cmd.Parameters.AddWithValue("@ITEMSNUMBER", itemsNumber);
                        cmd.Parameters.AddWithValue("@ATRVALUECODE", attrValueCode);

                        DataTable table = new DataTable("items");
                        SqlDataAdapter spResult = new SqlDataAdapter(cmd);

                        spResult.Fill(table);

                        con.Open();

                        await cmd.ExecuteNonQueryAsync();

                        return Ok(table);
                    }
                }
            }
            catch (Exception e)
            {

                return StatusCode(500, $"Something went wrong{e.Message}");
            }
        }
    }
}
