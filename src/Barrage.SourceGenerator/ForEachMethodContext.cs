using Microsoft.CodeAnalysis;

namespace Barrage.SourceGenerator;

internal record ForEachMethodContext
{
    public ForEachMethod? Metadata { get; set; }
    public required DiagnosticReporter DiagnosticReporter { get; init; }
    public required SemanticModel Model { get; init; }
}

public class ForEachMethod : IEquatable<ForEachMethod>
{
    public required ForEachMethodParameter[] Parameters { get; init; }

    public bool Equals(ForEachMethod other)
    {
        return Parameters.SequenceEqual(other.Parameters);
    }

    public override bool Equals(object obj)
    {
        return obj is ForEachMethod other && Equals(other);
    }

    public override int GetHashCode()
    {
        if (Parameters.Length == 0) return 0;
        var hashCode = Parameters[0].GetHashCode();
        for (int i = 1; i < Parameters.Length; i++)
        {
            hashCode ^= Parameters[i].GetHashCode();
        }
        return hashCode;
    }
}

public record ForEachMethodParameter
{
    public required string FullTypeName { get; init; }
    public required bool IsEntity { get; init; }
    public required bool IsRef { get; init; }
    public required bool IsIn { get; init; }
}