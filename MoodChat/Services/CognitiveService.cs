using Azure;
using Azure.AI.TextAnalytics;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
namespace MoodChat.Services
{


    public class CognitiveService
    {
        private readonly AzureKeyCredential credentials;
        private readonly Uri endpoint;
        private readonly TextAnalyticsClient client; 
        public CognitiveService(string key, string endpoint)
        {
            this.credentials = new AzureKeyCredential(key);
            this.endpoint = new Uri(endpoint);
            this.client = new TextAnalyticsClient(this.endpoint, this.credentials);
        }
        


        public DocumentSentiment Analyze(string text)
        {
            var result = client.AnalyzeSentiment(text);

            return result;
        }
    }



}
