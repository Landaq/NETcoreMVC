using FirstCoreMVCApplication.Models;
using Microsoft.AspNetCore.Mvc;

namespace FirstCoreMVCApplication.Controllers
{
    public class BlogPostController : Controller
    {
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
