using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;
using Planner.Challenges.Application.Challenges.Models;
using Planner.Challenges.Application.Challenges.Queries.GetUserChallenges;
using Planner.Common.Presentation.Endpoints;

namespace Planner.Challenges.Presentation.Challenges;

internal sealed class GetUserChallenges : IEndpoint
{
    public void MapEndpoint(IEndpointRouteBuilder app)
    {
        app.MapGet("api/challenges", Endpoint);
    }
    
    private static async Task<Ok<IReadOnlyCollection<Response>>> Endpoint(
        [FromQuery] int userId,
        [FromServices] ISender sender,
        CancellationToken cancellationToken)
    {
        var query = new GetUserChallengesQuery(userId);
        IReadOnlyCollection<ChallengeDto> result = await sender.Send(query, cancellationToken);

        IReadOnlyCollection<Response> response = result.Select(Response.FromDto).ToArray();
        
        return TypedResults.Ok(response);
    }

    internal sealed class Response
    {
        public required Guid Id { get; init; }

        public required string Name { get; init; }

        public required string? Description { get; set; }

        public required int UserId { get; set; }
        
        public static Response FromDto(ChallengeDto dto)
        {
            return new Response
            {
                Id = dto.Id,
                Name = dto.Name,
                Description = dto.Description,
                UserId = dto.UserId
            };
        }
    }
}
