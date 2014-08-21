namespace SortingHomework
{
    using System;
    using System.Collections.Generic;

    public class SortableCollection<T> where T : IComparable<T>
    {
        private readonly IList<T> items;

        public SortableCollection()
        {
            this.items = new List<T>();
        }

        public SortableCollection(IEnumerable<T> items)
        {
            this.items = new List<T>(items);
        }

        public IList<T> Items
        {
            get
            {
                return this.items;
            }
        }

        public void Sort(ISorter<T> sorter)
        {
            sorter.Sort(this.items);
        }

        public bool LinearSearch(T item)
        {
            foreach (var listItem in this.items)
            {
                if (item.CompareTo(listItem) == 0)
                {
                    return true;
                }
            }

            return false;
        }

        public bool BinarySearch(T item)
        {
            int min = 0;
            int max = this.items.Count;
            int mid = 0;

            while (min < max)
            {
                mid = min / 2 + max / 2;

                if (this.items[mid].CompareTo(item) < 0)
                {
                    min = mid + 1;
                }
                else if (this.items[mid].CompareTo(item) > 0)
                {
                    max = mid - 1;
                }
                else
                {
                    return true;
                }
            }

            return false;
        }

        //The modern version of the Fisher–Yates shuffle
        public void Shuffle()
        {
            for (int i = this.items.Count - 1; i >= 0; i--)
            {
                var swapped = MyRandom.Instance.Next(0, i + 1);

                var helper = this.items[i];
                this.items[i] = this.items[swapped];
                this.items[swapped] = helper;
            }
        }

        public void PrintAllItemsOnConsole()
        {
            for (int i = 0; i < this.items.Count; i++)
            {
                if (i == 0)
                {
                    Console.Write(this.items[i]);
                }
                else
                {
                    Console.Write(" " + this.items[i]);
                }
            }

            Console.WriteLine();
        }
    }
}
