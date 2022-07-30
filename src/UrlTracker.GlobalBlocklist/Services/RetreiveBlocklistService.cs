using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;
using UrlTracker.GlobalBlocklist.Models;

namespace UrlTracker.GlobalBlocklist.Services
{
    public class RetreiveBlocklistService : IRetreiveBlocklistService
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public RetreiveBlocklistService(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<GlobalSettings> GetGlobalSettings()
        {
            var _client = _httpClientFactory.CreateClient();
            var result = await _client.GetAsync(Defaults.Blocklist.BlocklistUrl);
            result.EnsureSuccessStatusCode();
            var content = await result.Content.ReadAsStringAsync();

            return JsonConvert.DeserializeObject<GlobalSettings>(content);
        }
    }
}
