using MoodChat.Hubs;
using System.Configuration;

namespace MoodChat
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            builder.Services.AddSignalR().AddAzureSignalR();
            builder.Services.AddControllersWithViews();
   
            var app = builder.Build();

            app.UseStaticFiles();

            app.MapHub<ChatHub>("/chathub");
            app.MapControllerRoute(name: "index", pattern: "{controller=Home}/{action=Index}");
            app.Run();
        }
    }
}
