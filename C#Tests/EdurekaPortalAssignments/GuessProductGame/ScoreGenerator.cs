using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuessProductGame
{
    public class ScoreGenerator
    {
        public void FindAndValidateProduct(int num1, int num2)
        {
            Console.WriteLine($"What's {num1} times {num2}?");
            int input = Convert.ToInt32(Console.ReadLine());
            if (input == (num1 * num2))
            {
                Console.WriteLine("That’s the correct answer!\nYour score: 1");
            }
            else
            {
                Console.WriteLine("Sorry,That’s incorrect answer!Your score: 0");
            }
        }
    }
}
