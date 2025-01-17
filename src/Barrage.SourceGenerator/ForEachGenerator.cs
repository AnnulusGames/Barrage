﻿using System.Collections.Immutable;
using System.Text;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.CodeAnalysis.Text;

namespace Barrage.SourceGenerator;

[Generator(LanguageNames.CSharp)]
public class ForEachGenerator : IIncrementalGenerator
{
    public void Initialize(IncrementalGeneratorInitializationContext context)
    {
        var queryMethodProvider = context.SyntaxProvider
            .CreateSyntaxProvider(
                (node, ct) =>
                {
                    if (node.IsKind(SyntaxKind.InvocationExpression))
                    {
                        if (node is not InvocationExpressionSyntax invocationExpression) return false;

                        var expr = invocationExpression.Expression as MemberAccessExpressionSyntax;
                        var methodName = expr?.Name.Identifier.Text;
                        if (methodName is "ForEach")
                        {
                            return true;
                        }

                        return false;
                    }

                    return false;
                }, (context, ct) =>
                {
                    var reporter = new DiagnosticReporter();
                    var result = new ForEachMethodContext
                    {
                        DiagnosticReporter = reporter,
                        Model = context.SemanticModel,
                    };

                    var node = (InvocationExpressionSyntax)context.Node;

                    var model = context.SemanticModel.GetTypeInfo((node.Expression as MemberAccessExpressionSyntax)!.Expression, ct);
                    if (model.Type?.Name is not "World") return result;

                    if (node.ArgumentList.Arguments.Count != 2)
                    {
                        reporter.ReportDiagnostic(DiagnosticDescriptors.RequireQueryAndMethod, node.GetLocation());
                        return result;
                    }

                    var queryArgument = node.ArgumentList.Arguments[0];
                    var actionArgument = node.ArgumentList.Arguments[1];

                    if (actionArgument.Expression is ParenthesizedLambdaExpressionSyntax lambda)
                    {
                        var isVoid = lambda.ReturnType == null;
                        if (!isVoid)
                        {
                            reporter.ReportDiagnostic(DiagnosticDescriptors.ReturnTypeLambda, actionArgument.GetLocation(), lambda.ReturnType!.ToFullString());
                            return result;
                        }

                        var parameters = lambda.ParameterList
                            .Parameters
                            .Where(x => x.Type != null)
                            .Select(x =>
                            {
                                var type = context.SemanticModel.GetTypeInfo(x.Type!);
                                var typeName = type.Type!.ToDisplayString(SymbolDisplayFormat.FullyQualifiedFormat);
                                var isEntity = typeName == "global::Barrage.Entity";

                                if (type.Type.IsValueType && !type.Type.IsUnmanagedType)
                                {
                                    reporter.ReportDiagnostic(DiagnosticDescriptors.ParameterTypeMustBeUnmanagedOrClass, x.Type!.GetLocation(), type.Type!.ToDisplayString(SymbolDisplayFormat.FullyQualifiedFormat));
                                    return null;
                                }

                                return new ForEachMethodParameter
                                {
                                    FullTypeName = type.Type!.ToDisplayString(SymbolDisplayFormat.FullyQualifiedFormat),
                                    IsEntity = isEntity,
                                    IsRef = x.Modifiers.Any(x => x.IsKind(SyntaxKind.RefKeyword)),
                                    IsIn = x.Modifiers.Any(x => x.IsKind(SyntaxKind.InKeyword)),
                                };
                            })
                            .Where(x => x != null)
                            .ToArray();

                        result.Metadata = new ForEachMethod
                        {
                            Parameters = parameters!,
                        };
                    }
                    else
                    {
                        var methodSymbols = context.SemanticModel.GetMemberGroup(actionArgument.Expression);
                        if (methodSymbols.Length == 0 || methodSymbols[0] is not IMethodSymbol methodSymbol) return result;

                        if (methodSymbol.DeclaringSyntaxReferences.Length == 0)
                        {
                            reporter.ReportDiagnostic(DiagnosticDescriptors.DefinedInOtherProject, node.GetLocation());
                            return result;
                        }

                        if (methodSymbol.ReturnType.SpecialType != SpecialType.System_Void)
                        {
                            reporter.ReportDiagnostic(DiagnosticDescriptors.ReturnTypeMethod, actionArgument.Expression.GetLocation(), methodSymbol.ReturnType.ToDisplayString(SymbolDisplayFormat.FullyQualifiedFormat));
                            return result;
                        }

                        var parameters = methodSymbol.Parameters
                            .Select(x =>
                            {
                                var type = x.Type!;
                                var typeName = type.ToDisplayString(SymbolDisplayFormat.FullyQualifiedFormat);
                                var isEntity = typeName == "global::Barrage.Entity";

                                if (type.IsValueType && !type.IsUnmanagedType)
                                {
                                    reporter.ReportDiagnostic(DiagnosticDescriptors.ParameterTypeMustBeUnmanagedOrClass, x.Locations[0], typeName);
                                    return null;
                                }

                                return new ForEachMethodParameter
                                {
                                    FullTypeName = typeName,
                                    IsEntity = isEntity,
                                    IsRef = x.RefKind is RefKind.Ref,
                                    IsIn = x.RefKind is RefKind.In,
                                };
                            })
                            .ToArray();

                        result.Metadata = new ForEachMethod
                        {
                            Parameters = parameters!,
                        };
                    }

                    return result;
                })
            .Collect();

        context.RegisterSourceOutput(queryMethodProvider, EmitForEachMethod);
    }

