namespace GenericListClass
{
    using System;
    using System.Linq;
    using System.Text;

    public class GenericList<T>
        where T : IComparable
    {
        private T[] theList;
        private int usedPositions;

        public GenericList(int size)
        {
            this.theList = new T[size];
            this.usedPositions = 0;
        }

        public T this[int position]
        {
            get
            {
                //even if the List is created with 3 positions and only one is set we can acces only 1 position
                CheckPositionValidity(position);
                return this.theList[position];
            }

            set
            {
                CheckPositionValidity(position);
                this.theList[position] = value;
            }
        }

        private void CheckPositionValidity(int position)
        {
                if (position < 0 || position >= this.usedPositions)
                {
                    throw new IndexOutOfRangeException("Invalid Index!");
                }
        }

        private void AutoDoubleSize()
        {
            T[] newList = new T[this.theList.Length * 2];
            Array.Copy(this.theList, newList, this.theList.Length);
            this.theList = newList;
        }

        public void Add(T item)
        {
            if (this.usedPositions == this.theList.Length)
            {
                this.AutoDoubleSize();
            }

            this.theList[usedPositions] = item;
            usedPositions++;
        }

        public void RemoveAt(int position)
        {
            CheckPositionValidity(position);
            T[] newArray = new T[this.theList.Length - 1];
            this.usedPositions--;
            Array.Copy(this.theList, 0, newArray, 0, position);
            Array.Copy(this.theList, position+1, newArray, position, this.theList.Length - 1 - position);
            this.theList = newArray;
        }

        public void InsertAt(T item, int position)
        {
            CheckPositionValidity(position);
            T[] newArray = new T[this.theList.Length + 1];
            this.usedPositions++;
            Array.Copy(this.theList, 0, newArray, 0, position);
            newArray[position] = item;
            Array.Copy(this.theList, position, newArray, position + 1, this.theList.Length - position);
            this.theList = newArray;
        }

        public int Find(T element)
        {
            return Array.IndexOf(this.theList, element);
        }

        public override string ToString()
        {
            if (this.usedPositions == 0)
            {
                return "The generic list is empty";
            }
            StringBuilder toStringer = new StringBuilder();
            for (int i = 0; i < this.theList.Length; i++)
            {
                toStringer.AppendFormat("Item {0} is --> {1} \r\n", i, this.theList[i]);
            }
            return toStringer.ToString();
        }

        public void Clear()
        {
            this.usedPositions = 0; // the elements remain in the array but they are unacessable this way
        }

        public T Min()
        {
            return this.theList.Min();
        }

        public T Max()
        {
            return this.theList.Max();
        }
    }


}
