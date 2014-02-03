namespace Wotstat.Infrastructure.BootstrapperTasks
{
    using MvcExtensions;
    using Application.Annotations;

    [UsedImplicitly]
    public class RunMigrations : BootstrapperTask
    {

        public override TaskContinuation Execute()
        {

            //migrations task
            return TaskContinuation.Continue;
        }
    }
}