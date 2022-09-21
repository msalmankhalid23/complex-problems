using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
/*
 Problem Statement
 

You would like to set a password for a bank account. However, there are three restrictions on the format of the password:

        it has to contain only alphanumerical characters (a−z, A−Z, 0−9);
        there should be an even number of letters;
        there should be an odd number of digits.

You are given a string S consisting of N characters. String S can be divided into words by splitting it at, and removing, the spaces. The goal is to choose the longest word that is a valid password. You can assume that if there are K spaces in string S then there are exactly K + 1 words.

For example, given "test 5 a0A pass007 ?xy1", there are five words and three of them are valid passwords: "5", "a0A" and "pass007". Thus the longest password is "pass007" and its length is 7. Note that neither "test" nor "?xy1" is a valid password, because "?" is not an alphanumerical character and "test" contains an even number of digits (zero).

Write a function:

    class Solution { public int solution(String S); }

that, given a non-empty string S consisting of N characters, returns the length of the longest word from the string that is a valid password. If there is no such word, your function should return −1.

For example, given S = "test 5 a0A pass007 ?xy1", your function should return 7, as explained above.

Assume that:

        N is an integer within the range [1..200];
        string S consists only of printable ASCII characters and spaces.

In your solution, focus on correctness. The performance of your solution will not be the focus of the assessment.
Copyright 2009–2022 by Codility Limited. All Rights Reserved. Unauthorized copying, publication or disclosure prohibited. 
*/
namespace ConsoleApp1
{
    class BinaryGap
    {

        static void Main(string[] args)
        {
            string[] input = { "test 5 a0A pass007 ?xy1", "jklmo5", "a", "ab", "5", "550ab", "4adf4dsk45", "asdf! 3ab qqqq adw3" };
            foreach (var value in input)
            {
                Console.WriteLine(GeneratePassword(value));
            }


        }
        
        public static int GeneratePassword(string S)
        {
            //valid: "5", "a0A" and "pass007".
            S = S.Trim();

            string[] data = S.Split(" ");
            string longestPassword = "";
            bool isValid = false;
            for (int i = 0; i < data.Length; i++)
            {
                string pass = data[i].Trim();
                isValid = false;
                if (Regex.IsMatch(pass, "^[a-zA-Z0-9]*$"))
                {

                    var letterCount = pass.Count(char.IsLetter);
                    var digitCount = pass.Count(char.IsDigit);
                    if (letterCount > 0 && letterCount % 2 == 0)
                    {
                        isValid = true;
                    }
                    if (digitCount > 0 && digitCount % 2 == 1)
                    {
                        isValid = true;
                    }
                    if (isValid)
                    {
                        if (pass.Length > longestPassword.Length)
                            longestPassword = pass;
                    }
                }

            }
            if (longestPassword.Length > 0)
            {
                return longestPassword.Length;
            }
            return -1;

        }
    }
}

