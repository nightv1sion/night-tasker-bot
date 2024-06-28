namespace NightPlanner.Blazor.Presentation.ApiServices.Contracts;

public interface IJsInteractor
{
    Task<string> GetUserInitData();
}