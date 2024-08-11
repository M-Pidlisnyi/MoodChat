namespace MoodChat.Models
{
    public class Message
    {
        public int Id { get; set; }
        public string? Text { get; set; }
        public string? Formatted_Date { get; set; }
        public string? Sentiment { get; set; }
    }
}
