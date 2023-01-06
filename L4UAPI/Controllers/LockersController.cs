using L4U_BAL_SERVICES.Logic;
using L4U_BOL_MODEL.Models;
using L4U_BOL_MODEL.Response;
using L4U_WebService.Utilities;
using Microsoft.AspNetCore.Mvc;

namespace L4U_WebService.Controllers
{
    /// <summary>
    /// This is the controller class, responsible to receive and handle all Locker's request
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class LockerController : ControllerBase
    {

        private readonly IConfiguration _configuration;

        public LockerController(IConfiguration configuration)
        {
            _configuration = configuration;
        }



        /// <summary>
        /// This is the controller of AddNewLocker Method
        /// </summary>
        /// <param name="locker"></param>
        /// <returns></returns>
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



        /// <summary>
        /// This is the controller of the Method that gives information about the availability of the locker
        /// When it is open it's state is 0
        /// </summary>
        /// <param name="locker"></param>
        /// <returns></returns>
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



        ///// <summary>
        ///// This is the controller of the Method that gives information about the closure of the locker
        ///// When it is close it's state is 1 
        ///// </summary>
        ///// <param name="locker"></param>
        ///// <returns></returns>
        //[HttpPut("CloseLocker")]
        //public async Task<IActionResult> CloseLocker(Locker locker)
        //{
        //    string cs = _configuration.GetConnectionString("conectorDb");
        //    ResponseFunction response = await LockersLogic.OpenLocker(locker, cs);
        //    if (response.StatusCode != L4U_BOL_MODEL.Utilities.StatusCodes.SUCCESS)
        //    {
        //        return StatusCode((int)response.StatusCode);
        //    }
        //    return new JsonResult(response);
        //}



        ///// <summary>
        ///// This is the controller of UpdateLocker Method
        ///// </summary>
        ///// <param name="locker"></param>
        ///// <returns></returns>
        //[HttpPut("UpdateLockerById")]
        //public async Task<IActionResult> UpdateLocker(Locker locker)
        //{
        //    string cs = _configuration.GetConnectionString("conectorDb");
        //    ResponseFunction response = await LockersLogic.UpdateLocker(locker, cs);
        //    if (response.StatusCode != L4U_BOL_MODEL.Utilities.StatusCodes.SUCCESS)
        //    {
        //        return StatusCode((int)response.StatusCode);
        //    }
        //    return new JsonResult(response);
        //}



        /// <summary>
        /// This is the controller of DeleteLocker Method
        /// </summary>
        /// <param name="locker"></param>
        /// <returns></returns>
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
        /// This controller method retrives all Lockers
        /// </summary>
        /// <returns>List of Lockers</returns>
        [HttpGet]
        [Route("GetAllLockers")]
        public async Task<ResponseFunction> GetAllLockers()
        {
            string cs = _configuration.GetConnectionString("conectorDb");
            return await LockersLogic.GetAllLockers(cs);
        }


        //COMENTAR----------------------------------------------
        [HttpGet]
        [Route("GetAllLockersFromStore")]
        public async Task<ResponseFunction> GetAllLockersFromStore([FromBody] RequestStoreIdModel request)
        {
            string cs = _configuration.GetConnectionString("conectorDb");
            return await LockersLogic.GetAllLockersFromStore(cs, request.StoreId);
        }



        //COMENTAR----------------------------------------------
        [HttpPost("ChooseLocker/{lockerId}")]
        public async Task<IActionResult> ChooseLocker([FromBody] User user, [FromRoute] string lockerId)
        {
            string connectionString = _configuration.GetConnectionString("conectorDb");
            ResponseFunction response = await LockersLogic.ChooseLocker(connectionString, user.Id, user.Email, lockerId);
            if (response.StatusCode != L4U_BOL_MODEL.Utilities.StatusCodes.SUCCESS)
            {
                return StatusCode((int)response.StatusCode);
            }
            return new JsonResult(response);
        }


        #region Material de estudo - para implementar

        #endregion



    }
}