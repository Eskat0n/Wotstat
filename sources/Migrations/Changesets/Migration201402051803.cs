namespace Migrations.Changesets
{
    using FluentMigrator;
    using JetBrains.Annotations;

    [Migration(201402051803), UsedImplicitly]
    public class Migration201402051803 : ForwardOnlyMigration
    {
        public override void Up()
        {
            Insert.IntoTable("Periods").Row(new
            {
                DaysCount = "1",
                Name = "День"
            });
        }
    }
}