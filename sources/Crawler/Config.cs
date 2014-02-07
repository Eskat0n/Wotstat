namespace Crawler
{
    using System.Configuration;
    using Domain.Model;

    public class Config : IConfig
    {
        public string ApplicationId
        {
            get { return ConfigurationManager.AppSettings["ApplicationId"]; }
        }
    }
}