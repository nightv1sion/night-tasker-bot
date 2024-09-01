using Microsoft.AspNetCore.Routing;

namespace Planner.Common.Presentation.Endpoints;

public interface IEndpoint
{
    void MapEndpoint(IEndpointRouteBuilder app);
}
