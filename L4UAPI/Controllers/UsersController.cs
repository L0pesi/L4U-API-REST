using L4U_BAL_SERVICES.Logic;
using L4U_BOL_MODEL.Response;
using L4U_BOL_MODEL.Models;
using L4U_BOL_MODEL.Utilities;
using L4U_WebService.Utilities;

using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace L4U_WebService.Controllers
{
    /// <summary>
    /// This is the controller class, responsible to receive and handle all Users's request
    /// </summary>
    [ApiController]
    [Route("api/[controller]")]
    public class UsersController : ControllerBase
    {

        private readonly UsersLogic _usersLogic;

        public UsersController()
        {
            _usersLogic = new UsersLogic();
        }


        // POST
        // ADICIONAR NOVO UTILIZADOR
        // api/<UsersController>
        [HttpPost]
        public void Post([FromBody] User user)
        {

            _usersLogic.AddNewUser(user);

        }


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

        */
        #endregion



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