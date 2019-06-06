using Bira.Domain.Domain;

namespace Bira.Domain.Events
{
    public struct Sprint_could_not_start
    {
        public readonly SprintId SprintId;
        public readonly Reason Reason;

        public Sprint_could_not_start(SprintId sprintId, Reason reason)
        {
            SprintId = sprintId;
            Reason = reason;
        }
    }

    public enum Reason
    {
        No_tasks_in_sprint
    }
}