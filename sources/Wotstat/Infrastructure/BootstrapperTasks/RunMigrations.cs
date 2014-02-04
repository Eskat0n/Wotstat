namespace Wotstat.Infrastructure.BootstrapperTasks
{
    using Migrations;
    using MvcExtensions;
    using Application.Annotations;

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