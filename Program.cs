using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NameGen
{
    class Program
    {
        static void Main(string[] args)
        {
            string input1 = "[S|Sp|Sk|St|T] [a|e|i|o|u|y] [r|t|p|d|f|j|k|l|v|b|n|m] [a|e|i|o|u|y] [q|p|k|ck|l]";
            string input2 = "[S|Sp|Sk|St|T] [a|e|i|o|u|y] [q|p|k|ck|l]";
            string input3 = "[T’|C] [P|K|Q] [a|e|i|o|u|y] [r|j|’p|k|l]";
            MakeName(input2);

            
        }

        static List<string[]> CleanInput(string input)
        {
            List<string> splitInput = input.Split(' ').ToList();

            List<string[]> output = new List<string[]>();

            for (int i = 0; i < splitInput.Count; i++)
            {
                splitInput[i] = splitInput[i].Replace("[", "");

                splitInput[i] = splitInput[i].Replace("]", "");

                splitInput[i] = splitInput[i].Replace('|', ' ');

                output.Add(splitInput[i].Split(' ').ToArray());
            }

            
            return output;
        }

        static void MakeName(string input)
        {
            List<string[]> CleanedInput = CleanInput(input);
            List<string> names = new List<string>();
            
            
            NameGenerator(CleanedInput, 0, names, "");
        }
        

        static void NameGenerator(List<string[]> input, int i, List<string> names, string name)
        {
            if (input.Count > i + 1) {
                foreach (string str in input[i])
                {
                    string newName = name + str;
                    
                    int newi = i + 1;

                    NameGenerator(input, newi, names, newName);
                }
            } else
            {
                foreach (string str in input[i])
                {
                    string newName = name + str;

                    names.Add(newName);
                }
            }
            
        }


    }



}
