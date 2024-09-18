namespace Planner.TelegramIntegration.Abstract;

public interface IMessageSender
{
    Task SendMessage(long destinationUserId, string message, CancellationToken cancellationToken);
}
