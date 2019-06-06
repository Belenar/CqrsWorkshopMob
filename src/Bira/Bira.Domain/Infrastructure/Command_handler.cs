using System;
using System.Collections.Generic;
using System.Linq;
using Bira.Domain.Commands;
using Bira.Domain.Domain;

namespace Bira.Domain.Infrastructure
{
    public class Command_handler
    {
        private readonly Func<Guid,IEnumerable<Event_message>> _events;
        private Action<Event_message> _publish;

        public Command_handler(Func<Guid, IEnumerable<Event_message>> events, Action<Event_message> publish)
        {
            _events = events;
            _publish = publish;
        }

        public void Handle(object command)
        {
            switch (command)
            {
                case Start_sprint cmd:
                    {
                        Action<object> publish = (e) => { _publish(new Event_message(cmd.SprintId.Value, e)); };
                        new Sprint(publish, new SprintState(_events(cmd.SprintId.Value).Select(_ => _.Payload)))
                            .Start();
                    }
                    break;
                case Remove_task_from_sprint cmd:
                    {
                        var state = new SprintState(_events(cmd.SprintId.Value).Select(_ => _.Payload));
                        Action<object> publish = (e) =>
                        {
                            state.Project(e);
                            _publish(new Event_message(cmd.SprintId.Value, e));
                        };
                        new Sprint(publish, state)
                            .Remove_task(cmd.TaskId);
                    }
                    break;
            }
            
        }
    }
}