using Microsoft.AspNetCore.Mvc;

namespace MoodChat.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
