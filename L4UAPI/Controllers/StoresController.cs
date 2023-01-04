using L4U_BAL_SERVICES.Logic;
using L4U_BOL_MODEL.Models;
using L4U_BOL_MODEL.Response;
using L4U_BOL_MODEL.Utilities;
using Microsoft.AspNetCore.Mvc;

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

        [HttpPost("AddNewStore")]
        public async Task<IActionResult> AddNewStore(Store store)
        {
            string cs = _configuration.GetConnectionString("conectorDb");
            ResponseFunction response = await StoresLogic.AddNewStore(store, cs);
            if (response.StatusCode != L4U_BOL_MODEL.Utilities.StatusCodes.SUCCESS)
            {
                return StatusCode((int)response.StatusCode);
            }
            return new JsonResult(response);
        }

        /// <summary>
        /// This controller method updates a given product store object
        /// </summary>
        /// <param name="request">Product store object</param>
        /// <returns>Response</returns>
        [HttpPut]
        [Route("UpdateStoreById")]
        public async Task<ResponseFunction> UpdateStore(Store request)
        {
            string cs = _configuration.GetConnectionString("conectorDb");
            ResponseFunction response = await StoresLogic.UpdateStore(request, cs);
            if (!ModelState.IsValid)
                return StandardResponse.InvalidRequestResponse();
            return await StoresLogic.UpdateStore(request, cs);
        }

        [HttpDelete("DeleteStoreById")]
        public async Task<IActionResult> DeleteLocker(Store store)
        {
            string cs = _configuration.GetConnectionString("conectorDb");
            ResponseFunction response = await StoresLogic.DeleteStore(store, cs);
            if (response.StatusCode != L4U_BOL_MODEL.Utilities.StatusCodes.SUCCESS)
            {
                return StatusCode((int)response.StatusCode);
            }
            return new JsonResult(response);
        }

        [HttpGet]
        [Route("GetAllUsers")]
        public async Task<ResponseFunction> GetAllStores()
        {
            string cs = _configuration.GetConnectionString("conectorDb");
            return await StoresLogic.GetAllStores(cs);
        }

    }
}
