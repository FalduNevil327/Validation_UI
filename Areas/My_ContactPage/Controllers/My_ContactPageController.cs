using Microsoft.AspNetCore.Mvc;

namespace Validation_UI.Areas.My_ContactPage.Controllers
{
    
    [Area("My_ContactPage")]
    [Route("My_ContactPage/[controller]/[action]")]
    public class My_ContactPageController : Controller
    {
        public IActionResult My_ContactPage()
        {
            return View();
        }
    }
}
