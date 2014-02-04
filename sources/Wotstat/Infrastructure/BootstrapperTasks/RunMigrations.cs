namespace Wotstat.Infrastructure.BootstrapperTasks
{
    using JetBrains.Annotations;
    using Migrations;
    using MvcExtensions;

    [UsedImplicitly]
    public class RunMigrations : BootstrapperTask
    {

        public override TaskContinuation Execute()
        {
            MigrationsRunner.Run();
            
            return TaskContinuation.Continue;
        }
    }
}