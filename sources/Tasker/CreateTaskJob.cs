namespace TaskScheduler
{
    using NCron;
    using TaskService;

    public class CreateTaskJob : CronJob
    {
        private readonly ITaskCreator _taskCreator;

        public CreateTaskJob(ITaskCreator taskCreator)
        {
            _taskCreator = taskCreator;
        }

        public override void Execute()
        {
            _taskCreator.CreateTaskForAllAccounts();
        }
    }
}