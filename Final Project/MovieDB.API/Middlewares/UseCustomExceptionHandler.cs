using Microsoft.AspNetCore.Diagnostics;
using MovieDB.Core.Models;
using System.Text.Json;

namespace MovieDB.API.Middlewares
{
    public static class UseCustomExceptionHandler
    {
        public static void UseCustomException(this IApplicationBuilder app)
        {
            app.UseExceptionHandler(config =>
            {
                config.Run(async context =>
                {
                    context.Response.ContentType = "application/json";
                    var exceptionFeature = context.Features.Get<IExceptionHandlerFeature>();
                    var statusCode = 500;
                    context.Response.StatusCode = statusCode;

                    var response = new Error
                    {
                        StatusCode = statusCode,
                        Message = exceptionFeature.Error.Message
                    };

                    await context.Response.WriteAsync(JsonSerializer.Serialize(response));
                });
            });
        }
    }
}

