using System;

namespace GenericApp
{
    class Program
    {
        public static void Main(string[] args)
        {
            MultiDictionary<int,string> dictionary = new MultiDictionary<int, string>();
            dictionary.Add(1,"one");
            dictionary.Add(2,"two");
            dictionary.Add(3, "three");
            dictionary.Add(1, "ich");
            dictionary.Add(2, "nee");
            dictionary.Add(3, "sun");

            PrintDictionary(dictionary);

            Console.WriteLine($"Does the dictionary contain a key \"1\"? {dictionary.ContainsKey(1)} to that brother");
            Console.WriteLine($"Does the dictionary contain a key \"3\" and value \"sun\" ? {dictionary.Contains(3,"sun")} to that brother\n");
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
            Console.WriteLine($"Now, does the dictionary contain a key \"1\"? {dictionary.ContainsKey(1)} to that brother\n");

            Console.WriteLine("Removing just \"nee\":");
            dictionary.Remove(2, "nee");
            PrintDictionary(dictionary);

            Console.WriteLine($"Now, does the dictionary contain a key \"2\" and value \"nee\"? {dictionary.Contains(2,"nee")} to that brother\n");

            Console.WriteLine("Clearing Dictionary");
            dictionary.Clear();
            PrintDictionary(dictionary);
        }


        private static void PrintDictionary(IMultiDictionary<int,string> dictionary)
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
