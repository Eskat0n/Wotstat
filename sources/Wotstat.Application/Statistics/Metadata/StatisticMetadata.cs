namespace Wotstat.Application.Statistics.Metadata
{
    using Domain.Model.Entities;
    using MvcExtensions;

    public class StatisticMetadata : ModelMetadataConfiguration<StatisticalData>
    {
        public StatisticMetadata()
        {
            Configure(x => x.HitsPercents).Description(() => "Процент попаданий");
            Configure(x => x.BattleAvgXp).Description(() => "Средний опыт за бой");
            Configure(x => x.WinsPercents).Description(() => "Процент побед");
            Configure(x => x.Battles).Description(() => "Проведено боёв");
            Configure(x => x.DamageDealt).Description(() => "Нанесено повреждений");
            Configure(x => x.Frags).Description(() => "Уничтожено техники");
            Configure(x => x.MaxXp).Description(() => "Максимальный опыт за бой");
        }
    }
}