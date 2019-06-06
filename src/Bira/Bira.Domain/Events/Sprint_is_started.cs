using System;
using Bira.Domain.Domain;

namespace Bira.Domain.Events
{
    public struct Sprint_is_started
    {
        public readonly SprintId SprintId;

        public Sprint_is_started(SprintId sprintId)
        {
            SprintId = sprintId;
        }
    }
}