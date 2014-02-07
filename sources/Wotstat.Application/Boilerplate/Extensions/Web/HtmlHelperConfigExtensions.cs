namespace Wotstat.Application.Boilerplate.Extensions.Web
{
    using System.Web.Mvc;
    using Enviroment;

    public static class HtmlHelperConfigExtensions
    {
        public static IConfig Config(this HtmlHelper htmlHelper)
        {
            return (IConfig)htmlHelper.ViewBag.Config;
        }
    }
}