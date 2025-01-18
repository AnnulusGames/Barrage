namespace Barrage
{
    public partial struct EntityQuery : IDisposable
    {
        readonly ushort token;
        readonly EntityQuerySource source;
        bool isPreserved;

        public bool IsDisposed => token != source.Token;
        public bool IsPreserved => isPreserved;

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

        public EntityQuery Preserve()
        {
            isPreserved = true;
            return this;
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