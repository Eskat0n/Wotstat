namespace Wotstat.Application.Enviroment
{
    public interface IConfig
    {
        string ApplicationId { get; }
        string OAuthUrl { get; }
    }
}