using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Anagrams
{
    class Anagram
    {
        private Dictionary<String, String> cValues = new Dictionary<String, String>();
        private List<List<String>> results = new List<List<String>>();

        public Dictionary<String, String> CheckedValues
        {
            get
            {
                return cValues;
            }
            set
            {
                Type t = value.GetType();
                if (t.IsGenericType && t.GetGenericTypeDefinition() == typeof(Dictionary<,>))
                {
                    cValues = value;
                }
            }
        }

        public List<List<String>> Results
        {
            get
            {
                return results;
            }
            set
            {
                /*Type t = value.GetType();
                if (t.IsGenericType && t.GetGenericTypeDefinition() == typeof(List<List<String>>))
                {
                    results = value;
                }*/

                results = value;
            }
        }

        public void appendToResults(String input, int count)
        {
            results[count].Add(input);
        }

        public Boolean CompareKey(String key)
        {
            return cValues.ContainsKey(key);
        }

        public String SortString(String input)
        {
            char[] characters = input.ToArray();
            Array.Sort(characters);
            return new string(characters);
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Anagram gram = new Anagram();
            String test = "bca";
            test = gram.SortString(test);
            Console.WriteLine(test);

            Dictionary<String, String> dict = new Dictionary<String, String>
            {
                ["One"] = "Two",
                ["Three"] = "Four",
                ["Five"] = "Six"
            };
            gram.CheckedValues = dict;
            Console.WriteLine(gram.CheckedValues["One"]);
            Console.WriteLine(gram.CheckedValues["Three"]);
            Console.WriteLine(gram.CheckedValues["Five"]);

            List<List<String>> results = new List<List<String>>();
            List<String> list1 = new List<String>
            {
                "One",
                "Two"
            };
            results.Add(list1);
            gram.Results = results;
            Console.WriteLine(results[0][0]);
            Console.WriteLine(gram.Results[0][0]);
            Console.WriteLine(gram.Results[0][1]);
        }
    }
}
