using Microsoft.AspNetCore.SignalR;
using System.Globalization;
namespace MoodChat.Hubs
{
    public class ChatHub: Hub
    {
        public async Task SendMessage(string message)
        {
            var now = DateTime.Now;

            var mfi = new DateTimeFormatInfo();
            string month = mfi.GetMonthName(now.Month);

            string date = $"{now.Day} {month}";
            string time = $"{now:HH:mm}";
          
            await Clients.All.SendAsync("RecieveMessage", message, $"{date}\n{time}");
        }
    }
}
