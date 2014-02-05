namespace Migrations.Changesets
{
    using FluentMigrator;
    using JetBrains.Annotations;

    [Migration(201402051429), UsedImplicitly]
    public class Migration201402051429 : ForwardOnlyMigration
    {
        public override void Up()
        {
            Alter.Column("HitsPercents").OnTable("StatisticData").AsDouble();
            Alter.Column("BattleAvgXp").OnTable("StatisticData").AsDouble();
            Alter.Column("WinsPercents").OnTable("StatisticData").AsDouble();
            Alter.Column("HitsPercents").OnTable("DynamicData").AsDouble();
            Alter.Column("BattleAvgXp").OnTable("DynamicData").AsDouble();
            Alter.Column("WinsPercents").OnTable("DynamicData").AsDouble();
        }
    }
}