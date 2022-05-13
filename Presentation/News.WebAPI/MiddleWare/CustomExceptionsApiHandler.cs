using Microsoft.AspNetCore.Http;
using News.Application.Common.Exceptions;
using System;
using System.Net;
using System.Text.Json;
using System.Threading.Tasks;

namespace News.WebAPI.MiddleWare
{
    public class CustomExceptionsApiHandler
    {
        private readonly RequestDelegate _next;

        public CustomExceptionsApiHandler(RequestDelegate next) => _next = next;

        public async Task InvokeAsync(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (Exception ex)
            {

                await HandleExceptionAsync(context, ex);
            }
        }

        private Task HandleExceptionAsync(HttpContext context, Exception ex)
        {
            var errCode = HttpStatusCode.InternalServerError;
            var res = string.Empty;

            switch (ex)
            {
                case NotFoundException:
                    errCode = HttpStatusCode.NotFound;
                    break;

                case FluentValidation.ValidationException validationEx:
                    errCode = HttpStatusCode.BadRequest;
                    res = JsonSerializer.Serialize(validationEx.Errors);
                    break;

                default:
                    break;
            }

            context.Response.ContentType = "application/json";
            context.Response.StatusCode = (int)errCode;

            if (string.IsNullOrEmpty(res))
                res = JsonSerializer.Serialize(new { errinfo = ex.Message });

            return context.Response.WriteAsync(res);
        }
    }
}
