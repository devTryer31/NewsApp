using Microsoft.AspNetCore.Builder;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace News.WebAPI.MiddleWare
{
    public static class CustomExceptionsHandlerMiddlewareExtension
    {
        public static IApplicationBuilder UseCustomExceptionHandler(this IApplicationBuilder builder) 
            => builder.UseMiddleware<CustomExceptionsApiHandler>();
    }
}
