using Microsoft.AspNetCore.SignalR;

namespace MoodChat.Hubs
{
    public class ChatHub: Hub
    {
        public async Task SendMessage(string message)
        {
            await Clients.All.SendAsync("RecieveMessage", message);
        }
    }
}
