using MediatR;

namespace Planner.Challenges.Application.Abstractions.Messaging;

public interface IEventHandler<in TEvent> : INotificationHandler<TEvent>
    where TEvent : IEvent;