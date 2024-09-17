using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;
using Planner.Common.Presentation.Endpoints;
using Planner.Plans.Application.Plans.UpdatePlan;
using Planner.Plans.Presentation.Extensions;

namespace Planner.Plans.Presentation.Plans;

internal sealed class UpdatePlan : IEndpoint
{
    public void MapEndpoint(IEndpointRouteBuilder app)
    {
        app.MapPut("api/plans/{planId:guid}", Endpoint);
    }
    
    private static async Task<Results<ProblemHttpResult, NoContent>> Endpoint(
        [FromRoute] Guid planId,
        [FromBody] Request request,
        [FromServices] ISender sender)
    {
        var command = new UpdatePlanCommand(planId, request.Name, request.Description);
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
