using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Hosting;
using MoodChat.Contexts;

namespace MoodChat.Controllers
{
    /// <summary>
    /// Handles HTTP requests related to the home page of the MoodChat application.
    /// </summary>
    public class HomeController : Controller
    {
        private readonly MoodChatContext db;


        /// <summary>
        /// Initializes a new instance of the <see cref="HomeController"/> class.
        /// </summary>
        /// <param name="db">The <see cref="MoodChatContext"/> instance used to interact with the database.</param>
        public HomeController(MoodChatContext db)
        {
            this.db = db;
        }

        /// <summary>
        /// Displays the home page with the most recent chat messages.
        /// </summary>
        /// <returns>An <see cref="IActionResult"/> representing the result of the action.</returns>
        public IActionResult Index()
        {
            // Retrieve the 5 most recent messages from the database, ordered by message Id.
            var messages = db.Messages.OrderByDescending(m => m.Id).Take(5).OrderBy(m => m.Id);

            return View(messages);
        }

            
    }
}
