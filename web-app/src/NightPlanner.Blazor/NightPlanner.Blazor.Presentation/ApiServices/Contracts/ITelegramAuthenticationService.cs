using NightPlanner.Blazor.Presentation.Models;

namespace NightPlanner.Blazor.Presentation.ApiServices.Contracts;

public interface ITelegramAuthenticationService
{
    Task<TelegramUser> GetTelegramUser();
}