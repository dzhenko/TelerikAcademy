using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace SortingHomework
{
    [TestClass]
    public class UnitTesting
    {
        [TestMethod]
        public void SelectionSort()
        {
            var collection = new SortableCollection<int>(new[] { 5, 1, 2, 4, 0, 6, 9, 8, 7 });

            collection.Sort(new SelectionSorter<int>());

            for (int i = 0; i < collection.Items.Count - 1; i++)
            {
                Assert.IsTrue(collection.Items[i] < collection.Items[i + 1]);
            }
        }

        [TestMethod]
        public void QuickSort()
        {
            var collection = new SortableCollection<int>(new[] { 5, 1, 2, 4, 0, 6, 9, 8, 7 });

            collection.Sort(new Quicksorter<int>());

            for (int i = 0; i < collection.Items.Count - 1; i++)
            {
                Assert.IsTrue(collection.Items[i] < collection.Items[i + 1]);
            }
        }

        [TestMethod]
        public void MergeSort()
        {
            var collection = new SortableCollection<int>(new[] { 5, 1, 2, 4, 0, 6, 9, 8, 7 });

            collection.Sort(new MergeSorter<int>());

            for (int i = 0; i < collection.Items.Count - 1; i++)
            {
                Assert.IsTrue(collection.Items[i] < collection.Items[i + 1]);
            }
        }

        [TestMethod]
        public void LinearSearchLast()
        {
            var collection = new SortableCollection<int>(new[] { 9, 8, 7, 6, 5, 4, 3, 2, 1, 0 });

            bool result = collection.LinearSearch(0);

            Assert.IsTrue(result);
        }

        [TestMethod]
        public void BinarySearch()
        {
            var collection = new SortableCollection<int>(new[] { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9 });

            bool result = collection.BinarySearch(8);

            Assert.IsTrue(result);
        }

        [TestMethod]
        public void Shuffle()
        {
            var collection = new SortableCollection<int>(new[] { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9 });

            collection.Shuffle();
            bool shuffled = false;

            for (int i = 0; i < collection.Items.Count - 1; i++)
            {
                if (collection.Items[i] > collection.Items[i + 1])
                {
                    shuffled = true;
                    break;
                }
            }

            Assert.IsTrue(shuffled);
        }
    }
}
