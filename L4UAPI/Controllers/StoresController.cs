using L4U_BAL_SERVICES.Logic;
using L4U_BOL_MODEL.Models;
using L4U_BOL_MODEL.Response;
using L4U_DAL_DATA.Services;
using Microsoft.AspNetCore.Mvc;
using System.Data.SqlClient;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace L4U_WebService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StoresController : ControllerBase
    {

        private readonly IConfiguration _configuration;

        public StoresController(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        //[Authorize]
        [HttpPost("AddNewStore")]
        public async Task<IActionResult> AddNewStore(Store store)
        {
            //string connectString = "Server=l4u.database.windows.net;Database=L4U;User Id=supergrupoadmin;Password=supergrupo+2022";
            string cs = _configuration.GetConnectionString("conectorDb");
            ResponseFunction response = await StoresLogic.AddNewStore(store, cs);
            if (response.StatusCode != L4U_BOL_MODEL.Utilities.StatusCodes.SUCCESS)
            {
                return StatusCode((int)response.StatusCode);
            }
            return new JsonResult(response);
        }

        /*[HttpPut]
        public void Put([FromBody] Store store)
        {

            _storeLogic.UpdateStores(store);
        }*/

        /*
        [HttpDelete]
        public IActionResult Delete(Store store)
        {
            string conexao = "Server=l4u.database.windows.net;Database=L4U;User Id=supergrupoadmin;Password=supergrupo+2022;";

            using (SqlConnection connection = new SqlConnection(conexao))
            {
                connection.Open();

                List<Store> stores = new List<Store>();
                string deleteSql = "DELETE FROM stores WHERE id = @Id";
                SqlCommand deleteCommand = new SqlCommand(deleteSql, connection);
                deleteCommand.Parameters.AddWithValue("@Id", store.Id);

                int rowsAffected = deleteCommand.ExecuteNonQuery();

                if (rowsAffected > 0)
                {
                    return Ok("Successfully deleted the user with ID: " + store.Id);
                }
                else
                {
                    return NotFound("No user found with ID: " + store.Id);
                }
            }
        }*/

       /* [HttpDelete]
        public void Delete([FromBody] Store store)
        {
            _storeLogic.DeleteStore(store);
        }*/

        /*
        // PUT api/<StoresController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<StoresController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
        */
    }
}
