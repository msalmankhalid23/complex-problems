using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
/*
 /* Problem Statemnet:


An array A consisting of N integers is given. Rotation of the array means that each element is shifted right by one index, and the last element of the array is moved to the first place. For example, the rotation of array A = [3, 8, 9, 7, 6] is [6, 3, 8, 9, 7] (elements are shifted right by one index and 6 is moved to the first place).

The goal is to rotate array A K times; that is, each element of A will be shifted to the right K times.

Write a function:

    class Solution { public int[] solution(int[] A, int K); }

that, given an array A consisting of N integers and an integer K, returns the array A rotated K times.

For example, given
    A = [3, 8, 9, 7, 6]
    K = 3

the function should return [9, 7, 6, 3, 8]. Three rotations were made:
    [3, 8, 9, 7, 6] -> [6, 3, 8, 9, 7]
    [6, 3, 8, 9, 7] -> [7, 6, 3, 8, 9]
    [7, 6, 3, 8, 9] -> [9, 7, 6, 3, 8]

For another example, given
    A = [0, 0, 0]
    K = 1

the function should return [0, 0, 0]

Given
    A = [1, 2, 3, 4]
    K = 4

the function should return [1, 2, 3, 4]

Assume that:

        N and K are integers within the range [0..100];
        each element of array A is an integer within the range [−1,000..1,000].

In your solution, focus on correctness. The performance of your solution will not be the focus of the assessment.
Copyright 2009–2022 by Codility Limited. All Rights Reserved. Unauthorized copying, publication or disclosure prohibited 

*/
namespace ConsoleApp1
{
    class Test
    {

        static void Main(string[] args)
        {

            Console.WriteLine(string.Join(",", CyclicRotation(new int[] { 3, 5, 1, 1, 2 }, 6)));
            Console.WriteLine(string.Join(",", CyclicRotation(new int[] { 3 }, 100)));
            Console.WriteLine(string.Join(",", CyclicRotationWithArrayOnly(new int[] { 0, 0, 0, 0 }, 1)));

        }
        public static int[] CyclicRotation(int[] A, int K)
        {
            if (K == 0 || A.Length <= 1 || A.Length == K)
                return A;

            List<int> list = A.ToList();
            for (int i = 0; i < K; i++)
            {
                int lastVAl = list.LastOrDefault();
                list.RemoveAt(list.Count - 1);
                list.Insert(0, lastVAl);
            }

            return list.ToArray();
        }

        public static int[] CyclicRotationWithArrayOnly(int[] A, int K)
        {
            if (K == 0 || A.Length == 1 || A.Length == K)
                return A;
            //3, 8, 9, 7, 6
            for (int i = 0; i < K; i++)
            {
                int current = A[0];
                int next = A[1];
                for (int j = 0; j < A.Length - 1; j++)
                {
                    next = A[j + 1];
                    A[j + 1] = current;
                    current = next;
                }
                A[0] = next;
            }

            return A;
        }
    }
}

