using BLL.Api;
using Data.Api;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using Utility;

namespace WebApi.Controllers
{
    public class AccountController : Controller
    {
        public ApiContext _context;
        public AccountController(ApiContext context)
        {
            _context = context;
        }

        private bool ValidateLogin(string userName = "", string password = "")
        {
            var accounts = _context.Accounts.Where(x => x.UserName.Equals(userName));
            if (accounts != null && accounts.Count() > 0)
            {
                foreach (var item in accounts)
                {
                    if (item.Password.Equals(password))
                    {
                        return true;
                    }
                }
            }
            return false;
        }

        [AllowAnonymous]
        [HttpPost]
        public ActionResult OAuthLogin([FromQuery] string userName = "", [FromQuery] string password = "")
        {            
            // Normally Identity handles sign in, but you can do it directly
            if (ValidateLogin(userName, password))
            {               
                var token = JwtHelper.CreateToken(123456);
                return Ok(new { code = 1, type = "Bearer", token });//Authorization = type + ' ' + token;
            }
            return BadRequest(new { code = -1, msg = "获取Token失败！" });
        }

    }
}