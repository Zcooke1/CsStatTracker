using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using RestSharp;
using Newtonsoft.Json;
using CsStatTracker.Models;



namespace CsStatTracker.Controllers
{
    public class ApiResponse<T>
    {
        public string ErrorCode { get; set; }
        public string ErrorMessage { get; set; }
        public T Data { get; set; }
    }
    public class StatsController : Controller
    {
        private readonly RestClient _client;
        private readonly string _trackerApiKey;
        private readonly ILogger _logger;


        public StatsController(IConfiguration configuration)
        {
            _trackerApiKey = configuration.GetSection("TrackerApiKey")["ApiKey"];
            _client = new RestClient("https://public-api.tracker.gg/v2/csgo/standard/profile/");
        }

        public async Task<IActionResult> MemberStats(string steamId)
        {
            if (string.IsNullOrEmpty(_trackerApiKey))
            {
                return BadRequest("API key not found.");
            }

            var request = new RestRequest($"https://public-api.tracker.gg/v2/csgo/standard/profile/steam/{steamId}", Method.Get);
            request.AddHeader("TRN-Api-Key", _trackerApiKey);
            var response = await _client.ExecuteAsync(request);
            var content = JsonConvert.DeserializeObject<ApiResponse<MemberStats>>(response.Content);
            

            var statsViewModel = new StatsViewModel();
            if(content.Data != null)
            {
                statsViewModel.SteamID = content.Data.SteamID;
                statsViewModel.Username = content.Data.Username;
                statsViewModel.Rank = content.Data.Rank;
                statsViewModel.Eliminations = content.Data.Eliminations;
                statsViewModel.Deaths = content.Data.Deaths;
                statsViewModel.Assists = content.Data.Assists;
                statsViewModel.WinRate = content.Data.WinRate;
                statsViewModel.Wins = content.Data.Wins;
                statsViewModel.Losses = content.Data.Losses;
                statsViewModel.HeadShotPercent = content.Data.HeadShotPercent;
                statsViewModel.EffectiveFlashes = content.Data.EffectiveFlashes;
                statsViewModel.UtilityDMG = content.Data.UtilityDMG;
                statsViewModel.ADR = content.Data.ADR;
            };

            return View(content.Data);
        }







        public async Task<string> SearchPlayer(string playerName)
        {
            var request = new RestRequest("search", Method.Get);
            request.AddParameter("query", playerName);
            request.AddHeader("TRN-Api-Key", _trackerApiKey);
            var response = await _client.ExecuteAsync<SearchResult>(request);

            if (response.IsSuccessful && response.Data?.Data?.Any() == true)
            {
                return response.Data.Data[0].PlatformUserHandle;
            }

            return null;
        }

        public class SearchResult
        {
            public List<SearchResultData> Data { get; set; }
        }

        public class SearchResultData
        {
            public string PlatformUserHandle { get; set; }
        }

    }
}
