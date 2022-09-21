using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
/*
 /* Problem Statemnet:
Write a function:

    class Solution { public int solution(int[] A); }

that, given an array A of N integers, returns the smallest positive integer (greater than 0) that does not occur in A.

For example, given A = [1, 3, 6, 4, 1, 2], the function should return 5.

Given A = [1, 2, 3], the function should return 4.

Given A = [−1, −3], the function should return 1.

Write an efficient algorithm for the following assumptions:

        N is an integer within the range [1..100,000];
        each element of array A is an integer within the range [−1,000,000..1,000,000].

Copyright 2009–2022 by Codility Limited. All Rights Reserved. Unauthorized copying, publication or disclosure prohibited. 

*/
namespace ConsoleApp1
{
    class MissingNumberInSequence
    {

        static void Main(string[] args)
        {
            Dictionary<string, int[]> inputDicWithIntArray = new Dictionary<string, int[]>
            {
                { "4", new int[] {-1000000,1 , 2, 3}},
                { "5", new int[] {1, 3, 6, 4, 1, 2}},
                { "1-", new int[] {-1,-2, -3, 0,100}},
                { "1--", new int[] {-1,-3,-10,4}},
                { "1---", new int[] {-10,4}},
            };

            foreach (KeyValuePair<string, int[]> kvp in inputDicWithIntArray)
            {
                Console.WriteLine("input: " + string.Join(',', kvp.Value.ToList()) + " expected Value: " + kvp.Key.ToString() + " Output: " + MissingNumber(kvp.Value.ToArray()));
            }

        }
        static int MissingNumber(int[] A)
        {
            if (A == null || A.Length <= 0)
                return 1;
            Array.Sort(A);

            int missingVal = 1;
            foreach (int val in A)
            {
                if (val == missingVal)
                {
                    missingVal++;
                }
                if (val > missingVal)
                {
                    break;
                }
            }

            return missingVal;
        }
    }
}

