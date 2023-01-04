using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using L4U_BAL_SERVICES.Logic;
using L4U_BOL_MODEL.Models;
using L4U_BOL_MODEL.Response;
using Microsoft.Extensions.Configuration;

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




        /*
        /// <summary>
        /// This is the Locker controller class, responsible to receive and handle all Locker's request
        /// </summary>
        [ApiController]
        [Route("api/[controller]")]
        public class LockerController : ControllerBase
        {

            /// <summary>
            /// Application path 
            /// </summary>
            private string appPath;



            /// <summary>
            /// Constructor
            /// Implementação do webHostEnvironment (com as duas declarações anteriores)
            /// </summary>
            /// <param name="webHostEnvironment">Dependecy injection of IWebHostEnvironment interface</param>
            public LockerController(IWebHostEnvironment webHostEnvironment)
            {
                this.appPath = webHostEnvironment.ContentRootPath;
            }



            /// <summary>
            /// This controller method retrives all lockers
            /// </summary>
            /// <returns>List dos lockers</returns>
            [HttpGet]
            [Route("getall")]
            public async Task<ResponseFunction> GetLockers()
            {
                return await LockersLogic.GetAllLockers(appPath);
            }
            */

    }
    }