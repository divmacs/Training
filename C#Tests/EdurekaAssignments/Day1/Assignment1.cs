using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day1
{
    public class Assignment1
    {
        public static void Display2To100()
        {
            for (int i = 2; i <= 100; i++)
            {
                if (i % 2 != 0)
                    continue;
                else
                    Console.WriteLine(i);
            }
        }

        public static void DisplayTableOfNumber()
        {
            int inputNumber, range;
            Console.WriteLine("Enter a number to print table");
            inputNumber = int.Parse(Console.ReadLine());
            Console.WriteLine("Enter range for table");
            range = int.Parse(Console.ReadLine());

            for (int i = 1; i <= range; i++)
            {
                int product = inputNumber * i;
                Console.WriteLine($"{inputNumber}*{i} = {product}");
            }
        }

        public static void CheckInputCharacter()
        {
            char ch;
            Console.WriteLine("Enter a character");
            ch = Convert.ToChar(Console.ReadLine());
            Console.WriteLine();
            char lowerCh = char.ToLower(ch);

            bool IsVowel(char input)
            {

                if (lowerCh == 'a' || lowerCh == 'e' || lowerCh == 'i' || lowerCh == 'o' || lowerCh == 'u')
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }

            if (IsVowel(ch))
                Console.WriteLine("You have entered vowel " + ch);
            else if (lowerCh >= 'a' || lowerCh <= 'z')
                Console.WriteLine("You have entered consonant " + ch);
            else if (char.IsDigit(ch))
                Console.WriteLine("You have entered number " + ch);
            else
                Console.WriteLine("You have entered special char " + ch);

        }

        public static void IsPrime()
        {
            int num, count = 0;
            Console.WriteLine("Enter a number to check prime or not");
            num = Convert.ToInt32(Console.ReadLine());

            for (int i = 1; i <= num; i++)
            {
                if (num % i == 0)
                {
                    count++;
                }
            }
            if (count == 2)
            {
                Console.WriteLine($"{num} is prime number");
            }
            else
            {
                Console.WriteLine($"{num} is not prime number");
            }
        }

        public static void DisplaySumOfTenNumbers()
        {
            int[] nums = new int[10];
            int sum = 0;
            Console.WriteLine("Enter 10 numbers ");
            string input = Console.ReadLine();

            nums = input.Split(' ').Select(int.Parse).ToArray();

            /*for (int i = 0; i < nums.Length; i++)
            {
                nums[i] = Convert.ToInt32(Console.ReadLine());
            }*/

            foreach (var num in nums)
            {
                sum += num;
            }

            Console.WriteLine($"Sum of given ten numbers is {sum}");

        }

        public static void SumOfTenPositiveNumbers()
        {

        }

        public static void SplitName()
        {
            Console.WriteLine("Enter your name");
            string input = Console.ReadLine(); 
            string[] firstlastNames = input.Split(' ');

            foreach(var name in firstlastNames)
            {
                Console.WriteLine(name);
            }
        }

        public static void CountNoOfVowels()
        {
            Console.WriteLine("Enter a name to count vowels");
            string input = Console.ReadLine();
            int count = 0;

            foreach (char item in input.ToLower())
            {
                if (item == 'a' || item == 'e' || item == 'i' || item == 'o' || item == 'u')
                {
                    count++;
                }
            }

            Console.WriteLine("No of vowels in given name is " + count); 
        }

    }
}
