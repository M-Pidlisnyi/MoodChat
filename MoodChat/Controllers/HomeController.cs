using Microsoft.AspNetCore.Mvc;
using MoodChat.Contexts;

namespace MoodChat.Controllers
{
    public class HomeController : Controller
    {
        private readonly MoodChatContext db;

        public HomeController(MoodChatContext db)
        {
            this.db = db;
        }

        public IActionResult Index()
        {
            var messages = db.Messages.ToList();
            return View(messages);
        }

            
    }
}
