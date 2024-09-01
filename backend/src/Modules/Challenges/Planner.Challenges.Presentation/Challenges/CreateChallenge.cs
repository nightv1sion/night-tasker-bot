using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;
using Planner.Challenges.Application.Challenges.Commands.CreateChallenge;
using Planner.Challenges.Presentation.Extensions;
using Planner.Common.Presentation.Endpoints;

namespace Planner.Challenges.Presentation.Challenges;

internal sealed class CreateChallenge : IEndpoint
{
    public void MapEndpoint(IEndpointRouteBuilder app)
    {
        app.MapPost("api/challenges", Endpoint);
    }
    
    private static async Task<Results<ProblemHttpResult, Ok<Guid>>> Endpoint(
        [FromBody] Request request,
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
    
    internal sealed class Request 
    {
        public required string Name { get; init; }

        public string? Description { get; init; }

        public required int UserId { get; init; }
    }
}
