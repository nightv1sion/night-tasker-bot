using Microsoft.JSInterop;
using NightPlanner.Blazor.Presentation.ApiServices.Contracts;

namespace NightPlanner.Blazor.Presentation.ApiServices.Implementations;

internal sealed class JsInteractor : IJsInteractor
{
    private readonly IJSRuntime _jsRuntime;

    public JsInteractor(IJSRuntime jsRuntime)
    {
        _jsRuntime = jsRuntime ?? throw new ArgumentNullException(nameof(jsRuntime));
    }
    public async Task<string> GetUserInitData(CancellationToken cancellationToken)
    {
        return await _jsRuntime.InvokeAsync<string>("getTelegramInitData", cancellationToken);
    }
}