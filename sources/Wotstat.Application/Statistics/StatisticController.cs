namespace Wotstat.Application.Statistics
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Web.Mvc;
    using ByndyuSoft.Infrastructure.Domain;
    using Domain.Model.Criteria;
    using Domain.Model.Entities;
    using Security.Services;
    using ViewModels;

    [Authorize]
    public class StatisticController : Controller
    {
        public IQueryBuilder Query { get; set; }

        public IContextAccountProvider ContextProvider { get; set; }

        public IRepository<Period> PeriodRepository { get; set; } 

        public ActionResult Index()
        {
            var currentUser = ContextProvider.ContextAccount();

            if (currentUser == null)
                return View(Enumerable.Empty<DynamicData>());

            var statistic = Query.For<StatisticalData>().With(new StatisticSearchCriterion(currentUser.PlayerId));

            var dynamic = Query.For<IEnumerable<DynamicData>>().With(new StatisticSearchCriterion(currentUser.PlayerId));

            var viewModel = new StatisticsViewModel(statistic, dynamic);

            PopulatePeriods();

            return View(viewModel);
        }

        public ActionResult All()
        {
            var currentUser = ContextProvider.ContextAccount();

            if (currentUser == null)
                return View(Enumerable.Empty<DynamicData>());

            return View();
        }

        private void PopulatePeriods()
        {
            ViewBag.Periods = PeriodRepository.All().OrderBy(x=>x.DaysCount);
        }
    }
}