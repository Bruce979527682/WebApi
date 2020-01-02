using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Utility;
using WebApi.Authorizations;

namespace WebApi.Controllers
{    
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        // GET api/values 
        [Authorize]
        [HttpGet]
        public ActionResult<IEnumerable<string>> Get()
        {
            var auth = HttpContext.Request;
            var token = JwtHelper.CreateToken(123456);
            HttpContext.Response.Cookies.Append(ConfigHelper.GetValue("CookieName"), token, new CookieOptions() { IsEssential = true });
            return new string[] { "value1", "value2" };
        }
        
    }
}
