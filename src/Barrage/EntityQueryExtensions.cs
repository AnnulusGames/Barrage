using System.Runtime.CompilerServices;

namespace Barrage;

public static partial class EntityQueryExtensions
{
    // EntityQuery

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static EntityQuery WithAll<T0>(this EntityQuery query)
    {
        var source = query.GetQuerySource();
        source.All.EnsureCapacity((int)MathF.Floor((ComponentRegistry.Count + 1) / 8f));
        source.All.Set(ComponentRegistry.GetComponentType(typeof(T0)).Id, true);
        return query;
    }
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static EntityQuery WithAll<T0,T1>(this EntityQuery query)
    {
        var source = query.GetQuerySource();
        source.All.EnsureCapacity((int)MathF.Floor((ComponentRegistry.Count + 2) / 8f));
        source.All.Set(ComponentRegistry.GetComponentType(typeof(T0)).Id, true);
        source.All.Set(ComponentRegistry.GetComponentType(typeof(T1)).Id, true);
        return query;
    }
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static EntityQuery WithAll<T0,T1,T2>(this EntityQuery query)
    {
        var source = query.GetQuerySource();
        source.All.EnsureCapacity((int)MathF.Floor((ComponentRegistry.Count + 3) / 8f));
        source.All.Set(ComponentRegistry.GetComponentType(typeof(T0)).Id, true);
        source.All.Set(ComponentRegistry.GetComponentType(typeof(T1)).Id, true);
        source.All.Set(ComponentRegistry.GetComponentType(typeof(T2)).Id, true);
        return query;
    }
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static EntityQuery WithAll<T0,T1,T2,T3>(this EntityQuery query)
    {
        var source = query.GetQuerySource();
        source.All.EnsureCapacity((int)MathF.Floor((ComponentRegistry.Count + 4) / 8f));
        source.All.Set(ComponentRegistry.GetComponentType(typeof(T0)).Id, true);
        source.All.Set(ComponentRegistry.GetComponentType(typeof(T1)).Id, true);
        source.All.Set(ComponentRegistry.GetComponentType(typeof(T2)).Id, true);
        source.All.Set(ComponentRegistry.GetComponentType(typeof(T3)).Id, true);
        return query;
    }
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static EntityQuery WithAll<T0,T1,T2,T3,T4>(this EntityQuery query)
    {
        var source = query.GetQuerySource();
        source.All.EnsureCapacity((int)MathF.Floor((ComponentRegistry.Count + 5) / 8f));
        source.All.Set(ComponentRegistry.GetComponentType(typeof(T0)).Id, true);
        source.All.Set(ComponentRegistry.GetComponentType(typeof(T1)).Id, true);
        source.All.Set(ComponentRegistry.GetComponentType(typeof(T2)).Id, true);
        source.All.Set(ComponentRegistry.GetComponentType(typeof(T3)).Id, true);
        source.All.Set(ComponentRegistry.GetComponentType(typeof(T4)).Id, true);
        return query;
    }
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static EntityQuery WithAll<T0,T1,T2,T3,T4,T5>(this EntityQuery query)
    {
        var source = query.GetQuerySource();
        source.All.EnsureCapacity((int)MathF.Floor((ComponentRegistry.Count + 6) / 8f));
        source.All.Set(ComponentRegistry.GetComponentType(typeof(T0)).Id, true);
        source.All.Set(ComponentRegistry.GetComponentType(typeof(T1)).Id, true);
        source.All.Set(ComponentRegistry.GetComponentType(typeof(T2)).Id, true);
        source.All.Set(ComponentRegistry.GetComponentType(typeof(T3)).Id, true);
        source.All.Set(ComponentRegistry.GetComponentType(typeof(T4)).Id, true);
        source.All.Set(ComponentRegistry.GetComponentType(typeof(T5)).Id, true);
        return query;
    }
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static EntityQuery WithAll<T0,T1,T2,T3,T4,T5,T6>(this EntityQuery query)
    {
        var source = query.GetQuerySource();
        source.All.EnsureCapacity((int)MathF.Floor((ComponentRegistry.Count + 7) / 8f));
        source.All.Set(ComponentRegistry.GetComponentType(typeof(T0)).Id, true);
        source.All.Set(ComponentRegistry.GetComponentType(typeof(T1)).Id, true);
        source.All.Set(ComponentRegistry.GetComponentType(typeof(T2)).Id, true);
        source.All.Set(ComponentRegistry.GetComponentType(typeof(T3)).Id, true);
        source.All.Set(ComponentRegistry.GetComponentType(typeof(T4)).Id, true);
        source.All.Set(ComponentRegistry.GetComponentType(typeof(T5)).Id, true);
        source.All.Set(ComponentRegistry.GetComponentType(typeof(T6)).Id, true);
        return query;
    }
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static EntityQuery WithAll<T0,T1,T2,T3,T4,T5,T6,T7>(this EntityQuery query)
    {
        var source = query.GetQuerySource();
        source.All.EnsureCapacity((int)MathF.Floor((ComponentRegistry.Count + 8) / 8f));
        source.All.Set(ComponentRegistry.GetComponentType(typeof(T0)).Id, true);
        source.All.Set(ComponentRegistry.GetComponentType(typeof(T1)).Id, true);
        source.All.Set(ComponentRegistry.GetComponentType(typeof(T2)).Id, true);
        source.All.Set(ComponentRegistry.GetComponentType(typeof(T3)).Id, true);
        source.All.Set(ComponentRegistry.GetComponentType(typeof(T4)).Id, true);
        source.All.Set(ComponentRegistry.GetComponentType(typeof(T5)).Id, true);
        source.All.Set(ComponentRegistry.GetComponentType(typeof(T6)).Id, true);
        source.All.Set(ComponentRegistry.GetComponentType(typeof(T7)).Id, true);
        return query;
    }
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static EntityQuery WithAll<T0,T1,T2,T3,T4,T5,T6,T7,T8>(this EntityQuery query)
    {
        var source = query.GetQuerySource();
        source.All.EnsureCapacity((int)MathF.Floor((ComponentRegistry.Count + 9) / 8f));
        source.All.Set(ComponentRegistry.GetComponentType(typeof(T0)).Id, true);
        source.All.Set(ComponentRegistry.GetComponentType(typeof(T1)).Id, true);
        source.All.Set(ComponentRegistry.GetComponentType(typeof(T2)).Id, true);
        source.All.Set(ComponentRegistry.GetComponentType(typeof(T3)).Id, true);
        source.All.Set(ComponentRegistry.GetComponentType(typeof(T4)).Id, true);
        source.All.Set(ComponentRegistry.GetComponentType(typeof(T5)).Id, true);
        source.All.Set(ComponentRegistry.GetComponentType(typeof(T6)).Id, true);
        source.All.Set(ComponentRegistry.GetComponentType(typeof(T7)).Id, true);
        source.All.Set(ComponentRegistry.GetComponentType(typeof(T8)).Id, true);
        return query;
    }
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static EntityQuery WithAll<T0,T1,T2,T3,T4,T5,T6,T7,T8,T9>(this EntityQuery query)
    {
        var source = query.GetQuerySource();
        source.All.EnsureCapacity((int)MathF.Floor((ComponentRegistry.Count + 10) / 8f));
        source.All.Set(ComponentRegistry.GetComponentType(typeof(T0)).Id, true);
        source.All.Set(ComponentRegistry.GetComponentType(typeof(T1)).Id, true);
        source.All.Set(ComponentRegistry.GetComponentType(typeof(T2)).Id, true);
        source.All.Set(ComponentRegistry.GetComponentType(typeof(T3)).Id, true);
        source.All.Set(ComponentRegistry.GetComponentType(typeof(T4)).Id, true);
        source.All.Set(ComponentRegistry.GetComponentType(typeof(T5)).Id, true);
        source.All.Set(ComponentRegistry.GetComponentType(typeof(T6)).Id, true);
        source.All.Set(ComponentRegistry.GetComponentType(typeof(T7)).Id, true);
        source.All.Set(ComponentRegistry.GetComponentType(typeof(T8)).Id, true);
        source.All.Set(ComponentRegistry.GetComponentType(typeof(T9)).Id, true);
        return query;
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static EntityQuery WithAny<T0>(this EntityQuery query)
    {
        var source = query.GetQuerySource();
        source.Any.EnsureCapacity((int)MathF.Floor((ComponentRegistry.Count + 1) / 8f));
        source.Any.Set(ComponentRegistry.GetComponentType(typeof(T0)).Id, true);
        return query;
    }
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static EntityQuery WithAny<T0,T1>(this EntityQuery query)
    {
        var source = query.GetQuerySource();
        source.Any.EnsureCapacity((int)MathF.Floor((ComponentRegistry.Count + 2) / 8f));
        source.Any.Set(ComponentRegistry.GetComponentType(typeof(T0)).Id, true);
        source.Any.Set(ComponentRegistry.GetComponentType(typeof(T1)).Id, true);
        return query;
    }
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static EntityQuery WithAny<T0,T1,T2>(this EntityQuery query)
    {
        var source = query.GetQuerySource();
        source.Any.EnsureCapacity((int)MathF.Floor((ComponentRegistry.Count + 3) / 8f));
        source.Any.Set(ComponentRegistry.GetComponentType(typeof(T0)).Id, true);
        source.Any.Set(ComponentRegistry.GetComponentType(typeof(T1)).Id, true);
        source.Any.Set(ComponentRegistry.GetComponentType(typeof(T2)).Id, true);
        return query;
    }
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static EntityQuery WithAny<T0,T1,T2,T3>(this EntityQuery query)
    {
        var source = query.GetQuerySource();
        source.Any.EnsureCapacity((int)MathF.Floor((ComponentRegistry.Count + 4) / 8f));
        source.Any.Set(ComponentRegistry.GetComponentType(typeof(T0)).Id, true);
        source.Any.Set(ComponentRegistry.GetComponentType(typeof(T1)).Id, true);
        source.Any.Set(ComponentRegistry.GetComponentType(typeof(T2)).Id, true);
        source.Any.Set(ComponentRegistry.GetComponentType(typeof(T3)).Id, true);
        return query;
    }
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static EntityQuery WithAny<T0,T1,T2,T3,T4>(this EntityQuery query)
    {
        var source = query.GetQuerySource();
        source.Any.EnsureCapacity((int)MathF.Floor((ComponentRegistry.Count + 5) / 8f));
        source.Any.Set(ComponentRegistry.GetComponentType(typeof(T0)).Id, true);
        source.Any.Set(ComponentRegistry.GetComponentType(typeof(T1)).Id, true);
        source.Any.Set(ComponentRegistry.GetComponentType(typeof(T2)).Id, true);
        source.Any.Set(ComponentRegistry.GetComponentType(typeof(T3)).Id, true);
        source.Any.Set(ComponentRegistry.GetComponentType(typeof(T4)).Id, true);
        return query;
    }
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static EntityQuery WithAny<T0,T1,T2,T3,T4,T5>(this EntityQuery query)
    {
        var source = query.GetQuerySource();
        source.Any.EnsureCapacity((int)MathF.Floor((ComponentRegistry.Count + 6) / 8f));
        source.Any.Set(ComponentRegistry.GetComponentType(typeof(T0)).Id, true);
        source.Any.Set(ComponentRegistry.GetComponentType(typeof(T1)).Id, true);
        source.Any.Set(ComponentRegistry.GetComponentType(typeof(T2)).Id, true);
        source.Any.Set(ComponentRegistry.GetComponentType(typeof(T3)).Id, true);
        source.Any.Set(ComponentRegistry.GetComponentType(typeof(T4)).Id, true);
        source.Any.Set(ComponentRegistry.GetComponentType(typeof(T5)).Id, true);
        return query;
    }
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static EntityQuery WithAny<T0,T1,T2,T3,T4,T5,T6>(this EntityQuery query)
    {
        var source = query.GetQuerySource();
        source.Any.EnsureCapacity((int)MathF.Floor((ComponentRegistry.Count + 7) / 8f));
        source.Any.Set(ComponentRegistry.GetComponentType(typeof(T0)).Id, true);
        source.Any.Set(ComponentRegistry.GetComponentType(typeof(T1)).Id, true);
        source.Any.Set(ComponentRegistry.GetComponentType(typeof(T2)).Id, true);
        source.Any.Set(ComponentRegistry.GetComponentType(typeof(T3)).Id, true);
        source.Any.Set(ComponentRegistry.GetComponentType(typeof(T4)).Id, true);
        source.Any.Set(ComponentRegistry.GetComponentType(typeof(T5)).Id, true);
        source.Any.Set(ComponentRegistry.GetComponentType(typeof(T6)).Id, true);
        return query;
    }
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static EntityQuery WithAny<T0,T1,T2,T3,T4,T5,T6,T7>(this EntityQuery query)
    {
        var source = query.GetQuerySource();
        source.Any.EnsureCapacity((int)MathF.Floor((ComponentRegistry.Count + 8) / 8f));
        source.Any.Set(ComponentRegistry.GetComponentType(typeof(T0)).Id, true);
        source.Any.Set(ComponentRegistry.GetComponentType(typeof(T1)).Id, true);
        source.Any.Set(ComponentRegistry.GetComponentType(typeof(T2)).Id, true);
        source.Any.Set(ComponentRegistry.GetComponentType(typeof(T3)).Id, true);
        source.Any.Set(ComponentRegistry.GetComponentType(typeof(T4)).Id, true);
        source.Any.Set(ComponentRegistry.GetComponentType(typeof(T5)).Id, true);
        source.Any.Set(ComponentRegistry.GetComponentType(typeof(T6)).Id, true);
        source.Any.Set(ComponentRegistry.GetComponentType(typeof(T7)).Id, true);
        return query;
    }
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static EntityQuery WithAny<T0,T1,T2,T3,T4,T5,T6,T7,T8>(this EntityQuery query)
    {
        var source = query.GetQuerySource();
        source.Any.EnsureCapacity((int)MathF.Floor((ComponentRegistry.Count + 9) / 8f));
        source.Any.Set(ComponentRegistry.GetComponentType(typeof(T0)).Id, true);
        source.Any.Set(ComponentRegistry.GetComponentType(typeof(T1)).Id, true);
        source.Any.Set(ComponentRegistry.GetComponentType(typeof(T2)).Id, true);
        source.Any.Set(ComponentRegistry.GetComponentType(typeof(T3)).Id, true);
        source.Any.Set(ComponentRegistry.GetComponentType(typeof(T4)).Id, true);
        source.Any.Set(ComponentRegistry.GetComponentType(typeof(T5)).Id, true);
        source.Any.Set(ComponentRegistry.GetComponentType(typeof(T6)).Id, true);
        source.Any.Set(ComponentRegistry.GetComponentType(typeof(T7)).Id, true);
        source.Any.Set(ComponentRegistry.GetComponentType(typeof(T8)).Id, true);
        return query;
    }
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static EntityQuery WithAny<T0,T1,T2,T3,T4,T5,T6,T7,T8,T9>(this EntityQuery query)
    {
        var source = query.GetQuerySource();
        source.Any.EnsureCapacity((int)MathF.Floor((ComponentRegistry.Count + 10) / 8f));
        source.Any.Set(ComponentRegistry.GetComponentType(typeof(T0)).Id, true);
        source.Any.Set(ComponentRegistry.GetComponentType(typeof(T1)).Id, true);
        source.Any.Set(ComponentRegistry.GetComponentType(typeof(T2)).Id, true);
        source.Any.Set(ComponentRegistry.GetComponentType(typeof(T3)).Id, true);
        source.Any.Set(ComponentRegistry.GetComponentType(typeof(T4)).Id, true);
        source.Any.Set(ComponentRegistry.GetComponentType(typeof(T5)).Id, true);
        source.Any.Set(ComponentRegistry.GetComponentType(typeof(T6)).Id, true);
        source.Any.Set(ComponentRegistry.GetComponentType(typeof(T7)).Id, true);
        source.Any.Set(ComponentRegistry.GetComponentType(typeof(T8)).Id, true);
        source.Any.Set(ComponentRegistry.GetComponentType(typeof(T9)).Id, true);
        return query;
    }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static EntityQuery WithNone<T0>(this EntityQuery query)
    {
        var source = query.GetQuerySource();
        source.None.EnsureCapacity((int)MathF.Floor((ComponentRegistry.Count + 1) / 8f));
        source.None.Set(ComponentRegistry.GetComponentType(typeof(T0)).Id, true);
        return query;
    }
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static EntityQuery WithNone<T0,T1>(this EntityQuery query)
    {
        var source = query.GetQuerySource();
        source.None.EnsureCapacity((int)MathF.Floor((ComponentRegistry.Count + 2) / 8f));
        source.None.Set(ComponentRegistry.GetComponentType(typeof(T0)).Id, true);
        source.None.Set(ComponentRegistry.GetComponentType(typeof(T1)).Id, true);
        return query;
    }
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static EntityQuery WithNone<T0,T1,T2>(this EntityQuery query)
    {
        var source = query.GetQuerySource();
        source.None.EnsureCapacity((int)MathF.Floor((ComponentRegistry.Count + 3) / 8f));
        source.None.Set(ComponentRegistry.GetComponentType(typeof(T0)).Id, true);
        source.None.Set(ComponentRegistry.GetComponentType(typeof(T1)).Id, true);
        source.None.Set(ComponentRegistry.GetComponentType(typeof(T2)).Id, true);
        return query;
    }
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static EntityQuery WithNone<T0,T1,T2,T3>(this EntityQuery query)
    {
        var source = query.GetQuerySource();
        source.None.EnsureCapacity((int)MathF.Floor((ComponentRegistry.Count + 4) / 8f));
        source.None.Set(ComponentRegistry.GetComponentType(typeof(T0)).Id, true);
        source.None.Set(ComponentRegistry.GetComponentType(typeof(T1)).Id, true);
        source.None.Set(ComponentRegistry.GetComponentType(typeof(T2)).Id, true);
        source.None.Set(ComponentRegistry.GetComponentType(typeof(T3)).Id, true);
        return query;
    }
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static EntityQuery WithNone<T0,T1,T2,T3,T4>(this EntityQuery query)
    {
        var source = query.GetQuerySource();
        source.None.EnsureCapacity((int)MathF.Floor((ComponentRegistry.Count + 5) / 8f));
        source.None.Set(ComponentRegistry.GetComponentType(typeof(T0)).Id, true);
        source.None.Set(ComponentRegistry.GetComponentType(typeof(T1)).Id, true);
        source.None.Set(ComponentRegistry.GetComponentType(typeof(T2)).Id, true);
        source.None.Set(ComponentRegistry.GetComponentType(typeof(T3)).Id, true);
        source.None.Set(ComponentRegistry.GetComponentType(typeof(T4)).Id, true);
        return query;
    }
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static EntityQuery WithNone<T0,T1,T2,T3,T4,T5>(this EntityQuery query)
    {
        var source = query.GetQuerySource();
        source.None.EnsureCapacity((int)MathF.Floor((ComponentRegistry.Count + 6) / 8f));
        source.None.Set(ComponentRegistry.GetComponentType(typeof(T0)).Id, true);
        source.None.Set(ComponentRegistry.GetComponentType(typeof(T1)).Id, true);
        source.None.Set(ComponentRegistry.GetComponentType(typeof(T2)).Id, true);
        source.None.Set(ComponentRegistry.GetComponentType(typeof(T3)).Id, true);
        source.None.Set(ComponentRegistry.GetComponentType(typeof(T4)).Id, true);
        source.None.Set(ComponentRegistry.GetComponentType(typeof(T5)).Id, true);
        return query;
    }
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static EntityQuery WithNone<T0,T1,T2,T3,T4,T5,T6>(this EntityQuery query)
    {
        var source = query.GetQuerySource();
        source.None.EnsureCapacity((int)MathF.Floor((ComponentRegistry.Count + 7) / 8f));
        source.None.Set(ComponentRegistry.GetComponentType(typeof(T0)).Id, true);
        source.None.Set(ComponentRegistry.GetComponentType(typeof(T1)).Id, true);
        source.None.Set(ComponentRegistry.GetComponentType(typeof(T2)).Id, true);
        source.None.Set(ComponentRegistry.GetComponentType(typeof(T3)).Id, true);
        source.None.Set(ComponentRegistry.GetComponentType(typeof(T4)).Id, true);
        source.None.Set(ComponentRegistry.GetComponentType(typeof(T5)).Id, true);
        source.None.Set(ComponentRegistry.GetComponentType(typeof(T6)).Id, true);
        return query;
    }
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static EntityQuery WithNone<T0,T1,T2,T3,T4,T5,T6,T7>(this EntityQuery query)
    {
        var source = query.GetQuerySource();
        source.None.EnsureCapacity((int)MathF.Floor((ComponentRegistry.Count + 8) / 8f));
        source.None.Set(ComponentRegistry.GetComponentType(typeof(T0)).Id, true);
        source.None.Set(ComponentRegistry.GetComponentType(typeof(T1)).Id, true);
        source.None.Set(ComponentRegistry.GetComponentType(typeof(T2)).Id, true);
        source.None.Set(ComponentRegistry.GetComponentType(typeof(T3)).Id, true);
        source.None.Set(ComponentRegistry.GetComponentType(typeof(T4)).Id, true);
        source.None.Set(ComponentRegistry.GetComponentType(typeof(T5)).Id, true);
        source.None.Set(ComponentRegistry.GetComponentType(typeof(T6)).Id, true);
        source.None.Set(ComponentRegistry.GetComponentType(typeof(T7)).Id, true);
        return query;
    }
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static EntityQuery WithNone<T0,T1,T2,T3,T4,T5,T6,T7,T8>(this EntityQuery query)
    {
        var source = query.GetQuerySource();
        source.None.EnsureCapacity((int)MathF.Floor((ComponentRegistry.Count + 9) / 8f));
        source.None.Set(ComponentRegistry.GetComponentType(typeof(T0)).Id, true);
        source.None.Set(ComponentRegistry.GetComponentType(typeof(T1)).Id, true);
        source.None.Set(ComponentRegistry.GetComponentType(typeof(T2)).Id, true);
        source.None.Set(ComponentRegistry.GetComponentType(typeof(T3)).Id, true);
        source.None.Set(ComponentRegistry.GetComponentType(typeof(T4)).Id, true);
        source.None.Set(ComponentRegistry.GetComponentType(typeof(T5)).Id, true);
        source.None.Set(ComponentRegistry.GetComponentType(typeof(T6)).Id, true);
        source.None.Set(ComponentRegistry.GetComponentType(typeof(T7)).Id, true);
        source.None.Set(ComponentRegistry.GetComponentType(typeof(T8)).Id, true);
        return query;
    }
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static EntityQuery WithNone<T0,T1,T2,T3,T4,T5,T6,T7,T8,T9>(this EntityQuery query)
    {
        var source = query.GetQuerySource();
        source.None.EnsureCapacity((int)MathF.Floor((ComponentRegistry.Count + 10) / 8f));
        source.None.Set(ComponentRegistry.GetComponentType(typeof(T0)).Id, true);
        source.None.Set(ComponentRegistry.GetComponentType(typeof(T1)).Id, true);
        source.None.Set(ComponentRegistry.GetComponentType(typeof(T2)).Id, true);
        source.None.Set(ComponentRegistry.GetComponentType(typeof(T3)).Id, true);
        source.None.Set(ComponentRegistry.GetComponentType(typeof(T4)).Id, true);
        source.None.Set(ComponentRegistry.GetComponentType(typeof(T5)).Id, true);
        source.None.Set(ComponentRegistry.GetComponentType(typeof(T6)).Id, true);
        source.None.Set(ComponentRegistry.GetComponentType(typeof(T7)).Id, true);
        source.None.Set(ComponentRegistry.GetComponentType(typeof(T8)).Id, true);
        source.None.Set(ComponentRegistry.GetComponentType(typeof(T9)).Id, true);
        return query;
    }

    // QueryArchetypeEnumerable

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static QueryArchetypeEnumerable WithAll<T0>(this QueryArchetypeEnumerable query)
    {
        var source = query.GetQuerySource();
        source.All.EnsureCapacity((int)MathF.Floor((ComponentRegistry.Count + 1) / 8f));
        source.All.Set(ComponentRegistry.GetComponentType(typeof(T0)).Id, true);
        return query;
    }
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static QueryArchetypeEnumerable WithAll<T0,T1>(this QueryArchetypeEnumerable query)
    {
        var source = query.GetQuerySource();
        source.All.EnsureCapacity((int)MathF.Floor((ComponentRegistry.Count + 2) / 8f));
        source.All.Set(ComponentRegistry.GetComponentType(typeof(T0)).Id, true);
        source.All.Set(ComponentRegistry.GetComponentType(typeof(T1)).Id, true);
        return query;
    }
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static QueryArchetypeEnumerable WithAll<T0,T1,T2>(this QueryArchetypeEnumerable query)
    {
        var source = query.GetQuerySource();
        source.All.EnsureCapacity((int)MathF.Floor((ComponentRegistry.Count + 3) / 8f));
        source.All.Set(ComponentRegistry.GetComponentType(typeof(T0)).Id, true);
        source.All.Set(ComponentRegistry.GetComponentType(typeof(T1)).Id, true);
        source.All.Set(ComponentRegistry.GetComponentType(typeof(T2)).Id, true);
        return query;
    }
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static QueryArchetypeEnumerable WithAll<T0,T1,T2,T3>(this QueryArchetypeEnumerable query)
    {
        var source = query.GetQuerySource();
        source.All.EnsureCapacity((int)MathF.Floor((ComponentRegistry.Count + 4) / 8f));
        source.All.Set(ComponentRegistry.GetComponentType(typeof(T0)).Id, true);
        source.All.Set(ComponentRegistry.GetComponentType(typeof(T1)).Id, true);
        source.All.Set(ComponentRegistry.GetComponentType(typeof(T2)).Id, true);
        source.All.Set(ComponentRegistry.GetComponentType(typeof(T3)).Id, true);
        return query;
    }
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static QueryArchetypeEnumerable WithAll<T0,T1,T2,T3,T4>(this QueryArchetypeEnumerable query)
    {
        var source = query.GetQuerySource();
        source.All.EnsureCapacity((int)MathF.Floor((ComponentRegistry.Count + 5) / 8f));
        source.All.Set(ComponentRegistry.GetComponentType(typeof(T0)).Id, true);
        source.All.Set(ComponentRegistry.GetComponentType(typeof(T1)).Id, true);
        source.All.Set(ComponentRegistry.GetComponentType(typeof(T2)).Id, true);
        source.All.Set(ComponentRegistry.GetComponentType(typeof(T3)).Id, true);
        source.All.Set(ComponentRegistry.GetComponentType(typeof(T4)).Id, true);
        return query;
    }
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static QueryArchetypeEnumerable WithAll<T0,T1,T2,T3,T4,T5>(this QueryArchetypeEnumerable query)
    {
        var source = query.GetQuerySource();
        source.All.EnsureCapacity((int)MathF.Floor((ComponentRegistry.Count + 6) / 8f));
        source.All.Set(ComponentRegistry.GetComponentType(typeof(T0)).Id, true);
        source.All.Set(ComponentRegistry.GetComponentType(typeof(T1)).Id, true);
        source.All.Set(ComponentRegistry.GetComponentType(typeof(T2)).Id, true);
        source.All.Set(ComponentRegistry.GetComponentType(typeof(T3)).Id, true);
        source.All.Set(ComponentRegistry.GetComponentType(typeof(T4)).Id, true);
        source.All.Set(ComponentRegistry.GetComponentType(typeof(T5)).Id, true);
        return query;
    }
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static QueryArchetypeEnumerable WithAll<T0,T1,T2,T3,T4,T5,T6>(this QueryArchetypeEnumerable query)
    {
        var source = query.GetQuerySource();
        source.All.EnsureCapacity((int)MathF.Floor((ComponentRegistry.Count + 7) / 8f));
        source.All.Set(ComponentRegistry.GetComponentType(typeof(T0)).Id, true);
        source.All.Set(ComponentRegistry.GetComponentType(typeof(T1)).Id, true);
        source.All.Set(ComponentRegistry.GetComponentType(typeof(T2)).Id, true);
        source.All.Set(ComponentRegistry.GetComponentType(typeof(T3)).Id, true);
        source.All.Set(ComponentRegistry.GetComponentType(typeof(T4)).Id, true);
        source.All.Set(ComponentRegistry.GetComponentType(typeof(T5)).Id, true);
        source.All.Set(ComponentRegistry.GetComponentType(typeof(T6)).Id, true);
        return query;
    }
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static QueryArchetypeEnumerable WithAll<T0,T1,T2,T3,T4,T5,T6,T7>(this QueryArchetypeEnumerable query)
    {
        var source = query.GetQuerySource();
        source.All.EnsureCapacity((int)MathF.Floor((ComponentRegistry.Count + 8) / 8f));
        source.All.Set(ComponentRegistry.GetComponentType(typeof(T0)).Id, true);
        source.All.Set(ComponentRegistry.GetComponentType(typeof(T1)).Id, true);
        source.All.Set(ComponentRegistry.GetComponentType(typeof(T2)).Id, true);
        source.All.Set(ComponentRegistry.GetComponentType(typeof(T3)).Id, true);
        source.All.Set(ComponentRegistry.GetComponentType(typeof(T4)).Id, true);
        source.All.Set(ComponentRegistry.GetComponentType(typeof(T5)).Id, true);
        source.All.Set(ComponentRegistry.GetComponentType(typeof(T6)).Id, true);
        source.All.Set(ComponentRegistry.GetComponentType(typeof(T7)).Id, true);
        return query;
    }
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static QueryArchetypeEnumerable WithAll<T0,T1,T2,T3,T4,T5,T6,T7,T8>(this QueryArchetypeEnumerable query)
    {
        var source = query.GetQuerySource();
        source.All.EnsureCapacity((int)MathF.Floor((ComponentRegistry.Count + 9) / 8f));
        source.All.Set(ComponentRegistry.GetComponentType(typeof(T0)).Id, true);
        source.All.Set(ComponentRegistry.GetComponentType(typeof(T1)).Id, true);
        source.All.Set(ComponentRegistry.GetComponentType(typeof(T2)).Id, true);
        source.All.Set(ComponentRegistry.GetComponentType(typeof(T3)).Id, true);
        source.All.Set(ComponentRegistry.GetComponentType(typeof(T4)).Id, true);
        source.All.Set(ComponentRegistry.GetComponentType(typeof(T5)).Id, true);
        source.All.Set(ComponentRegistry.GetComponentType(typeof(T6)).Id, true);
        source.All.Set(ComponentRegistry.GetComponentType(typeof(T7)).Id, true);
        source.All.Set(ComponentRegistry.GetComponentType(typeof(T8)).Id, true);
        return query;
    }
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static QueryArchetypeEnumerable WithAll<T0,T1,T2,T3,T4,T5,T6,T7,T8,T9>(this QueryArchetypeEnumerable query)
    {
        var source = query.GetQuerySource();
        source.All.EnsureCapacity((int)MathF.Floor((ComponentRegistry.Count + 10) / 8f));
        source.All.Set(ComponentRegistry.GetComponentType(typeof(T0)).Id, true);
        source.All.Set(ComponentRegistry.GetComponentType(typeof(T1)).Id, true);
        source.All.Set(ComponentRegistry.GetComponentType(typeof(T2)).Id, true);
        source.All.Set(ComponentRegistry.GetComponentType(typeof(T3)).Id, true);
        source.All.Set(ComponentRegistry.GetComponentType(typeof(T4)).Id, true);
        source.All.Set(ComponentRegistry.GetComponentType(typeof(T5)).Id, true);
        source.All.Set(ComponentRegistry.GetComponentType(typeof(T6)).Id, true);
        source.All.Set(ComponentRegistry.GetComponentType(typeof(T7)).Id, true);
        source.All.Set(ComponentRegistry.GetComponentType(typeof(T8)).Id, true);
        source.All.Set(ComponentRegistry.GetComponentType(typeof(T9)).Id, true);
        return query;
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static QueryArchetypeEnumerable WithAny<T0>(this QueryArchetypeEnumerable query)
    {
        var source = query.GetQuerySource();
        source.Any.EnsureCapacity((int)MathF.Floor((ComponentRegistry.Count + 1) / 8f));
        source.Any.Set(ComponentRegistry.GetComponentType(typeof(T0)).Id, true);
        return query;
    }
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static QueryArchetypeEnumerable WithAny<T0,T1>(this QueryArchetypeEnumerable query)
    {
        var source = query.GetQuerySource();
        source.Any.EnsureCapacity((int)MathF.Floor((ComponentRegistry.Count + 2) / 8f));
        source.Any.Set(ComponentRegistry.GetComponentType(typeof(T0)).Id, true);
        source.Any.Set(ComponentRegistry.GetComponentType(typeof(T1)).Id, true);
        return query;
    }
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static QueryArchetypeEnumerable WithAny<T0,T1,T2>(this QueryArchetypeEnumerable query)
    {
        var source = query.GetQuerySource();
        source.Any.EnsureCapacity((int)MathF.Floor((ComponentRegistry.Count + 3) / 8f));
        source.Any.Set(ComponentRegistry.GetComponentType(typeof(T0)).Id, true);
        source.Any.Set(ComponentRegistry.GetComponentType(typeof(T1)).Id, true);
        source.Any.Set(ComponentRegistry.GetComponentType(typeof(T2)).Id, true);
        return query;
    }
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static QueryArchetypeEnumerable WithAny<T0,T1,T2,T3>(this QueryArchetypeEnumerable query)
    {
        var source = query.GetQuerySource();
        source.Any.EnsureCapacity((int)MathF.Floor((ComponentRegistry.Count + 4) / 8f));
        source.Any.Set(ComponentRegistry.GetComponentType(typeof(T0)).Id, true);
        source.Any.Set(ComponentRegistry.GetComponentType(typeof(T1)).Id, true);
        source.Any.Set(ComponentRegistry.GetComponentType(typeof(T2)).Id, true);
        source.Any.Set(ComponentRegistry.GetComponentType(typeof(T3)).Id, true);
        return query;
    }
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static QueryArchetypeEnumerable WithAny<T0,T1,T2,T3,T4>(this QueryArchetypeEnumerable query)
    {
        var source = query.GetQuerySource();
        source.Any.EnsureCapacity((int)MathF.Floor((ComponentRegistry.Count + 5) / 8f));
        source.Any.Set(ComponentRegistry.GetComponentType(typeof(T0)).Id, true);
        source.Any.Set(ComponentRegistry.GetComponentType(typeof(T1)).Id, true);
        source.Any.Set(ComponentRegistry.GetComponentType(typeof(T2)).Id, true);
        source.Any.Set(ComponentRegistry.GetComponentType(typeof(T3)).Id, true);
        source.Any.Set(ComponentRegistry.GetComponentType(typeof(T4)).Id, true);
        return query;
    }
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static QueryArchetypeEnumerable WithAny<T0,T1,T2,T3,T4,T5>(this QueryArchetypeEnumerable query)
    {
        var source = query.GetQuerySource();
        source.Any.EnsureCapacity((int)MathF.Floor((ComponentRegistry.Count + 6) / 8f));
        source.Any.Set(ComponentRegistry.GetComponentType(typeof(T0)).Id, true);
        source.Any.Set(ComponentRegistry.GetComponentType(typeof(T1)).Id, true);
        source.Any.Set(ComponentRegistry.GetComponentType(typeof(T2)).Id, true);
        source.Any.Set(ComponentRegistry.GetComponentType(typeof(T3)).Id, true);
        source.Any.Set(ComponentRegistry.GetComponentType(typeof(T4)).Id, true);
        source.Any.Set(ComponentRegistry.GetComponentType(typeof(T5)).Id, true);
        return query;
    }
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static QueryArchetypeEnumerable WithAny<T0,T1,T2,T3,T4,T5,T6>(this QueryArchetypeEnumerable query)
    {
        var source = query.GetQuerySource();
        source.Any.EnsureCapacity((int)MathF.Floor((ComponentRegistry.Count + 7) / 8f));
        source.Any.Set(ComponentRegistry.GetComponentType(typeof(T0)).Id, true);
        source.Any.Set(ComponentRegistry.GetComponentType(typeof(T1)).Id, true);
        source.Any.Set(ComponentRegistry.GetComponentType(typeof(T2)).Id, true);
        source.Any.Set(ComponentRegistry.GetComponentType(typeof(T3)).Id, true);
        source.Any.Set(ComponentRegistry.GetComponentType(typeof(T4)).Id, true);
        source.Any.Set(ComponentRegistry.GetComponentType(typeof(T5)).Id, true);
        source.Any.Set(ComponentRegistry.GetComponentType(typeof(T6)).Id, true);
        return query;
    }
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static QueryArchetypeEnumerable WithAny<T0,T1,T2,T3,T4,T5,T6,T7>(this QueryArchetypeEnumerable query)
    {
        var source = query.GetQuerySource();
        source.Any.EnsureCapacity((int)MathF.Floor((ComponentRegistry.Count + 8) / 8f));
        source.Any.Set(ComponentRegistry.GetComponentType(typeof(T0)).Id, true);
        source.Any.Set(ComponentRegistry.GetComponentType(typeof(T1)).Id, true);
        source.Any.Set(ComponentRegistry.GetComponentType(typeof(T2)).Id, true);
        source.Any.Set(ComponentRegistry.GetComponentType(typeof(T3)).Id, true);
        source.Any.Set(ComponentRegistry.GetComponentType(typeof(T4)).Id, true);
        source.Any.Set(ComponentRegistry.GetComponentType(typeof(T5)).Id, true);
        source.Any.Set(ComponentRegistry.GetComponentType(typeof(T6)).Id, true);
        source.Any.Set(ComponentRegistry.GetComponentType(typeof(T7)).Id, true);
        return query;
    }
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static QueryArchetypeEnumerable WithAny<T0,T1,T2,T3,T4,T5,T6,T7,T8>(this QueryArchetypeEnumerable query)
    {
        var source = query.GetQuerySource();
        source.Any.EnsureCapacity((int)MathF.Floor((ComponentRegistry.Count + 9) / 8f));
        source.Any.Set(ComponentRegistry.GetComponentType(typeof(T0)).Id, true);
        source.Any.Set(ComponentRegistry.GetComponentType(typeof(T1)).Id, true);
        source.Any.Set(ComponentRegistry.GetComponentType(typeof(T2)).Id, true);
        source.Any.Set(ComponentRegistry.GetComponentType(typeof(T3)).Id, true);
        source.Any.Set(ComponentRegistry.GetComponentType(typeof(T4)).Id, true);
        source.Any.Set(ComponentRegistry.GetComponentType(typeof(T5)).Id, true);
        source.Any.Set(ComponentRegistry.GetComponentType(typeof(T6)).Id, true);
        source.Any.Set(ComponentRegistry.GetComponentType(typeof(T7)).Id, true);
        source.Any.Set(ComponentRegistry.GetComponentType(typeof(T8)).Id, true);
        return query;
    }
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static QueryArchetypeEnumerable WithAny<T0,T1,T2,T3,T4,T5,T6,T7,T8,T9>(this QueryArchetypeEnumerable query)
    {
        var source = query.GetQuerySource();
        source.Any.EnsureCapacity((int)MathF.Floor((ComponentRegistry.Count + 10) / 8f));
        source.Any.Set(ComponentRegistry.GetComponentType(typeof(T0)).Id, true);
        source.Any.Set(ComponentRegistry.GetComponentType(typeof(T1)).Id, true);
        source.Any.Set(ComponentRegistry.GetComponentType(typeof(T2)).Id, true);
        source.Any.Set(ComponentRegistry.GetComponentType(typeof(T3)).Id, true);
        source.Any.Set(ComponentRegistry.GetComponentType(typeof(T4)).Id, true);
        source.Any.Set(ComponentRegistry.GetComponentType(typeof(T5)).Id, true);
        source.Any.Set(ComponentRegistry.GetComponentType(typeof(T6)).Id, true);
        source.Any.Set(ComponentRegistry.GetComponentType(typeof(T7)).Id, true);
        source.Any.Set(ComponentRegistry.GetComponentType(typeof(T8)).Id, true);
        source.Any.Set(ComponentRegistry.GetComponentType(typeof(T9)).Id, true);
        return query;
    }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static QueryArchetypeEnumerable WithNone<T0>(this QueryArchetypeEnumerable query)
    {
        var source = query.GetQuerySource();
        source.None.EnsureCapacity((int)MathF.Floor((ComponentRegistry.Count + 1) / 8f));
        source.None.Set(ComponentRegistry.GetComponentType(typeof(T0)).Id, true);
        return query;
    }
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static QueryArchetypeEnumerable WithNone<T0,T1>(this QueryArchetypeEnumerable query)
    {
        var source = query.GetQuerySource();
        source.None.EnsureCapacity((int)MathF.Floor((ComponentRegistry.Count + 2) / 8f));
        source.None.Set(ComponentRegistry.GetComponentType(typeof(T0)).Id, true);
        source.None.Set(ComponentRegistry.GetComponentType(typeof(T1)).Id, true);
        return query;
    }
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static QueryArchetypeEnumerable WithNone<T0,T1,T2>(this QueryArchetypeEnumerable query)
    {
        var source = query.GetQuerySource();
        source.None.EnsureCapacity((int)MathF.Floor((ComponentRegistry.Count + 3) / 8f));
        source.None.Set(ComponentRegistry.GetComponentType(typeof(T0)).Id, true);
        source.None.Set(ComponentRegistry.GetComponentType(typeof(T1)).Id, true);
        source.None.Set(ComponentRegistry.GetComponentType(typeof(T2)).Id, true);
        return query;
    }
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static QueryArchetypeEnumerable WithNone<T0,T1,T2,T3>(this QueryArchetypeEnumerable query)
    {
        var source = query.GetQuerySource();
        source.None.EnsureCapacity((int)MathF.Floor((ComponentRegistry.Count + 4) / 8f));
        source.None.Set(ComponentRegistry.GetComponentType(typeof(T0)).Id, true);
        source.None.Set(ComponentRegistry.GetComponentType(typeof(T1)).Id, true);
        source.None.Set(ComponentRegistry.GetComponentType(typeof(T2)).Id, true);
        source.None.Set(ComponentRegistry.GetComponentType(typeof(T3)).Id, true);
        return query;
    }
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static QueryArchetypeEnumerable WithNone<T0,T1,T2,T3,T4>(this QueryArchetypeEnumerable query)
    {
        var source = query.GetQuerySource();
        source.None.EnsureCapacity((int)MathF.Floor((ComponentRegistry.Count + 5) / 8f));
        source.None.Set(ComponentRegistry.GetComponentType(typeof(T0)).Id, true);
        source.None.Set(ComponentRegistry.GetComponentType(typeof(T1)).Id, true);
        source.None.Set(ComponentRegistry.GetComponentType(typeof(T2)).Id, true);
        source.None.Set(ComponentRegistry.GetComponentType(typeof(T3)).Id, true);
        source.None.Set(ComponentRegistry.GetComponentType(typeof(T4)).Id, true);
        return query;
    }
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static QueryArchetypeEnumerable WithNone<T0,T1,T2,T3,T4,T5>(this QueryArchetypeEnumerable query)
    {
        var source = query.GetQuerySource();
        source.None.EnsureCapacity((int)MathF.Floor((ComponentRegistry.Count + 6) / 8f));
        source.None.Set(ComponentRegistry.GetComponentType(typeof(T0)).Id, true);
        source.None.Set(ComponentRegistry.GetComponentType(typeof(T1)).Id, true);
        source.None.Set(ComponentRegistry.GetComponentType(typeof(T2)).Id, true);
        source.None.Set(ComponentRegistry.GetComponentType(typeof(T3)).Id, true);
        source.None.Set(ComponentRegistry.GetComponentType(typeof(T4)).Id, true);
        source.None.Set(ComponentRegistry.GetComponentType(typeof(T5)).Id, true);
        return query;
    }
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static QueryArchetypeEnumerable WithNone<T0,T1,T2,T3,T4,T5,T6>(this QueryArchetypeEnumerable query)
    {
        var source = query.GetQuerySource();
        source.None.EnsureCapacity((int)MathF.Floor((ComponentRegistry.Count + 7) / 8f));
        source.None.Set(ComponentRegistry.GetComponentType(typeof(T0)).Id, true);
        source.None.Set(ComponentRegistry.GetComponentType(typeof(T1)).Id, true);
        source.None.Set(ComponentRegistry.GetComponentType(typeof(T2)).Id, true);
        source.None.Set(ComponentRegistry.GetComponentType(typeof(T3)).Id, true);
        source.None.Set(ComponentRegistry.GetComponentType(typeof(T4)).Id, true);
        source.None.Set(ComponentRegistry.GetComponentType(typeof(T5)).Id, true);
        source.None.Set(ComponentRegistry.GetComponentType(typeof(T6)).Id, true);
        return query;
    }
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static QueryArchetypeEnumerable WithNone<T0,T1,T2,T3,T4,T5,T6,T7>(this QueryArchetypeEnumerable query)
    {
        var source = query.GetQuerySource();
        source.None.EnsureCapacity((int)MathF.Floor((ComponentRegistry.Count + 8) / 8f));
        source.None.Set(ComponentRegistry.GetComponentType(typeof(T0)).Id, true);
        source.None.Set(ComponentRegistry.GetComponentType(typeof(T1)).Id, true);
        source.None.Set(ComponentRegistry.GetComponentType(typeof(T2)).Id, true);
        source.None.Set(ComponentRegistry.GetComponentType(typeof(T3)).Id, true);
        source.None.Set(ComponentRegistry.GetComponentType(typeof(T4)).Id, true);
        source.None.Set(ComponentRegistry.GetComponentType(typeof(T5)).Id, true);
        source.None.Set(ComponentRegistry.GetComponentType(typeof(T6)).Id, true);
        source.None.Set(ComponentRegistry.GetComponentType(typeof(T7)).Id, true);
        return query;
    }
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static QueryArchetypeEnumerable WithNone<T0,T1,T2,T3,T4,T5,T6,T7,T8>(this QueryArchetypeEnumerable query)
    {
        var source = query.GetQuerySource();
        source.None.EnsureCapacity((int)MathF.Floor((ComponentRegistry.Count + 9) / 8f));
        source.None.Set(ComponentRegistry.GetComponentType(typeof(T0)).Id, true);
        source.None.Set(ComponentRegistry.GetComponentType(typeof(T1)).Id, true);
        source.None.Set(ComponentRegistry.GetComponentType(typeof(T2)).Id, true);
        source.None.Set(ComponentRegistry.GetComponentType(typeof(T3)).Id, true);
        source.None.Set(ComponentRegistry.GetComponentType(typeof(T4)).Id, true);
        source.None.Set(ComponentRegistry.GetComponentType(typeof(T5)).Id, true);
        source.None.Set(ComponentRegistry.GetComponentType(typeof(T6)).Id, true);
        source.None.Set(ComponentRegistry.GetComponentType(typeof(T7)).Id, true);
        source.None.Set(ComponentRegistry.GetComponentType(typeof(T8)).Id, true);
        return query;
    }
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static QueryArchetypeEnumerable WithNone<T0,T1,T2,T3,T4,T5,T6,T7,T8,T9>(this QueryArchetypeEnumerable query)
    {
        var source = query.GetQuerySource();
        source.None.EnsureCapacity((int)MathF.Floor((ComponentRegistry.Count + 10) / 8f));
        source.None.Set(ComponentRegistry.GetComponentType(typeof(T0)).Id, true);
        source.None.Set(ComponentRegistry.GetComponentType(typeof(T1)).Id, true);
        source.None.Set(ComponentRegistry.GetComponentType(typeof(T2)).Id, true);
        source.None.Set(ComponentRegistry.GetComponentType(typeof(T3)).Id, true);
        source.None.Set(ComponentRegistry.GetComponentType(typeof(T4)).Id, true);
        source.None.Set(ComponentRegistry.GetComponentType(typeof(T5)).Id, true);
        source.None.Set(ComponentRegistry.GetComponentType(typeof(T6)).Id, true);
        source.None.Set(ComponentRegistry.GetComponentType(typeof(T7)).Id, true);
        source.None.Set(ComponentRegistry.GetComponentType(typeof(T8)).Id, true);
        source.None.Set(ComponentRegistry.GetComponentType(typeof(T9)).Id, true);
        return query;
    }

    // QueryChunkEnumerable

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static QueryChunkEnumerable WithAll<T0>(this QueryChunkEnumerable query)
    {
        var source = query.GetQuerySource();
        source.All.EnsureCapacity((int)MathF.Floor((ComponentRegistry.Count + 1) / 8f));
        source.All.Set(ComponentRegistry.GetComponentType(typeof(T0)).Id, true);
        return query;
    }
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static QueryChunkEnumerable WithAll<T0,T1>(this QueryChunkEnumerable query)
    {
        var source = query.GetQuerySource();
        source.All.EnsureCapacity((int)MathF.Floor((ComponentRegistry.Count + 2) / 8f));
        source.All.Set(ComponentRegistry.GetComponentType(typeof(T0)).Id, true);
        source.All.Set(ComponentRegistry.GetComponentType(typeof(T1)).Id, true);
        return query;
    }
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static QueryChunkEnumerable WithAll<T0,T1,T2>(this QueryChunkEnumerable query)
    {
        var source = query.GetQuerySource();
        source.All.EnsureCapacity((int)MathF.Floor((ComponentRegistry.Count + 3) / 8f));
        source.All.Set(ComponentRegistry.GetComponentType(typeof(T0)).Id, true);
        source.All.Set(ComponentRegistry.GetComponentType(typeof(T1)).Id, true);
        source.All.Set(ComponentRegistry.GetComponentType(typeof(T2)).Id, true);
        return query;
    }
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static QueryChunkEnumerable WithAll<T0,T1,T2,T3>(this QueryChunkEnumerable query)
    {
        var source = query.GetQuerySource();
        source.All.EnsureCapacity((int)MathF.Floor((ComponentRegistry.Count + 4) / 8f));
        source.All.Set(ComponentRegistry.GetComponentType(typeof(T0)).Id, true);
        source.All.Set(ComponentRegistry.GetComponentType(typeof(T1)).Id, true);
        source.All.Set(ComponentRegistry.GetComponentType(typeof(T2)).Id, true);
        source.All.Set(ComponentRegistry.GetComponentType(typeof(T3)).Id, true);
        return query;
    }
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static QueryChunkEnumerable WithAll<T0,T1,T2,T3,T4>(this QueryChunkEnumerable query)
    {
        var source = query.GetQuerySource();
        source.All.EnsureCapacity((int)MathF.Floor((ComponentRegistry.Count + 5) / 8f));
        source.All.Set(ComponentRegistry.GetComponentType(typeof(T0)).Id, true);
        source.All.Set(ComponentRegistry.GetComponentType(typeof(T1)).Id, true);
        source.All.Set(ComponentRegistry.GetComponentType(typeof(T2)).Id, true);
        source.All.Set(ComponentRegistry.GetComponentType(typeof(T3)).Id, true);
        source.All.Set(ComponentRegistry.GetComponentType(typeof(T4)).Id, true);
        return query;
    }
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static QueryChunkEnumerable WithAll<T0,T1,T2,T3,T4,T5>(this QueryChunkEnumerable query)
    {
        var source = query.GetQuerySource();
        source.All.EnsureCapacity((int)MathF.Floor((ComponentRegistry.Count + 6) / 8f));
        source.All.Set(ComponentRegistry.GetComponentType(typeof(T0)).Id, true);
        source.All.Set(ComponentRegistry.GetComponentType(typeof(T1)).Id, true);
        source.All.Set(ComponentRegistry.GetComponentType(typeof(T2)).Id, true);
        source.All.Set(ComponentRegistry.GetComponentType(typeof(T3)).Id, true);
        source.All.Set(ComponentRegistry.GetComponentType(typeof(T4)).Id, true);
        source.All.Set(ComponentRegistry.GetComponentType(typeof(T5)).Id, true);
        return query;
    }
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static QueryChunkEnumerable WithAll<T0,T1,T2,T3,T4,T5,T6>(this QueryChunkEnumerable query)
    {
        var source = query.GetQuerySource();
        source.All.EnsureCapacity((int)MathF.Floor((ComponentRegistry.Count + 7) / 8f));
        source.All.Set(ComponentRegistry.GetComponentType(typeof(T0)).Id, true);
        source.All.Set(ComponentRegistry.GetComponentType(typeof(T1)).Id, true);
        source.All.Set(ComponentRegistry.GetComponentType(typeof(T2)).Id, true);
        source.All.Set(ComponentRegistry.GetComponentType(typeof(T3)).Id, true);
        source.All.Set(ComponentRegistry.GetComponentType(typeof(T4)).Id, true);
        source.All.Set(ComponentRegistry.GetComponentType(typeof(T5)).Id, true);
        source.All.Set(ComponentRegistry.GetComponentType(typeof(T6)).Id, true);
        return query;
    }
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static QueryChunkEnumerable WithAll<T0,T1,T2,T3,T4,T5,T6,T7>(this QueryChunkEnumerable query)
    {
        var source = query.GetQuerySource();
        source.All.EnsureCapacity((int)MathF.Floor((ComponentRegistry.Count + 8) / 8f));
        source.All.Set(ComponentRegistry.GetComponentType(typeof(T0)).Id, true);
        source.All.Set(ComponentRegistry.GetComponentType(typeof(T1)).Id, true);
        source.All.Set(ComponentRegistry.GetComponentType(typeof(T2)).Id, true);
        source.All.Set(ComponentRegistry.GetComponentType(typeof(T3)).Id, true);
        source.All.Set(ComponentRegistry.GetComponentType(typeof(T4)).Id, true);
        source.All.Set(ComponentRegistry.GetComponentType(typeof(T5)).Id, true);
        source.All.Set(ComponentRegistry.GetComponentType(typeof(T6)).Id, true);
        source.All.Set(ComponentRegistry.GetComponentType(typeof(T7)).Id, true);
        return query;
    }
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static QueryChunkEnumerable WithAll<T0,T1,T2,T3,T4,T5,T6,T7,T8>(this QueryChunkEnumerable query)
    {
        var source = query.GetQuerySource();
        source.All.EnsureCapacity((int)MathF.Floor((ComponentRegistry.Count + 9) / 8f));
        source.All.Set(ComponentRegistry.GetComponentType(typeof(T0)).Id, true);
        source.All.Set(ComponentRegistry.GetComponentType(typeof(T1)).Id, true);
        source.All.Set(ComponentRegistry.GetComponentType(typeof(T2)).Id, true);
        source.All.Set(ComponentRegistry.GetComponentType(typeof(T3)).Id, true);
        source.All.Set(ComponentRegistry.GetComponentType(typeof(T4)).Id, true);
        source.All.Set(ComponentRegistry.GetComponentType(typeof(T5)).Id, true);
        source.All.Set(ComponentRegistry.GetComponentType(typeof(T6)).Id, true);
        source.All.Set(ComponentRegistry.GetComponentType(typeof(T7)).Id, true);
        source.All.Set(ComponentRegistry.GetComponentType(typeof(T8)).Id, true);
        return query;
    }
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static QueryChunkEnumerable WithAll<T0,T1,T2,T3,T4,T5,T6,T7,T8,T9>(this QueryChunkEnumerable query)
    {
        var source = query.GetQuerySource();
        source.All.EnsureCapacity((int)MathF.Floor((ComponentRegistry.Count + 10) / 8f));
        source.All.Set(ComponentRegistry.GetComponentType(typeof(T0)).Id, true);
        source.All.Set(ComponentRegistry.GetComponentType(typeof(T1)).Id, true);
        source.All.Set(ComponentRegistry.GetComponentType(typeof(T2)).Id, true);
        source.All.Set(ComponentRegistry.GetComponentType(typeof(T3)).Id, true);
        source.All.Set(ComponentRegistry.GetComponentType(typeof(T4)).Id, true);
        source.All.Set(ComponentRegistry.GetComponentType(typeof(T5)).Id, true);
        source.All.Set(ComponentRegistry.GetComponentType(typeof(T6)).Id, true);
        source.All.Set(ComponentRegistry.GetComponentType(typeof(T7)).Id, true);
        source.All.Set(ComponentRegistry.GetComponentType(typeof(T8)).Id, true);
        source.All.Set(ComponentRegistry.GetComponentType(typeof(T9)).Id, true);
        return query;
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static QueryChunkEnumerable WithAny<T0>(this QueryChunkEnumerable query)
    {
        var source = query.GetQuerySource();
        source.Any.EnsureCapacity((int)MathF.Floor((ComponentRegistry.Count + 1) / 8f));
        source.Any.Set(ComponentRegistry.GetComponentType(typeof(T0)).Id, true);
        return query;
    }
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static QueryChunkEnumerable WithAny<T0,T1>(this QueryChunkEnumerable query)
    {
        var source = query.GetQuerySource();
        source.Any.EnsureCapacity((int)MathF.Floor((ComponentRegistry.Count + 2) / 8f));
        source.Any.Set(ComponentRegistry.GetComponentType(typeof(T0)).Id, true);
        source.Any.Set(ComponentRegistry.GetComponentType(typeof(T1)).Id, true);
        return query;
    }
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static QueryChunkEnumerable WithAny<T0,T1,T2>(this QueryChunkEnumerable query)
    {
        var source = query.GetQuerySource();
        source.Any.EnsureCapacity((int)MathF.Floor((ComponentRegistry.Count + 3) / 8f));
        source.Any.Set(ComponentRegistry.GetComponentType(typeof(T0)).Id, true);
        source.Any.Set(ComponentRegistry.GetComponentType(typeof(T1)).Id, true);
        source.Any.Set(ComponentRegistry.GetComponentType(typeof(T2)).Id, true);
        return query;
    }
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static QueryChunkEnumerable WithAny<T0,T1,T2,T3>(this QueryChunkEnumerable query)
    {
        var source = query.GetQuerySource();
        source.Any.EnsureCapacity((int)MathF.Floor((ComponentRegistry.Count + 4) / 8f));
        source.Any.Set(ComponentRegistry.GetComponentType(typeof(T0)).Id, true);
        source.Any.Set(ComponentRegistry.GetComponentType(typeof(T1)).Id, true);
        source.Any.Set(ComponentRegistry.GetComponentType(typeof(T2)).Id, true);
        source.Any.Set(ComponentRegistry.GetComponentType(typeof(T3)).Id, true);
        return query;
    }
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static QueryChunkEnumerable WithAny<T0,T1,T2,T3,T4>(this QueryChunkEnumerable query)
    {
        var source = query.GetQuerySource();
        source.Any.EnsureCapacity((int)MathF.Floor((ComponentRegistry.Count + 5) / 8f));
        source.Any.Set(ComponentRegistry.GetComponentType(typeof(T0)).Id, true);
        source.Any.Set(ComponentRegistry.GetComponentType(typeof(T1)).Id, true);
        source.Any.Set(ComponentRegistry.GetComponentType(typeof(T2)).Id, true);
        source.Any.Set(ComponentRegistry.GetComponentType(typeof(T3)).Id, true);
        source.Any.Set(ComponentRegistry.GetComponentType(typeof(T4)).Id, true);
        return query;
    }
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static QueryChunkEnumerable WithAny<T0,T1,T2,T3,T4,T5>(this QueryChunkEnumerable query)
    {
        var source = query.GetQuerySource();
        source.Any.EnsureCapacity((int)MathF.Floor((ComponentRegistry.Count + 6) / 8f));
        source.Any.Set(ComponentRegistry.GetComponentType(typeof(T0)).Id, true);
        source.Any.Set(ComponentRegistry.GetComponentType(typeof(T1)).Id, true);
        source.Any.Set(ComponentRegistry.GetComponentType(typeof(T2)).Id, true);
        source.Any.Set(ComponentRegistry.GetComponentType(typeof(T3)).Id, true);
        source.Any.Set(ComponentRegistry.GetComponentType(typeof(T4)).Id, true);
        source.Any.Set(ComponentRegistry.GetComponentType(typeof(T5)).Id, true);
        return query;
    }
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static QueryChunkEnumerable WithAny<T0,T1,T2,T3,T4,T5,T6>(this QueryChunkEnumerable query)
    {
        var source = query.GetQuerySource();
        source.Any.EnsureCapacity((int)MathF.Floor((ComponentRegistry.Count + 7) / 8f));
        source.Any.Set(ComponentRegistry.GetComponentType(typeof(T0)).Id, true);
        source.Any.Set(ComponentRegistry.GetComponentType(typeof(T1)).Id, true);
        source.Any.Set(ComponentRegistry.GetComponentType(typeof(T2)).Id, true);
        source.Any.Set(ComponentRegistry.GetComponentType(typeof(T3)).Id, true);
        source.Any.Set(ComponentRegistry.GetComponentType(typeof(T4)).Id, true);
        source.Any.Set(ComponentRegistry.GetComponentType(typeof(T5)).Id, true);
        source.Any.Set(ComponentRegistry.GetComponentType(typeof(T6)).Id, true);
        return query;
    }
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static QueryChunkEnumerable WithAny<T0,T1,T2,T3,T4,T5,T6,T7>(this QueryChunkEnumerable query)
    {
        var source = query.GetQuerySource();
        source.Any.EnsureCapacity((int)MathF.Floor((ComponentRegistry.Count + 8) / 8f));
        source.Any.Set(ComponentRegistry.GetComponentType(typeof(T0)).Id, true);
        source.Any.Set(ComponentRegistry.GetComponentType(typeof(T1)).Id, true);
        source.Any.Set(ComponentRegistry.GetComponentType(typeof(T2)).Id, true);
        source.Any.Set(ComponentRegistry.GetComponentType(typeof(T3)).Id, true);
        source.Any.Set(ComponentRegistry.GetComponentType(typeof(T4)).Id, true);
        source.Any.Set(ComponentRegistry.GetComponentType(typeof(T5)).Id, true);
        source.Any.Set(ComponentRegistry.GetComponentType(typeof(T6)).Id, true);
        source.Any.Set(ComponentRegistry.GetComponentType(typeof(T7)).Id, true);
        return query;
    }
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static QueryChunkEnumerable WithAny<T0,T1,T2,T3,T4,T5,T6,T7,T8>(this QueryChunkEnumerable query)
    {
        var source = query.GetQuerySource();
        source.Any.EnsureCapacity((int)MathF.Floor((ComponentRegistry.Count + 9) / 8f));
        source.Any.Set(ComponentRegistry.GetComponentType(typeof(T0)).Id, true);
        source.Any.Set(ComponentRegistry.GetComponentType(typeof(T1)).Id, true);
        source.Any.Set(ComponentRegistry.GetComponentType(typeof(T2)).Id, true);
        source.Any.Set(ComponentRegistry.GetComponentType(typeof(T3)).Id, true);
        source.Any.Set(ComponentRegistry.GetComponentType(typeof(T4)).Id, true);
        source.Any.Set(ComponentRegistry.GetComponentType(typeof(T5)).Id, true);
        source.Any.Set(ComponentRegistry.GetComponentType(typeof(T6)).Id, true);
        source.Any.Set(ComponentRegistry.GetComponentType(typeof(T7)).Id, true);
        source.Any.Set(ComponentRegistry.GetComponentType(typeof(T8)).Id, true);
        return query;
    }
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static QueryChunkEnumerable WithAny<T0,T1,T2,T3,T4,T5,T6,T7,T8,T9>(this QueryChunkEnumerable query)
    {
        var source = query.GetQuerySource();
        source.Any.EnsureCapacity((int)MathF.Floor((ComponentRegistry.Count + 10) / 8f));
        source.Any.Set(ComponentRegistry.GetComponentType(typeof(T0)).Id, true);
        source.Any.Set(ComponentRegistry.GetComponentType(typeof(T1)).Id, true);
        source.Any.Set(ComponentRegistry.GetComponentType(typeof(T2)).Id, true);
        source.Any.Set(ComponentRegistry.GetComponentType(typeof(T3)).Id, true);
        source.Any.Set(ComponentRegistry.GetComponentType(typeof(T4)).Id, true);
        source.Any.Set(ComponentRegistry.GetComponentType(typeof(T5)).Id, true);
        source.Any.Set(ComponentRegistry.GetComponentType(typeof(T6)).Id, true);
        source.Any.Set(ComponentRegistry.GetComponentType(typeof(T7)).Id, true);
        source.Any.Set(ComponentRegistry.GetComponentType(typeof(T8)).Id, true);
        source.Any.Set(ComponentRegistry.GetComponentType(typeof(T9)).Id, true);
        return query;
    }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static QueryChunkEnumerable WithNone<T0>(this QueryChunkEnumerable query)
    {
        var source = query.GetQuerySource();
        source.None.EnsureCapacity((int)MathF.Floor((ComponentRegistry.Count + 1) / 8f));
        source.None.Set(ComponentRegistry.GetComponentType(typeof(T0)).Id, true);
        return query;
    }
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static QueryChunkEnumerable WithNone<T0,T1>(this QueryChunkEnumerable query)
    {
        var source = query.GetQuerySource();
        source.None.EnsureCapacity((int)MathF.Floor((ComponentRegistry.Count + 2) / 8f));
        source.None.Set(ComponentRegistry.GetComponentType(typeof(T0)).Id, true);
        source.None.Set(ComponentRegistry.GetComponentType(typeof(T1)).Id, true);
        return query;
    }
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static QueryChunkEnumerable WithNone<T0,T1,T2>(this QueryChunkEnumerable query)
    {
        var source = query.GetQuerySource();
        source.None.EnsureCapacity((int)MathF.Floor((ComponentRegistry.Count + 3) / 8f));
        source.None.Set(ComponentRegistry.GetComponentType(typeof(T0)).Id, true);
        source.None.Set(ComponentRegistry.GetComponentType(typeof(T1)).Id, true);
        source.None.Set(ComponentRegistry.GetComponentType(typeof(T2)).Id, true);
        return query;
    }
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static QueryChunkEnumerable WithNone<T0,T1,T2,T3>(this QueryChunkEnumerable query)
    {
        var source = query.GetQuerySource();
        source.None.EnsureCapacity((int)MathF.Floor((ComponentRegistry.Count + 4) / 8f));
        source.None.Set(ComponentRegistry.GetComponentType(typeof(T0)).Id, true);
        source.None.Set(ComponentRegistry.GetComponentType(typeof(T1)).Id, true);
        source.None.Set(ComponentRegistry.GetComponentType(typeof(T2)).Id, true);
        source.None.Set(ComponentRegistry.GetComponentType(typeof(T3)).Id, true);
        return query;
    }
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static QueryChunkEnumerable WithNone<T0,T1,T2,T3,T4>(this QueryChunkEnumerable query)
    {
        var source = query.GetQuerySource();
        source.None.EnsureCapacity((int)MathF.Floor((ComponentRegistry.Count + 5) / 8f));
        source.None.Set(ComponentRegistry.GetComponentType(typeof(T0)).Id, true);
        source.None.Set(ComponentRegistry.GetComponentType(typeof(T1)).Id, true);
        source.None.Set(ComponentRegistry.GetComponentType(typeof(T2)).Id, true);
        source.None.Set(ComponentRegistry.GetComponentType(typeof(T3)).Id, true);
        source.None.Set(ComponentRegistry.GetComponentType(typeof(T4)).Id, true);
        return query;
    }
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static QueryChunkEnumerable WithNone<T0,T1,T2,T3,T4,T5>(this QueryChunkEnumerable query)
    {
        var source = query.GetQuerySource();
        source.None.EnsureCapacity((int)MathF.Floor((ComponentRegistry.Count + 6) / 8f));
        source.None.Set(ComponentRegistry.GetComponentType(typeof(T0)).Id, true);
        source.None.Set(ComponentRegistry.GetComponentType(typeof(T1)).Id, true);
        source.None.Set(ComponentRegistry.GetComponentType(typeof(T2)).Id, true);
        source.None.Set(ComponentRegistry.GetComponentType(typeof(T3)).Id, true);
        source.None.Set(ComponentRegistry.GetComponentType(typeof(T4)).Id, true);
        source.None.Set(ComponentRegistry.GetComponentType(typeof(T5)).Id, true);
        return query;
    }
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static QueryChunkEnumerable WithNone<T0,T1,T2,T3,T4,T5,T6>(this QueryChunkEnumerable query)
    {
        var source = query.GetQuerySource();
        source.None.EnsureCapacity((int)MathF.Floor((ComponentRegistry.Count + 7) / 8f));
        source.None.Set(ComponentRegistry.GetComponentType(typeof(T0)).Id, true);
        source.None.Set(ComponentRegistry.GetComponentType(typeof(T1)).Id, true);
        source.None.Set(ComponentRegistry.GetComponentType(typeof(T2)).Id, true);
        source.None.Set(ComponentRegistry.GetComponentType(typeof(T3)).Id, true);
        source.None.Set(ComponentRegistry.GetComponentType(typeof(T4)).Id, true);
        source.None.Set(ComponentRegistry.GetComponentType(typeof(T5)).Id, true);
        source.None.Set(ComponentRegistry.GetComponentType(typeof(T6)).Id, true);
        return query;
    }
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static QueryChunkEnumerable WithNone<T0,T1,T2,T3,T4,T5,T6,T7>(this QueryChunkEnumerable query)
    {
        var source = query.GetQuerySource();
        source.None.EnsureCapacity((int)MathF.Floor((ComponentRegistry.Count + 8) / 8f));
        source.None.Set(ComponentRegistry.GetComponentType(typeof(T0)).Id, true);
        source.None.Set(ComponentRegistry.GetComponentType(typeof(T1)).Id, true);
        source.None.Set(ComponentRegistry.GetComponentType(typeof(T2)).Id, true);
        source.None.Set(ComponentRegistry.GetComponentType(typeof(T3)).Id, true);
        source.None.Set(ComponentRegistry.GetComponentType(typeof(T4)).Id, true);
        source.None.Set(ComponentRegistry.GetComponentType(typeof(T5)).Id, true);
        source.None.Set(ComponentRegistry.GetComponentType(typeof(T6)).Id, true);
        source.None.Set(ComponentRegistry.GetComponentType(typeof(T7)).Id, true);
        return query;
    }
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static QueryChunkEnumerable WithNone<T0,T1,T2,T3,T4,T5,T6,T7,T8>(this QueryChunkEnumerable query)
    {
        var source = query.GetQuerySource();
        source.None.EnsureCapacity((int)MathF.Floor((ComponentRegistry.Count + 9) / 8f));
        source.None.Set(ComponentRegistry.GetComponentType(typeof(T0)).Id, true);
        source.None.Set(ComponentRegistry.GetComponentType(typeof(T1)).Id, true);
        source.None.Set(ComponentRegistry.GetComponentType(typeof(T2)).Id, true);
        source.None.Set(ComponentRegistry.GetComponentType(typeof(T3)).Id, true);
        source.None.Set(ComponentRegistry.GetComponentType(typeof(T4)).Id, true);
        source.None.Set(ComponentRegistry.GetComponentType(typeof(T5)).Id, true);
        source.None.Set(ComponentRegistry.GetComponentType(typeof(T6)).Id, true);
        source.None.Set(ComponentRegistry.GetComponentType(typeof(T7)).Id, true);
        source.None.Set(ComponentRegistry.GetComponentType(typeof(T8)).Id, true);
        return query;
    }
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static QueryChunkEnumerable WithNone<T0,T1,T2,T3,T4,T5,T6,T7,T8,T9>(this QueryChunkEnumerable query)
    {
        var source = query.GetQuerySource();
        source.None.EnsureCapacity((int)MathF.Floor((ComponentRegistry.Count + 10) / 8f));
        source.None.Set(ComponentRegistry.GetComponentType(typeof(T0)).Id, true);
        source.None.Set(ComponentRegistry.GetComponentType(typeof(T1)).Id, true);
        source.None.Set(ComponentRegistry.GetComponentType(typeof(T2)).Id, true);
        source.None.Set(ComponentRegistry.GetComponentType(typeof(T3)).Id, true);
        source.None.Set(ComponentRegistry.GetComponentType(typeof(T4)).Id, true);
        source.None.Set(ComponentRegistry.GetComponentType(typeof(T5)).Id, true);
        source.None.Set(ComponentRegistry.GetComponentType(typeof(T6)).Id, true);
        source.None.Set(ComponentRegistry.GetComponentType(typeof(T7)).Id, true);
        source.None.Set(ComponentRegistry.GetComponentType(typeof(T8)).Id, true);
        source.None.Set(ComponentRegistry.GetComponentType(typeof(T9)).Id, true);
        return query;
    }


}