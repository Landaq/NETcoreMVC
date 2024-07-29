using DataAnnotiationsDemo.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace DataAnnotiationsDemo.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(UserInput model)
        {
            // Check if the Model State is Valid
            if (ModelState.IsValid)
            {
                // Save the Data  into the Database
                // Redirect to a Diffrent View
                return RedirectToAction("Successful");
            }
            // Return to the same View and Display Model Validation error
            return View(model);
        }

        public string Successful()
        {
            return "Role Added Successfully";
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
