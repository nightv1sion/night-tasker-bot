using MediatR;

namespace TaskTracker.Core.Application.Abstractions.Messaging;

public interface IQuery<out TResponse> : IRequest<TResponse>;