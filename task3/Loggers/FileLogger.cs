using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Configuration;
using System;
using System.IO;

namespace task3.Loggers
{
    public class FileLogger : IActionLogger
    {
        private string filePath;
        private object _lock = new object();
        public FileLogger(IConfiguration configuration)
        {
            filePath = configuration["LogFileName"];
        }
        public void Log(ActionExecutingContext context)
        {
            if (context != null)
            {
                lock (_lock)
                {
                    using (StreamWriter sr = new StreamWriter(filePath, true, System.Text.Encoding.Default))
                    {
                        sr.WriteLine("Action info");
                        sr.WriteLine("---------------");
                        sr.WriteLine(string.Concat("Action: ",context.ActionDescriptor.DisplayName));
                        sr.WriteLine(string.Concat("Method: ", context.HttpContext.Request.Method));
                        sr.WriteLine(string.Concat("Date: ", DateTime.Now));
                    }
                }
            }
        }
        public void Log(ExceptionContext context)
        {
            if (context != null)
            {
                lock (_lock)
                {
                    using (StreamWriter sr = new StreamWriter(filePath, true, System.Text.Encoding.Default))
                    {
                        sr.WriteLine("Exception info");
                        sr.WriteLine("---------------");
                        sr.WriteLine(string.Concat("Exception: ",context.Exception));
                    }
                }
            }
        }
    }
}
