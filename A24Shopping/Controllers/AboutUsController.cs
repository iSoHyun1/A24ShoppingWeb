using Microsoft.AspNetCore.Mvc;

namespace A24Shopping.Controllers
{
    public class AboutUsController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
