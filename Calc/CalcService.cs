namespace Calc
{
    using System.Collections.Generic;
    using System.ServiceProcess;
    using ByndyuSoft.Infrastructure.Domain;
    using Domain.Model.Criteria;
    using Domain.Model.Entities;
    using EasyNetQ;
    using Messages;
    using NArms.Windsor;
    using NHibernate.Linq;

    public partial class CalcService : ServiceBase
    {
        private IBus _bus;
        private readonly IQueryBuilder _query;
        private readonly IRepository<Period> _periodsRepository;
        private readonly IRepository<StatisticData> _statisticDataRepository;
        private readonly IRepository<DynamicData> _dynamicDataRepository;
        private IEnumerable<Period> _periods;

        public CalcService()
        {
            InitializeComponent();

            IoC.Init();
            _query = IoC.Resolve<IQueryBuilder>();
            _periodsRepository = IoC.Resolve<IRepository<Period>>();
            _statisticDataRepository = IoC.Resolve<IRepository<StatisticData>>();
            _dynamicDataRepository = IoC.Resolve<IRepository<DynamicData>>();
        }

        public void Start()
        {
            _bus = RabbitHutch.CreateBus("host=localhost");
            _bus.Subscribe<PlayerInfo>("Wotstat", OnMessage);
            _periods = _periodsRepository.All();
        }

        public new void Stop()
        {
            try
            {
                _bus.Dispose();
            }
            catch {}
        }

        protected override void OnStart(string[] args)
        {
            Start();
        }

        private void OnMessage(PlayerInfo message)
        {
            var nowData = Convert(message);
            _statisticDataRepository.Add(nowData);
            
            _periods.ForEach(period =>
            {
                var oldData = _query.For<StatisticData>().With(new PlayerIdAndDateCriterion(message.PlayerId, nowData.Date.AddDays(-period.DaysCount)));
                if (oldData == null)
                    return;
                var res = Subtraction(nowData, oldData);
                res.Period = period;
                res.User = message.PlayerId;
                _dynamicDataRepository.Add(res);
            });
        }

        private StatisticData Convert(PlayerInfo a)
        {
            return new StatisticData
            {
                BattleAvgXp = a.BattleAvgXp,
                Battles = a.Battles,
                DamageDealt = a.DamageDealt,
                Frags = a.Frags,
                HitsPercents = a.HitsPercents,
                MaxXp = a.MaxXp,
                Date = a.Time.Date,
                User = a.PlayerId,
                WinsPercents = ((double) a.Wins)/(a.Wins + a.Losses + a.Draws)*100
            };
        }
        private DynamicData Subtraction(StatisticData a, StatisticData b)
        {
            return new DynamicData
            {
                BattleAvgXp = a.BattleAvgXp - b.BattleAvgXp,
                Battles = a.Battles - b.Battles,
                DamageDealt = a.DamageDealt - b.DamageDealt,
                Frags = a.Frags - b.Frags,
                HitsPercents = a.HitsPercents - b.HitsPercents,
                WinsPercents = a.WinsPercents - b.WinsPercents,
                MaxXp = a.MaxXp - b.MaxXp
            };
        }

        protected override void OnStop()
        {
            Stop();
        }
    }
}