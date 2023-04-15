namespace CsStatTracker.Models
{
    public class MemberStats
    {
        /// <summary>
        /// The amount of eliminations a player has in Counter-Strike.
        /// </summary>
        public int Elimations { get; set; }
        /// <summary>
        /// The amount of assists a player has in Counter-Strike.
        /// </summary>
        public int Assists { get; set; }
        /// <summary>
        /// The amount of deaths a player has in Counter-Strike.
        /// </summary>
        public int Deaths { get; set; }
        /// <summary>
        /// The percentage of kills obtained with a headshot that a player has in Counter-Strike.
        /// </summary>
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
        public int Wins { get; set; }
        /// <summary>
        /// The amount of losses a player has in Counter-Strike.
        /// </summary>
        public int Losses { get; set; }
        /// <summary>
        /// The average WinRate a player has by dividing wins by losses in Counter-Strike.
        /// </summary>
        public double WinRate { get; set; }
        /// <summary>
        /// The official matchmaking rank a player has achieved in Counter-Strike.
        /// </summary>
        public string Rank { get; set; }
    }
}
