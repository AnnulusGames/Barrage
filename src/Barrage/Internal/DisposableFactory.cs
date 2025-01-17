namespace Barrage;

internal static class DisposableFactory
{
    public static IDisposable Create(Action action) => new AnonymousDisposable(action);
    public static IDisposable Create<T>(T state, Action<T> action) => new AnonymousDisposable<T>(state, action);
}

internal sealed class AnonymousDisposable(Action action) : IDisposable
{
    public void Dispose()
    {
        action();
    }
}

internal sealed class AnonymousDisposable<T>(T state, Action<T> action) : IDisposable
{
    public void Dispose()
    {
        action(state);
    }
}