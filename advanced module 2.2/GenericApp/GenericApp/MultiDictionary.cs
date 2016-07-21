using System;
using System.Collections;
using System.Collections.Generic;

namespace GenericApp
{
    
    public class MultiDictionary<K,V>  : IMultiDictionary<K, V>, IEnumerable<KeyValuePair<K, IEnumerable<V>>>  where V:struct
    {
        public ICollection<K> Keys => _dictionary.Keys;
        public ICollection<V> Values { get; }
        public int Count { get; private set; }
        private Dictionary<K, LinkedList<V>> _dictionary;

        public MultiDictionary()
        {
            Count = 0;
            Values = new List<V>();
            _dictionary = new Dictionary<K, LinkedList<V>>();
        }

        public void Add(K key, V value)
        {
            bool validKey = false;
            var keyAttributes = key.GetType().GetCustomAttributes(typeof(KeyAttribute),false);

            foreach (KeyAttribute att in keyAttributes)
                validKey = true;
            
            if (!validKey) throw new Exception($"{key} is an invalid key");

            if (!_dictionary.ContainsKey(key))
                _dictionary.Add(key, new LinkedList<V>());

            _dictionary[key].AddLast(value);
            Values.Add(value);
            ++Count;
        }

        public void CreateNewValue(K key)
        {
            var newItem = Activator.CreateInstance(typeof(V));
            Add(key,(V)newItem);
        }

        public bool Remove(K key)
        {
            if (!ContainsKey(key)) throw new ArgumentOutOfRangeException();
            Count -= _dictionary[key].Count;
            foreach (var item in _dictionary[key])
                Values.Remove(item);
            return _dictionary.Remove(key);
        }

        public bool Remove(K key, V value)
        {
            if (_dictionary.ContainsKey(key))
            {
                Values.Remove(value);
                --Count;
                return _dictionary[key].Remove(value);

            }
            return false;
        }

        public void Clear()
        {
            _dictionary.Clear();
            Count = 0;
            Values.Clear();
        }

        public bool ContainsKey(K key)
        {
            return _dictionary.ContainsKey(key);
        }
        
        public bool Contains(K key, V value)
        {
            if (_dictionary.ContainsKey(key))
                return _dictionary[key].Contains(value);
            return false;
        }
        

        public IEnumerator<KeyValuePair<K, IEnumerable<V>>> GetEnumerator()
        {
            foreach (var pair in _dictionary)
            {
                yield return new KeyValuePair<K, IEnumerable<V>>(pair.Key, pair.Value);
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
