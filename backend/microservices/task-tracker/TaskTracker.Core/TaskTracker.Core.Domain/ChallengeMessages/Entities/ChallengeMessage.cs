using TaskTracker.Core.Domain.Challenges.Entities;
using TaskTracker.Core.Domain.Core.Primitives;

namespace TaskTracker.Core.Domain.ChallengeMessages.Entities;

public sealed class ChallengeMessage : AggregateRoot
{
    private ChallengeMessage()
    {
    }

    private ChallengeMessage(
        int messageId,
        Guid challengeId,
        DateTimeOffset sentAt) : base(Guid.NewGuid())
    {
        MessageId = messageId;
        ChallengeId = challengeId;
        SentAt = sentAt;
    }

    public Guid ChallengeId { get; private set; }

    public DateTimeOffset SentAt { get; private set; }

    public Challenge Challenge { get; private set; } = null!;

    public int MessageId { get; set; }

    public static ChallengeMessage Create(
        int messageId,
        Guid challengeId)
    {
        return new ChallengeMessage(messageId, challengeId, DateTimeOffset.Now);
    }
}