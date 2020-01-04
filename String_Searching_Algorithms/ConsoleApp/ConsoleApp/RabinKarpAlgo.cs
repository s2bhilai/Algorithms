using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp
{
    public class RabinKarpAlgo
    {
        const int hbase = 256;
        const int prime = 101;

        public void AlgoSteps()
        {
            string subStr = string.Empty;
            bool rollingHash = false;
            double firstCharValue = 0.0;
            double textHashValue = 0.0;
            double patternHashValue = 0.0;

            string pattern = "bra";//hia
            string text = "abra";

            //Calculate Pattern Hash
            patternHashValue = ComputeHash(pattern);

            for (int i = 0; i <= text.Length - pattern.Length; i++)
            {
                subStr = text.Substring(i, pattern.Length);               

                if (!rollingHash)
                {
                    textHashValue = ComputeHash(subStr);
                    rollingHash = true;
                }                    
                else
                    textHashValue = ComputeRollingHash(textHashValue, subStr[pattern.Length - 1], firstCharValue);

                //Store the Value of first Char for Computing Rolling Hash
                firstCharValue = ((int)text[i] * (Math.Pow(hbase, (double)pattern.Length - 1 - i))) % prime;

                if (textHashValue == patternHashValue)
                {
                    int j = 0;
                    while (j < pattern.Length)
                    {
                        if(subStr[j] == pattern[j])
                        {
                            j++;
                        }
                    }

                    if(j == pattern.Length)
                        Console.WriteLine($"Pattern Found at position { i }");
                }
            }
        }

        public double ComputeHash(string str)
        {
            int strLength = str.Length;
            double sum = 0;

            for (int i = 0; i < str.Length; i++)
            {
                sum += ( (int)str[i] * ( Math.Pow(hbase, (double)strLength - 1 - i) ) ) % prime;
            }

            return sum % prime;
        }

        public double ComputeRollingHash(double previousHashValue,char nextChar,double previousFirstCharComputedValue)
        {
            double nextHashValue = 0.0;

            nextHashValue = ( ((previousHashValue + (prime - previousFirstCharComputedValue)) * hbase) +
                (int)nextChar) % prime;

            return nextHashValue;
        }


    }
}
