namespace Migrations.Changesets
{
    using FluentMigrator;
    using JetBrains.Annotations;

    [Migration(201402041101), UsedImplicitly]
    public class Migration201402041101 : ForwardOnlyMigration
    {
        public override void Up()
        {
            Create.Table("Accounts")
                .WithColumn("Id").AsInt32().NotNullable().Identity().PrimaryKey()
                .WithColumn("Name").AsString().NotNullable()
                .WithColumn("PlayerId").AsInt32().NotNullable();
        }
    }
}