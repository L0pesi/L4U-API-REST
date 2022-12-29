using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using L4U_BAL_SERVICES.Logic;
using L4U_BOL_MODEL.Models;

namespace L4U_WebService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LockerController : ControllerBase
    {
        private readonly LockersLogic _lockersLogic;

        public LockerController()
        {
            _lockersLogic = new LockersLogic();
        }


        //GET :api/LockerController
        [HttpGet]
        public IEnumerable<Locker> Get()
        {
            return _lockersLogic.GetLockers;
        }

        // GET api/<UsersController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        [HttpPost]
        public void Post([FromBody] Locker locker)
        {

            _lockersLogic.AddLocker(locker);
        }

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