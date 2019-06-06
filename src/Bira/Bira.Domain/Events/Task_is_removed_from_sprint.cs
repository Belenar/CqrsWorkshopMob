using Bira.Domain.Domain;

namespace Bira.Domain.Events
{
    public struct Task_is_removed_from_sprint
    {
        public readonly SprintId SprintId;
        public readonly TaskId TaskId;

        public Task_is_removed_from_sprint(SprintId sprintId, TaskId taskId)
        {
            SprintId = sprintId;
            TaskId = taskId;
        }
    }
}