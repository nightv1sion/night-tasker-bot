using Carter;
using MediatR;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Planner.Challenges.Presentation.Endpoints.Challenges.Requests;

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

    private async Task<Ok<IReadOnlyCollection<ChallengeDto>>> GetUserChallenges(
        [FromQuery] int userId,
        [FromServices] ISender sender,
        CancellationToken cancellationToken)
    {
        var query = new GetUserChallengesQuery(userId);
        var result = await sender.Send(query, cancellationToken);
        return TypedResults.Ok(result);
    }

    private async Task<Results<ProblemHttpResult, Ok<Guid>>> CreateChallenge(
        [FromBody] CreateChallengeRequest request,
        [FromServices] ISender sender)
    {
        var command = new CreateChallengeCommand(request.Name, request.Description, request.UserId);
        var result = await sender.Send(command);

        if (result.IsFailure)
        {
            return result.ToProblemDetails();
        }

        return TypedResults.Ok(result.Value);
    }

    private async Task<Results<ProblemHttpResult, NoContent>> UpdateChallenge(
        [FromRoute] Guid challengeId,
        [FromBody] UpdateChallengeRequest request,
        [FromServices] ISender sender)
    {
        var command = new UpdateChallengeCommand(challengeId, request.Name, request.Description);
        var result = await sender.Send(command);

        if (result.IsFailure)
        {
            return result.ToProblemDetails();
        }

        return TypedResults.NoContent();
    }
}
