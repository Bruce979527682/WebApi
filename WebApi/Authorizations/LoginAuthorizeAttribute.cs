using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using System.Linq;
using Utility;

namespace WebApi.Authorizations
{
    internal class LoginAuthorizeAttribute : AuthorizeAttribute
    {

        public LoginAuthorizeAttribute()
        {
            //var key = HttpContextHelper.HttpContext.Request.Cookies.TryGetValue(ConfigHelper.GetValue("CookieName"), out string value);

        } 
        
    }
}
