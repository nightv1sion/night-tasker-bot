using Planner.TelegramIntegration.Abstract;
using Telegram.Bot;
using Telegram.Bot.Types;

namespace Planner.TelegramIntegration.Services;

internal sealed class MessageSender(ITelegramBotClient bot) : IMessageSender
{
    public async Task SendMessage(long destinationUserId, string message, CancellationToken cancellationToken)
    {
        ChatId chatId = new(destinationUserId);
        await bot.SendTextMessageAsync(chatId, message, cancellationToken: cancellationToken);
    }
}
