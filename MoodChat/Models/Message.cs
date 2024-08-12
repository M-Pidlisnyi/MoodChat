namespace MoodChat.Models
{
    /// <summary>
    /// Represents a message in the chat application.
    /// </summary>
    public class Message
    {
        public int Id { get; set; }
        public string? Text { get; set; }

        /// <summary>
        /// Gets or sets the date and time when message was sent in format 'day monthName HH:mm'
        /// </summary>
        public string? Formatted_Date { get; set; }

        /// <summary>
        /// Gets or sets the sentiment analysis result of the message text. Possible meaningful values are:
        /// 'positive',
        /// 'negative',
        /// 'mixed',
        /// 'neutral'
        /// </summary>
        public string? Sentiment { get; set; }
    }
}
