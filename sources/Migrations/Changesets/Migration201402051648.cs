namespace Migrations.Changesets
{
    using FluentMigrator;
    using JetBrains.Annotations;

    [Migration(201402051648), UsedImplicitly]
    public class Migration201402051648 : ForwardOnlyMigration
    {
        public override void Up()
        {
            Rename.Table("StatisticData").To("StatisticalDatas");
            Rename.Table("DynamicData").To("DynamicDatas");
        }
    }
}