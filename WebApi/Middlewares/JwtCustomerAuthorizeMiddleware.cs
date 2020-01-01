using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Options;
using Microsoft.Extensions.Primitives;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApi.Middlewares
{
    public class JwtCustomerAuthorizeMiddleware
    {
        private readonly RequestDelegate _next;

        public JwtCustomerAuthorizeMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            var keyValue = context.Request.Query["key"];

            if (!string.IsNullOrWhiteSpace(keyValue))
            {
                context.Response.Cookies.Append("AuthorizeToken", JwtHelper.CreateTokenByHandler());
            }

            await _next(context);
        }
    }
}
