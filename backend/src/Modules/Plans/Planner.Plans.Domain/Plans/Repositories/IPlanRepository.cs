using Planner.Plans.Domain.Plans.Entities;

namespace Planner.Plans.Domain.Plans.Repositories;

public interface IPlanRepository
{
    Task<Plan?> TryGetByIdAsync(Guid planId, CancellationToken cancellationToken);

    Task<Plan?> TryGetByAsync(Guid planId, int userId, CancellationToken cancellationToken);

    Task InsertAsync(Plan entity, CancellationToken cancellationToken);
    
    void Update(Plan entity);
    
    void Remove(Plan entity);
}
