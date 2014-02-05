namespace Migrations.Changesets
{
    using FluentMigrator;
    using JetBrains.Annotations;

    [Migration(201402051749), UsedImplicitly]
    public class Migration201402051749 : ForwardOnlyMigration
    {
        public override void Up()
        {
            Rename.Column("Period").OnTable("DynamicDatas").To("PeriodId");
        }
    }
}