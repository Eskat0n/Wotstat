namespace WargamingApi
{
    using Messages;

    public interface IWargamingApi
    {
        string GetLoginUrl(string redirectUrl);
        PlayerInfo GetPlayerData(int playerId);
    }
}