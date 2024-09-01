using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;
using Planner.Challenges.Application.Challenges.Commands.UpdateChallenge;
using Planner.Challenges.Presentation.Extensions;
using Planner.Common.Presentation.Endpoints;

namespace Planner.Challenges.Presentation.Challenges;

internal sealed class UpdateChallenge : IEndpoint
{
    public void MapEndpoint(IEndpointRouteBuilder app)
    {
        app.MapPut("api/challenges/{challengeId:guid}", Endpoint);
    }
    
    private static async Task<Results<ProblemHttpResult, NoContent>> Endpoint(
        [FromRoute] Guid challengeId,
        [FromBody] Request request,
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
    
    internal sealed class Request
    {
        public required string Name { get; init; }

        public string? Description { get; init; }
    }
}
