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
    public class ItemsController : ControllerBase
    {
        private readonly SFADB_ECOMMERCEContext _dbContext;
        private readonly string dbConnection;

        public ItemsController(SFADB_ECOMMERCEContext dbContext, IConfiguration configuration)
        {
            _dbContext = dbContext;
            dbConnection = configuration.GetConnectionString("SFADB_ECOMMERCE");
        }

        [HttpGet]
        [Route("all-items")]
        public async Task<IActionResult> getAllItems([FromQuery]int scrolledTimes, [FromQuery]int itemsNumber)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(dbConnection))
                {
                    using (SqlCommand cmd = new SqlCommand("getItemsWithDetailsAndPagination", con))
                    {

                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@SCROLLEDTIMES", scrolledTimes);
                        cmd.Parameters.AddWithValue("@ITEMSNUMBER", itemsNumber);

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
                return StatusCode(500, $"Something Went Wrong{e.Message}");
            }
        }

        [HttpGet]
        [Route("search/{searchVar}")]
        public async Task<IActionResult> SearchAnItemWithPagination([FromRoute]string searchVar, [FromQuery] int scrolledTimes, [FromQuery] int itemsNumber)
        {
            try
            {
                //searchItemsWithPagination
                using (SqlConnection con = new SqlConnection(dbConnection))
                {
                    using (SqlCommand cmd = new SqlCommand("searchItemsWithPagination", con))
                    {

                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@SCROLLEDTIMES", scrolledTimes);
                        cmd.Parameters.AddWithValue("@ITEMSNUMBER", itemsNumber);
                        cmd.Parameters.AddWithValue("@SEARCHVAR", searchVar);

                        DataTable table = new DataTable("items");
                        SqlDataAdapter spResult = new SqlDataAdapter(cmd);

                        spResult.Fill(table);

                        con.Open();

                        await cmd.ExecuteNonQueryAsync();

                        return Ok(table);
                    }
                }
            }
            catch (Exception  e)
            {

                return StatusCode(500, $"Something Went Wrong{e.Message}");
            }
        }


        [HttpGet]
        [Route("item/{itemCode}")]
        public async Task<IActionResult> getItemByCode([FromRoute]string itemCode)
        {
            try
            {
                
                using (SqlConnection con = new SqlConnection(dbConnection))
                {
                    using (SqlCommand cmd = new SqlCommand("getItemByCode", con))
                    {

                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@ITEMCODE", itemCode);


                        DataTable table = new DataTable("item");
                        
                        SqlDataAdapter spResult = new SqlDataAdapter(cmd);

                        spResult.Fill(table);

                        con.Open();

                        await cmd.ExecuteNonQueryAsync();

                        if (table.Rows.Count == 0)
                        {
                            return NotFound();
                        }


                        var itemRow = table.Rows[0];

                        ItemDto item = new ItemDto() {
                            Item_code = itemRow["item_code"].ToString(),
                            Description = itemRow["description"].ToString(),
                            Price = (decimal)itemRow["price"],
                            Quantity = (decimal)itemRow["quantity"],
                            Base_path = itemRow["base_path"].ToString(),
                            Folder_path = itemRow["folder_path"].ToString(),
                            Physical_file_name = itemRow["physical_file_name"].ToString()

                        };



                        return Ok(item);
                    }
                }
            }
            catch (Exception e)
            {

                return StatusCode(500, $"Something Went Wrong{e.Message}");
            }


        }


        [HttpGet]
        [Route("items-by-attribute-and-attribute-value/{attributeCode}/{attributeValueCode}")]
        public async Task<IActionResult> getItemsByAttributeAndAttributeValuePag([FromRoute] string attributeValueCode, [FromRoute] string attributeCode, [FromQuery] int scrolledTimes, [FromQuery] int itemsNumber)
        {
            try
            {


                using (SqlConnection con = new SqlConnection(dbConnection))
                {
                    using (SqlCommand cmd = new SqlCommand("getItemsByAttributeCodeAndAttributeValueCode", con))
                    {

                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@SCROLLEDTIMES", scrolledTimes);
                        cmd.Parameters.AddWithValue("@ITEMSNUMBER", itemsNumber);
                        cmd.Parameters.AddWithValue("@ATRCODE", attributeCode);
                        cmd.Parameters.AddWithValue("@ATRVALUECODE", attributeValueCode);

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

                return StatusCode(500, $"Something Went Wrong{e.Message}");
            }
        }

        [HttpGet]
        [Route("items-by-attribute/{attrCode}")]
        public async Task<IActionResult> getItemByAttributeCode([FromRoute] string attrCode, [FromQuery] int scrolledTimes, [FromQuery] int itemsNumber)
        {
            try
            {


                using (SqlConnection con = new SqlConnection(dbConnection))
                {
                    using (SqlCommand cmd = new SqlCommand("getItemsByAttribute", con))
                    {

                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@SCROLLEDTIMES", scrolledTimes);
                        cmd.Parameters.AddWithValue("@ITEMSNUMBER", itemsNumber);
                        cmd.Parameters.AddWithValue("@ATRCODE", attrCode);

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

                return StatusCode(500, "Something went wrong");
            }
        }

    }
}
