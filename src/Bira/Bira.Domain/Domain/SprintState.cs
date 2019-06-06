using System.Collections.Generic;
using System.Linq;
using Bira.Domain.Events;

namespace Bira.Domain.Domain
{
    public class SprintState
    {
        public List<TaskId> All_Tasks = new List<TaskId>();

        public SprintState(IEnumerable<object> events)
        {
            foreach (var e in events)
            {
                switch (e)
                {
                    case Sprint_is_planned sprint_is_planned:
                        Apply(sprint_is_planned);
                        break;
                    case Task_is_committed_to_sprint task_is_committed_to_sprint:
                        Apply(task_is_committed_to_sprint);
                        break;
                    case Task_is_removed_from_sprint task_is_removed_from_sprint:
                        Apply(task_is_removed_from_sprint);
                        break;
                }
            }
        }

        public SprintId Sprint;

        public bool HasTasks => All_Tasks.Any();
        public bool Has_no_tasks => !HasTasks;

        public bool Contains_task(TaskId taskId) => All_Tasks.Contains(taskId);

        public void Project(object @event)
        {
            Apply((dynamic) @event);
        }

        private void Apply(object @event)
        {

        }

        private void Apply(Sprint_is_planned @event)
        {
            Sprint = @event.SprintId;
        }

        private void Apply(Task_is_committed_to_sprint @event)
        {
            All_Tasks.Add(@event.TaskId);
        }

        private void Apply(Task_is_removed_from_sprint @event)
        {
            All_Tasks.Remove(@event.TaskId);
        }
    }
}