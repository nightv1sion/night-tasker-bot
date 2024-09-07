namespace Planner.Plans.Application.Abstractions.Data;

public interface IUnitOfWork
{
    Task<int> SaveChangesAsync(CancellationToken cancellationToken);
}
