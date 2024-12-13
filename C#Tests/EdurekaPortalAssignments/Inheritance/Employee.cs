using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inheritance
{
    public class Employee
    {
        private static int _EmpIdIndex = 100;
        static List<Employee> _EmpList = new List<Employee>();
        public int Id { get; set; }
        public string Name { get; set; }
        public double Salary { get; set; }
        public Employee()
        {

        }
        public Employee(string name, double salary)
        {
            Id = _EmpIdIndex++;
            Name = name;
            Salary = salary;
        }

        public void GetEmployeeDetails()
        {
            Console.WriteLine("Enter First Employee Name");
            string name1 = Console.ReadLine();
            Console.WriteLine("Enter First Employee salary");
            double salary1 = Convert.ToDouble(Console.ReadLine());
            Console.WriteLine("Enter Second Employee Name");
            string name2 = Console.ReadLine();
            Console.WriteLine("Enter Second Employee salary");
            double salary2 = Convert.ToDouble(Console.ReadLine());

            _EmpList.Add(new Employee(name1,salary1));
            _EmpList.Add(new Employee(name2,salary2));

            Console.WriteLine();
            Console.WriteLine("Employee Details are : ");
            foreach (var emp in _EmpList)
            {
                Console.WriteLine($"{emp.Id} {emp.Name} {emp.Salary}");
            }
        }
    }
}
