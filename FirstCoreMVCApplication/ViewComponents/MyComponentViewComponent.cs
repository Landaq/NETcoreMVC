using Microsoft.AspNetCore.Mvc;

namespace FirstCoreMVCApplication.ViewComponents
{
    public class MyComponentViewComponent : ViewComponent
    {
        public IViewComponentResult Invoke(string param)
        {
            // Logic or Data Retrieval
            // Returns the Default view with the passed parm
            return View("Default", param);
        }
    }
}
