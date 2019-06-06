using System;

namespace Bira.Domain.Domain
{
    public struct SprintId
    {
        private Guid _value;

        private SprintId(Guid value)
        {
            _value = value;
        }

        public Guid Value => _value;

        public static SprintId From_value(Guid id)
        {
            return new SprintId(id);
        }
    }
}