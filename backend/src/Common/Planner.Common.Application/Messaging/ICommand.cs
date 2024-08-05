﻿using MediatR;

namespace Planner.Common.Application.Messaging;

public interface ICommand<out TResponse> : IRequest<TResponse>;

public interface ICommand : IRequest;