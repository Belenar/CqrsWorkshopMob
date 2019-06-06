using Bira.Domain.Domain;

namespace Bira.Domain.Events
{
    public struct Project_is_defined
    {
        public readonly ProjectId ProjectId;

        public Project_is_defined(ProjectId projectId)
        {
            ProjectId = projectId;
        }
    }
}