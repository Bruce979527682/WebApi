using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Utility;

namespace WebApi.Controllers
{
    public class AccountController : Controller
    {        
        private bool ValidateLogin(string userName, string password)
        {
            // For this sample, all logins are successful.
            return true;
        }

        [AllowAnonymous]
        [HttpPost]
        public ActionResult OAuthLogin([FromBody] string userName, [FromBody] string password)
        {
            // Normally Identity handles sign in, but you can do it directly
            if (ValidateLogin(userName, password))
            {               
                var token = JwtHelper.CreateToken(123456);
                return Ok(new { code = 1, token });
            }
            return BadRequest(new { code = -1, msg = "获取Token失败！" });
        }

    }
}