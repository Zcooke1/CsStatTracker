using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using RestSharp;
using Newtonsoft.Json;
using CsStatTracker.Models;



namespace CsStatTracker.Controllers
{
    

    public class ApiResponse
    {
       public Data Data { get; set; }
        
    }
    public class Data
    {
        public platformInfo platformInfo { get; set; }
        public List<Segments> Segments { get; set; }
        
    }
    public class StatsController : Controller
    {
        private readonly RestClient _client;
        private readonly string _trackerApiKey;
        private readonly ILogger _logger;


        public StatsController(IConfiguration configuration)
        {
            _trackerApiKey = configuration.GetSection("TrackerApiKey")["UserSecret"];
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
            var content = JsonConvert.DeserializeObject<ApiResponse>(response.Content);
            

            var statsViewModel = new StatsViewModel();
            if(content.Data != null)
            {
                statsViewModel.SteamID = content.Data.platformInfo.platformUserId;
                statsViewModel.Username = content.Data.platformInfo.platformUserHandle;
                statsViewModel.Wins = content.Data.Segments[0].stats.wins.value;
                statsViewModel.Losses = content.Data.Segments[0].stats.losses.value;
                statsViewModel.WinRate = content.Data.Segments[0].stats.wlPercentage.value;
                statsViewModel.RoundsPlayed = content.Data.Segments[0].stats.roundsPlayed.value;
                statsViewModel.RoundsWon = content.Data.Segments[0].stats.roundsWon.value;
                statsViewModel.Damage = content.Data.Segments[0].stats.damage.value;
                statsViewModel.HeadShotPercent = content.Data.Segments[0].stats.headshotPct.value;
                

                
            };

            return View(statsViewModel);
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
