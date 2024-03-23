using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Filters;

namespace HospitalManegementSystem.ActionFilters
{
    public class LogSensitiveActionFilter : IActionFilter
{
    private readonly ILogger<LogSensitiveActionFilter> _logger;

    public LogSensitiveActionFilter(ILogger<LogSensitiveActionFilter> logger)
    {
        _logger = logger ?? throw new ArgumentNullException(nameof(logger));
    }

    public void OnActionExecuting(ActionExecutingContext context)
    {
        
        _logger.LogInformation("Sensitive action exceuted at {DateTime}", 
            context.ActionDescriptor.DisplayName, DateTime.UtcNow);
    }

    public void OnActionExecuted(ActionExecutedContext context)
    {
        
        _logger.LogInformation("Sensitive action completed at {DateTime}", 
            context.ActionDescriptor.DisplayName, DateTime.UtcNow);
    }
}
}