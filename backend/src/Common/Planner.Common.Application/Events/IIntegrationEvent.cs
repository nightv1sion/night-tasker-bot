﻿namespace Planner.Common.Application.Events;

public interface IIntegrationEvent
{
    Guid Id { get; }

    DateTimeOffset OccurredAt { get; }
}
