using L4U_BOL_MODEL.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System;

namespace ISI_WebService.Helpers
{
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method)]
    public class AuthorizeAttribute : Attribute, IAuthorizationFilter
    {
        public void OnAuthorization(AuthorizationFilterContext context)
        {
            User user = (User)context.HttpContext.Items["User"];

            if (user == null)
                context.Result = new JsonResult(new { message = "Não autorizado" }) { StatusCode = StatusCodes.Status401Unauthorized };
        }
    }
}