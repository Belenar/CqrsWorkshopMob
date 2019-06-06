using Bira.Domain.Domain;

namespace Bira.Domain.Events
{
    public struct Sprint_is_planned
    {
        public readonly ProjectId ProjectId;
        public readonly SprintId SprintId;

        public Sprint_is_planned(ProjectId projectId, SprintId sprintId)
        {
            ProjectId = projectId;
            SprintId = sprintId;
        }
    }
}