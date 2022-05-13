using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using SFAeCommerce.Entitties;
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
                var attributes = await _dbContext.Attributes.Include("AttributeValues").ToListAsync();
                return Ok(attributes);
            }
            catch (Exception e)
            {
                return StatusCode(500, "Something went wrong");
            }
        }

        [HttpGet]
        [Route("search-attribute-values")]
        public async Task<IActionResult> searchAttributeValues([FromQuery]string attrCode, [FromQuery] string searchAttrValue)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(dbConnection))
                {
                    using (SqlCommand cmd = new SqlCommand("searchAttributeValues", con))
                    {

                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@ATTRCODE", attrCode);
                        cmd.Parameters.AddWithValue("@ATTRVALUE", searchAttrValue);

                        DataTable table = new DataTable("attributeValues");

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


        [HttpPost]
        [Route("attribute-value-entity")]
        public async Task<IActionResult> getAttributeValueEntities([FromBody]List<string> attrValuesCode, [FromQuery]string sortBy, [FromQuery]int scrolledTimes, [FromQuery]int itemsNumber)
        {
            try
            {
                DataTable attrValuesTable = new DataTable("attrValuesTable");
                DataColumn dtColumn;
                DataRow myDataRow;

                dtColumn = new DataColumn();
                dtColumn.DataType = typeof(string);
                dtColumn.ColumnName = "attr_value_code";
                dtColumn.Caption = "Attribute Value Code";
                dtColumn.AutoIncrement = false;
                dtColumn.ReadOnly = false;
                dtColumn.Unique = false;
                /// Add column to the DataColumnCollection.
                attrValuesTable.Columns.Add(dtColumn);

                foreach (var attr in attrValuesCode)
                {
                    myDataRow = attrValuesTable.NewRow();
                    myDataRow["attr_value_code"] = attr;
                    attrValuesTable.Rows.Add(myDataRow);
                }



                using (SqlConnection con = new SqlConnection(dbConnection))
                {
                    using (SqlCommand cmd = new SqlCommand("getItemsByAttributeValuePagination", con))
                    {

                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@SCROLLEDTIMES", scrolledTimes);
                        cmd.Parameters.AddWithValue("@ITEMSNUMBER", itemsNumber);
                        cmd.Parameters.AddWithValue("@ATRVALUESCODE", attrValuesTable);
                        cmd.Parameters.AddWithValue("@SORTBY", sortBy);

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
