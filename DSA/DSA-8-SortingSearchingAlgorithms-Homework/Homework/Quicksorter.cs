namespace SortingHomework
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Quicksorter<T> : ISorter<T> where T : IComparable<T>
    {
        public void Sort(IList<T> collection)
        {
            var sorted = this.quickSort(collection.ToList());

            collection.Clear();

            foreach (var item in sorted)
            {
                collection.Add(item);
            }
        }

        private List<T> quickSort(List<T> listToSort)
        {
            if (listToSort.Count < 2)
            {
                return listToSort;
            }

            List<T> left = new List<T>();
            List<T> right = new List<T>();
            List<T> pivots = new List<T>();

            T pivot = listToSort[1];

            foreach (var item in listToSort)
            {
                if (item.CompareTo(pivot) < 0)
                {
                    left.Add(item);
                }
                else if (item.CompareTo(pivot) > 0)
                {
                    right.Add(item);
                }
                else
                {
                    pivots.Add(item);
                }
            }

            left = this.quickSort(left);
            right = this.quickSort(right);

            List<T> answer = new List<T>(left.Count + pivots.Count + right.Count);
            answer.AddRange(left);
            answer.AddRange(pivots);
            answer.AddRange(right);

            return answer;
        }
    }
}
