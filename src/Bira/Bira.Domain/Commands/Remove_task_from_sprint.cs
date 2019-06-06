using Bira.Domain.Domain;

namespace Bira.Domain.Commands
{
    public struct Remove_task_from_sprint
    {
        public readonly SprintId SprintId;
        public readonly TaskId TaskId;

        public Remove_task_from_sprint(SprintId sprintId, TaskId taskId)
        {
            SprintId = sprintId;
            TaskId = taskId;
        }
    }
}