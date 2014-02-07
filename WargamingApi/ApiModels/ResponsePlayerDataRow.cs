using System.Collections.Generic;
using Newtonsoft.Json;

namespace WargamingApi.ApiModels
{
    public class ResponsePlayerDataRow
    {
        public Dictionary<int, PlayerInfoRaw> Data { get; set; }
    }

    public class PlayerInfoRaw
    {
        [JsonProperty("statistics")]
        public StatisticsRaw Statistics { get; set; }
    }

    public class StatisticsRaw
    {
        [JsonProperty("all")]
        public StatisticsBlockRaw All { get; set; }

        [JsonProperty("max_xp")]
        public int MaxXp { get; set; }
    }

    public class StatisticsBlockRaw
    {
        [JsonProperty("hits_percents")]
        public double HitsPercents { get; set; }

        [JsonProperty("battle_avg_xp")]
        public double BattleAvgXp { get; set; }

        [JsonProperty("draws")]
        public int Draws { get; set; }

        [JsonProperty("wins")]
        public int Wins { get; set; }

        [JsonProperty("losses")]
        public int Losses { get; set; }

        [JsonProperty("battles")]
        public int Battles { get; set; }

        [JsonProperty("damage_dealt")]
        public int DamageDealt { get; set; }

        [JsonProperty("frags")]
        public int Frags { get; set; }
    }
}
