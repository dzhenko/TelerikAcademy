namespace _05.JSet
{
    using System;
    using System.Collections.Generic;
    using _04.JHashTable;

    /// <summary>
    /// A new shiny set of elements
    /// </summary>
    /// <typeparam name="T">The type of elements in the JSet</typeparam>
    public class JSet<T> : IEnumerable<T>
    {
        private JHashTable<int, T> elements;

        /// <summary>
        /// Empty Constructor that initializes the JSet
        /// </summary>
        public JSet()
        {
            this.elements = new JHashTable<int, T>();
        }

        /// <summary>
        /// Add a new <typeparamref name="T"/> element to the JSet 
        /// </summary>
        /// <param name="element">The element to add to the JSet</param>
        public void Add(T element)
        {
            this.elements.Add(element.GetHashCode(), element);
        }

        /// <summary>
        /// Removes a <typeparamref name="T"/> element from the JSet 
        /// </summary>
        /// <param name="element">The element to remove from the JSet</param>
        public void Remove(T element)
        {
            this.elements.Remove(element.GetHashCode());
        }

        /// <summary>
        /// Finds a <typeparamref name="T"/> value by givven <typeparamref name="K"/> key
        /// </summary>
        /// <param name="element">The element to search for</param>
        /// <returns><typeparamref name="T"/> value or default</returns>
        public T Find(T element)
        {
            T returnedElement;
            if(this.elements.Find(element.GetHashCode(), out returnedElement))
            {
                return returnedElement;
            }

            return default(T);
        }

        /// <summary>
        /// The number of elements in the JSet
        /// </summary>
        /// <returns><typeparamref name="int"/>The total elements in the JSet</returns>
        public int Count
        {
            get
            {
                return this.elements.Count;
            }
        }

        /// <summary>
        /// Cleares all the elements from the JSet
        /// </summary>
        public void Clear()
        {
            this.elements.Clear();
        }

        /// <summary>
        /// Produces a JSet of <typeparamref name="T"/> values intersected with another JSet <typeparamref name="K"/> key
        /// </summary>
        /// <param name="other">The other JSet to intersect with</param>
        /// <returns><typeparamref name="JSet<T>"/></returns>
        public JSet<T> Intersect(JSet<T> other)
        {
            JSet<T> newSet = new JSet<T>();

            foreach (var element in this)
            {
                foreach (var otherElement in other)
                {
                    if (element.Equals(otherElement))
                    {
                        newSet.Add(element);
                    }
                }
            }

            return newSet;
        }

        /// <summary>
        /// Produces a JSet of <typeparamref name="T"/> values united with another JSet <typeparamref name="K"/> key
        /// </summary>
        /// <param name="other">The other JSet to union with</param>
        /// <returns><typeparamref name="JSet<T>"/></returns>
        public JSet<T> Union(JSet<T> other)
        {
            JSet<T> newSet = new JSet<T>();

            foreach (var element in this)
            {
                newSet.Add(element);
            }

            foreach (var element in other)
            {
                newSet.Add(element);
            }

            return newSet;
        }

        public IEnumerator<T> GetEnumerator()
        {
            foreach (var pair in this.elements)
            {
                yield return pair.Value;
            }
        }

        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }

        public override string ToString()
        {
            return string.Join(", ", this);
        }
    }
}
