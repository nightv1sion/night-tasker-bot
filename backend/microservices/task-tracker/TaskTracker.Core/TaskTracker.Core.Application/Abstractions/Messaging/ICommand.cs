using MediatR;

namespace TaskTracker.Core.Application.Abstractions.Messaging;

public interface ICommand<out TResponse> : IRequest<TResponse>;

public interface ICommand : IRequest;