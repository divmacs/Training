using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day1
{
    public class Assignment2
    {
        //1) Count no.of characters in the sentence
        public static void CountNoOfChars(string input)
        {
            while (input.Length > 0)
            {
                int count = 0;
                Console.Write(input[0] + " = ");
                for (int i = 0; i < input.Length; i++)
                {
                    if (input[0] == input[i])
                    {
                        count++;
                    }
                } 
                Console.WriteLine(count);
                input = input.Replace(input[0].ToString(),String.Empty);
            }
        }

        //2) Count no.of words in a sentence
        //3) Reverse a sentence
        //4) Check whether the sentence is palindrome or not.
        //5) Count number of vowels, consonants, integers and special characters in the sentence.


        //Now take two strings and perform the following operations:
        //1) Compare them
        //2) Copy one string to other
        //3) Combine them and give third string

        ///Take two numbers and perform following functions on them,
        ///1) Addition,subtraction,multiplication,division(Pass two numbers and this function should 
        ///return result of sum, difference, product and multiplication)
        public void BasicOperationOfTwoNumber(float num1, float num2)
        {
            //Sum
            Console.WriteLine($"Sum of {num1} and {num2} is : {num1+num2}");
            Console.WriteLine($"Difference of {num1} and {num2} is {Math.Abs(num1 - num2)}");
            Console.WriteLine($"Product of {num1} and {num2} is {num1*num2}");
            Console.WriteLine($"Quotient of {num1} and {num2} is {num1/num2}");
            Console.WriteLine($"Remainder of {num1} and {num2} is {num1%num2}");
        }

        //2) Print all tables from in between these two numbers
        //3) Print all prime numbers between these two numbers


    }


}
