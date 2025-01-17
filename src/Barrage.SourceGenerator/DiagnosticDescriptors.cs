using Microsoft.CodeAnalysis;

namespace Barrage.SourceGenerator;

internal sealed class DiagnosticReporter
{
    List<Diagnostic>? diagnostics;

    public bool HasDiagnostics => diagnostics != null && diagnostics.Count != 0;

    public void ReportDiagnostic(DiagnosticDescriptor diagnosticDescriptor, Location location, params object?[]? messageArgs)
    {
        var diagnostic = Diagnostic.Create(diagnosticDescriptor, location, messageArgs);
        diagnostics ??= [];
        diagnostics.Add(diagnostic);
    }

    public void ReportToContext(SourceProductionContext context)
    {
        if (diagnostics != null)
        {
            foreach (var item in diagnostics)
            {
                context.ReportDiagnostic(item);
            }
        }
    }
}

public static class DiagnosticDescriptors
{
    const string Category = "GenerateBarrageForEach";

    public static void ReportDiagnostic(this SourceProductionContext context, DiagnosticDescriptor diagnosticDescriptor, Location location, params object?[]? messageArgs)
    {
        var diagnostic = Diagnostic.Create(diagnosticDescriptor, location, messageArgs);
        context.ReportDiagnostic(diagnostic);
    }

    public static DiagnosticDescriptor Create(int id, string message)
    {
        return Create(id, message, message);
    }

    public static DiagnosticDescriptor Create(int id, string title, string messageFormat)
    {
        return new DiagnosticDescriptor(
            id: "BARRAGE" + id.ToString("000"),
            title: title,
            messageFormat: messageFormat,
            category: Category,
            defaultSeverity: DiagnosticSeverity.Error,
            isEnabledByDefault: true);
    }

    public static DiagnosticDescriptor RequireQueryAndMethod { get; } = Create(
        1,
        "world.ForEach requires EntiryQuery query and lambda/method in arguments.");

    public static DiagnosticDescriptor ReturnTypeLambda { get; } = Create(
        2,
        "ForEach lambda expressions return type must be void.",
        "ForEach lambda expressions return type must be void but returned '{0}'.");

    public static DiagnosticDescriptor ReturnTypeMethod { get; } = Create(
        3,
        "ForEach methods return type must be void.",
        "ForEach methods return type must be void but returned '{0}'.");

    public static DiagnosticDescriptor ParameterTypeMustBeUnmanagedOrClass { get; } = Create(
        4,
        "Unmanaged component types cannot contain references. Use managed(class) components instead.",
        "Unmanaged component type '{0}' cannot contain references. Use managed(class) components instead.");

    public static DiagnosticDescriptor DefinedInOtherProject { get; } = Create(
        5,
        "Barrage cannot register type/method in another project outside the SourceGenerator referenced project.");
}