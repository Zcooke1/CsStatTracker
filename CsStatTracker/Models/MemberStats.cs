using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;

namespace CsStatTracker.Models
{
    public class MemberStats
    {
        [Key]
        [JsonProperty("platformUserId")]
        public string SteamID { get; set; }

        /// <summary>
        /// The amount of eliminations a player has in Counter-Strike.
        /// </summary>
        [JsonProperty("kills")]
        public int Eliminations { get; set; }
        /// <summary>
        /// The amount of assists a player has in Counter-Strike.
        /// </summary>
        public int Assists { get; set; }
        /// <summary>
        /// The amount of deaths a player has in Counter-Strike.
        /// </summary>
        [JsonProperty("deaths")]
        public int Deaths { get; set; }
        /// <summary>
        /// The percentage of kills obtained with a headshot that a player has in Counter-Strike.
        /// </summary>
        
        [JsonProperty("headshotPct")]
        public double HeadShotPercent { get; set; }
        /// <summary>
        /// The amount of flashes that have effectively flashed an enemy in Counter-Strike.
        /// </summary>
        public int EffectiveFlashes { get; set; }
        /// <summary>
        /// The amount of damage dealt by utility to an enemy in Counter-Strike.
        /// </summary>
        public int UtilityDMG { get; set; }
        /// <summary>
        /// The average damage per round a player has in Counter-Strike.
        /// </summary>
        public int ADR { get; set; }
        /// <summary>
        /// The amount of wins a player has in Counter-Strike.
        /// </summary>
        
        [JsonProperty("wins")]
        public int Wins { get; set; }
        /// <summary>
        /// The amount of losses a player has in Counter-Strike.
        /// </summary>
        
        [JsonProperty("losses")]
        public int Losses { get; set; }
        /// <summary>
        /// The average WinRate a player has by dividing wins by losses in Counter-Strike.
        /// </summary>
        
        [JsonProperty("wlPercentage")]
        public double WinRate { get; set; }
        /// <summary>
        /// The official matchmaking rank a player has achieved in Counter-Strike.
        /// </summary>
        public string Rank { get; set; }
        /// <summary>
        /// The Platform the API needs to function (in this case it MUST be 'Steam').
        /// </summary>
        public string PlatformSlug { get; set; }
        /// <summary>
        /// The users steam username
        /// </summary>
        [JsonProperty("platformUserHandle")]
        public string Username { get; set; }

        /// <summary>
        /// The URL to the users avatar or profile picture.
        /// </summary>
        [JsonProperty("avatarUrl")]
        public string AvatarURL { get; set; }

        /// <summary>
        /// The URL to the users account page
        /// </summary>
        public string ProfileURL { get; set; }

        /// <summary>
        /// The steam level of the user.
        /// </summary>
        public int Level { get; set; }

        [JsonIgnore]
        public MemberStats Data { get { return this; } }


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
        public int Eliminations { get; set; }
        [JsonProperty("deaths")]
        public int Deaths { get; set; }
        
        public int Assists { get; set; }
        [JsonProperty("wlPercentage")]
        public double WinRate { get; set; }
        [JsonProperty("wins")]
        public int Wins { get; set; }
        [JsonProperty("losses")]
        public int Losses { get; set; }
        [JsonProperty("headshotPct")]
        public double HeadShotPercent { get; set; }
        
        public int EffectiveFlashes { get; set; }
        
        public int UtilityDMG { get; set; }
        
        public double ADR { get; set; }
	}
}
