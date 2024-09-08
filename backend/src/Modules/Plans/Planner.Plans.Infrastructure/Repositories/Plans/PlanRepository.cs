using Microsoft.EntityFrameworkCore;
using Planner.Plans.Domain.Plans.Entities;
using Planner.Plans.Domain.Plans.Repositories;

namespace Planner.Plans.Infrastructure.Repositories.Plans;

internal sealed class PlanRepository(
    PlansDbContext dbContext) : GenericRepository<Plan>(dbContext), IPlanRepository
{
    public async Task<Plan?> TryGetByIdAsync(Guid planId, CancellationToken cancellationToken)
    {
        return await DbContext
            .Set<Plan>()
            .FirstOrDefaultAsync(plan => plan.Id == planId, cancellationToken);
    }

    public async Task<Plan?> TryGetByAsync(Guid planId, int userId, CancellationToken cancellationToken)
    {
        return await DbContext
            .Set<Plan>()
            .Where(x => x.UserId == userId)
            .Where(x => x.Id == planId)
            .FirstOrDefaultAsync(cancellationToken);
    }
}
