//Implement the ADT stack as auto-resizable array. 
//Resize the capacity on demand (when no space is available to add / insert a new element).


namespace _12.StackImplementation
{
    using System;

    /// <summary>
    /// A new shiny stack implementation
    /// </summary>
    /// <typeparam name="T">The type of elements stored in the stack</typeparam>
    public class JStack<T>
    {
        private const int InitialSize = 4;

        private T[] array;
        private int pointer;

        /// <summary>
        /// Default constructor that initializes the stack with the default initial size
        /// </summary>
        public JStack() : this(InitialSize) { }

        /// <summary>
        /// Default constructor that initializes the stack with a specific initial size
        /// </summary>
        public JStack(int initialSize)
        {
            this.array = new T[initialSize];
            this.pointer = 0;
        }

        /// <summary>
        /// Adds an element to the top of the stack
        /// </summary>
        /// <param name="element">The element to add to the stack</param>
        public void Push(T element)
        {
            if (this.pointer == this.array.Length)
            {
                AutoGrow();
            }
            array[pointer] = element;
            pointer++;
        }

        /// <summary>
        /// Gets the top element in the stack WITHOUT removing it
        /// </summary>
        /// <returns>The top element from the stack</returns>
        public T Peek()
        {
            if (this.pointer==0)
            {
                throw new ArgumentException("The stack is empty");
            }

            T objectToReturn = this.array[this.pointer - 1];

            return objectToReturn;
        }

        /// <summary>
        /// The number of elements in the stack
        /// </summary>
        public int Count { get { return this.pointer;} }


        /// <summary>
        /// Removes the top element from the stack
        /// </summary>
        /// <returns>The top element from the stack</returns>
        public T Pop()
        {
            pointer--;
            return this.Peek();
        }

        private void AutoGrow()
        {
            T[] newArray = new T[2 * this.array.Length];
            Array.Copy(this.array, newArray, this.array.Length);
            this.array = newArray;
        }
    }
}
