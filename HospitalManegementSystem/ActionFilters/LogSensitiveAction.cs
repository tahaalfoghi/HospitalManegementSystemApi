using Microsoft.AspNetCore.Mvc.Filters;
using System.Diagnostics;

namespace HospitalManegementSystem.ActionFilters
{
    public class LogSensitiveAction:ActionFilterAttribute
    {
        public override Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        {
            Debug.WriteLine("Sensitive action executed");
            return Task.CompletedTask;
        }
    }
}
