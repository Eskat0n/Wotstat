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
        private readonly IRepository<StatisticalData> _statisticDataRepository;
        private readonly IRepository<DynamicData> _dynamicDataRepository;
        private IEnumerable<Period> _periods;

        public CalcService()
        {
            InitializeComponent();

            IoC.Init();
            _query = IoC.Resolve<IQueryBuilder>();
            _periodsRepository = IoC.Resolve<IRepository<Period>>();
            _statisticDataRepository = IoC.Resolve<IRepository<StatisticalData>>();
            _dynamicDataRepository = IoC.Resolve<IRepository<DynamicData>>();
        }

        public void Start()
        {
            _periods = _periodsRepository.All();
            _bus = RabbitHutch.CreateBus("host=localhost");
            _bus.Subscribe<PlayerInfo>("Wotstat", OnMessage);
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
                var oldData = _query.For<StatisticalData>().With(new PlayerIdAndDateCriterion(message.PlayerId, nowData.Date.AddDays(-period.DaysCount)));
                if (oldData == null)
                    return;
                var res = Subtraction(nowData, oldData);
                res.Period = period;
                res.PlayerId = message.PlayerId;
                _dynamicDataRepository.Add(res);
            });
        }

        private StatisticalData Convert(PlayerInfo a)
        {
            return new StatisticalData
            {
                BattleAvgXp = a.BattleAvgXp,
                Battles = a.Battles,
                DamageDealt = a.DamageDealt,
                Frags = a.Frags,
                HitsPercents = a.HitsPercents,
                MaxXp = a.MaxXp,
                Date = a.Time.Date,
                PlayerId = a.PlayerId,
                WinsPercents = ((double) a.Wins)/(a.Wins + a.Losses + a.Draws)*100
            };
        }
        private DynamicData Subtraction(StatisticalData a, StatisticalData b)
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