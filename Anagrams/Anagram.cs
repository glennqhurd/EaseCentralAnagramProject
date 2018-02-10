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

        public Dictionary<String, List<String>> CheckedValues
        {
            get
            {
                return cValues;
            }
        }

        private String SortString(String input)
        {
            char[] characters = input.ToArray();
            Array.Sort(characters);
            return new string(characters);
        }

        private void ProcessList(List<String> input)
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
                    CheckedValues[sorted] = new List<String> {input[i]};
                }
            }
        }

        private List<String> CountGreaterThanOne()
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
                        partial += ", " + cValues[s][i];
                    }
                    result.Add(partial);
                }
            }
            return result;
        }

        public void ProcessFile(String filename)
        {
            String line;
            List<String> inputList = new List<String>();

            // Read the file and display it line by line.  
            System.IO.StreamReader file =
                new System.IO.StreamReader(filename);
            while ((line = file.ReadLine()) != null)
            {
                inputList.Add(line);
            }

            file.Close();

            ProcessList(inputList);
            List<String> greaterList = CountGreaterThanOne();
            for (int i = 0; i < greaterList.Count; i++)
            {
                Console.WriteLine(greaterList[i]);
            }
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Anagram anagram = new Anagram();

            anagram.ProcessFile(@"../../fileInput.txt");
        }
    }
}
