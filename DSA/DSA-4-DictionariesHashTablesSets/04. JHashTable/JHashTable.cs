﻿namespace _04.JHashTable
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    /// <summary>
    /// A new shiny hash table with key-value pairs
    /// </summary>
    /// <typeparam name="K">The type of keys in the JHash table</typeparam>
    /// <typeparam name="T">The type of values in the JHash table</typeparam>
    public class JHashTable<K,T> : IEnumerable<KeyValuePair<K,T>>
    {
        #region Error Messages
        private const string CapacityZeroOrNegativeErrorMessage = "Initial JHashTable size can not be less than or equal to 0!";
        #endregion

        private const int InitialCapacity = 16;
        private const double LoadFactor = 0.75;

        private LinkedList<KeyValuePair<K, T>>[] buckets;
        private int occupiedBucketsCounter;
        private int elementsCounter;

        #region Constructors
        /// <summary>
        /// Empty Constructor that initializes the hash table with the default initial size
        /// </summary>
        public JHashTable()
            : this(InitialCapacity) { }

        /// <summary>
        /// Constructor that initializes the hash table with predefined capacity
        /// </summary>
        /// <param name="capacity">The initial size of the JHash table</param>
        public JHashTable(int capacity)
        {
            if (capacity <= 0)
            {
                throw new ArgumentException(CapacityZeroOrNegativeErrorMessage);
            }
            this.buckets = new LinkedList<KeyValuePair<K, T>>[capacity];
            this.occupiedBucketsCounter = 0;
            this.elementsCounter = 0;
        }

        /// <summary>
        /// Constructor that initializes the hash table with predefined capacity
        /// </summary>
        /// <param name="capacity">The initial size of the JHash table</param>
        /// <param name="jHashTable">Another JHash table to inculde in this one</param>
        public JHashTable(int capacity, JHashTable<K,T> jHashTable)
            : this(capacity)
        {
            foreach (var pair in jHashTable)
            {
                this.Add(pair.Key, pair.Value);
            }
        }
        #endregion

        /// <summary>
        /// Add a new key-value pair to the JHasTable
        /// </summary>
        /// <param name="key">The key from the key-value pair to add</param>
        /// <param name="value">The value from the key-value pair to add</param>
        public void Add(K key, T value)
        {
            CheckAndGrow();

            var elementToAdd = new KeyValuePair<K,T>(key,value);

            int position = GetBucketPosition(key);

            if (this.buckets[position] == null)
            {
                this.buckets[position] = new LinkedList<KeyValuePair<K, T>>();
                this.buckets[position].AddFirst(elementToAdd);

                //only when we create a list in a table slot we increaze it's positions taken
                this.occupiedBucketsCounter++;
            }
            else
            {
                var currElement = this.buckets[position].First;
                for (int i = 0; i < this.buckets[position].Count; i++)
                {
                    if (currElement.Value.Key.Equals(key))
                    {
                        this.buckets[position].Remove(currElement);
                        break;
                    }

                    currElement = currElement.Next;
                }

                this.buckets[position].AddLast(elementToAdd);
            }

            this.elementsCounter++;
        }

        /// <summary>
        /// Finds a <typeparamref name="T"/> value by givven <typeparamref name="K"/> key
        /// </summary>
        /// <param name="key">The key from the key-value pair to find</param>
        /// <returns><typeparamref name="T"/> value or default</returns>
        public T Find(K key)
        {
            int position = GetBucketPosition(key);

            if (this.buckets[position] != null)
            {
                foreach (var pair in buckets[position])
                {
                    if (pair.Key.Equals(key))
                    {
                        return pair.Value;
                    }
                }
            }

            return default(T);
        }

        /// <summary>
        /// Removes a <typeparamref name="T"/> value by givven <typeparamref name="K"/> key
        /// </summary>
        /// <param name="key">The key from the key-value pair to remove</param>
        public void Remove(K key)
        {
            int position = GetBucketPosition(key);

            if (this.buckets[position] != null)
            {
                var valueToRemove = this.Find(key);

                if (valueToRemove != null)
	            {
                    var listNodeToRemove = this.buckets[position].First(x => x.Key.Equals(key));

                    this.buckets[position].Remove(listNodeToRemove);

                    this.elementsCounter--;

                    if (this.buckets[position].Count == 0)
                    {
                        this.buckets[position] = null;
                        this.occupiedBucketsCounter--;
                    }
	            }
            }
        }

        /// <summary>
        /// Cleares all the elements from the JHashTable
        /// </summary>
        public void Clear()
        {
            this.buckets = new LinkedList<KeyValuePair<K, T>>[this.buckets.Length];
            this.occupiedBucketsCounter = 0;
        }

        public T this[K key]
        {
            get
            {
                int position = GetBucketPosition(key);

                if (this.buckets[position] == null)
                {
                    return default(T);
                }
                else
                {
                    return this.buckets[position].First.Value.Value;
                }
            }

            set
            {
                this.Add(key, value);
            }
        }

        /// <summary>
        /// The number of elements in the JHash Table
        /// </summary>
        /// <returns><typeparamref name="int"/>The total elements in the JHash Table</returns>
        public int Count
        {
            get
            {
                return this.elementsCounter;
            }
        }

        /// <summary>
        /// A collection of all the keys in the JHash Table
        /// </summary>
        /// <returns>An array of <typeparamref name="K"/> elements</returns>
        public K[] Keys
        {
            get
            {
                var listOfKeys = new List<K>(this.elementsCounter);

                foreach (var pair in this)
                {
                    listOfKeys.Add(pair.Key);
                }

                return listOfKeys.ToArray();
            }
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            foreach (var pair in this)
            {
                sb.AppendFormat("({0}->{1}) ; ", pair.Key, pair.Value);
            }

            return sb.ToString().TrimEnd(new char[] { ';', ' ' });
        }


        public IEnumerator<KeyValuePair<K, T>> GetEnumerator()
        {
            foreach (var list in this.buckets)
            {
                if (list != null)
                {
                    foreach (var pair in list)
                    {
                        yield return pair;
                    }
                }
            }
        }

        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }

        private int GetBucketPosition(K key)
        {
            var position = key.GetHashCode() % this.buckets.Length;

            if (position < 0)
            {
                position = position * (-1);
            }

            return position;
        }

        private void CheckAndGrow()
        {
            if (this.occupiedBucketsCounter >= this.buckets.Length * LoadFactor)
            {
                var newJHashTable = new JHashTable<K, T>(this.buckets.Length * 2);

                foreach (var pair in this)
                {
                    newJHashTable.Add(pair.Key, pair.Value);
                }

                this.buckets = newJHashTable.buckets;
            }
        }
    }
}
