namespace Planner.TelegramIntegration.PublicApi;

public interface ITelegramIntegrationApi
{
    Task SendMessage(long userId, string message, CancellationToken cancellationToken);
}
