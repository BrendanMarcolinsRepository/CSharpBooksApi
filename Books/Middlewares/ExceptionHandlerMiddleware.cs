using System.Net;

namespace Books.Middlewares
{
    public class ExceptionHandlerMiddleware
    {
        private readonly ILogger<ExceptionHandlerMiddleware> logger;
        private readonly RequestDelegate requestDelegate;

        public ExceptionHandlerMiddleware(ILogger<ExceptionHandlerMiddleware> logger, RequestDelegate requestDelegate)
        {
            this.logger = logger;
            this.requestDelegate = requestDelegate;
        }

        public async Task InvokeAsync(HttpContext httpContext) 
        {
            try
            { 
                await requestDelegate(httpContext);
            }
            catch (Exception exception) 
            {
                var errorId = Guid.NewGuid().ToString();
                //log execeptions
                logger.LogError($"{errorId} =========> {exception.Message}", exception);

                //custom error response
                httpContext.Response.StatusCode = int.Parse(HttpStatusCode.InternalServerError.ToString());
                httpContext.Response.ContentType = "application/json";

                var error = new { Id = errorId, ErrorMessage = "OH NO! Something Screwed Up!! " };

                await httpContext.Response.WriteAsJsonAsync(error);
                
            }
        }
    }
}
