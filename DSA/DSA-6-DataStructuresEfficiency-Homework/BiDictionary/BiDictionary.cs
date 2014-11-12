namespace BiDictionary
{
    using System;
    using System.Collections.Generic;

    using Wintellect.PowerCollections;

    public class BiDictionary<K1, K2, V>
    {
        private readonly MultiDictionary<K1, V> dict1;
        private readonly MultiDictionary<K2, V> dict2;
        private readonly MultiDictionary<Tuple<K1, K2>, V> dict3;

        public BiDictionary()
        {
            dict1 = new MultiDictionary<K1, V>(true);
            dict2 = new MultiDictionary<K2, V>(true);
            dict3 = new MultiDictionary<Tuple<K1, K2>, V>(true);
        }

        public void Add(K1 key1, K2 key2, V value)
        {
            this.dict1.Add(key1, value);
            this.dict2.Add(key2, value);
            this.dict3.Add(new Tuple<K1, K2>(key1, key2), value);
        }

        public ICollection<V> FindByFirstKey(K1 key)
        {
            return this.dict1[key]; 
        }

        public ICollection<V> FindBySecondKey(K2 key)
        {
            return this.dict2[key];
        }

        public ICollection<V> FindByBothKeys(K1 key1, K2 key2)
        {
            return this.dict3[new Tuple<K1, K2>(key1, key2)];
        }
    }
}
