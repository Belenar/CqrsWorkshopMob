using Bira.Domain.Domain;

namespace Bira.Domain.Events
{
    public struct Task_is_defined
    {
        public readonly TaskId TaskId;

        public Task_is_defined(TaskId taskId)
        {
            TaskId = taskId;
        }
    }
}