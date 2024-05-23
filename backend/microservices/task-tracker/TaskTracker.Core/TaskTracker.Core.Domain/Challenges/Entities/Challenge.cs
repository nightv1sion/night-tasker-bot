using TaskTracker.Core.Domain.Core.Primitives;

namespace TaskTracker.Core.Domain.Challenges.Entities;

public sealed class Challenge : AggregateRoot
{
    private Challenge()
    {
    }

    private Challenge(
        string name,
        string? description,
        int userId) : base(Guid.NewGuid())
    {
        Name = name;
        Description = description;
        UserId = userId;
    }

    public string Name { get; private set; }

    public string? Description { get; private set; }

    public int UserId { get; private set; }

    public static Challenge Create(string name, string? description, int userId)
    {
        return new Challenge(name, description, userId);
    }
}