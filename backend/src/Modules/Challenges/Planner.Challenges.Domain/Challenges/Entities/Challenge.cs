using Planner.Challenges.Domain.Core.Primitives;

namespace Planner.Challenges.Domain.Challenges.Entities;

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

    public int UserId { get; set; }

    public static Challenge Create(string name, string? description, int userId)
    {
        return new Challenge(name, description, userId);
    }

    public void UpdateName(string name)
    {
        Name = name;
    }

    public void UpdateDescription(string? description)
    {
        Description = description;
    }
}