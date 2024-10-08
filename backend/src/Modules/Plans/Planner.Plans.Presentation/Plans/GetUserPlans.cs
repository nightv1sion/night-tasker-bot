using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;
using Planner.Common.Presentation.Endpoints;
using Planner.Plans.Application.Plans.GetUserPlans;

namespace Planner.Plans.Presentation.Plans;

internal sealed class GetUserPlans : IEndpoint
{
    public void MapEndpoint(IEndpointRouteBuilder app)
    {
        app.MapGet("api/plans", Endpoint);
    }
    
    private static async Task<Ok<IReadOnlyCollection<Response>>> Endpoint(
        [FromQuery] long userId,
        [FromServices] ISender sender,
        CancellationToken cancellationToken)
    {
        var query = new GetUserPlansQuery(userId);
        IReadOnlyCollection<PlanDto> result = await sender.Send(query, cancellationToken);

        IReadOnlyCollection<Response> response = result.Select(Response.FromDto).ToArray();
        
        return TypedResults.Ok(response);
    }

    internal sealed class Response
    {
        public required Guid Id { get; init; }

        public required string Name { get; init; }

        public required string? Description { get; set; }

        public required long UserId { get; set; }

        public required IReadOnlyCollection<ReminderModel> Reminders { get; set; }
        
        public sealed class ReminderModel 
        {
            public required Guid Id { get; init; }

            public required DateTimeOffset RemindAt { get; init; }
        }
        
        public static Response FromDto(PlanDto dto)
        {
            return new Response
            {
                Id = dto.Id,
                Name = dto.Name,
                Description = dto.Description,
                UserId = dto.UserId,
                Reminders = dto.Reminders
                    .Select(x => new ReminderModel
                    {
                        Id = x.Id,
                        RemindAt = x.RemindAt
                    })
                    .ToArray()
            };
        }
    }
}
