using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;
using Planner.Challenges.Application.Features.Challenges.Commands.CreateChallenge;
using Planner.Challenges.Application.Features.Challenges.Commands.UpdateChallenge;
using Planner.Challenges.Application.Features.Challenges.Models;
using Planner.Challenges.Application.Features.Challenges.Queries.GetUserChallenges;
using Planner.Challenges.Presentation.Endpoints.Challenges.Requests;
using Planner.Challenges.Presentation.Extensions;

namespace Planner.Challenges.Presentation.Endpoints.Challenges;

public sealed class ChallengeEndpoints
{
    public static void AddRoutes(IEndpointRouteBuilder app)
    {
        RouteGroupBuilder challengeEndpointsGroup = app.MapGroup("api/challenges");

        challengeEndpointsGroup.MapGet("", GetUserChallenges);
        challengeEndpointsGroup.MapPost("", CreateChallenge);
        challengeEndpointsGroup.MapPut("{challengeId:guid}", UpdateChallenge);
    }

    private static async Task<Ok<IReadOnlyCollection<ChallengeDto>>> GetUserChallenges(
        [FromQuery] int userId,
        [FromServices] ISender sender,
        CancellationToken cancellationToken)
    {
        var query = new GetUserChallengesQuery(userId);
        IReadOnlyCollection<ChallengeDto> result = await sender.Send(query, cancellationToken);

        return TypedResults.Ok(result);
    }

    private static async Task<Results<ProblemHttpResult, Ok<Guid>>> CreateChallenge(
        [FromBody] CreateChallengeRequest request,
        [FromServices] ISender sender)
    {
        var command = new CreateChallengeCommand(request.Name, request.Description, request.UserId);
        Common.Domain.Core.Primitives.Result.Result<Guid> result = await sender.Send(command);

        if (result.IsFailure)
        {
            return result.ToProblemDetails();
        }

        return TypedResults.Ok(result.Value);
    }

    private static async Task<Results<ProblemHttpResult, NoContent>> UpdateChallenge(
        [FromRoute] Guid challengeId,
        [FromBody] UpdateChallengeRequest request,
        [FromServices] ISender sender)
    {
        var command = new UpdateChallengeCommand(challengeId, request.Name, request.Description);
        Common.Domain.Core.Primitives.Result.Result result = await sender.Send(command);

        if (result.IsFailure)
        {
            return result.ToProblemDetails();
        }

        return TypedResults.NoContent();
    }
}
