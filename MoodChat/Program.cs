using Microsoft.EntityFrameworkCore;
using MoodChat.Hubs;
using MoodChat.Contexts;
using System;
using System.Configuration;
using MoodChat.Services;

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


            string? keySecret = builder.Configuration["SentimentAnalysisKey1"];//SentimentAnalysisKey2 may be used as well
            string? endpointSecret = builder.Configuration["SentimentAnalysisEndpoint"];

            if (keySecret == null)
            {
                throw new Exception("API Key cannot be null.");
            }
            if (endpointSecret == null)
            {
                throw new Exception("Endpoint cannot be null.");
            }

            builder.Services.AddTransient(
                service => new CognitiveService(keySecret, endpointSecret)
            );

            var app = builder.Build();

            app.UseStaticFiles();
            app.MapHub<ChatHub>("/chathub");
            app.MapControllerRoute(name: "index", pattern: "{controller=Home}/{action=Index}");
            app.Run();
        }
    }
}
