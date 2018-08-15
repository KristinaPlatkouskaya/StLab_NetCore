using Microsoft.AspNetCore.Mvc.Filters;

namespace task3.Loggers
{
    public interface IActionLogger
    {
        void Log(ActionExecutingContext context);
        void Log(ExceptionContext context);
    }
}
