namespace Prickly
{
    namespace Core
    {
        public interface IInitializable
        {
            public abstract void Init();
        }

        public interface IInitializable<T1>
        {
            public abstract void Init(T1 t1);
        }

        public interface IInitializable<T1, T2>
        {
            public abstract void Init(T1 t1, T2 t2);
        }

        public interface IInitializable<T1, T2, T3>
        {
            public abstract void Init(T1 t1, T2 t2, T3 t3);
        }

        public interface IInitializable<T1, T2, T3, T4>
        {
            public abstract void Init(T1 t1, T2 t2, T3 t3, T4 t4);
        }
    }
}

