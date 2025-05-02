using Azure;
using Shared.ErrorModels;

namespace E_Commerce.Api.CustomMiddlewares
{
    public class ErrorHandlerMiddleware(RequestDelegate next, ILogger<ErrorHandlerMiddleware> logger)
    {

        public async Task Invoke(HttpContext context)
        {
            try
            {

                // Call the next middleware in the pipeline

                //await next(context);

                await next.Invoke(context);
            }
            catch (Exception ex)
            {
                logger.LogError(ex, "An error occurred while processing the request.");
                context.Response.StatusCode = StatusCodes.Status500InternalServerError;
                context.Response.ContentType = "application/json";

                var error = new Error
                {
                    StatusCode = context.Response.StatusCode,
                    Message = "An unexpected error occurred. Please try again later."
                };

                // Serialize the error object to JSON and write it to the response
                await context.Response.WriteAsJsonAsync(error);
            }
        }
    }
}
