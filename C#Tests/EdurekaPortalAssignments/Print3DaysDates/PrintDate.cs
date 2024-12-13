using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Print3DaysDates
{
    public class PrintDate
    {
        DateTime todayDate = DateTime.Now;
        public void PrintDates()
        {
            Console.WriteLine("Today's Date:");
            Console.WriteLine(todayDate.ToString("M/dd/yyyy hh:mm:ss tt"));
            Console.WriteLine("Tomorrow's Date:");
            Console.WriteLine(todayDate.AddDays(1).ToString("M/dd/yyyy hh:mm:ss tt"));
            Console.WriteLine("Yesterday's Date:");
            Console.WriteLine(todayDate.AddDays(-1).ToString("M/dd/yyyy hh:mm:ss tt"));
        }
    }
}
