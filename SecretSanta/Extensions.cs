using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SecretSanta
{
    public static class Extensions
    {
        private static Random rng = new Random();

        public static void Shuffle<T>(this IList<T> list)
        {

            for (int index = list.Count - 1; index > 1; --index)
            {
                int randIndex = rng.Next(index + 1);

                T temp = list[randIndex];
                list[randIndex] = list[index];
                list[index] = temp;
            }

        }

    }
}
