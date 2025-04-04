namespace ITIWebApi.MiddleWare
{
    public class LoggingMiddleWare
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<LoggingMiddleWare> _logger;
        public LoggingMiddleWare(RequestDelegate next, ILogger<LoggingMiddleWare> logger)
        {
            _next = next;
            _logger = logger;
        }
        public async Task InvokeAsync(HttpContext context)
        {
            // Log the request path and HTTP verb
            _logger.LogInformation("hi Request Path: {Path}, HTTP Verb: {Method}",
                context.Request.Path,
                context.Request.Method);

            // Continue the request pipeline
            await _next(context);
        }
    }
}
