using System;

namespace Bira.Domain.Domain
{
    public struct TaskId
    {
        private Guid _value;

        private TaskId(Guid value)
        {
            _value = value;
        }

        public Guid Value =>  _value;

        public static TaskId From_value(Guid id)
        {
            return new TaskId(id);
        }
    }
}