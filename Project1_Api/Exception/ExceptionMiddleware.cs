namespace Project1_Api.Exception
{
    public class ExceptionMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<ExceptionMiddleware> _logger;

        public ExceptionMiddleware(RequestDelegate nex, ILogger<ExceptionMiddleware> logger)
        {
            _next = nex;
            _logger = logger;
        }

        public async Task InvokeAsync(HttpContext httpContext)
        {
            try
            {
                await _next(httpContext);
            }
            catch (System.Exception ex) // Explicitly qualify Exception with the System namespace.
            {
                _logger.LogError(ex, "An unhandled exception occurred while processing the request.");
                httpContext.Response.StatusCode = StatusCodes.Status500InternalServerError;
                httpContext.Response.ContentType = "application/json";
                var errorResponse = new
                {
                    StatusCode = httpContext.Response.StatusCode,
                    Message = "An unexpected error occurred. Please try again later."
                };
                await httpContext.Response.WriteAsJsonAsync(errorResponse);
            }
        }
    }
}
