using L4U_BAL_SERVICES.Logic;
using L4U_BOL_MODEL.Models;
using L4U_BOL_MODEL.Response;
using L4U_BOL_MODEL.Utilities;
using Microsoft.AspNetCore.Mvc;


namespace L4U_WebService.Controllers
{
    /// <summary>
    /// This is the controller class, responsible to receive and handle all Store's request
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class StoresController : ControllerBase
    {   

        private readonly IConfiguration _configuration;

        public StoresController(IConfiguration configuration)
        {
            _configuration = configuration;
        }



        /// <summary>
        /// This is the controller of AddNewStore Method
        /// </summary>
        /// <param name="store"></param>
        /// <returns></returns>
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



        /// <summary>
        /// This is the controller of DeleteStore Method by its Id
        /// </summary>
        /// <param name="store"></param>
        /// <returns></returns>
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



        /// <summary>
        /// This is the controller of GetAllStores Method
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("GetAllStores")]
        public async Task<ResponseFunction> GetAllStores()
        {
            string cs = _configuration.GetConnectionString("conectorDb");
            return await StoresLogic.GetAllStores(cs);
        }




        #region Material de estudo - para implementar

        #endregion


    }
}
