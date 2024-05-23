using MediatR;

namespace TaskTracker.Core.Application.Abstractions.Messaging;

public interface IEventHandler<in TEvent> : INotificationHandler<TEvent> 
    where TEvent : IEvent;