using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
/*
 Problem Statement


    A binary gap within a positive integer N is any maximal sequence of consecutive zeros that is surrounded by ones at both ends in the binary representation of N.

    For example, number 9 has binary representation 1001 and contains a binary gap of length 2. The number 529 has binary representation 1000010001 and contains two binary gaps: one of length 4 and one of length 3. The number 20 has binary representation 10100 and contains one binary gap of length 1. The number 15 has binary representation 1111 and has no binary gaps. The number 32 has binary representation 100000 and has no binary gaps.

    Write a function:

        class Solution { public int solution(int N); }

    that, given a positive integer N, returns the length of its longest binary gap. The function should return 0 if N doesn't contain a binary gap.

    For example, given N = 1041 the function should return 5, because N has binary representation 10000010001 and so its longest binary gap is of length 5. Given N = 32 the function should return 0, because N has binary representation '100000' and thus no binary gaps.

    Write an efficient algorithm for the following assumptions:

            N is an integer within the range [1..2,147,483,647].

    Copyright 2009–2022 by Codility Limited. All Rights Reserved. Unauthorized copying, publication or disclosure prohibited. 
*/
namespace ConsoleApp1
{
    class BinaryGap
    {

        static void Main(string[] args)
        {
           Dictionary<string, int> inputDicWithInt = new Dictionary<string, int>
            {
                { "2", 1073741727},
                { "3", 20000},
                { "0-", -50},
                { "0--", 0},
                { "1---", 5},
            };

            foreach (KeyValuePair<string, int> kvp in inputDicWithInt)
            {
                Console.WriteLine("input: " + string.Join(',', kvp.Value) + " expected Value: " + kvp.Key.ToString() + " Output: " + ReturnLongestBinaryGap(kvp.Value));
            }
           

        }
        //Find longest sequence of zeros in binary representation of an integer. 
        public static int ReturnLongestBinaryGap(int N)
        {
          
            if(N < 0 || N > 2147483647)
            {
                return 0;
            }
            string binary = Convert.ToString(N, 2);
            Console.WriteLine("Binary " + binary);
            int longestGap = 0;

            string [] gaps =  binary.Split('1');
            
            for(int i = 0; i < gaps.Length; i++)
            {
                string value = gaps[i];

                if (i == 0 && string.IsNullOrWhiteSpace(value))
                {
                    
                    continue;
                }
                if( i == gaps.Length-1 && !string.IsNullOrWhiteSpace(value))
                {
                    continue;
                }
                if(value.Length > longestGap)
                {
                    longestGap = value.Length;
                }
                
            }
            
            return longestGap;
        }
    }
}

