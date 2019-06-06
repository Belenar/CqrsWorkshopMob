using System;
using System.Collections.Generic;
using System.Linq;
using Bira.Domain.Events;

namespace Bira.Domain.Domain
{
    public class Sprint
    {
        private readonly Action<object> _publish;
        private readonly SprintState _state;

        public Sprint(Action<object> publish, SprintState state)
        {
            _publish = publish;
            _state = state;
        }

        public void Start()
        {
            if (_state.HasTasks)
            {
                _publish(new Sprint_is_started(_state.Sprint));
            }
            else
            {
                _publish(new Sprint_could_not_start(_state.Sprint, Reason.No_tasks_in_sprint));
            }
        }

        public void Remove_task(TaskId task)
        {
            if (_state.Contains_task(task))
            {
                _publish(new Task_is_removed_from_sprint(_state.Sprint, task));
                if (_state.Has_no_tasks)
                {
                    _publish(new Sprint_is_closed(_state.Sprint));
                }
            }
        }
    }
}