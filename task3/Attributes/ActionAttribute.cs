using Microsoft.AspNetCore.Mvc.Filters;
using task3.Loggers;

namespace task3.Attributes
{
    public class ActionAttribute : ActionFilterAttribute
    {
        private readonly IActionLogger _logger;
        public ActionAttribute(IActionLogger logger)
        {
            this._logger = logger;
        }
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            _logger.Log(context);
        }
    }
}
