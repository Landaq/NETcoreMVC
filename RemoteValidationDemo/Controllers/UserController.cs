using Microsoft.AspNetCore.Mvc;
using RemoteValidationDemo.Models;

namespace RemoteValidationDemo.Controllers
{
    public class UserController : Controller
    {
        private readonly EFCoreDBContext _context;
        private readonly GenerateSuggestions _generateSuggestions;
        public UserController(EFCoreDBContext context, GenerateSuggestions generateSuggestions)
        {
            _context = context;
            _generateSuggestions = generateSuggestions;
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View(); 
        }

        [HttpPost]
        public async Task<IActionResult> Create(RegisterViewModel model)
        {
            if (ModelState.IsValid)
            {
                //if (_context.Users.Any(u => u.Email == model.Email))
                //{
                //    // The second parameter will decide the number of unique suggestions to be generated
                //    var suggestedEmails = await _generateSuggestions.GenerateUniqueEmailsAsync(model.UserName, 2);

                //    //Dynamically Adding Model Validation Error incase JavaScript is Disabled
                //    ModelState.AddModelError("Email", $"Email is already in use. Try anyone of these: {suggestedEmails}");
                //}

                //if(_context.Users.Any(u => u.UserName == model.UserName))
                //{
                //    // The second parameter will decide the number of unique suggestions to be generated
                //    var suggestedUsername = await _generateSuggestions.GenerateUniqueUsernamesAsync(model.UserName, 2);

                //    //Dynamically Adding Model Validation Error incase JavaScript is Disabled
                //    ModelState.AddModelError("UserName", $"Username is already taken. Try anyone of these: {suggestedUsername}");
                //}

                if (ModelState.IsValid)
                {
                    // Proceed with saving the new user or any other business logic
                    User user = new User
                    {
                        Email = model.Email,
                        UserName = model.UserName,
                        Password = model.Password,
                    };

                    await _context.Users.AddAsync(user);
                    await _context.SaveChangesAsync();
                    return RedirectToAction("Successful");
                }
            }

            // Return the view with validation message if any checks fail
            return View(model);
        }
        public string Successful()
        {
            return "User Added Successfully";
        }
    }
}
