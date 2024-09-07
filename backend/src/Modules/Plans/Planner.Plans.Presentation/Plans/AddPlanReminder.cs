using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;
using Planner.Common.Domain.Core.Primitives.Result;
using Planner.Common.Presentation.Endpoints;
using Planner.Plans.Application.Plans.Commands.AddReminder;
using Planner.Plans.Presentation.Extensions;

namespace Planner.Plans.Presentation.Plans;

internal sealed class AddPlanReminder : IEndpoint
{
    public void MapEndpoint(IEndpointRouteBuilder app)
    {
        app.MapPost("api/plans/{planId}/reminders", Endpoint);
    }

    private static async Task<Results<ProblemHttpResult, Ok<Guid>>> Endpoint(
        [FromRoute] Guid planId,
        [FromBody] Request request,
        [FromServices] ISender sender,
        CancellationToken cancellationToken)
    {
        var command = new AddPlanReminderCommand(
            request.UserId,
            planId,
            request.RemindAt);

        Result<Guid> result = await sender.Send(command, cancellationToken);

        if (result.IsFailure)
        {
            return result.ToProblemDetails();
        }

        return TypedResults.Ok(result.Value);

    }

    internal sealed record Request(DateTimeOffset RemindAt, int UserId);
}
