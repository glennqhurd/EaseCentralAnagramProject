using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Anagrams
{
    class Anagram
    {
        private Dictionary<String, List<String>> cValues = new Dictionary<String, List<String>>();
        private List<List<String>> results = new List<List<String>>();

        public Dictionary<String, List<String>> CheckedValues
        {
            get
            {
                return cValues;
            }
            /*set
            {
                Type t = value.GetType();
                if (t.IsGenericType && t.GetGenericTypeDefinition() == typeof(Dictionary<,>))
                {
                    cValues = value;
                }
            }*/
        }

        public List<List<String>> Results
        {
            get
            {
                return results;
            }
            set
            {
                results = value;
            }
        }

        public void AppendToResults(String input, int count)
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

        public void ProcessList(List<String> input)
        {
            for(int i = 0; i < input.Count; i++)
            {
                String sorted = SortString(input[i]);
                if(CheckedValues.ContainsKey(sorted))
                {
                    CheckedValues[sorted].Add(input[i]);
                }
                else
                {
                    CheckedValues[sorted] = new List<String> {input[i] };
                }
            }
        }

        public List<String> CountGreaterThanTwo()
        {
            Dictionary<String, List<String>>.KeyCollection keyColl = cValues.Keys;
            List<String> result = new List<string>();

            foreach (String s in keyColl)
            {
                if (cValues[s].Count > 1)
                {
                    String partial = cValues[s][0];
                    for (int i = 1; i < cValues[s].Count; i++)
                    {
                        partial += " " + cValues[s][i];
                    }
                    result.Add(partial);
                }
            }

            return result;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            //Testing different methods of Anagram below
            Anagram gram = new Anagram();
            String test = "bca";
            test = gram.SortString(test);
            Console.WriteLine(test);

            /*Dictionary<String, String> dict = new Dictionary<String, String>
            {
                ["One"] = "Two",
                ["Three"] = "Four",
                ["Five"] = "Six"
            };
            gram.CheckedValues = dict;
            Console.WriteLine(gram.CheckedValues["One"]);
            Console.WriteLine(gram.CheckedValues["Three"]);
            Console.WriteLine(gram.CheckedValues["Five"]);*/

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

            List<String> listToSort = new List<String> {"abc", "acb", "def", "ghi", "igh", "hig"};
            gram.ProcessList(listToSort);
            Console.WriteLine(gram.CheckedValues["abc"].Count);
            Console.WriteLine(gram.CheckedValues["def"].Count);
            Console.WriteLine(gram.CheckedValues["ghi"].Count);

            List<String> listGreater = gram.CountGreaterThanTwo();
            for (int i = 0; i < listGreater.Count; i++)
            {
                Console.WriteLine("listGreater {0} ", i + listGreater[i]);
            }
        }
    }
}
