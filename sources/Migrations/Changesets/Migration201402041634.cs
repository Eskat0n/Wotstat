namespace Migrations.Changesets
{
    using FluentMigrator;
    using FluentMigrator.Runner.Announcers;
    using JetBrains.Annotations;

    [Migration(201402041634), UsedImplicitly]
    public class Migration201402041634 : ForwardOnlyMigration
    {
        public override void Up()
        {
            Create.Table("StatisticData")
                .WithColumn("Id").AsInt32().NotNullable().Identity().PrimaryKey()
                .WithColumn("Date").AsDate().NotNullable()
                .WithColumn("User").AsInt32().NotNullable().ForeignKey("FK_StatisticData_Accounts", "Accounts", "Id")
                .WithColumn("HitsPercents").AsInt32().NotNullable()
                .WithColumn("BattleAvgXp").AsInt32().NotNullable()
                .WithColumn("WinsPercents").AsInt32().NotNullable()
                .WithColumn("Battles").AsInt32().NotNullable()
                .WithColumn("DamageDealt").AsInt32().NotNullable()
                .WithColumn("Frags").AsInt32().NotNullable()
                .WithColumn("MaxXp").AsInt32().NotNullable();

            Create.Table("Periods")
                .WithColumn("Id").AsInt32().NotNullable().Identity().PrimaryKey()
                .WithColumn("DaysCount").AsInt32().NotNullable()
                .WithColumn("Name").AsString();

            Insert.IntoTable("Periods").Row(new
            {
                DaysCount = "7",
                Name = "Неделя"
            }).Row(new
            {
                DaysCount = "31",
                Name = "Месяц"
            }).Row(new
            {
                DaysCount = "92",
                Name = "3 месяца"
            }).Row(new
            {
                DaysCount = "182",
                Name = "Пол года"
            }).Row(new
            {
                DaysCount = "365",
                Name = "Год"
            });
            
            Create.Table("DynamicData")
                .WithColumn("Id").AsInt32().NotNullable().Identity().PrimaryKey()
                .WithColumn("Period").AsInt32().NotNullable().ForeignKey("FK_DynamicData_Periods", "Periods", "Id")
                .WithColumn("User").AsInt32().NotNullable().ForeignKey("FK_DynamicData_Accounts", "Accounts", "Id")
                .WithColumn("HitsPercents").AsInt32().NotNullable()
                .WithColumn("BattleAvgXp").AsInt32().NotNullable()
                .WithColumn("WinsPercents").AsInt32().NotNullable()
                .WithColumn("Battles").AsInt32().NotNullable()
                .WithColumn("DamageDealt").AsInt32().NotNullable()
                .WithColumn("Frags").AsInt32().NotNullable()
                .WithColumn("MaxXp").AsInt32().NotNullable();

        }
    }
}