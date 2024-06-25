using Carter;
using MediatR;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using TaskTracker.Core.Application.Features.ChallengeMessages.Commands.AddChallengeMessage;
using TaskTracker.Core.Application.Features.Challenges.Models;
using TaskTracker.Core.Application.Features.Challenges.Queries.GetChallengeByMessageId;
using TaskTracker.Presentation.Api.Endpoints.ChallengeMessages.Requests;
using TaskTracker.Presentation.Api.Extensions;

namespace TaskTracker.Presentation.Api.Endpoints.ChallengeMessages;

public sealed class ChallengeMessageEndpoints : ICarterModule
{
    public void AddRoutes(IEndpointRouteBuilder app)
    {
        var challengeMessageEndpointsGroup = app.MapGroup("api/challenge-messages");

        challengeMessageEndpointsGroup.MapPost("", AddChallengeMessages);
        challengeMessageEndpointsGroup.MapGet("{messageId}", GetChallengeByMessageId);
    }

    private async Task<Results<ProblemHttpResult, Ok>> AddChallengeMessages(
        [FromBody] AddChallengeMessageRequest request,
        [FromServices] ISender sender,
        CancellationToken cancellationToken)
    {
        var command = new AddChallengeMessageCommand(request.ChallengeMessages, request.UserId);

        var result = await sender.Send(command, cancellationToken);

        if (result.IsFailure)
        {
            return result.ToProblemDetails();
        }

        return TypedResults.Ok();
    }

    private async Task<Results<ProblemHttpResult, Ok<ChallengeDto>>> GetChallengeByMessageId(
        [FromRoute] int messageId,
        [FromQuery] int userId,
        [FromServices] ISender sender,
        CancellationToken cancellationToken)
    {
        var query = new GetChallengeByMessageIdQuery(messageId, userId);
        var result = await sender.Send(query, cancellationToken);

        if (result.IsFailure)
        {
            return result.ToProblemDetails();
        }

        return TypedResults.Ok(result.Value);
    }
}