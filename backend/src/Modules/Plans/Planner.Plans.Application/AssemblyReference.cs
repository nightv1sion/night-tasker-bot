using System.Reflection;

namespace Planner.Plans.Application;

public static class AssemblyReference
{
    public static readonly Assembly Assembly = typeof(AssemblyReference).Assembly;
}
