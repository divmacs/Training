using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultiplicationTable
{
    public class Table
    {
        public void DisplayTableOfNumber()
        {
            int inputNumber;
            Console.WriteLine("Input the number (Table to be calculated) : ");
            inputNumber = int.Parse(Console.ReadLine());

            for (int i = 1; i <= 10; i++)
            {
                int product = inputNumber * i;
                Console.WriteLine($"{inputNumber} x {i} = {product}");
            }
        }

        public void CountLengthOfString()
        {
            Console.WriteLine("Input the string : ");
            string input = Console.ReadLine();
            Console.WriteLine("Length of the string is : "+input.Length);
        }
    }
}
