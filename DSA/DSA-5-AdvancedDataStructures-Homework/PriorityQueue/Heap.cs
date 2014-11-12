using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PriorityQueue
{
    public class Heap<T> where T : IComparable<T>
    {
        private const int InitialCapacity = 16;

        private T[] elements;
        private bool isMinHeap;
        private int nextIndex = 0;

        public Heap(bool isMinHeap)
        {
            this.elements = new T[InitialCapacity];
            this.isMinHeap = isMinHeap;
        }

        public void Add(T element)
        {
            this.CheckCapacity();

            this.elements[this.nextIndex] = element;

            this.ArrangeElementsOnAdd(this.nextIndex);

            this.nextIndex++;
        }

        public T First()
        {
            return this.elements[0];
        }

        public void DeleteFirst()
        {
            var swapper = this.elements[0];
            this.elements[0] = this.elements[this.nextIndex - 1];
            this.elements[this.nextIndex - 1] = swapper;

            this.nextIndex--;

            this.ArrangeElementsOnDelete(0);
        }

        private void ArrangeElementsOnAdd(int indexToCheck)
        {
            var parentElement = (indexToCheck - 1) / 2;

            var comparison = this.elements[indexToCheck].CompareTo(this.elements[parentElement]);

            if (this.isMinHeap ? comparison < 0 : comparison > 0)
            {
                var swapper = this.elements[indexToCheck];
                this.elements[indexToCheck] = this.elements[parentElement];
                this.elements[parentElement] = swapper;

                this.ArrangeElementsOnAdd(parentElement);
            }
        }

        private void ArrangeElementsOnDelete(int indexToCheck)
        {
            var left = indexToCheck * 2 + 1;
            var right = left + 1;

            if (left < this.nextIndex)
            {
                var comparison = this.elements[indexToCheck].CompareTo(this.elements[left]);

                if (this.isMinHeap ? comparison > 0 : comparison < 0)
                {
                    var swapper = this.elements[indexToCheck];
                    this.elements[indexToCheck] = this.elements[left];
                    this.elements[left] = swapper;

                    this.ArrangeElementsOnDelete(left);
                }
                else if (right < this.nextIndex)
                {
                    comparison = this.elements[indexToCheck].CompareTo(this.elements[right]);
                    if (this.isMinHeap ? comparison > 0 : comparison < 0)
                    {
                        var swapper = this.elements[indexToCheck];
                        this.elements[indexToCheck] = this.elements[right];
                        this.elements[right] = swapper;

                        this.ArrangeElementsOnDelete(right);
                    }
                }

            }
        }

        private void CheckCapacity()
        {
            if (this.nextIndex == elements.Length)
            {
                var newElements = new T[this.elements.Length * 2];
                for (int i = 0; i < this.elements.Length; i++)
                {
                    newElements[i] = this.elements[i];
                }

                this.elements = newElements;
            }
        }

        public override string ToString()
        {
            return string.Join(", ", this.elements);
        }
    }
}
