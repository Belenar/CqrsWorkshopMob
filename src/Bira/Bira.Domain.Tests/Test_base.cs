using System;
using System.Collections.Generic;
using System.Linq;
using Bira.Domain.Commands;
using Bira.Domain.Domain;
using Bira.Domain.Events;
using Bira.Domain.Infrastructure;
using FluentAssertions;

namespace Bira.Domain.Tests
{
    public abstract class Test_base
    {
        private Event_message[] _history;
        private List<Event_message> _publishedEvents = new List<Event_message>();

        protected SprintId Sprint_1 => SprintId.From_value(new Guid("1A399E8B-C2C0-44D7-A84E-AE4122E6E5DC"));
        protected SprintId Sprint_2 => SprintId.From_value(new Guid("44C07730-1785-48CB-A7D9-280B8013CF99"));
        
        protected TaskId Task_1 => TaskId.From_value(new Guid("16D60A64-6653-4ABF-B9F2-EE619C7ECE4A"));
        protected TaskId Task_2 => TaskId.From_value(new Guid("CF7CA951-59BD-4D7B-8EA7-93BF3EA17BEA"));

        protected ProjectId Project_1 => ProjectId.From_value(new Guid("F901DB51-E8C5-45F3-97BF-4B62EA837A02"));

        protected void Then_expect(params Event_message[] expectedEvents)
        {
            _publishedEvents.Should().Equal(expectedEvents);
        }

        protected void When(object command)
        {
            var command_handler = new Command_handler((source) => _history.Where(_ => _.Source == source),  e => _publishedEvents.Add(e));
            command_handler.Handle(command);
        }

        protected Event_message Sprint_is_started(SprintId sprintId)
        {
            return new Event_message(sprintId.Value, new Sprint_is_started(sprintId));
        }

        protected Start_sprint Start_sprint(SprintId sprintId)
        {
            return new Start_sprint(sprintId);

        }

        protected Remove_task_from_sprint Remove_task_from_sprint(SprintId sprintId, TaskId taskId)
        {
            return new Remove_task_from_sprint(sprintId, taskId);
        }

        protected Event_message Task_is_committed_to_sprint(SprintId sprintId, TaskId taskId)
        {
            return new Event_message(sprintId.Value, new Task_is_committed_to_sprint(sprintId, taskId));
        }

        protected Event_message Task_is_removed_from_sprint(SprintId sprintId, TaskId taskId)
        {
            return new Event_message(sprintId.Value, new Task_is_removed_from_sprint(sprintId, taskId));
        }

        protected Event_message Sprint_is_planned(ProjectId projectId, SprintId sprintId)
        {
            return new Event_message(sprintId.Value, new Sprint_is_planned(projectId, sprintId));
        }

        protected Event_message Project_is_defined(ProjectId projectId)
        {
            return new Event_message(projectId.Value, new Project_is_defined(projectId));
        }

        protected Event_message Task_is_defined(TaskId taskId)
        {
            return new Event_message(taskId.Value, new Task_is_defined(taskId));
        }

        public void Given(params Event_message[] events)
        {
            _history = events;
        }

        protected Event_message Sprint_could_not_start(SprintId sprintId, Reason reason)
        {
            return new Event_message(sprintId.Value, new Sprint_could_not_start(sprintId, reason));
        }

        protected Event_message Sprint_is_closed(SprintId sprintId)
        {
            return new Event_message(sprintId.Value, new Sprint_is_closed(sprintId));
        }

        protected void No_tasks_committed_to_the_sprint(SprintId sprint1) { }
    }
}