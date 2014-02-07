namespace Wotstat.Application.Enviroment.Impl
{
    using System.Configuration;

    public class Config : IConfig
    {
        public string ApplicationId
        {
            get { return ConfigurationManager.AppSettings["ApplicationId"]; }
        }

        public string OAuthUrl
        {
            get { return ConfigurationManager.AppSettings["OAuthUrl"]; }
        }
    }
}