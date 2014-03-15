namespace _01.PriorityQueue
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    /// <summary>
    /// Holds elements in a heap - like manner and keeps max/min on top
    /// </summary>
    /// <typeparam name="T">The type of elements to keep</typeparam>
    public class BinaryHeap<T>
    {
        const int InitialCapacity = 16;

        private int index;
        private readonly Comparer<T> compararer;

        private T[] data;

        #region Constructors
        /// <summary>
        /// Default constructor using the default initial capacity and default compararer
        /// </summary>
        public BinaryHeap()
            : this(InitialCapacity, null) { }

        /// <summary>
        /// Default constructor using a predefined initial capacity and default compararer
        /// </summary>
        /// <param name="initialSize">predefined initial capacity</param>
        public BinaryHeap(int initialSize)
            : this(initialSize, null) { }

        /// <summary>
        /// Default constructor using the default initial capacity and predefined compararer
        /// </summary>
        /// <param name="compararer"></param>
        public BinaryHeap(Comparer<T> compararer)
            : this(InitialCapacity, compararer) { }

        /// <summary>
        /// Default constructor using the predefined initial capacity and predefined compararer
        /// </summary>
        /// <param name="initialSize"></param>
        /// <param name="compararer"></param>
        public BinaryHeap(int initialSize, Comparer<T> compararer)
        {
            this.data = new T[initialSize];
            this.index = 0;
            this.compararer = compararer;

            if (compararer == null)
            {
                this.compararer = Comparer<T>.Default;
            }
        }
        #endregion

        /// <summary>
        /// Adds an element to the heap
        /// </summary>
        /// <param name="element"></param>
        public void Add(T element)
        {
            if (this.index == this.data.Length)
            {
                this.IncreazeSize();
            }

            this.data[index] = element;

            this.HeapUp(this.index);

            this.index++;
        }

        /// <summary>
        /// Removes the top element (min/max)
        /// </summary>
        public void RemoveTop()
        {
            this.data[0] = this.data[this.index - 1];

            this.index--;

            this.HeapDown();
        }

        /// <summary>
        /// Returns the top element (min/max)
        /// </summary>
        /// <returns>The top element</returns>
        public T GetTopElement()
        {
            return this.data[0];
        }

        /// <summary>
        /// Deletes all the elements in the heap
        /// </summary>
        public void Clear()
        {
            this.data = new T[this.data.Length];
            this.index = 0;
        }

        private void HeapUp(int newElementIndex)
        {
            int parentIndex = this.GetParentIndex(newElementIndex);

            //compararer if default keeps a MAX HEAP by default
            //<0 means that the order is reversed
            while (parentIndex >= 0 && this.compararer.Compare(this.data[parentIndex],this.data[newElementIndex]) < 0)
            {
                T helper = this.data[parentIndex];
                this.data[parentIndex] = this.data[newElementIndex];
                this.data[newElementIndex] = helper;

                newElementIndex = parentIndex;
                parentIndex = this.GetParentIndex(newElementIndex);
            }
        }

        private void HeapDown()
        {
            int parentIndex = 0;
            
            int indexOfChildToUse = 0;

            while (true)
            {
                int childIndex1 = this.GetChildLeftIndex(parentIndex);
                int childIndex2 = this.GetChildRightIndex(parentIndex);

                if (childIndex1 >= this.index)
                {
                    break;
                }

                if (childIndex2 >= this.index)
                {
                    indexOfChildToUse = childIndex1;
                }
                else
                {
                    indexOfChildToUse = this.compararer.Compare(this.data[childIndex1], this.data[childIndex2]) < 0 ? 
                        childIndex2 : childIndex1;
                }

                if (this.compararer.Compare(this.data[parentIndex],this.data[indexOfChildToUse]) < 0)
                {
                    T helper = this.data[parentIndex];
                    this.data[parentIndex] = this.data[indexOfChildToUse];
                    this.data[indexOfChildToUse] = helper;

                    parentIndex = indexOfChildToUse;
                }
                else
                {
                    break;
                }
            }
        }

        private void IncreazeSize()
        {
            var newData = new T[this.data.Length * 2];

            Array.Copy(this.data, newData, this.data.Length);

            this.data = newData;
        }

        private int GetChildLeftIndex(int parentPosition)
        {
            //represents * 2 but faster :)
            return (parentPosition << 1) + 1;
        }

        private int GetChildRightIndex(int parentPosition)
        {
            //represents * 2 but faster :)
            return (parentPosition << 1) + 2;
        }

        private int GetParentIndex(int childPosition)
        {
            //represents * 2 but faster :)
            return (childPosition - 1) >> 1;
        }
    }
}
