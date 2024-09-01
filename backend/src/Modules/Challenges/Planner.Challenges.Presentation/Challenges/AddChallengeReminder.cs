using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;
using Planner.Challenges.Application.Challenges.Commands.AddReminder;
using Planner.Challenges.Presentation.Extensions;
using Planner.Common.Domain.Core.Primitives.Result;
using Planner.Common.Presentation.Endpoints;

namespace Planner.Challenges.Presentation.Challenges;

internal sealed class AddChallengeReminder : IEndpoint
{
    public void MapEndpoint(IEndpointRouteBuilder app)
    {
        app.MapPost("api/challenges/{challengeId}/reminders", Endpoint);
    }

    private static async Task<Results<ProblemHttpResult, Ok<Guid>>> Endpoint(
        [FromRoute] Guid challengeId,
        [FromBody] Request request,
        [FromServices] ISender sender,
        CancellationToken cancellationToken)
    {
        var command = new AddChallengeReminderCommand(
            request.UserId,
            challengeId,
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
