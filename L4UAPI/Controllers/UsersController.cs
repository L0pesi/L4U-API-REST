using L4U_BAL_SERVICES.Logic;
using L4U_BOL_MODEL.Models;
using L4U_BOL_MODEL.Response;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text.Json.Serialization;
using static L4U_WebService.Controllers.UsersController;
using JsonIgnoreAttribute = Newtonsoft.Json.JsonIgnoreAttribute;

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