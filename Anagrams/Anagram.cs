using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Anagrams
{
    class Program
    {
        static void Main(string[] args)
        {
            Anagram anagram = new Anagram();

            // @"../../fileInput.txt" is the file name for the input file used.
            anagram.ProcessFile(@"../../fileInput.txt");
        }
    }

    class LoadFile
    {
        // I kept the load function in a separate class for clarity reasons and also so it could be reused
        // if needed.  It reads a file and stores each line in a List element then returns the List<String>.
        public List<String> ReadFile(String filename)
        {
            String line;
            List<String> inputList = new List<String>();

            // Read the file and display it line by line.  
            System.IO.StreamReader file = new System.IO.StreamReader(filename);
            while ((line = file.ReadLine()) != null)
            {
                inputList.Add(line);
            }

            file.Close();

            return inputList;
        }
    }

    class Anagram
    {
        private Dictionary<String, List<String>> cValues = new Dictionary<String, List<String>>();

        // Added a getter but no setter since I may want to retrieve the values but to change them I use
        // separate methods.
        public Dictionary<String, List<String>> CheckedValues
        {
            get
            {
                return cValues;
            }
        }

        // Method that starts the chain of methods then after everything has been processed prints out 
        // the results to Console
        public void ProcessFile(String filename)
        {
            LoadFile lfile = new LoadFile();

            ProcessList(lfile.ReadFile(filename));
            List<String> greaterList = CountGreaterThanOne();
            for (int i = 0; i < greaterList.Count; i++)
            {
                Console.WriteLine(greaterList[i]);
            }
        }

        // Method that alphabetically sorts the String.
        private String SortString(String input)
        {
            char[] characters = input.ToArray();
            Array.Sort(characters);
            return new string(characters);
        }

        // Method that loops through a List<String> and uses SortString to sort each element then
        // checks to see if the sorted element is already a key in the Dictionary CheckedValues.  If
        // it is then the original unsorted element gets appended to the List<String> in the value.
        // If there is not a key for the sorted element then a key is assigned and a new List<String> is
        // added with an initial element added of the original value.
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

        // Method that counts the number of values in the Dictionary for each key and appends each Key that has
        // 2 or more elements in their List<String> value. 
        private List<String> CountGreaterThanOne()
        {
            Dictionary<String, List<String>>.KeyCollection keyColl = cValues.Keys;
            List<String> result = new List<String>();

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
    }
}
