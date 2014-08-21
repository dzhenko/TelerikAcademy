namespace SortingHomework
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class MergeSorter<T> : ISorter<T> where T : IComparable<T>
    {
        public void Sort(IList<T> collection)
        {
            var sorted = this.MergeSort(collection);

            collection.Clear();

            foreach (var sortedItem in sorted)
            {
                collection.Add(sortedItem);
            }
        }

        private List<T> MergeSort(IList<T> collection)
        {
            if (collection.Count < 2)
            {
                return collection.ToList();
            }

            List<T> left = new List<T>();
            List<T> right = new List<T>();

            for (int i = 0; i < collection.Count/2; i++)
            {
                left.Add(collection[i]);
            }

            for (int i = collection.Count / 2; i < collection.Count; i++)
            {
                right.Add(collection[i]);
            }

            left = this.MergeSort(left);
            right = this.MergeSort(right);

            return this.MergeThoseDamnLists(left, right);
        }

        private List<T> MergeThoseDamnLists(IList<T> left, IList<T> right)
        {
            List<T> answer = new List<T>(left.Count + right.Count);

            int leftIndex = 0;
            int rightIndex = 0;

            for (int i = 0; i < answer.Capacity; i++)
            {
                if (leftIndex >= left.Count)
                {
                    answer.Add(right[rightIndex]);
                    rightIndex++;
                }
                else if (rightIndex >= right.Count)
                {
                    answer.Add(left[leftIndex]);
                    leftIndex++;
                }
                else if (left[leftIndex].CompareTo(right[rightIndex]) > 0)
                {
                    answer.Add(right[rightIndex]);
                    rightIndex++;
                }
                else
                {
                    answer.Add(left[leftIndex]);
                    leftIndex++;
                }
            }

            return answer;
        }
    }
}
