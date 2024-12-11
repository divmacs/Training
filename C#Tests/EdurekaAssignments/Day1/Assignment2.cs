using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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
        public static void CountNoOfWordsInSentence(string str)
        {
            string[] strArray = str.Split(' ');
            Console.WriteLine($"No of words in \"{str}\" : {strArray.Length}");
        }

        //3) Reverse a sentence
        public static void ReverseString(string str)
        {
            StringBuilder reverseString = new StringBuilder();
            for(int i = str.Length-1; i >= 0; i--)
            {
                reverseString.Append(str[i]);
            }
            Console.WriteLine("Actual string {0}: ",str);
            Console.WriteLine("Reverse string {0}: ",reverseString);
        }

        //4) Check whether the sentence is palindrome or not.
        public static void IsPalindrome(string str)
        {
            //oteeto
            bool isPalindrome = true;

            string newstr = Regex.Replace(str, "[^0-9A-Za-z]", string.Empty);
            newstr = newstr.Replace(" ",string.Empty);
            
            int start = 0, end = newstr.Length - 1;

            if (newstr.Length > 0)
            {
                while (start < end)
                {
                    if (char.ToLower(newstr[start]) != char.ToLower(newstr[end]))
                    {
                        isPalindrome = false;
                    }
                    start++;
                    end--;
                } 
            }
            if (isPalindrome)
                Console.WriteLine($"\"{str}\" is Palindrome");
            else
                Console.WriteLine($"\"{str}\" is not Palindrome");
        }

        //5) Count number of vowels, consonants, integers and special characters in the sentence.


        //Now take two strings and perform the following operations:
        //1) Compare them
        public static void CompareTwoString(string str1, string str2)
        {
            int length = string.Compare(str1, str2);
            if(length == 0)
            {
                Console.WriteLine("Both strings are of same length");
            }
            if(length > 0)
            {
                Console.WriteLine($"{str1} is greater than the {str2}");
            }
            else
            {
                Console.WriteLine($"{str1} is less than the {str2}");
            }
        }
        
        //2) Copy one string to other
        public static void CopyStrings(string str1)
        {
            string str2 = string.Copy(str1);
            Console.WriteLine($"{str1} and {str2} are same");
        }

        //3) Combine them and give third string
        public static void CombineTwoStrings(string str1, string str2)
        {
            string str3 = string.Join(" ",new string[] {str1,str2});
            Console.WriteLine("New string after combination is "+str3);
        }

        ///Take two numbers and perform following functions on them,
        ///1) Addition,subtraction,multiplication,division(Pass two numbers and this function should 
        ///return result of sum, difference, product and multiplication)
        public static void BasicOperationsOfTwoNumber(float num1, float num2)
        {
            Console.WriteLine($"Sum of {num1} and {num2} is : {num1+num2}");
            Console.WriteLine($"Difference of {num1} and {num2} is {Math.Abs(num1 - num2)}");
            Console.WriteLine($"Product of {num1} and {num2} is {num1*num2}");
            Console.WriteLine($"Quotient of {num1} and {num2} is {num1/num2}");
            Console.WriteLine($"Remainder of {num1} and {num2} is {num1%num2}");
        }

        //2) Print all tables from in between these two numbers
        public static void PrintTablesInRange(int min, int max) //int 2, int 4
        {
            for (int i = min; i <= max; i++)
            {
                for (int j = 1; j <= 10; j++)
                {
                    Console.WriteLine($"{i} * {j} = {i*j}");
                }
                Console.WriteLine("--------------------");
            }
        }
        //3) Print all prime numbers between these two numbers
        public static void PrintAllPrimeNumbersInRange(int start, int end)
        {
            int count = 0;
            Console.Write($"Prime numbers in between {start} and {end} are");
            for (int i = start; i <= end; i++)
            {
                for (int j = 1; j <= i; j++)
                {
                    if (i % j == 0)
                    {
                        count++;
                    }
                    if(count > 2)
                    {
                        count = 0;
                        break;
                    }
                }
                if(count == 2)
                    Console.Write(" " + i);
            }
        }

    }


}
