using TaskTracker.Core.Domain.Core.Utility;

namespace TaskTracker.Core.Domain.Core.Primitives;

public abstract class Entity
{
    protected Entity(Guid id)
    {
        Ensure.NotEmpty(id, "The identifier is required", nameof(id));

        Id = id;
    }

    protected Entity()
    {
        
    }

    public Guid Id { get; private set; }
}