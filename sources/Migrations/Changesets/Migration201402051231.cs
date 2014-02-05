namespace Migrations.Changesets
{
    using FluentMigrator;
    using FluentMigrator.Runner.Announcers;
    using JetBrains.Annotations;

    [Migration(201402051231), UsedImplicitly]
    public class Migration201402051231 : ForwardOnlyMigration
    {
        public override void Up()
        {
            Delete.ForeignKey("FK_StatisticData_Accounts").OnTable("StatisticData");
            Delete.ForeignKey("FK_DynamicData_Accounts").OnTable("DynamicData"); ;
        }
    }
}