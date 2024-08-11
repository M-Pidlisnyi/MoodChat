using Microsoft.EntityFrameworkCore;
using MoodChat.Models;


namespace MoodChat.Contexts
{
    public class MoodChatContext:DbContext
    {
        public MoodChatContext(DbContextOptions<MoodChatContext> options ): base(options)
        { 
                
        }

        public DbSet<Message> Messages { get; set; }
    }
}
