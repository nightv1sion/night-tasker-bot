using System.Reflection;

namespace Planner.Challenges.Presentation;

public sealed class AssemblyReference
{
    public static readonly Assembly Assembly = typeof(AssemblyReference).Assembly;
}
