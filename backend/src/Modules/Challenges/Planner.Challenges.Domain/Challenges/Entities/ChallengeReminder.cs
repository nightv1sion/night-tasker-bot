using Planner.Common.Domain.Core.Primitives;

namespace Planner.Challenges.Domain.Challenges.Entities;

public sealed class ChallengeReminder : Entity
{
    private ChallengeReminder()
    {
        
    }

    public static ChallengeReminder Create(
        Guid challengeId,
        DateTimeOffset remindAt)
    {
        return new ChallengeReminder
        {
            ChallengeId = challengeId,
            RemindAt = remindAt,
            CreatedAt = DateTimeOffset.Now,
        };
    }

    public Guid ChallengeId { get; private set; }
    
    public DateTimeOffset RemindAt { get; private set; }

    public DateTimeOffset CreatedAt { get; private set; }
}
