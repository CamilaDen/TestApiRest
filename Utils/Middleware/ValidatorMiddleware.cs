using Microsoft.AspNetCore.Http;
using System.Net;
using System.Text.Json;
using Utils.Exceptions;

namespace Utils.Middleware
{
    public class ValidatorMiddleware
    {
        private readonly RequestDelegate _next;

        public ValidatorMiddleware(RequestDelegate next)
        {
            _next= next;
        }
        public async Task Invoke(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (Exception ex)
            {
                if(ex.InnerException is KeyNotFoundException)
                {
                    ex = ex.InnerException as KeyNotFoundException;
                }
                if(ex.InnerException is BadRequestException)
                {
                    ex = ex.InnerException as BadRequestException;
                }
                var resp = context.Response;
                resp.ContentType = "application/json";
                var respModel = ex.Message;
                switch (ex)
                {
                    case BadRequestException e:
                        resp.StatusCode = (int)HttpStatusCode.BadRequest;
                        break;
                    case KeyNotFoundException e:
                        resp.StatusCode = (int)HttpStatusCode.NotFound;
                        break;
                    default:
                        resp.StatusCode = (int)HttpStatusCode.InternalServerError;
                        break;
                }
                var result = JsonSerializer.Serialize(respModel);
                await resp.WriteAsync(result);
            }
        }
    }
}
