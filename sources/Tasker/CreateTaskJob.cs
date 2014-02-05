namespace Tasker
{
    using NCron;

    public class CreateTaskJob : CronJob
    {
        public override void Execute()
        {
            new TaskCreator().Execute();
        }
    }
}