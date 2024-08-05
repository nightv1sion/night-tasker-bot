using MediatR;

namespace Planner.Common.Application.Messaging;

public interface IQuery<out TResponse> : IRequest<TResponse>;