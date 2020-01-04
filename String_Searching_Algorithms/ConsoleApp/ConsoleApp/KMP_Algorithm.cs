using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp
{
    public class KMP_Algorithm
    {

        public void Start()
        {
            bool result = kmpalgo("abcxabcdabcdabcy", "abcdabcy");

            if(result)
                Console.WriteLine("TRUE");
            else
                Console.WriteLine("FALSE");
        }

        public int[] ComputePrefixTable(string pattern)
        {
            int[] table = new int[pattern.Length];

            int j = 0, i = j + 1;
            table[0] = j;

            while(i < pattern.Length)
            {
                if (pattern[i] == pattern[j])
                {
                    table[i] = j + 1;
                    i++;j++;
                }                    
                else
                {
                    if (j != 0)
                        j = table[j - 1]; //If mismatch occurs then consider the j value as
                                          // value of previous location where mismatch occurs.     
                    else
                    {
                        table[i] = 0;
                        i++;
                    }
                }
            }

            //for (int k = 0; k < table.Length; k++)
            //{
            //    Console.WriteLine($"k[{k}] is { table[k] }");
            //}

            return table;
        }

        public bool kmpalgo(string text,string pattern)
        {
            int[] lps = ComputePrefixTable(pattern);
            int i = 0, j = 0;

            while(i < text.Length && j < pattern.Length)
            {
                if(text[i].Equals(pattern[j]))
                {
                    i++;j++;
                }
                else
                {
                    if (j != 0)
                        j = lps[j - 1];
                    else
                    {
                        i++; //This will start comparing text with first char of pattern
                    }
                }
            }

            if (j == pattern.Length)
                return true;

            return false;

        }
    }
}
