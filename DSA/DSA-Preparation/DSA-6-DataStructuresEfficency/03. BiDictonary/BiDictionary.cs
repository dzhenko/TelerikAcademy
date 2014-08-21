namespace _03.BiDictionary
{
    using System;
    using System.Linq;
    using Wintellect.PowerCollections;

    /// <summary>
    /// A new shiny BiDictionary implementation
    /// </summary>
    /// <typeparam name="K1">Type of first key</typeparam>
    /// <typeparam name="K2">Type of second key</typeparam>
    /// <typeparam name="V">Type of values to store</typeparam>
    public class BiDictionary<K1,K2,V>
    {
        private MultiDictionary<K1, V> dict1;
        private MultiDictionary<K2, V> dict2;
        private MultiDictionary<int, V> dict3;

        /// <summary>
        /// Default constructor
        /// </summary>
        public BiDictionary()
        {
            this.dict1 = new MultiDictionary<K1, V>(true);
            this.dict2 = new MultiDictionary<K2, V>(true);
            this.dict3 = new MultiDictionary<int, V>(true);
        }

        /// <summary>
        /// Adds a new element to the BiDictionary
        /// </summary>
        /// <param name="key1">The first key</param>
        /// <param name="key2">The second key</param>
        /// <param name="element">The element to add</param>
        public void Add(K1 key1, K2 key2,V element)
        {
            this.dict1.Add(key1, element);
            this.dict2.Add(key2, element);

            var hash = this.GetHashFromTwoKeys(key1, key2);
            this.dict3.Add(hash, element);
        }

        /// <summary>
        /// Finds an array of values for givven first key
        /// </summary>
        /// <param name="key1">The key to search by</param>
        /// <returns>An array of <typeparamref name="V"/> elements</returns>
        public V[] FindByFirstKey(K1 key1)
        {
            return this.dict1[key1].ToArray();
        }

        /// <summary>
        /// Finds an array of values for givven second key
        /// </summary>
        /// <param name="key2">The key to search by</param>
        /// <returns>An array of <typeparamref name="V"/> elements</returns>
        public V[] FindBySecondKey(K2 key2)
        {
            return this.dict2[key2].ToArray();
        }

        /// <summary>
        /// Finds an array of values for givven first and second key
        /// </summary>
        /// <param name="key1">The first key to search by</param>
        /// <param name="key2">The second key to search by</param>
        /// <returns>An array of <typeparamref name="V"/> elements</returns>
        public V[] FindByBothKeys(K1 key1, K2 key2)
        {
            var hash = this.GetHashFromTwoKeys(key1, key2);
            return this.dict3[hash].ToArray();
        }

        private int GetHashFromTwoKeys(K1 key1, K2 key2)
        {
            return key1.GetHashCode() ^ key2.GetHashCode();
        }
    }
}
