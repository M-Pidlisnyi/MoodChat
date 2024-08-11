using Microsoft.AspNetCore.SignalR;
using MoodChat.Contexts;
using System.Globalization;

namespace MoodChat.Hubs
{
    public class ChatHub: Hub
    {

        private readonly MoodChatContext db;

        public ChatHub(MoodChatContext db)
        {
            this.db = db;
        }


        public async Task SendMessage(string message)
        {
            var now = DateTime.Now;

            var mfi = new DateTimeFormatInfo();
            string month = mfi.GetMonthName(now.Month);

            string formattedDatetime = $"{now.Day} {month} {now:HH:mm}";

            var newMessage = new Models.Message
            {
                Text = message,
                Formatted_Date = formattedDatetime,
                Sentiment = "neutral"
            };

            db.Messages.Add(newMessage);
            db.SaveChanges();

            await Clients.All.SendAsync("RecieveMessage", newMessage.Text, newMessage.Formatted_Date, newMessage.Sentiment);
        }
    }
}
