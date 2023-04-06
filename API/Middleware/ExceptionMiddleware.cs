using API.Errors;
using Microsoft.AspNetCore.Diagnostics;
using System.Net;
using System.Text.Json;

namespace API.Middleware
{
    public class ExceptionMiddleware
    {
        public ExceptionMiddleware(RequestDelegate next,
            ILogger<ExceptionHandlerMiddleware> logger, IHostEnvironment env)
        {
            Next = next;
            Logger = logger;
            Env = env;
        }

        public RequestDelegate Next { get; }
        public ILogger<ExceptionHandlerMiddleware> Logger { get; }
        public IHostEnvironment Env { get; }

        public async Task InvokeAsync(HttpContext context)
        {
            try
            {
                await Next(context);
            }
            catch (Exception ex)
            {

                Logger.LogError(ex, ex.Message);
                context.Response.ContentType = "application/json";
                context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;

                var response = Env.IsDevelopment()
                    ? new ApiExcepiton((int)HttpStatusCode.InternalServerError, ex.Message, ex.StackTrace
                    .ToString())
                    : new ApiExcepiton((int)HttpStatusCode.InternalServerError);

                var options = new JsonSerializerOptions { PropertyNamingPolicy = JsonNamingPolicy.CamelCase };


                var json = JsonSerializer.Serialize(response);

                await context.Response.WriteAsync(json);
            }
        }
    }
}
