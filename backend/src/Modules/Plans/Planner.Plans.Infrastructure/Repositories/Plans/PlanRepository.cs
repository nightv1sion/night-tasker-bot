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
            .Include(plan => plan.Reminders)
            .FirstOrDefaultAsync(plan => plan.Id == planId, cancellationToken);
    }
}
