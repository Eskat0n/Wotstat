namespace Wotstat.Application.Boilerplate.Extensions.Web
{
    using System.Web.Mvc;
    using JetBrains.Annotations;

    [UsedImplicitly]
    public static class HtmlHelperAuthExtensions
    {
        [CanBeNull]
        public static string AccountName(this HtmlHelper htmlHelper)
        {
            var accountName = htmlHelper.ViewBag.AccountName;
            if (accountName == null)
                return null;

            return (string)accountName;
        } 
    }
}