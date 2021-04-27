using GreenwayCoding.Models;
using GreenwayCoding.Services.Abstractions;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace GreenwayCoding.Services
{
    public class WebRetrieverService: IWebRetrieverService
    {

        private readonly IHttpClientFactory _clientFactory;
        public WebRetrieverService(IHttpClientFactory clientFactory)
        {
            _clientFactory = clientFactory;
        }

        public async Task<List<TriviaQuestion>> GetTriviaQueryResponse()
        {
            var trivias = new List<TriviaQuestion>();
            var request = new HttpRequestMessage(HttpMethod.Get,"https://opentdb.com/api.php?amount=5&amp;category=11&amp;difficulty=medium&amp;type=multiple");            

            var client = _clientFactory.CreateClient();

            var response = await client.SendAsync(request);

            if (response.IsSuccessStatusCode)
            {
                var responseString = await response.Content.ReadAsStringAsync();
                var jsonObject = JObject.Parse(responseString);
                trivias = jsonObject["results"].ToObject<List<TriviaQuestion>>();
                
            }

            return trivias;
        }
    }
}
