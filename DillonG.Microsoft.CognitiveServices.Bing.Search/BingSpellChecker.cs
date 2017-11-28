using DillonG.Microsoft.CognitiveServices.Bing.Search.Interfaces;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace DillonG.Microsoft.CognitiveServices.Bing.Search
{
    public class BingSpellChecker : ISpellChecker
    {
        HttpClient _client;

        const string host = "https://api.cognitive.microsoft.com";
        const string path = "/bing/v7.0/spellcheck?";
        const string market = "en-US";

        const string mode = "spell";

        public BingSpellChecker(string key)
        {
            _client = new HttpClient();
            _client.DefaultRequestHeaders.Add("Ocp-Apim-Subscription-Key", key);

        }
        public async Task<SpellCheckResult> CheckSpelling(string text)
        {
             var uri = host + path;

            var values = new List<KeyValuePair<string, string>>
            {
                new KeyValuePair<string, string>("mkt", market),
                new KeyValuePair<string, string>("mode", mode),
                new KeyValuePair<string, string>("text", text)
            };

            using (var content = new FormUrlEncodedContent(values))
            {
                content.Headers.ContentType = new MediaTypeHeaderValue("application/x-www-form-urlencoded");
                var response = await _client.PostAsync(uri, content);

                response.EnsureSuccessStatusCode();

                var contentString = await response.Content.ReadAsStringAsync();

                return JsonConvert.DeserializeObject<SpellCheckResult>(contentString);
            }
        }
    }
}
