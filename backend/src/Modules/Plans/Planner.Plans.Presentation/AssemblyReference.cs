using System.Reflection;

namespace Planner.Plans.Presentation;

public sealed class AssemblyReference
{
    public static readonly Assembly Assembly = typeof(AssemblyReference).Assembly;
}