    void EmitForEachMethod(SourceProductionContext context, ImmutableArray<ForEachMethodContext> methodContexts)
    {
        var id = 0;
        var methods = new HashSet<ForEachMethod>();
        foreach (var methodContext in methodContexts)
        {
            // check compilation errors
            if (methodContext.DiagnosticReporter.HasDiagnostics)
            {
                methodContext.DiagnosticReporter.ReportToContext(context);
                continue;
            }

            // check metadata is valid
            var meta = methodContext.Metadata;
            if (meta == null) continue;

            if (!methods.Add(meta)) return;

            var spans = new SourceBuilder(5);
            var references = new SourceBuilder(6);
            var index = 0;
            var containeEntity = false;
            foreach (var parameter in meta.Parameters)
            {
                if (parameter.IsEntity)
                {
                    if (!containeEntity)
                    {
                        spans.AppendLine("var entities = chunk.GetEntities();");
                        references.AppendLine("var entity = entities[i];");
                        containeEntity = true;
                    }
                }
                else
                {
                    spans.AppendLine($"var span{index} = chunk.GetComponentArray<{parameter.FullTypeName}>();");
                    references.AppendLine($"ref var component{index} = ref span{index}[i];");
                }

                index++;
            }

            var delegateDeclaration = $"internal delegate void ForEach_{id}({string.Join(", ", meta.Parameters.Select((x, i) =>
            {
                if (x.IsEntity) return $"global::Barrage.Entity arg{i}";
                else if (x.IsRef) return $"ref {x.FullTypeName} arg{i}";
                else if (x.IsIn) return $"in {x.FullTypeName} arg{i}";
                else return $"{x.FullTypeName} arg{i}";
            }))});";

            var callAction = $"action({string.Join(", ", meta.Parameters.Select((x, i) =>
                {
                    if (x.IsEntity) return "entity";
                    else if (x.IsRef) return $"ref component{i}";
                    else return $"component{i}";
                }))});";

            var source =
    $$"""
// <auto-generated/>
namespace Barrage
{

{{delegateDeclaration}}

internal static partial class WorldForEachExtensions
{
    internal static void ForEach(this global::Barrage.World world, global::Barrage.EntityQuery query, ForEach_{{id}} action)
    {
        try
        {
            foreach (var archetype in world.Archetypes)
            {
                if (!archetype.Match(query)) continue;

                foreach (var chunk in archetype.Chunks)
                {
    {{spans}}
                    for (int i = 0; i < chunk.Count; i++)
                    {
    {{references}}
                        {{callAction}}
                    }
                }
            }
        }
        finally
        {
            if (!query.IsPreserved) query.Dispose();
        }
    }
}

}
""";

            context.AddSource($"WorldForEachExtensions.g.{id}.cs", source);
            id++;
        }
    }
}