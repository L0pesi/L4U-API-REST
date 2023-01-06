using L4U_BAL_SERVICES.Logic;
using L4U_BOL_MODEL.Models;
using L4U_BOL_MODEL.Response;
using Microsoft.AspNetCore.Mvc;
using System.Reflection;

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


        [HttpPost("ChooseLocker")]
        public async Task<IActionResult> ChooseLocker([FromBody] User user, [FromQuery] string lockerId)
        {
            string connectionString = _configuration.GetConnectionString("conectorDb");
            ResponseFunction response = await LockersLogic.ChooseLocker(connectionString, user.Id, lockerId);
            if (response.StatusCode != L4U_BOL_MODEL.Utilities.StatusCodes.SUCCESS)
            {
                return StatusCode((int)response.StatusCode);
            }
            return new JsonResult(response);
        }


        /* [HttpPost("AddNewLocker")]
         public async Task<IActionResult> AddNewLocker(Locker locker)
         {
             string cs = _configuration.GetConnectionString("conectorDb");
             ResponseFunction response = await LockersLogic.AddNewLocker(locker, cs);
             if (response.StatusCode != L4U_BOL_MODEL.Utilities.StatusCodes.SUCCESS)
             {
                 return StatusCode((int)response.StatusCode);
             }
             return new JsonResult(response);
         }
        */

    }
    }