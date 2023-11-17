using Prickly.Core;

namespace Prickly
{
    namespace Debug
    {
        public abstract class Debug : InGameObject, IInitializable
        {
            public abstract void Init();
            public abstract void Log();
        }

        public abstract class Debug<T> : InGameObject, IInitializable<T>
        {
            public abstract void Init(T t1);
            public abstract void Log();
        }

        public abstract class Debug<T1, T2> : InGameObject, IInitializable<T1, T2>
        {
            public abstract void Init(T1 t1, T2 t2);
            public abstract void Log();
        }

        public abstract class Debug<T1, T2, T3> : InGameObject, IInitializable<T1, T2, T3>
        {
            public abstract void Init(T1 t1, T2 t2, T3 t3);
            public abstract void Log();
        }
    }
}
