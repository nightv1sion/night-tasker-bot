using System.Reflection;

namespace Planner.Notifications.Presentation;

public sealed class AssemblyReference
{
    public static readonly Assembly Assembly = typeof(AssemblyReference).Assembly;
}
