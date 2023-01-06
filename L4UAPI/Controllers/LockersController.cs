using L4U_BAL_SERVICES.Logic;
using L4U_BOL_MODEL.Models;
using L4U_BOL_MODEL.Response;
using Microsoft.AspNetCore.Mvc;

namespace L4U_WebService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LockerController : ControllerBase
    {


        private readonly IConfiguration _configuration;

        public LockerController(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        [HttpPost("AddNewLocker")]
        public async Task<IActionResult> AddNewLocker(Locker locker)
        {
            //string connectString = "Server=l4u.database.windows.net;Database=L4U;User Id=supergrupoadmin;Password=supergrupo+2022";
            string cs = _configuration.GetConnectionString("conectorDb");
            ResponseFunction response = await LockersLogic.AddNewLocker(locker, cs);
            if (response.StatusCode != L4U_BOL_MODEL.Utilities.StatusCodes.SUCCESS)
            {
                return StatusCode((int)response.StatusCode);
            }
            return new JsonResult(response);
        }

        [HttpPut("OpenLocker")]
        public async Task<IActionResult> OpenLocker(Locker locker)
        {
            //string connectString = "Server=l4u.database.windows.net;Database=L4U;User Id=supergrupoadmin;Password=supergrupo+2022";
            string cs = _configuration.GetConnectionString("conectorDb");
            ResponseFunction response = await LockersLogic.OpenLocker(locker, cs);
            if (response.StatusCode != L4U_BOL_MODEL.Utilities.StatusCodes.SUCCESS)
            {
                return StatusCode((int)response.StatusCode);
            }
            return new JsonResult(response);
        }

        [HttpPut("CloseLocker")]
        public async Task<IActionResult> CloseLocker(Locker locker)
        {
            //string connectString = "Server=l4u.database.windows.net;Database=L4U;User Id=supergrupoadmin;Password=supergrupo+2022";
            string cs = _configuration.GetConnectionString("conectorDb");
            ResponseFunction response = await LockersLogic.OpenLocker(locker, cs);
            if (response.StatusCode != L4U_BOL_MODEL.Utilities.StatusCodes.SUCCESS)
            {
                return StatusCode((int)response.StatusCode);
            }
            return new JsonResult(response);
        }

        [HttpPut("UpdateLockerById")]
        public async Task<IActionResult> UpdateLocker(Locker locker)
        {
            //string connectString = "Server=l4u.database.windows.net;Database=L4U;User Id=supergrupoadmin;Password=supergrupo+2022";
            string cs = _configuration.GetConnectionString("conectorDb");
            ResponseFunction response = await LockersLogic.UpdateLocker(locker, cs);
            if (response.StatusCode != L4U_BOL_MODEL.Utilities.StatusCodes.SUCCESS)
            {
                return StatusCode((int)response.StatusCode);
            }
            return new JsonResult(response);
        }

        [HttpDelete("DeleteLocker")]
        public async Task<IActionResult> DeleteLocker(Locker locker)
        {
            //string connectString = "Server=l4u.database.windows.net;Database=L4U;User Id=supergrupoadmin;Password=supergrupo+2022";
            string cs = _configuration.GetConnectionString("conectorDb");
            ResponseFunction response = await LockersLogic.DeleteLocker(locker, cs);
            if (response.StatusCode != L4U_BOL_MODEL.Utilities.StatusCodes.SUCCESS)
            {
                return StatusCode((int)response.StatusCode);
            }
            return new JsonResult(response);
        }


        /// <summary>
        /// This controller method retrives all products
        /// </summary>
        /// <returns>List of products</returns>
        [HttpGet]
        [Route("GetAllLockers")]
        public async Task<ResponseFunction> GetAllLockers()
        {
            string cs = _configuration.GetConnectionString("conectorDb");
            return await LockersLogic.GetAllLockers(cs);
        }


        [HttpGet]
        [Route("GetAllLockersFromStore")]
        public async Task<ResponseFunction> GetAllLockersFromStore(string storeId)
        {
            string cs = _configuration.GetConnectionString("conectorDb");
            return await LockersLogic.GetAllLockersFromStore(cs, storeId);
        }
    }
}