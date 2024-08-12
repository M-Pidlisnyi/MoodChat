using Microsoft.EntityFrameworkCore;
using MoodChat.Models;


namespace MoodChat.Contexts
{
    /// <summary>
    /// Represents the database context for the MoodChat application.
    /// 
    /// This context manages the entity sets and provides access to the underlying database.
    /// </summary>
    /// <remarks>
    ///     A DbContext instance represents a session with the database and can be used to
    ///     query and save instances of your entities. DbContext is a combination of the
    ///     Unit Of Work and Repository patterns.
    /// </remarks>
    public class MoodChatContext:DbContext
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="MoodChatContext"/> class.
        /// </summary>
        /// <param name="options">The options to configure the <see cref="DbContext"/> instance.</param>
        public MoodChatContext(DbContextOptions<MoodChatContext> options ): base(options)
        { 
                
        }

        public DbSet<Message> Messages { get; set; }
    }
}
