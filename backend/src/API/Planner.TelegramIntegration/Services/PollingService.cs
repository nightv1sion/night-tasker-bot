using Microsoft.Extensions.Logging;
using Planner.TelegramIntegration.Abstract;

namespace Planner.TelegramIntegration.Services;

public class PollingService(IServiceProvider serviceProvider, ILogger<PollingService> logger)
    : PollingServiceBase<ReceiverService>(serviceProvider, logger);
