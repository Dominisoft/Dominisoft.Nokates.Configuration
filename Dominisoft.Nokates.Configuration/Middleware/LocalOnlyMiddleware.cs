using System;
using System.Threading.Tasks;
using Dominisoft.Nokates.Common.Infrastructure.CustomExceptions;
using Dominisoft.Nokates.Configuration.Extensions;
using Microsoft.AspNetCore.Http;

namespace Dominisoft.Nokates.Configuration.Middleware
{
    public class LocalOnlyMiddleware
    {
        private readonly RequestDelegate _next;

        public LocalOnlyMiddleware(RequestDelegate next)
        {
            _next = next;
        }


        public async Task Invoke(HttpContext context)
        {

            if (!context.Request.IsLocal())
            {
                // Forbidden http status code
                context.Response.StatusCode = 403;
                return;
            }

            await _next(context);

        }
    }
}
