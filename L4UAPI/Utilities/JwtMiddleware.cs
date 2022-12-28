using L4U_BOL_MODEL.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Text;

namespace L4U_WebService.Utilities
{
    public class JwtMiddleware
    {

        private readonly RequestDelegate _next;
        //private readonly RequestDelegate _previous;
        //private readonly ILogger _logger;
        private readonly AppSettings _appSettings;

        public JwtMiddleware(RequestDelegate next, IOptions<AppSettings> appSettings)
        {
            _next = next;
            _appSettings = appSettings.Value;
        }

        public async Task Invoke(HttpContext context, User user)
        {
            var token = context.Request.Headers["Authorization"].FirstOrDefault()?.Split(" ").Last();

            if (token != null)
                attachUserToContext(context, user, token);

            await _next(context);
        }

        private void attachUserToContext(HttpContext context, User user, string token)
        {
            try
            {
                var tokenHandler = new JwtSecurityTokenHandler();
                var key = Encoding.ASCII.GetBytes(_appSettings.SecretCode);
                tokenHandler.ValidateToken(token, new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(key),
                    ValidateIssuer = false,
                    ValidateAudience = false,
                    //set clockskew to zero so tokens expire exactly at token expiration time (instead of 5min later)
                    ClockSkew = TimeSpan.Zero

                }, out SecurityToken validatedToken);

                var jwtToken = (JwtSecurityToken)validatedToken;
                var userId = jwtToken.Claims.First(x => x.Type.Equals("id")).Value.ToString();

                // attach user to context on successful jwt validation
                context.Items["User"] = user;

            }
            catch
            {

                // se validação jwt falhar, não faz nada
                // user is not attached to context so request won't have access to secure routes

            }
        }



    }
}
