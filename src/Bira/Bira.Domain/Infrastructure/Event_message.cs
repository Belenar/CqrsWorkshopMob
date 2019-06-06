using System;
using System.Net.Http.Headers;

namespace Bira.Domain.Infrastructure
{
    public struct Event_message
    {
        public readonly Guid Source;
        public readonly object Payload;

        public Event_message(Guid source, object payload)
        {
            Source = source;
            Payload = payload;
        }
    }
}