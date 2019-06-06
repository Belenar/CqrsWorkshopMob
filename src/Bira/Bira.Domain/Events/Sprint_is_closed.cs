using Bira.Domain.Domain;

namespace Bira.Domain.Events
{
    public struct Sprint_is_closed
    {
        public readonly SprintId SprintId;

        public Sprint_is_closed(SprintId sprintId)
        {
            SprintId = sprintId;
        }
    }
}