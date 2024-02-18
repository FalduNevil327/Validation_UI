using Microsoft.AspNetCore.Mvc;

namespace Validation_UI.Areas.My_Profile.Controllers
{
    
    public class My_ProfileController : Controller
    {
        [Area("My_Profile")]
        [Route("My_Profile/[controller]/[action]")]
        public IActionResult Index()
        {
            return View();
        }
    }
}
