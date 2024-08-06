using MediatR;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Planner.Challenges.Presentation.Endpoints.ChallengeMessages.Requests;
using Planner.Challenges.Application.Features.ChallengeMessages.Commands.AddChallengeMessage;
using Planner.Challenges.Application.Features.Challenges.Queries.GetChallengeByMessageId;
using Microsoft.AspNetCore.Routing;
using Microsoft.AspNetCore.Builder;
using Planner.Challenges.Presentation.Extensions;
using Microsoft.AspNetCore.Http;
using Planner.Challenges.Application.Features.Challenges.Models;

namespace Planner.Challenges.Presentation.Endpoints.ChallengeMessages;

public sealed class ChallengeMessageEndpoints
{
    public static void AddRoutes(IEndpointRouteBuilder app)
    {
        RouteGroupBuilder challengeMessageEndpointsGroup = app.MapGroup("api/challenge-messages");

        challengeMessageEndpointsGroup.MapPost("", AddChallengeMessages);
        challengeMessageEndpointsGroup.MapGet("{messageId}", GetChallengeByMessageId);
    }

    private static async Task<Results<ProblemHttpResult, Ok>> AddChallengeMessages(
        [FromBody] AddChallengeMessageRequest request,
        [FromServices] ISender sender,
        CancellationToken cancellationToken)
    {
        var command = new AddChallengeMessageCommand(request.ChallengeMessages, request.UserId);

        Common.Domain.Core.Primitives.Result.Result result = await sender.Send(command, cancellationToken);

        if (result.IsFailure)
        {
            return result.ToProblemDetails();
        }

        return TypedResults.Ok();
    }

    private static async Task<Results<ProblemHttpResult, Ok<ChallengeDto>>> GetChallengeByMessageId(
        [FromRoute] int messageId,
        [FromQuery] int userId,
        [FromServices] ISender sender,
        CancellationToken cancellationToken)
    {
        var query = new GetChallengeByMessageIdQuery(messageId, userId);
        Common.Domain.Core.Primitives.Result.Result<ChallengeDto> result = await sender.Send(query, cancellationToken);

        if (result.IsFailure)
        {
            return result.ToProblemDetails();
        }

        return TypedResults.Ok(result.Value);
    }
}
