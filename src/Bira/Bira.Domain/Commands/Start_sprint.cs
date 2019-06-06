using Bira.Domain.Domain;

namespace Bira.Domain.Commands
{
    public struct Start_sprint
    {
        public readonly SprintId SprintId;

        public Start_sprint(SprintId sprintId)
        {
            SprintId = sprintId;
        }
    }
}