using Microsoft.EntityFrameworkCore;
using MoodChat.Hubs;
using MoodChat.Contexts;
using System;
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
            
            builder.Services.AddDbContext<MoodChatContext>(
                    options =>  options.UseSqlServer("name=AzureSQLDB:ConnectionString")
                );
   
            var app = builder.Build();

            app.UseStaticFiles();

            app.MapHub<ChatHub>("/chathub");
            app.MapControllerRoute(name: "index", pattern: "{controller=Home}/{action=Index}");
            app.Run();
        }
    }
}
