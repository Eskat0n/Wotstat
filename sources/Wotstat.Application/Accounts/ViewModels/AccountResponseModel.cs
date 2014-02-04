﻿namespace Wotstat.Application.Accounts.ViewModels
{
    using System;
    using Newtonsoft.Json;

    public class AccountResponseModel
    {
        [JsonProperty("status")]
        public string Status { get; set; }

        [JsonProperty("access_token")]
        public string Token { get; set; }
       
        [JsonProperty("account_id")]
        public string Id { get; set; }

        [JsonProperty("nickname")]
        public string Nickname { get; set; } 
 
        [JsonProperty("expires_at")]
        public DateTime ExpiresDate { get; set; }
    }
}