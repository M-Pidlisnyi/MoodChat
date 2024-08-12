using Azure;
using Azure.AI.TextAnalytics;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
namespace MoodChat.Services
{
    /// <summary>
    /// Provides sentiment analysis capabilities using Azure Text Analytics service.
    /// </summary>
    public class CognitiveService
    {
        private readonly AzureKeyCredential credentials;
        private readonly Uri endpoint;
        private readonly TextAnalyticsClient client;

        /// <summary>
        /// Initializes a new instance of the <see cref="CognitiveService"/> class.
        /// </summary>
        /// <param name="key">The API key for the Azure Text Analytics service.</param>
        /// <param name="endpoint">The endpoint URL for the Azure Text Analytics service.</param>
        public CognitiveService(string key, string endpoint)
        {
            this.credentials = new AzureKeyCredential(key);
            this.endpoint = new Uri(endpoint);
            this.client = new TextAnalyticsClient(this.endpoint, this.credentials);
        }


        /// <summary>
        /// Analyzes the sentiment of the provided text.
        /// </summary>
        /// <param name="text">The text to analyze.</param>
        /// <returns>A <see cref="DocumentSentiment"/> object representing the sentiment analysis result.</returns>
        public DocumentSentiment Analyze(string text)
        {
            return client.AnalyzeSentiment(text); ;
        }
    }



}
