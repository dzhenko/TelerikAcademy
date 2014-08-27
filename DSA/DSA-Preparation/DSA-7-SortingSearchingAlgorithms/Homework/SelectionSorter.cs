namespace SortingHomework
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class SelectionSorter<T> : ISorter<T> where T : IComparable<T>
    {
        public void Sort(IList<T> collection)
        {
            for (int i = 0; i < collection.Count - 1; i++)
            {
                int currMin = i;

                for (int j = i + 1; j < collection.Count; j++)
                {
                    if (collection[currMin].CompareTo(collection[j]) > 0)
                    {
                        currMin = j;
                    }
                }

                T helper = collection[i];
                collection[i] = collection[currMin];
                collection[currMin] = helper;
            }
        }
    }
}
