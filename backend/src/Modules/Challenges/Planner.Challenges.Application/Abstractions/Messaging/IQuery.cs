﻿using MediatR;

namespace Planner.Challenges.Application.Abstractions.Messaging;

public interface IQuery<out TResponse> : IRequest<TResponse>;