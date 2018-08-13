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
                    using (StreamWriter reader = new StreamWriter(filePath, true, System.Text.Encoding.Default))
                    {
                        reader.WriteLine("Action info");
                        reader.WriteLine("---------------");
                        reader.WriteLine(string.Concat("Action: ",context.ActionDescriptor.DisplayName));
                        reader.WriteLine(string.Concat("Method: ", context.HttpContext.Request.Method));
                        reader.WriteLine(string.Concat("Date: ", DateTime.Now));
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
                    using (StreamWriter reader = new StreamWriter(filePath, true, System.Text.Encoding.Default))
                    {
                        reader.WriteLine("Exception info");
                        reader.WriteLine("---------------");
                        reader.WriteLine(string.Concat("Exception: ",context.Exception));
                    }
                }
            }
        }
    }
}
