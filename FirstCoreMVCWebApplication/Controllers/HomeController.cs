using FirstCoreMVCWebApplication.Models;
using Microsoft.AspNetCore.Mvc;

namespace FirstCoreMVCWebApplication.Controllers
{
    public class HomeController : Controller
    {
        public JsonResult Index ()
        {
            StudentRepository repository = new StudentRepository ();
            List<Student> allStrudentDetails = repository.GetAllStudent();
            return Json(allStrudentDetails);
        }
        public JsonResult GetStudentDetails(int Id)
        {
            StudentRepository repository = new StudentRepository();
            Student studentDetails = repository.GetStudentById(Id);
            return Json(studentDetails);
        }
    }
}
