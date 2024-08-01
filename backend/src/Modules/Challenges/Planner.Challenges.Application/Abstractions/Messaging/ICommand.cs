using MediatR;

namespace Planner.Challenges.Application.Abstractions.Messaging;

public interface ICommand<out TResponse> : IRequest<TResponse>;

public interface ICommand : IRequest;