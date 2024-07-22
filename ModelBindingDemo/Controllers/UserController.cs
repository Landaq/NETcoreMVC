using Microsoft.AspNetCore.Mvc;
using ModelBindingDemo.Models;

namespace ModelBindingDemo.Controllers
{
    public class UserController : Controller
    {
        private List<User> _users;
        public UserController()
        {
            _users = new List<User>()
            {
                new User(){Id =1, Name ="Pranaya", Age = 35},
                new User(){Id =2, Name ="Priyanka", Age = 30},
                new User(){Id =3, Name ="Anurag", Age = 35},
                new User(){Id =4, Name ="Prateek", Age=30},
                new User(){Id =5, Name ="Hina", Age=35}
            };
        }

        [HttpGet("users/create")]
        public IActionResult Create()
        {
            return View();
        }

        [HttpGet]
        [Route("users/{Id}/getdetails")]
        public IActionResult GetUserById([FromRoute(Name="Id")] int UserId)
        {
            // Here, you can use the 'id' to fetch user details form a database or other data sources.

            var user = _users.FirstOrDefault(x => x.Id == UserId);
            if (user == null) 
            {
                return NotFound();
            }
            return Ok(user);
        }

        [HttpGet]
        [Route("users/data")]
        public IActionResult GetUsers([FromHeader(Name = "X-Api-Version")] string apiVersion)
        {
            if (string.IsNullOrEmpty(apiVersion))
            {
                return BadRequest("X-Api-Version header is required");
            }

            if (apiVersion == "1.0")
            {
                // Return data specific to version 1.0
                return Ok(new { version = "1.0", data = "Data for v1.0" });
            }
            else if (apiVersion == "2.0")
            {
                // Return data specific to version 2.0
                return Ok(new { version = "2.0", data = "Data for v2.0" });
            }
            else
            {
                return BadRequest($"Unsupported API version: {apiVersion}");
            }
        }

        //[HttpGet("users/search")]
        //public IActionResult Search([FromQuery] UserSearchCriteria criteria)
        //{
        //    List<User> FilteredUsers = new List<User>();

        //    if (criteria != null)
        //    {
        //        if (!string.IsNullOrEmpty(criteria.Name) && criteria.Age > 0)
        //        {
        //            FilteredUsers = _users.Where(x =>
        //            x.Name.ToLower().StartsWith(criteria.Name.ToLower()) || x.Age > criteria.Age).ToList();
        //        }
        //        else if (!string.IsNullOrEmpty(criteria.Name))
        //        {
        //            FilteredUsers = _users.Where(x =>
        //            x.Name.ToLower().StartsWith(criteria.Name.ToLower())).ToList();
        //        }
        //        else if (criteria.Age > 0)
        //        {
        //            FilteredUsers = _users.Where(x => x.Age > criteria.Age).ToList();
        //        }
        //    }

        //    return Ok(FilteredUsers);
        //}
        [HttpGet("users/search")]
        public IActionResult Search([FromQuery] string Name, [FromQuery] int? Age)
        {
            List<User> FilteredUsers = new List<User>();
            if (!string.IsNullOrEmpty(Name) && Age != null && Age > 0)
            {
                FilteredUsers = _users.Where(x => x.Name.ToLower().StartsWith(Name.ToLower()) || x.Age > Age).ToList();
            }
            else if (!string.IsNullOrEmpty(Name))
            {
                FilteredUsers = _users.Where(x => x.Name.ToLower().StartsWith(Name.ToLower())).ToList();
            }
            else if (Age != null & Age > 0)
            {
                FilteredUsers = _users.Where(x => x.Age > Age).ToList();
            }
            return Ok(FilteredUsers);
        }

        [HttpPost("users/create")]
        //public IActionResult Create([FromForm] User user)
        //{
        //    if (!ModelState.IsValid)
        //    {
        //        return View(user);
        //    }

        //    return RedirectToAction("SuccessAction");
        //}
        public IActionResult Create([FromForm] string Name, [FromForm] string Email,
            [FromForm] string Password, [FromForm] string Mobile)
        {
            return RedirectToAction("SuccessAction");
        }

        public string SuccessAction()
        {
            return "User Created Successfully";
        }
    }
}
