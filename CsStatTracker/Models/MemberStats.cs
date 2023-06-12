using Microsoft.CodeAnalysis;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion.Internal;
using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;

namespace CsStatTracker.Models
{
    
    public class Segments
    {
        
        public platformInfo platformInfo { get; set; }
        
        public Stats stats { get; set; }
    }
    public class Stats
        {
        
            public StatsInfo timePlayed { get; set; }
            public StatsInfo score { get; set; }
            public StatsInfo kills { get; set; }
            public StatsInfo deaths { get; set; }
            public StatsInfo kd { get; set; }
            public StatsInfo damage { get; set; }
            public StatsInfo headshots { get; set; }
            public StatsInfo dominations { get; set; }
            public StatsInfo shotsFired { get; set; }
            public StatsInfo shotsHit { get; set; }
            public StatsInfo shotsAccuracy { get; set; }
            public StatsInfo snipersKilled { get; set; }
            public StatsInfo dominationOverkills { get; set; }
            public StatsInfo dominationRevenges { get; set; }
            public StatsInfo bombsPlanted { get; set; }
            public StatsInfo bombsDefused { get; set; }
            public StatsInfo moneyEarned { get; set; }
            public StatsInfo hostagesRescued { get; set; }
            public StatsInfo mvp { get; set; }
            public StatsInfo wins { get; set; }
            public StatsInfo ties { get; set; }
            public StatsInfo matchesPlayed { get; set; }
            public StatsInfo losses { get; set; }
            public StatsInfo roundsPlayed { get; set; }
            public StatsInfo roundsWon { get; set; }
            public StatsInfo wlPercentage { get; set; }
            public StatsInfo headshotPct { get; set; }


    }
    public class platformInfo
    {
        public string platformSlug { get; set; }
        public string platformUserId { get; set; }
        public string platformUserHandle { get; set; }
        public string avatarUrl { get; set; }

    }
    public class StatsInfo 
    {
        public string rank { get; set; }
        public double? percentile { get; set; }
        public string displayName { get; set; }
        public string displayCategory { get; set; }
        public string category { get; set; }
        public string displayValue { get; set; }
        public string displayType { get; set; }
        public double value { get; set; }
    }
    public class StatsViewModel
    {
        [JsonProperty("platformUserId")]
        public string SteamID { get; set; }
        [JsonProperty("platformUserHandle")]
        public string Username { get; set; }
        [JsonProperty("avatarUrl")]
        public string AvatarURL { get; set; }
        
        public string Rank { get; set; }
        [JsonProperty("kills")]
        public double Eliminations { get; set; }
        [JsonProperty("deaths")]
        public double Deaths { get; set; }
        
        public int Assists { get; set; }
        [JsonProperty("wlPercentage")]
        public double WinRate { get; set; }
        [JsonProperty("wins")]
        public double Wins { get; set; }
        [JsonProperty("losses")]
        public double Losses { get; set; }
        [JsonProperty("headshotPct")]
        public double HeadShotPercent { get; set; }
        
        public double RoundsWon { get; set; }
        
        public double Damage { get; set; }
        
        public double RoundsPlayed { get; set; }
	}
}
