using FirstCoreMVCApplication.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Diagnostics;

namespace FirstCoreMVCApplication.Controllers
{
    public class HomeController : Controller
    {
        private List<Student> listStudents = new List<Student>();
        public HomeController() 
        {
            listStudents = new List<Student>()
            {
               new Student() { StudentId = 101, Name = "James", Branch = Branch.CSE, Gender = Gender.Male, Address = "A1-2018", Email = "James@g.com" },
               new Student() { StudentId = 102, Name = "Priyanka", Branch = Branch.ETC, Gender = Gender.Female, Address = "A1-2019", Email = "Priyanka@g.com" },
               new Student() { StudentId = 103, Name = "David", Branch = Branch.CSE, Gender = Gender.Male, Address = "A1-2020", Email = "David@g.com" },
               new Student() { StudentId = 104, Name = "Pranaya", Branch = Branch.Mech, Gender = Gender.Male, Address = "A1-2021", Email = "Pranaya@g.com" }
            };
        }
        public ViewResult Index()
        {
            return View(listStudents);
        }
        public ViewResult Details(int Id)
        {
            var studentDetails = listStudents.FirstOrDefault(std => std.StudentId == Id);
            return View(studentDetails);
        }

        [HttpGet]
        public ViewResult Create()
        {
            ViewBag.AllGenders = Enum.GetValues(typeof(Gender)).Cast<Gender>().ToList();
            ViewBag.AllBranches = new List<SelectListItem>()
            {
                new SelectListItem { Text = "None", Value = "1" },
                new SelectListItem { Text = "CSE", Value = "2" },
                new SelectListItem { Text = "ETC", Value = "3" },
                new SelectListItem { Text = "Mech", Value = "4" }
            };

            return View();
        }

        public IActionResult BlogPost(int id = 1000)
        {
            //In Real-Time, you will get the data from the database
            //Here, we have hard coded the data
            var post = new BlogPost
            {
                Id = id,
                Title = "What is ASP.NET Core",
                Author = "Pranaya Rout",
                Content = "ASP.NET Core (.NET) is a free, open-source, and cloud-optimized framework that can run on Windows, Linux, or macOS.",
                Comments = new List<Comment>
                {
                    new Comment { Name = "James", Email = "James@Example.com", Text = "Great post!" },
                    new Comment { Name = "Kumar", Email = "Kumar@Example.com", Text = "Thanks for sharing." },
                    new Comment { Name = "Rout", Email = "Rout@Example.com", Text = "Appreciate your work..." }
                }
            };

            return View(post);
        }
    }
}
