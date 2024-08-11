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

        public  IActionResult Index()
        {
            var messages = db.Messages.OrderByDescending(m => m.Id).Take(5).OrderBy(m => m.Id);

            return View(messages);
        }

            
    }
}
