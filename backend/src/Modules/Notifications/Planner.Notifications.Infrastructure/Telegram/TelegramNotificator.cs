using Planner.Notifications.Application.Abstractions;
using Planner.TelegramIntegration.PublicApi;

namespace Planner.Notifications.Infrastructure.Telegram;

internal sealed class TelegramNotificator(ITelegramIntegrationApi telegramIntegrationApi) : ITelegramNotificator
{
    public async Task SendNotification(long destinationUserId, string message, CancellationToken cancellationToken)
    {
        await telegramIntegrationApi.SendMessage(destinationUserId, message, cancellationToken);
    }
}
