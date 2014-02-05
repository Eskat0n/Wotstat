namespace Crawler
{
    using System;
    using System.Collections.Generic;
    using System.Net;
    using Messages;
    using Newtonsoft.Json;

    public interface IPlayerInfoProvider
    {
        PlayerInfo GetPlayerInfo(int id);
    }

    public class PlayerInfoProvider : IPlayerInfoProvider
    {
        private const string ClientId = "171745d21f7f98fd8878771da1000a31";

        public PlayerInfo GetPlayerInfo(int id)
        {
            var client = new WebClient();
            var info =
                client.DownloadString(
                    string.Format(
                        "http://api.worldoftanks.ru/2.0/account/info/?application_id={0}&fields=statistics.all.battles,statistics.all.frags,statistics.all.damage_dealt,statistics.max_xp,statistics.all.wins,statistics.all.losses,statistics.all.draws,statistics.all.hits_percents,statistics.all.battle_avg_xp&account_id={1}",
                        ClientId, id));
            var responseRaw = JsonConvert.DeserializeObject<ResponseRaw>(info);
            var statisticsRaw = responseRaw.Data[id].Statistics;
            var statisticsBlockRaw = statisticsRaw.All;
            return new PlayerInfo()
            {
                Time = DateTime.Now,
                PlayerId = id,
                HitsPercents = statisticsBlockRaw.HitsPercents,
                BattleAvgXp = statisticsBlockRaw.BattleAvgXp,
                Draws = statisticsBlockRaw.Draws,
                Wins = statisticsBlockRaw.Wins,
                Losses = statisticsBlockRaw.Losses,
                Battles = statisticsBlockRaw.Battles,
                DamageDealt = statisticsBlockRaw.DamageDealt,
                Frags = statisticsBlockRaw.Frags,
                MaxXp = statisticsRaw.MaxXp
            };
        }

        private class ResponseRaw
        {
            public Dictionary<int, PlayerInfoRaw> Data { get; set; }
        }

        private class PlayerInfoRaw
        {
            [JsonProperty("statistics")]
            public StatisticsRaw Statistics { get; set; }
        }

        private class StatisticsRaw
        {
            [JsonProperty("all")]
            public StatisticsBlockRaw All { get; set; }

            [JsonProperty("max_xp")]
            public int MaxXp { get; set; }
        }

        private class StatisticsBlockRaw
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
}