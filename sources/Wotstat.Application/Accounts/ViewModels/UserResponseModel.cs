namespace Wotstat.Application.Accounts.ViewModels
{
    using Newtonsoft.Json;

    public class UserResponseModel
    {
        [JsonProperty("status")]
        public string Status { get; set; }

        [JsonProperty("access_token")]
        public string Access_Token { get; set; }
       
        [JsonProperty("account_id")]
        public int Account_Id { get; set; }

        [JsonProperty("nickname")]
        public string Nickname { get; set; } 
 
        [JsonProperty("expires_at")]
        public string Expires_At { get; set; }
    }
}