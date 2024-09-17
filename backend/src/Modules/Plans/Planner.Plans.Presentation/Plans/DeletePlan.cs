using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;
using Planner.Common.Domain.Core.Primitives.Result;
using Planner.Common.Presentation.Endpoints;
using Planner.Plans.Application.Plans.DeletePlan;
using Planner.Plans.Presentation.Extensions;

namespace Planner.Plans.Presentation.Plans;

internal sealed class DeletePlan : IEndpoint
{
    public void MapEndpoint(IEndpointRouteBuilder app)
    {
        app.MapDelete("api/plans/{planId:guid}", Endpoint);
    }
    
    private static async Task<Results<ProblemHttpResult, NoContent>> Endpoint(
        [FromRoute] Guid planId,
        [FromBody] Request request,
        [FromServices] ISender sender,
        CancellationToken cancellationToken)
    {
        var command = new DeletePlanCommand(
            request.UserId,
            planId);

        Result result = await sender.Send(command, cancellationToken);

        if (result.IsFailure)
        {
            return result.ToProblemDetails();
        }

        return TypedResults.NoContent();
    }
    
    internal sealed record Request(int UserId);
}
