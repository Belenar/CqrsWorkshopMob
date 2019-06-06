using Bira.Domain.Domain;

namespace Bira.Domain.Events
{
    public struct Task_is_committed_to_sprint
    {
        public readonly SprintId SprintId;
        public readonly TaskId TaskId;

        public Task_is_committed_to_sprint(SprintId sprintId, TaskId taskId)
        {
            SprintId = sprintId;
            TaskId = taskId;
        }
    }
}