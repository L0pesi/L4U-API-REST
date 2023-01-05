using L4U_BAL_SERVICES.Logic;
using L4U_BOL_MODEL.Response;
using L4U_BOL_MODEL.Models;
using L4U_BOL_MODEL.Utilities;
using L4U_WebService.Utilities;
using L4U_DAL_DATA.Utilities;

using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.AspNetCore.Authorization;

namespace L4U_WebService.Controllers
{
    /// <summary>
    /// This is the controller class, responsible to receive and handle all Users's request
    /// </summary>
    [ApiController]
    [Route("api/[controller]")]
    public class UsersController : ControllerBase
    {

        private readonly IConfiguration _configuration;

        public UsersController(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        //[Authorize]
        [HttpPost("AddNewUser")]
        public async Task<IActionResult> AddNewUser(User user)
        {
            string cs = _configuration.GetConnectionString("conectorDb");
            ResponseFunction response = await UsersLogic.AddNewUser(user, cs);
            if (response.StatusCode != L4U_BOL_MODEL.Utilities.StatusCodes.SUCCESS)
            {
                return StatusCode((int)response.StatusCode);
            }
            return new JsonResult(response);
        }

        [HttpPost("authenticate")]
        public async Task<IActionResult> AuthenticateMe(UserAuth user)
        {
            string cs = _configuration.GetConnectionString("conectorDb");
            ResponseFunction response = await UsersLogic.AuthenticateUser(user, cs);
            if (response.StatusCode != L4U_BOL_MODEL.Utilities.StatusCodes.SUCCESS)
            {
                return StatusCode((int)response.StatusCode);
            }
            return new JsonResult(response);
        }

        [HttpDelete("DeleteUser")]
        public async Task<IActionResult> DeleteUser(User user)
        {
            //string connectString = "Server=l4u.database.windows.net;Database=L4U;User Id=supergrupoadmin;Password=supergrupo+2022";
            string cs = _configuration.GetConnectionString("conectorDb");
            ResponseFunction response = await UsersLogic.DeleteUser(user, cs);
            if (response.StatusCode != L4U_BOL_MODEL.Utilities.StatusCodes.SUCCESS)
            {
                return StatusCode((int)response.StatusCode);
            }
            return new JsonResult(response);
        }


        [HttpPut("UpdateUser")]
        public async Task<IActionResult> UpdateUser(User user)
        {
            //string connectString = "Server=l4u.database.windows.net;Database=L4U;User Id=supergrupoadmin;Password=supergrupo+2022";
            string cs = _configuration.GetConnectionString("conectorDb");
            ResponseFunction response = await UsersLogic.UpdateUser(user, cs);
            if (response.StatusCode != L4U_BOL_MODEL.Utilities.StatusCodes.SUCCESS)
            {
                return StatusCode((int)response.StatusCode);
            }
            return new JsonResult(response);
        }

        [HttpGet]
        [Route("GetAllUsers")]
        public async Task<ResponseFunction> GetAllUsers()
        {
            string cs = _configuration.GetConnectionString("conectorDb");
            return await UsersLogic.GetAllUsers(cs);
        }

        //inativar user => definir o bit isActive = 0

        //Login => WHERE isActive = 1

        /*
        // POST
        // ADICIONAR NOVO UTILIZADOR
        // api/<UsersController>
        [HttpPost]
        public void Post([FromBody] User user)
        {

            _usersLogic.AddNewUser(user);

        }
        /*


        // GET
        // LISTAR TODOS UTILIZADORES
        // api/<UsersController>
        [HttpGet]
        public IEnumerable<User> Get()
        {
            return _usersLogic.GetUsers;
        }

        [HttpPut]
        public void Putt([FromBody] User user)
        {

            _usersLogic.UpdateUser(user);

        }


        #region Versão com erros - Stored Procedures

        /*
          
        
        /// <summary>
        /// Application path
        /// </summary>
        private string appPath;

        /// <summary>
        /// App settings class
        /// </summary>
        private readonly AppSettings appSettings;

        /// <summary>
        /// Constructor
        /// Implementação do webHostEnvironment (com as duas declarações anteriores)
        /// </summary>
        /// <param name="webHostEnvironment">Dependecy injection of IWebHostEnvironment interface</param>
        public UsersController(IWebHostEnvironment webHostEnvironment, IOptions<AppSettings> _appSettings)
        {
            this.appPath = webHostEnvironment.ContentRootPath;
            this.appSettings = _appSettings.Value;
        }
        
          
          
         
        [HttpPost]
        [Route("create")]
        public async Task<ResponseFunction> AddNewUser([FromBody] User request)
        {

            if (!ModelState.IsValid)
                return StandardResponse.InvalidRequestResponse();
            return await UsersLogic.AddNewUser(request, appPath);

        }

        [HttpDelete]
        [Route("delete")]
        public async Task<ResponseFunction> DeleteUser([FromBody] RequestModel request)
        {
            if (!ModelState.IsValid)
                return StandardResponse.InvalidRequestResponse();
            return await UsersLogic.DeleteUser(request.Uid, appPath);
        }

        
        [HttpPost]
        [Route("login")]
        public async Task<Response> Login([FromBody] UserRequestMin request)
        {
            if (!ModelState.IsValid)
                return StandardResponse.InvalidRequestResponse();

            Response AuthUser = await UsersLogic.LoginUser(request, appPath);

            //adds token jwt
            User temp = (User)AuthUser.Data;
            temp.Token = GenerateJwtToken(temp);

            AuthUser.Data = temp;

            return AuthUser;
        }

        
        #endregion
        */


        #region Generate Token - Mais tarde

        /*

        /// <summary>
        /// This method generates the token
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        private string GenerateJwtToken(User user)
        {
            // generate token that is valid for 7 days
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(appSettings.SecretCode);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new[] { new Claim("id", user.Id.ToString()) }),
                Expires = DateTime.UtcNow.AddDays(7),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }


        */
        #endregion



    }
}