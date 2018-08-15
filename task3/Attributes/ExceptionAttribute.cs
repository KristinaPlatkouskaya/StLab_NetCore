using Microsoft.AspNetCore.Mvc.Filters;
using task3.Loggers;

namespace task3.Attributes
{
    public class ExceptionAttribute : ExceptionFilterAttribute
    {
        private readonly IActionLogger _logger;
        public ExceptionAttribute(IActionLogger logger)
        {
            this._logger = logger;
        }
        public override void OnException(ExceptionContext context)
        {
            _logger.Log(context);
        }
    }
}
