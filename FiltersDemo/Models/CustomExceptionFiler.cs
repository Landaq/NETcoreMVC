using Microsoft.AspNetCore.Mvc.Filters;

namespace FiltersDemo.Models
{
    public class CustomExceptionFiler : IExceptionFilter
    {
        public void OnException(ExceptionContext context)
        {
            var controllerName = context.RouteData.Values["controller"];
            var actionName = context.RouteData.Values["action"];

            string message = $"\nTime: {DateTime.Now}, Controller: {controllerName}, Action: {actionName}, Exception: {context.Exception.Message}";
            string filePath = Path.Combine(Directory.GetCurrentDirectory(), "Log", "Log.txt");

            //saving the data in a text file called log.txt
            File.AppendAllText(filePath, message);
        }
    }
}
