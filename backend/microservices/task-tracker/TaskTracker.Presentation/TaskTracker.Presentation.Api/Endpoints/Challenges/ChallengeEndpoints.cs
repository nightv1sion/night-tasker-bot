using Carter;
using MediatR;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using TaskTracker.Core.Application.Features.Challenges.Commands.CreateChallenge;
using TaskTracker.Core.Application.Features.Challenges.Models;
using TaskTracker.Core.Application.Features.Challenges.Queries.GetUserChallenges;
using TaskTracker.Presentation.Api.Endpoints.Challenges.Requests;
using TaskTracker.Presentation.Api.Extensions;

namespace TaskTracker.Presentation.Api.Endpoints.Challenges;

public sealed class ChallengeEndpoints : ICarterModule
{
    public void AddRoutes(IEndpointRouteBuilder app)
    {
        var challengeEndpointsGroup = app.MapGroup("api/challenges");

        challengeEndpointsGroup.MapGet("", GetUserChallenges);
        challengeEndpointsGroup.MapPost("", CreateChallenge);
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

        if (result.IsFailure) return result.ToProblemDetails();

        return TypedResults.Ok(result.Value);
    }
}