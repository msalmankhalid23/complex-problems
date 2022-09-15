using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace ConsoleApp1
{
    class Program
    {

        static void Main(string[] args)
        {
            Console.WriteLine("Longest Gap" + ReturnLongestBinaryGap(6291457));
            //GeneratePassword(null);
           

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

        /*
        it has to contain only alphanumerical characters (a−z, A−Z, 0−9);
        there should be an even number of letters;
        there should be an odd number of digits.


         */
        public static int GeneratePassword(string S)
        {
            //valid: "5", "a0A" and "pass007".
            S = S.Trim();

            string[] data =  S.Split(" ");
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
                        if(pass.Length > longestPassword.Length)
                            longestPassword = pass;
                    }
                }
                
            }
            if(longestPassword.Length > 0)
            {
            Console.WriteLine("Longest password"+longestPassword);
                return longestPassword.Length;
            }
            return -1;

        }
    }
}

