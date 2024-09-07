using Planner.Plans.Domain.Plans.Entities;

namespace Planner.Plans.Domain.Plans.Repositories;

public interface IPlanReadRepository
{
    Task<IReadOnlyCollection<Plan>> GetUserPlansAsync(int userId);
}
