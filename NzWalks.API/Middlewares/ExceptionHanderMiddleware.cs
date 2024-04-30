using System.Net;

namespace NzWalks.API.Middlewares
{
    public class ExceptionHanderMiddleware
    {
        private readonly ILogger<ExceptionHanderMiddleware> logger;
        private readonly RequestDelegate next;

        public ExceptionHanderMiddleware(ILogger<ExceptionHanderMiddleware> logger,
            RequestDelegate next)
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

                // log this Exception
                logger.LogError(ex, $"{errorId} : {ex.Message}");

                // return a Custon Exrror Response
                httpContext.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
                httpContext.Response.ContentType = "application/json";

                var error = new
                {
                    Id = errorId,
                    ErrorMessage = "Something went wrong! We are looking into resolving this."
                };

                await httpContext.Response.WriteAsJsonAsync(error);
            }
        }
    }
}
