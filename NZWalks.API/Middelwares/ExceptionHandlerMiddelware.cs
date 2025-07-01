using Microsoft.AspNetCore.Http.HttpResults;
using System.Net;

namespace NZWalks.API.Middelwares
{
    public class ExceptionHandlerMiddelware
    {
        private readonly ILogger<ExceptionHandlerMiddelware> logger;
        private readonly RequestDelegate next;

        public ExceptionHandlerMiddelware(ILogger<ExceptionHandlerMiddelware> logger, RequestDelegate next)
        {
            this.logger = logger;
            this.next = next;
        }

        public async Task InvokeAsync(HttpContext httpContext)
        {
            try
            {
                await next(httpContext);
            }
            catch (Exception ex)
            {
                var errorId = Guid.NewGuid();

                logger.LogError(ex, $"{errorId} : {ex.Message}");

                //Return a custom error response
                httpContext.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
                httpContext.Response.ContentType = "application/json";

                var error = new
                {
                    Id = errorId,
                    ErrorMessage = "Something went worng! we are looking into resolving this."
                };

                await httpContext.Response.WriteAsJsonAsync(error);
            }
        }
    }
}
