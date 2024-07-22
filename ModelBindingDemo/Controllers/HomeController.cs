using Microsoft.AspNetCore.Mvc;
using ModelBindingDemo.Models;
using System.Diagnostics;
using System.Net.Http.Headers;

namespace ModelBindingDemo.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public string SubmitForm(User user)
        {
            if (user != null)
            {
                if (ModelState.IsValid)
                {
                    // Handle data as needed...
                    return $"User Created: UserName: {user.Name}, UserEmail:{user.Email}";
                }
            }
            return "Some Error Occured";
        }

        [HttpGet("home/getdetails")]
        public IActionResult GetDetails([ModelBinder(typeof(CommaSeperatedModelBinder))] List<int> Ids)
        {
            return Ok(Ids);
        }

        [HttpGet("home/getdata")]
        public IActionResult GetData([ModelBinder(typeof(DateRangeModelBinder))] DateRange range)
        {
            //Do somethig with range.StartDate and range.EndDate
            return Ok($"From{range.StartDate} to{range.EndDate}");
        }

        [HttpGet("data/{country}")]
        public IActionResult GetComplexUserData([ModelBinder(typeof(ComplexUserModeBinder))] ComplexUser user)
        {
            return Ok(user);
        }

    }
}
