using System.Text.Json;
using NightPlanner.Blazor.Presentation.ApiServices.Contracts;
using NightPlanner.Blazor.Presentation.Models;

namespace NightPlanner.Blazor.Presentation.ApiServices.Implementations;

internal sealed class TelegramAuthenticationService : ITelegramAuthenticationService
{
    private readonly IJsInteractor _jsInteractor;
    private TelegramUser? _user;

    public TelegramAuthenticationService(IJsInteractor jsInteractor)
    {
        _jsInteractor = jsInteractor ?? throw new ArgumentNullException(nameof(jsInteractor));
    }
    
    public async Task<TelegramUser> GetTelegramUser(CancellationToken cancellationToken)
    {
        if (_user is not null)
        {
            return _user;
        }
        
        var initData = await _jsInteractor.GetUserInitData(cancellationToken);
        var initDataObject = JsonSerializer.Deserialize<TelegramInitData>(initData, new JsonSerializerOptions()
        {
            PropertyNamingPolicy = JsonNamingPolicy.SnakeCaseLower,
        });

        if (initDataObject is null)
        {
            throw new InvalidOperationException("Telegram user can not be null");
        }
        
        _user = initDataObject.User;
        return _user;
    }

    public async Task<int> GetTelegramUserId(CancellationToken cancellationToken)
    {
        var user = await GetTelegramUser(cancellationToken);
        return user.Id;
    }
}