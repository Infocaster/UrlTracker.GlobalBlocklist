using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;
using UrlTracker.GlobalBlocklist.Models;
using System.Text.Json;

namespace UrlTracker.GlobalBlocklist.Services
{
    public class RetrieveBlocklistService : IRetrieveBlocklistService
    {
        private readonly HttpClient _httpClient;

        public RetrieveBlocklistService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<GlobalSettings> GetGlobalSettings()
        {
            var result = await _httpClient.GetAsync(Defaults.Blocklist.BlocklistUrl);
            result.EnsureSuccessStatusCode();
            var content = await result.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<GlobalSettings>(content);
        }
    }
}
