namespace Wotstat.Application.Statistics
{
    using System;
    using System.Collections.Generic;
    using System.Globalization;
    using System.Linq;
    using System.Web.Mvc;
    using AutoMapper;
    using ByndyuSoft.Infrastructure.Domain;
    using Domain.Model.Criteria;
    using Domain.Model.Entities;
    using NArms.Utility;
    using Security.Services;
    using Services;
    using ViewModels;

    [Authorize]
    public class StatisticController : Controller
    {
        public IGraphicStatisticService GraphicStatisticService { get; set; }
        public IQueryBuilder Query { get; set; }

        public IContextAccountProvider ContextProvider { get; set; }

        public IRepository<Period> PeriodRepository { get; set; }

        public DynamicFieldItemArray DynamicFieldItems { get; private set; }

        public StatisticController()
        {
            DynamicFieldItems = new DynamicFieldItemArray()
                .Add("Процент попаданий", x => x.HitsPercents)
                .Add("Средний опыт за бой", x => x.BattleAvgXp)
                .Add("Процент побед", x => x.WinsPercents)
                .Add("Проведено боёв", x => x.Battles)
                .Add("Нанесено повреждений", x => x.DamageDealt)
                .Add("Уничтожено техники", x => x.Frags)
                .Add("Максимальный опыт за бой", x => x.MaxXp);
        }

        public ActionResult Index()
        {
            var currentUser = ContextProvider.ContextAccount();

            if (currentUser == null)
                return View(Enumerable.Empty<DynamicData>());

            var statistic = Query.For<StatisticalData>().With(new StatisticSearchCriterion(currentUser.PlayerId));

            var dynamic = Query.For<IEnumerable<DynamicData>>().With(new StatisticSearchCriterion(currentUser.PlayerId));

            var viewModel = new StatisticsViewModel(statistic, dynamic);

            PopulateViewBag();

            return View(viewModel);
        }

        public ActionResult GraphicDate(string propertyName, DateTime? startDate, DateTime? endDate)
        {
            var currentUser = ContextProvider.ContextAccount();

            /*var data = GraphicStatisticService.GetGraphicData(currentUser, x => x.,
                startDate.HasValue ? startDate.Value : DateTime.MinValue,
                DateTime.MaxValue);*/

            return /*Json(data);*/ null; // TODO
        }

        private void PopulateViewBag()
        {
            ViewBag.Periods = PeriodRepository.All().OrderBy(x => x.DaysCount);
            ViewBag.GraphicPeriods = GenerateSelectedListItem(DynamicFieldItems.Names);
        }

        private static IEnumerable<SelectListItem> GenerateSelectedListItem(IEnumerable<string> names)
        {
            var i = 0;
            foreach (var name in names)
            {
                yield return new SelectListItem { Text= name, Value = i.ToString(CultureInfo.InvariantCulture) };
                i++;
            }
        }

        public class DynamicFieldItemArray
        {
            public DynamicFieldItemArray()
            {
                Names = new List<string>();
                Functions = new List<Func<DynamicData, double>>();
            }

            public DynamicFieldItemArray Add(string name, Func<DynamicData, double> func)
            {
                Names.Add(name);
                Functions.Add(func);
                return this;
            }

            public List<string> Names { get; private set; }
            public List<Func<DynamicData, double>> Functions { get; private set; }
        }
    }
}