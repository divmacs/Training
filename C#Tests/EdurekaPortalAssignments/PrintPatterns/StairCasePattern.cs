using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrintPatterns
{
    public class StairCasePattern
    {
        public void PrintStairCasePattern()
        {
            Console.WriteLine("Enter the number of steps to print");
            int input = Convert.ToInt32(Console.ReadLine());

            /*
             Input : 7
                
                *  *
                *  *  
                *  *  *  *
                *  *  *  *
                *  *  *  *  *  *
                *  *  *  *  *  *
                *  *  *  *  *  *  *
                *  *  *  *  *  *  * 
 
                i = 1,n = 6
             */

            Console.WriteLine();
            for (int i = 1; i <= input; i++)
            {
                for (int j = 1; j <= 2*i; j++)
                {
                    Console.Write("*  ");
                }
                Console.WriteLine();

                for (int j = 1; j <= 2*i; j++)
                {
                    Console.Write("*  ");
                }
                Console.WriteLine();
            }

        }
    }
}
