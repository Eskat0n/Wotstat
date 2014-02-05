namespace Migrations.Changesets
{
    using FluentMigrator;
    using JetBrains.Annotations;

    [Migration(201402051642), UsedImplicitly]
    public class Migration201402051642 : ForwardOnlyMigration
    {
        public override void Up()
        {
            Rename.Column("User").OnTable("StatisticData").To("PlayerId");
            Rename.Column("User").OnTable("DynamicData").To("PlayerId");
        }
    }
}