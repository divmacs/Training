using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CollectionsAssignment
{
    internal class Helper
    {
       internal void SortInputStrings()
       {
            Console.WriteLine("Enter list of strings to sort(seperated by space)");
            string input = Console.ReadLine();
            string[] strArr = input.Split(' ');
            List<string> lstStr = new List<string>();
            foreach (string str in strArr)
            {
                lstStr.Add(str);
            }
            lstStr.Sort();
            Console.WriteLine("Sorted String are: ");
            foreach (var str in lstStr)
            {
                Console.WriteLine(str);
            }
       }
    }
}
