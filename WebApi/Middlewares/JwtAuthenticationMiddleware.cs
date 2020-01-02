using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Utility;

namespace WebApi.Middlewares
{
    public class JwtAuthenticationMiddleware
    {
        private readonly RequestDelegate _next;

        public JwtAuthenticationMiddleware(RequestDelegate next) =>  _next = next;
                
        public async Task Invoke(HttpContext context)
        {
            var keyValue = context.Request.Cookies[ConfigHelper.GetValue("CookieName")] ?? "";
            if (string.IsNullOrWhiteSpace(keyValue) || !JwtHelper.Validate(keyValue))
            {
                throw new UnauthorizedAccessException("未授权");                
            }
            await _next.Invoke(context);
        }
    }
}
