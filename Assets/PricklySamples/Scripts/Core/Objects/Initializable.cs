namespace Prickly
{
    namespace Core
    {
        public abstract class Initializable : InGameObject
        {
            public void Init()
            {
                OnInit();
                Initialized = true;
            }
            protected abstract void OnInit();
        }

        public abstract class Initializable<T1> : InGameObject
        {
            public void Init(T1 t1)
            {
                OnInit(t1);
                Initialized = true;
            }
            protected abstract void OnInit(T1 t1);
        }

        public abstract class Initializable<T1, T2> : InGameObject
        {
            public void Init(T1 t1, T2 t2)
            {
                OnInit(t1, t2);
                Initialized = true;
            }
            protected abstract void OnInit(T1 t1, T2 t2);
        }

        public abstract class Initializable<T1, T2, T3> : InGameObject
        {
            public void Init(T1 t1, T2 t2, T3 t3)
            {
                OnInit(t1, t2, t3);
                Initialized = true;
            }
            protected abstract void OnInit(T1 t1, T2 t2, T3 t3);
        }

        public abstract class Initializable<T1, T2, T3, T4> : InGameObject
        {
            public void Init(T1 t1, T2 t2, T3 t3, T4 t4)
            {
                OnInit(t1, t2, t3, t4);
                Initialized = true;
            }
            protected abstract void OnInit(T1 t1, T2 t2, T3 t3, T4 t4);
        }
    }
}
