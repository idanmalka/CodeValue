using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Strings
{
    public class Program
    {
        //Cool
        public static void Reverse(string[] s) => Array.Reverse(s);

        // would be enough to write: str.Length == 0;
        public static bool CheckEmptyString(string str) => str.Length == 0 ? true : false;

        //Neet
        public static void SortReversedArray(string[] arr) => Array.Sort(arr);

        public static void Main(string[] args)
        {
            string sentence;

            //What about other white spaces or multiple whitespaces?
            string[] seperator = { " " };
            do
            {
                Console.WriteLine("Please enter a sentence");
                sentence = Console.ReadLine();
                if (sentence != null) sentence = sentence.Trim();
                else return;

                if (CheckEmptyString(sentence)) Environment.Exit(1);
                
                string[] words = sentence.Split(seperator, StringSplitOptions.None);
                Console.WriteLine($"The number of words: {words.Length}");


                Console.WriteLine("reversed:");
                for (int i = words.Length-1 ; i >=0 ; i--)
                {
                    Console.Write($"{words[i]} ");
                }
                Console.WriteLine();

                SortReversedArray(words);

                Console.WriteLine("Your sentence in reversed sorted order:");
                foreach (var word in words)
                    Console.WriteLine(word.ToString());

            } while (sentence.Length > 0);


        }


    }
}
