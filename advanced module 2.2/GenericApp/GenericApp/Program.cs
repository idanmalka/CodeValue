using System;
using System.Security.Cryptography;
using System.Collections.Generic;

namespace GenericApp
{
    [Key]
    public struct Keys
    {
        public int mynumber { private set; get; }
        private static Dictionary<int, Keys> _keys = new Dictionary<int, Keys>();
        
        public static implicit operator Keys(int key)
        {
            if (_keys.ContainsKey(key)) return _keys[key];
            Keys newKey = new Keys();
            newKey.mynumber = key;
            _keys.Add(key, newKey);
            return newKey;
        }

        public override string ToString()
        {
            return mynumber.ToString();
        }
    }// keys

    public struct myString {

        private string str;

        private myString(string s)
        {
            str = s;
        }

        public static implicit operator myString(string s)
        {
            return new myString(s);           
        }

        public override string ToString()
        {
            return str;
        }
    }

    class Program
    {
        public static void Main(string[] args)
        {
            var dictionary = new MultiDictionary<Keys, myString>
            {
                {1, "one"},
                {2, "two"},
                {3, "three"},
                {1, "ich"},
                {2, "nee"},
                {3, "sun"}
            };

            PrintDictionary(dictionary);

            Console.WriteLine($"Does the dictionary contain a key \"1\"? \n{dictionary.ContainsKey(1)} to that brother");
            Console.WriteLine($"Does the dictionary contain a key \"3\" and value \"sun\" ? \n{dictionary.Contains(3, "sun")} to that brother\n");
            Console.WriteLine("Removing all one's");
            try
            {
                dictionary.Remove(1);
            }
            catch (ArgumentOutOfRangeException e)
            {
                Console.WriteLine("there was no key called \"1\"");
            }

            PrintDictionary(dictionary);
            Console.WriteLine($"Now, does the dictionary contain a key \"1\"? \n{dictionary.ContainsKey(1)} to that brother\n");

            Console.WriteLine("Removing just \"nee\":");
            dictionary.Remove(2, "nee");
            PrintDictionary(dictionary);

            Console.WriteLine($"Now, does the dictionary contain a key \"2\" and value \"nee\"? \n{dictionary.Contains(2, "nee")} to that brother\n");

            Console.WriteLine("Clearing Dictionary");
            dictionary.Clear();
            PrintDictionary(dictionary);
        }


        private static void PrintDictionary<T,V>(IMultiDictionary<T,V> dictionary) where V:struct
        {
            Console.WriteLine($"Dictionary Contains {dictionary.Count} values:");
            Console.WriteLine($"Keys:");
            foreach (var item in dictionary.Keys)
                Console.Write($"{item} ");

            Console.WriteLine();
            Console.WriteLine($"Values:");
            foreach (var item in dictionary.Values)
                Console.Write($"{item} ");
            Console.WriteLine("\n");
        }
    }
}
