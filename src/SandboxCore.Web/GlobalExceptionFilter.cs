using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Logging;

namespace SandboxCore.Web
{
    public class GlobalExceptionFilter : IExceptionFilter
    {
        private readonly ILogger logger;

        public GlobalExceptionFilter(ILoggerFactory logger)
        {
            if (logger == null)
            {
                throw new ArgumentNullException(nameof(logger));
            }

            this.logger = logger.CreateLogger<GlobalExceptionFilter>();
        }

        public void OnException(ExceptionContext context)
        {
             this.logger.LogError(LoggingEvents.Exception, context.Exception, context.Exception.Message);
        }
    }
}