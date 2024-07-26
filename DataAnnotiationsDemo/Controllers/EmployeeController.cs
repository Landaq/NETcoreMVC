using DataAnnotiationsDemo.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace DataAnnotiationsDemo.Controllers
{
    public class EmployeeController : Controller
    {
        public IActionResult Create()
        {
            PrepareEmployeeViewModel();
            return View();
        }

        public IActionResult Default()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Default(Employee employee)
        {
            // check if the model state is valid
            if (ModelState.IsValid)
            {
                // Save the Data into the Database
                // Redirect to a Diffrent View
                return RedirectToAction("Successful");
            }

            // Return to the same View and Display Model Validation error
            return View(employee);
        }

        [HttpPost]
        public IActionResult Create(Employee employee)
        {
            // check if the model state is valid
            if (ModelState.IsValid)
            {
                // Save the Data into the Database
                // Redirect to a Diffrent View
                return RedirectToAction("Successful");
            }

            // Return to the same View and Display Model Validation error
            return View(employee);
        }

        [HttpPost]  
        public string Successful()
        {
            return "Employee Addedd Successfully";
        }

        private void PrepareEmployeeViewModel() 
        {
            ViewBag.AllGenders = Enum.GetValues(typeof(Gender)).Cast<Gender>().ToList();
            ViewBag.Departments = GetDepartments();
            ViewBag.SkillSets = new List<string> { "Dot Net", "Java", "Python", "PHP", "Database" };
        }

        private List<SelectListItem> GetDepartments()
        {
            // You can get the data from the database and populate the SelectListItem
            return new List<SelectListItem>()
            {
                new SelectListItem { Text = "IT", Value = "1"},
                new SelectListItem { Text = "HR", Value="2"},
                new SelectListItem { Text = "Payroll", Value="3"},
                new SelectListItem { Text ="Admin", Value="4"}
            };
        }
    }
}
