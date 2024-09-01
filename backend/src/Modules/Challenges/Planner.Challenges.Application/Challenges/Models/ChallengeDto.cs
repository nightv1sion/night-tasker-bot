using Planner.Challenges.Domain.Challenges.Entities;

namespace Planner.Challenges.Application.Challenges.Models;

public sealed record ChallengeDto(
    Guid Id,
    string Name,
    string? Description,
    int UserId,
    IReadOnlyCollection<ChallengeDto.ReminderModel> Reminders)
{
    public sealed record ReminderModel(
        Guid Id,
        DateTimeOffset RemindAt);
    
    public static ChallengeDto FromEntity(Challenge challenge)
    {
        return new ChallengeDto(
            challenge.Id,
            challenge.Name,
            challenge.Description,
            challenge.UserId,
            challenge.Reminders.Select(x => new ReminderModel(
                x.Id,
                x.RemindAt))
                .ToArray());
    }
};
