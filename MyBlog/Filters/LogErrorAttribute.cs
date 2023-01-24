using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.AspNetCore.Mvc;

namespace MyBlog.Filters
{
    public class LogErrorAttribute : ExceptionFilterAttribute
    {
        private readonly ILogger<LogErrorAttribute> _logger;

        public LogErrorAttribute(ILogger<LogErrorAttribute> logger)
        {
            _logger = logger;
        }

        public override void OnException(ExceptionContext context)
        {
            _logger.LogError(context.Exception, "An unhandled exception occurred.");
            context.Result = new ViewResult
            {
                ViewName = "Error",
                ViewData = new ViewDataDictionary(new EmptyModelMetadataProvider(), new ModelStateDictionary())
            {
                {"ErrorMessage", "An unhandled exception occurred. Please try again later."},
            }
            };
            context.ExceptionHandled = true;
        }
    }

}
