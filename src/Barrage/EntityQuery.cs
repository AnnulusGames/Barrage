namespace Barrage
{
    public readonly partial struct EntityQuery : IDisposable
    {
        readonly ushort token;
        readonly EntityQuerySource source;

        public bool IsDisposed => token != source.Token;

        internal EntityQuerySource GetQuerySource()
        {
            CheckIsDisposed();
            return source;
        }

        public EntityQuery()
        {
            source = EntityQuerySource.Rent();
            token = source.Token;
        }

        public void Dispose()
        {
            CheckIsDisposed();
            EntityQuerySource.Return(source);
        }

        void CheckIsDisposed()
        {
            if (IsDisposed)
            {
                throw new ObjectDisposedException(nameof(EntityQuery));
            }
        }
    }
}