using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;
using Planner.Common.Presentation.Endpoints;
using Planner.Plans.Application.Plans.CreatePlan;
using Planner.Plans.Presentation.Extensions;

namespace Planner.Plans.Presentation.Plans;

internal sealed class CreatePlan : IEndpoint
{
    public void MapEndpoint(IEndpointRouteBuilder app)
    {
        app.MapPost("api/plans", Endpoint);
    }
    
    private static async Task<Results<ProblemHttpResult, Ok<Guid>>> Endpoint(
        [FromBody] Request request,
        [FromServices] ISender sender)
    {
        var command = new CreatePlanCommand(request.Name, request.Description, request.UserId);
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

        public required long UserId { get; init; }
    }
}
