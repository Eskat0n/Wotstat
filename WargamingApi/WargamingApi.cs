namespace WargamingApi
{
    using System;
    using System.Net;
    using ApiModels;
    using Domain.Model;
    using Domain.Model.Entities;
    using Messages;
    using Newtonsoft.Json;

    public class WargamingApi : IWargamingApi
    {
        private readonly IConfig _config;
        private readonly string apiAddress = "https://api.worldoftanks.ru";

        public WargamingApi(IConfig config)
        {
            _config = config;
        }

        public string GetLoginUrl(string redirectUrl)
        {
            return string.Format("{0}/wot/auth/login/?application_id={1}&redirect_uri={2}", apiAddress,
                _config.ApplicationId, redirectUrl);
        }
        public PlayerInfo GetPlayerData(int playerId)
        {
            var client = new WebClient();
            var info =
                client.DownloadString(
                    string.Format("http://api.worldoftanks.ru/2.0/account/info/?application_id={0}&fields=statistics.all.battles,statistics.all.frags,statistics.all.damage_dealt,statistics.max_xp,statistics.all.wins,statistics.all.losses,statistics.all.draws,statistics.all.hits_percents,statistics.all.battle_avg_xp&account_id={1}",
                        _config.ApplicationId, playerId));
            var responseRaw = JsonConvert.DeserializeObject<ResponsePlayerDataRow>(info);
            var statisticsRaw = responseRaw.Data[playerId].Statistics;
            var statisticsBlockRaw = statisticsRaw.All;
            return new PlayerInfo
            {
                Time = DateTime.Now,
                PlayerId = playerId,
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
    }
}