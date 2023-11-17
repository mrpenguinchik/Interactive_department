using System;

namespace Prickly
{
    namespace Utils
    {
        public static class Utils
        {
            public static T GetElementOfArray<T>(int index, T[] array)
            {
                return array[index - (array.Length * (index / array.Length))];
            }

            public static float EvaluteFloat(float min, float max, float evalute)
            {
                float minEvalute = 1 - evalute;
                return min * minEvalute + max * evalute;
            }

            public static T2 Unboxing<T1, T2>(object obj)
            {
                if (typeof(T1) != typeof(T2))
                {
                    throw new InvalidOperationException();
                }

                return (T2)obj;
            }
        }
    }
}
