using Microsoft.AspNetCore.Mvc.Filters;
using System.Diagnostics;

namespace MyBlog.Filters
{
    public class LogExecutionTimeAttribute : ActionFilterAttribute
    {
        private readonly ILogger _logger;
        private Stopwatch _stopwatch;

        public LogExecutionTimeAttribute(ILogger<LogExecutionTimeAttribute> logger)
        {
            _logger = logger;
        }

        public override void OnActionExecuting(ActionExecutingContext context)
        {
            _stopwatch = Stopwatch.StartNew();
        }

        public override void OnActionExecuted(ActionExecutedContext context)
        {
            _stopwatch.Stop();
            var elapsed = _stopwatch.ElapsedMilliseconds;
            _logger.LogInformation($"Execution time for {context.ActionDescriptor.DisplayName} is {elapsed}ms.");
        }
    }

}
