using Planner.TelegramIntegration.Abstract;
using Planner.TelegramIntegration.PublicApi;

namespace Planner.TelegramIntegration.Public;

internal sealed class TelegramIntegrationApi(IMessageSender messageSender) : ITelegramIntegrationApi
{
    public async Task SendMessage(long userId, string message, CancellationToken cancellationToken)
    {
        await messageSender.SendMessage(userId, message, cancellationToken);
    }
}
