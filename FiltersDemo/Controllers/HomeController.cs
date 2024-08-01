using FiltersDemo.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace FiltersDemo.Controllers
{
    // [CustomResultFilter]
    [TypeFilter(typeof(CustomResultFilter))]
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View(); 
        }

        public ViewResult Details(int id)
        {
            // Let us assume the Product with the given Id is does not exists in the database
            Product? product = null;

            if (product == null)
            {
                Response.StatusCode = 404;
                return View("ProductNotFound", id);
            }

            return View(product);
        }

        // 400 Bad Request
        public IActionResult SomeAction1()
        {
            var someConditionIsNotMet = true;
            if (someConditionIsNotMet)
            {
                return new StatusCodeResult(400);
            }
            // other logic
            return View();
        }

        // 401 Unauthorized
        public IActionResult SomeAction2()
        {
            var IsAuthenticated = false;
            if (IsAuthenticated)
            {
                return Unauthorized(); // This will return a 401 status code
            }
            // Other logic
            return View();
        }

        // 403 Forbidden
        public IActionResult SomeAction3()
        {
            var UserHasPermissionToAccessResource = false;
            if (!UserHasPermissionToAccessResource)
            {
                return new StatusCodeResult(403);
            }
            // other logic
            return View();
        }

        // 404 Not Found
        public IActionResult SomeAction4()
        {
            var requestedResourceNotFound = true;
            if (requestedResourceNotFound)
            {
                return NotFound();
            }
            return View();
        }

        // 500 Internal Server Error
        public IActionResult SomeAction5()
        {
            try
            {
                // Some code that might throw an exception
                throw new Exception("Some Exception Occurred");
                return Ok();
            }
            catch (Exception ex)
            {
                // Log the exception
                return new StatusCodeResult(500);
            }
        }

        // 503 Service Unavailable
        public IActionResult SomeAction6()
        {
            var isServiceUnavailable = true;
            if (isServiceUnavailable)
            {
                return new StatusCodeResult(503);
            }
            return View();
        }
    }
}
