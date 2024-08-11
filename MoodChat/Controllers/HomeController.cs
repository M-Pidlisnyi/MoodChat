using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using MoodChat.Contexts;
using MoodChat.Hubs;
using static System.Runtime.InteropServices.JavaScript.JSType;

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
            var messages = db.Messages.ToList();

            return View(messages);
        }

            
    }
}
