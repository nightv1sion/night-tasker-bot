namespace Planner.Notifications.Infrastructure.Infrastructure;

public sealed class ConnectionString(string value)
{
    public const string SettingsKey = "Database";

    public string Value { get; set; } = value;
}