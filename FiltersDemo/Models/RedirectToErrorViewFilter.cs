using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace FiltersDemo.Models
{
    public class RedirectToErrorViewFilter : ExceptionFilterAttribute
    {
        public override void OnException(ExceptionContext context)
        {
            context.Result = new ViewResult
            {
                ViewName = "Error"
            };
            context.ExceptionHandled = true;
        }
    }
}
