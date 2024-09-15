using Microsoft.Extensions.Logging;
using Planner.TelegramIntegration.Abstract;
using Telegram.Bot;

namespace Planner.TelegramIntegration.Services;

public class ReceiverService(ITelegramBotClient botClient, UpdateHandler updateHandler, ILogger<ReceiverServiceBase<UpdateHandler>> logger)
    : ReceiverServiceBase<UpdateHandler>(botClient, updateHandler, logger);
