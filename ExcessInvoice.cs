using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
/*
 Problem Statement
 
An internal unit of company XYZ provides services to other departments.


Service prices are fixed at the beginning of the quarter based on projected expenses and utilization. However, usage is billed at the end of the quarter.

So while composing quarterly invoices there may be an excess. We suppose planning is very go so there is only ever a modest overage.

This amount should be returned to the departments by discounting a portion of it on each invoice

Your job is to write a function which considers the excess S and allocates it fairly. Allocation proceeds from the largest to the smallest invoice. And is distributed as the ratio of the invoice's contribution to the sum of itself and those which follow.

Example 1:

Given S="300.01" and B= ["300.00", "200.00","100.00"].

R[0]="150.00" (=300.01 * 300.00/600.00) 
R[1]="100.00" (=150.01 * 200.00/300.00)
R[2]="50.01" (=50.01*100.00/100.00)

Example 2 (Pay careful attention to this one).

Given S="1.00" and B=["0.05","1.00"]. 1. First we consider 1.00 because it is the largest,

a. 1.00*1.00/1.05~0.95238...

b. Round 0.95238... to "0.95". Rounding down to carry pennies to smaller departments. 
c. Set R[1]=0.95. Notice, this is in the same place as 1.00. It is the 2nd value in the result! 2. Now we have 0.05 left

3. Next we look at the smaller B[0]=0.05 department

a. 0.05 0.05/0.05 = 0.05 b. No rounding required

c. Set R[0]=0.05. R=["0.05", "0.95"]

Write a function:

class Solution { public String[] solution(String S, String[] B); }

that, given a string S representing the total excess billables and an array B consisting of K strings representing the undiscounted bills for each 
customer. The return value should be an array of strings R (length M) in the same order as B representing the amount of the discount to each customer.

Notes:

1. The total S should be completely refunded. Neither more nor less than S should be returned. Don't lose or gain a penny!

2. Be careful with the types you choose to represent currencies. Floating points numbers are notoriously error prone for precise calculations with 
currencies.

Test Output

3. Amounts should be rounded down to the nearest $0.01. By design, fractional pennies are pushed to groups with smaller unadjusted invoices.

4. Results should be represented with 2 decimal places of precision as strings, even if these are both zeroes. ex. "100.00" 5. 
You may assume sensible inputs. The total to be discounted will never exceed the total of the unadjusted invoices.

6. Please do pay attention to returning the discounts in the same order as the incoming invoices.

*/
namespace ConsoleApp1
{
    class ExcessInvoice
    {

        static void Main(string[] args)
        {
            Console.WriteLine(string.Join(",", AllocateExcess("300.01", new string[] { "300.00", "200.00", "100.00" })));
            Console.WriteLine(string.Join(",", AllocateExcess("1.00", new string[] { "0.05", "1.00" })));

        }
        static string[] AllocateExcess(string S, string[] B)
        {
            var list = B.ToList();
            list = list.OrderByDescending(s => s).ToList();
            decimal sum = list.Sum(s => Convert.ToDecimal(s));
            string[] output = new string[B.Length];
            decimal actualValue = Convert.ToDecimal(S);
            decimal updateAllocation = actualValue;
            foreach (var item in list)
            {
                decimal decimalItem = Convert.ToDecimal(item);
                decimal allocation = updateAllocation * decimalItem / sum;
                decimal roudnedAllocation = RoundDecimal(allocation);

                int index = Array.IndexOf(B, item);
                output[index] = roudnedAllocation.ToString();

                updateAllocation -= roudnedAllocation;
                sum -= decimalItem;
            }

            return output.ToArray();
        }

        static decimal RoundDecimal(decimal value)
        {

            var array = value.ToString().Split('.');
            string roundedString = value.ToString();
            if (array.Length > 1)
            {
                roundedString = $"{array[0]}.{array[1].Substring(0, 2)}";
            }

            return Convert.ToDecimal(roundedString);
        }
    }
}

