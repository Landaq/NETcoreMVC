using Microsoft.AspNetCore.Mvc;

namespace FiltersDemo.Controllers
{
    public class ErrorController : Controller
    {
        // If there is 404 status code, the route path will become Error/404
        [Route("Error/{statusCode}")]
        public IActionResult Index(int statusCode)
        {
            Response.Clear();
            Response.StatusCode = statusCode;

            switch (statusCode) 
            {
                case 401:
                    return View("UnauthorizedError");
                case 404:
                    return View("PageNotFoundError");
                case 500:
                    return View("InternalServerError");
                default:
                    return View("GenericError");
            }

        }
    }
}
