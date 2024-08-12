using Microsoft.AspNetCore.SignalR;
using MoodChat.Contexts;
using MoodChat.Services;
using System.Globalization;

namespace MoodChat.Hubs
{
    /// <summary>
    /// Represents a hub that handles real-time messaging and sentiment analysis.
    /// </summary>
    public class ChatHub: Hub
    {

        private readonly MoodChatContext db;
        private readonly CognitiveService gs;

        /// <summary>
        /// Initializes a new instance of the <see cref="ChatHub"/> class.
        /// </summary>
        /// <param name="db">An instance of <see cref="MoodChatContext"/> used to interact with the database.</param>
        /// <param name="gs">An instance of <see cref="CognitiveService"/> used for sentiment analysis.</param>
        public ChatHub(MoodChatContext db, CognitiveService gs)
        {
            this.db = db;
            this.gs = gs;
        }

        /// <summary>
        /// Processes and sends a chat message to all clients.
        /// Before message is sent it is saved to database and sentiment analysis on it is performed.
        /// </summary>
        /// <param name="message">The content of the message to be sent.</param>
        /// <returns>A <see cref="Task"/> representing the asynchronous operation.</returns>
        public async Task SendMessage(string message)
        {
            var now = DateTime.Now;
            var mfi = new DateTimeFormatInfo();
            string month = mfi.GetMonthName(now.Month);
            string formattedDatetime = $"{now.Day} {month} {now:HH:mm}";//e.g. 22 June 17:55

            var sentimentAnalysisData = gs.Analyze(message);//this may be used to provide more detailed results

            var newMessage = new Models.Message
            {
                Text = message,
                Formatted_Date = formattedDatetime,
                Sentiment = sentimentAnalysisData.Sentiment.ToString().ToLower()
            };

            db.Messages.Add(newMessage);
            db.SaveChanges();

            //all data about message is sent to all clients as well as string representation of sentiment analysis full result
            await Clients.All.SendAsync("RecieveMessage", newMessage.Text, newMessage.Formatted_Date, newMessage.Sentiment, sentimentAnalysisData.ToString());
        }
    }
}
