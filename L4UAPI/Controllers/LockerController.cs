using L4U_WebService.Utilities;
using L4U_BOL_MODEL.Response;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;

namespace L4U_WebService.Controllers
{

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



    }


}
