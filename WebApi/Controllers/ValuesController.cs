using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BLL.Api;
using Data.Api;
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
            var request = HttpContext.Request;            
            return new string[] { "value1", "value2" };
        }
        
    }
}
