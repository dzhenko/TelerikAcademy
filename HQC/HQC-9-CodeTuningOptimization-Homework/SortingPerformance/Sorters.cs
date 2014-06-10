namespace SortingPerformance
{
    using System;

    public static class Sorters
    {
        public static void InsertionSort(IComparable[] elements)
        {
            var index = elements[0];
            int j = 0;

            for (int i = 1; i < elements.Length; i++)
            {
                index = elements[i];
                j = i;
                while ((j > 0) && (elements[j - 1].CompareTo(index) > 0))
                {
                    elements[j] = elements[j - 1];
                    j = j - 1;
                }

                elements[j] = index;
            }
        }

        public static void SelectionSort(IComparable[] array)
        {
            var min = 0;
            var temp = array[0];

            for (var i = 0; i < array.Length - 1; i++)
            {
                min = i;
                for (var j = i + 1; j < array.Length; j++)
                {
                    if (array[j].CompareTo(array[min])  < 0)
                    {
                        min = j;
                    }
                }

                temp = array[i];
                array[i] = array[min];
                array[min] = temp;
            }
        }

        public static void Quicksort(IComparable[] elements)
        {
            Quicksort(elements, 0, elements.Length - 1);
        }

        private static void Quicksort(IComparable[] elements, int left, int right)
        {
            int i = left, j = right;
            IComparable pivot = elements[(left + right) / 2];

            while (i <= j)
            {
                while (elements[i].CompareTo(pivot) < 0)
                {
                    i++;
                }

                while (elements[j].CompareTo(pivot) > 0)
                {
                    j--;
                }

                if (i <= j)
                {
                    // Swap
                    IComparable tmp = elements[i];
                    elements[i] = elements[j];
                    elements[j] = tmp;

                    i++;
                    j--;
                }
            }

            // Recursive calls
            if (left < j)
            {
                Quicksort(elements, left, j);
            }

            if (i < right)
            {
                Quicksort(elements, i, right);
            }
        }
    }
}
