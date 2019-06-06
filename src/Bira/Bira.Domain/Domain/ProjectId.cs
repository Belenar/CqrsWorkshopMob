using System;

namespace Bira.Domain.Domain
{
    public struct ProjectId
    {
        private Guid _value;

        private ProjectId(Guid value)
        {
            _value = value;
        }

        public Guid Value => _value;

        public static ProjectId From_value(Guid id)
        {
            return new ProjectId(id);
        }
    }
}