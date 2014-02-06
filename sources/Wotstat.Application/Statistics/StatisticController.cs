namespace Wotstat.Application.Statistics
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Web.Mvc;
    using ByndyuSoft.Infrastructure.Domain;
    using Domain.Model.Criteria;
    using Domain.Model.Entities;
    using Security.Services;

    public class StatisticController : Controller
    {
        public IQueryBuilder Query { get; set; }

        public IContextAccountProvider ContextProvider { get; set; }

        public ActionResult Index()
        {
            var currentUser = ContextProvider.ContextAccount();

            if (currentUser == null)
                return View(Enumerable.Empty<DynamicData>());

            var statistics =
                Query.For<IEnumerable<DynamicData>>().With(new StatisticSearchCriterion(currentUser.PlayerId));

            return View(statistics ?? Enumerable.Empty<DynamicData>());
        }
    }
}