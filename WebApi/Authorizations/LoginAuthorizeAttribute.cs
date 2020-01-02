using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using System.Linq;

namespace WebApi.Authorizations
{
    internal class LoginAuthorizeAttribute : AuthorizeAttribute
    {
        public LoginAuthorizeAttribute()
        {
            
        }

       
    }
}
