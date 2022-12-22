using L4U_BAL_SERVICES.Logic;
using L4U_BOL_MODEL.Models;
using L4U_BOL_MODEL.Response;
using L4U_BOL_MODEL.Utilities;
using Microsoft.AspNetCore.Mvc;

namespace L4U_WebService.Controllers
{

    /// <summary>
    /// Classe controller base
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {

        /// <summary>
        /// Application path? 
        /// </summary>
        private string appPath;

        /// <summary>
        /// App setting class? 
        /// </summary>

        /// <summary>
        /// Implementação do webHostEnvironment (com as duas declarações anteriores) 
        /// </summary>


        [HttpPost]
        [Route("create")]
        public async Task<ResponseFunction> AddNewUser([FromBody] User request)
        {
            if (!ModelState.IsValid)
                return StandardResponse.InvalidRequestResponse();
            return await UsersLogic.AddNewUser(request, appPath);
        }



    }
}
