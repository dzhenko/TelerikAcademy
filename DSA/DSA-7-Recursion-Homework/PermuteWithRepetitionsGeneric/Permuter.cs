namespace PermuteWithRepetitionsGeneric
{
    using System;
    using System.Collections.Generic;

    public static class Permuter
    {
        public static void GeneratePermutationsWithRepetitions<T>(List<T> elementsToUse, Action<List<T>> action) where T : IComparable<T>
        {
            var elements = new List<T>(elementsToUse);
            elements.Sort();

            InnerPermute<T>(elements, 0, action);
        }

        private static void InnerPermute<T>(List<T> elementsToUse, int index, Action<List<T>> action) where T : IComparable<T>
        {
            action(elementsToUse);

            T temp = elementsToUse[0];

            if (index < elementsToUse.Count)
            {
                for (int i = elementsToUse.Count - 2; i >= index; i--)
                {
                    for (int j = i + 1; j < elementsToUse.Count; j++)
                    {
                        if (elementsToUse[i].CompareTo(elementsToUse[j]) != 0)
                        {
                            temp = elementsToUse[i];
                            elementsToUse[i] = elementsToUse[i + 1];
                            elementsToUse[i + 1] = temp;

                            InnerPermute<T>(elementsToUse, index + 1, action);
                        }
                    }

                    T old = elementsToUse[i];
                    for (int k = i; k < elementsToUse.Count - 1; k++)
                    {
                        elementsToUse[k] = elementsToUse[++k];
                    }
                    elementsToUse[elementsToUse.Count - 1] = old;
                }
            }
        }
    }
}
