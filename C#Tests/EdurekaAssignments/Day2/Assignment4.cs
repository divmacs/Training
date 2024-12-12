using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day2
{
    public abstract class Employee
    {
        static int _EmpIdIndex = 1000;
        public int EmpId { get; set; }
        public string Name { get; set; }
        public string ReportingManager { get; set; }

        public Employee()
        {

        }
        public Employee(string name, string RM)
        {
            EmpId = _EmpIdIndex++;
            Name = name;
            ReportingManager = RM;
        }
    }
    public class ContractEmployee : Employee
    {
        public ContractEmployee()
        {

        }
        public ContractEmployee(string name, string RM,int duration, double charges) : base(name, RM)
        {
            Name = name;
            ReportingManager = RM;
            ContractDurationInMonths = duration;
            Charges = charges;
        }

        public int ContractDurationInMonths { get; set; }
        public double Charges { get; set; }

    }
    public class PayrollEmployee : Employee
    {
        public DateTime DoJ { get; set; }
        public double YoE { get; set; }
        public double BasicSalary { get; set; }
        public double HRA { get; set; }
        public double DA { get; set; }
        public double PF { get; set; }
        public PayrollEmployee()
        {

        }
        public PayrollEmployee(string name, string RM, DateTime doj, double exp, double basicSalary, 
            double hra, double da, double pf) : base(name, RM)
        {
            Name = name;
            ReportingManager = RM;
            DoJ = doj;
            YoE = exp;
            BasicSalary = basicSalary;
            HRA = hra;
            DA = da;
            PF = pf;
        }

        public double CalNetSalary(PayrollEmployee employee)
        {
            /*
            if exp > 10 years , DA = 10% of basic, HRA = 8.5 % of basic , PF = 6200
            if exp > 7 years and less than 10 years , DA = 7% of basic, HRA = 6.5 % of basic , PF = 4100
            if exp > 5 years and less than 7 years, DA = 4.1% of basic, HRA = 3.8 % of basic , PF = 1800
            if exp < 5 years , DA = 1.9% of basic, HRA = 2.0 % of basic , PF = 1200
            */

            if(employee.YoE < 5)
            {
                employee.DA = (1.9 / 100) * employee.BasicSalary;
                employee.HRA = (2 / 100) * employee.BasicSalary;
                employee.PF = 1200;
            }
            else if(employee.YoE > 5 && employee.YoE < 7)
            {
                employee.DA = (4.1 / 100) * employee.BasicSalary;
                employee.HRA = (3.8 / 100) * employee.BasicSalary;
                employee.PF = 1800;
            }
            else if(employee.YoE > 7 && employee.YoE < 10)
            {
                employee.DA = (7 / 100) * employee.BasicSalary;
                employee.HRA = (86.5 / 100) * employee.BasicSalary;
                employee.PF = 4100;
            }
            else if(employee.YoE > 10)
            {
                employee.DA = (10 / 100) * employee.BasicSalary;
                employee.HRA = (8.5 / 100) * employee.BasicSalary;
                employee.PF = 6200;
            }

            double grossSalary = employee.BasicSalary + employee.DA + employee.HRA + employee.PF;
            double netSalary = grossSalary - employee.PF;

            return netSalary;
        }

    }

    public class EmployeeManager
    {
        List<PayrollEmployee> payrollEmployees { get; set; }
        List<ContractEmployee> contractEmployees { get; set; }

        public EmployeeManager()
        {
           payrollEmployees = new List<PayrollEmployee>()
           {
               new PayrollEmployee("Arjun","Ramya",new DateTime(2022,01,10),2.3,15000,6000,1000,1800),
               new PayrollEmployee("Arun","Leona",new DateTime(2021,01,20),5,20000,8000,2000,2400),
               new PayrollEmployee("Sitara","Jaya",new DateTime(2021,01,12),6,20000,8000,2000,2400),
               new PayrollEmployee("Megana","Leona",new DateTime(2021,01,15),5.2,20000,8000,2000,2400),
               new PayrollEmployee("Pushpa","Ramya",new DateTime(2021,08,30),7.1,22000,8500,3000,2500),
               new PayrollEmployee("Tejaswi","Adarsh",new DateTime(2021,12,23),11,30000,10000,5000,5000)
           };
           contractEmployees = new List<ContractEmployee>()
           {
               new ContractEmployee("Geetha","Michael",12,50000),
               new ContractEmployee("Reetha","Nikhil",20,60000),
               new ContractEmployee("Sita","Gaurav",6,20000),
               new ContractEmployee("Amit","Pradip",4,12000),
               new ContractEmployee("Shrenik","Naresh",15,50000),
               new ContractEmployee("Lakshmi","Vikram",24,80000),
               new ContractEmployee("Raja","Michael",6,20000),
               new ContractEmployee("Mani","Sachin",12,50000)

           };
        
        } 

        public void MainMenu()
        {
            int choice = -1;
            do
            {
                Console.WriteLine("Welcome Employee Management Application");
                Console.WriteLine(".........................................");
                Console.WriteLine("1. Add Payroll Employee\n2. Display Payroll Employees\n3. Add Contract Employee\n" +
                    "4. Display Contract Employee Detalils\n5. Total Employees\n6. Clear Console\n0. Exit\n");

                if (int.TryParse(Console.ReadLine(),out choice))
                {
                    switch (choice)
                    {
                        case 1:
                            GetPayrollEmployeeDetails();
                            break;
                        case 2:
                            DisplayPayrollEmployeeDetails();
                            break;
                        case 3:
                            GetContractEmployeeDetails();
                            break;
                        case 4:
                            DisplayContractEmployeeDetails();
                            break;
                        case 5:
                            TotalEmployees();
                            break;
                        case 6:
                            Console.Clear();
                            break;
                        case 0:
                            Console.WriteLine("Exiting application..!");
                            break;
                        default:
                            Console.WriteLine("Chose valid input");
                            break;
                    } 
                }
                if(choice != 0)
                {
                    Console.WriteLine("Enter any key to go main menu");
                    Console.ReadLine();
                }
            } 
            while (choice != 0);        }

        public void DisplayContractEmployeeDetails()
        {
            Console.WriteLine("Contract Employee Details\n-------------------");

            foreach (var emp in contractEmployees)
            {
                Console.WriteLine($"ContractID : {emp.EmpId}\nName : {emp.Name}\nReporting Manager : {emp.ReportingManager}\n" +
                        $"ContractDuration : {emp.ContractDurationInMonths}(months)\nCharges : {emp.Charges}\n");
            }
        }

        public void GetContractEmployeeDetails()
        {
            Console.WriteLine("Enter Contract Employee Details");
            Console.WriteLine("...................................");
            Console.WriteLine("Enter Employee Name");
            string name = Console.ReadLine();
            Console.WriteLine("Enter RM name");
            string rm = Console.ReadLine();
            Console.WriteLine("Enter contract durantion(months)");
            int duration = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter contract charges");
            double charges = Convert.ToDouble(Console.ReadLine());

            contractEmployees.Add(new ContractEmployee(name, rm, duration, charges));
        }

        public void DisplayPayrollEmployeeDetails()
        {
            PayrollEmployee payrollEmployeeObj = new PayrollEmployee();
            double netSalary = 0; 
            Console.WriteLine("Payroll Employee Details\n----------------------------");
            foreach (var emp in payrollEmployees)
            {
                Console.WriteLine($"EmployeeID : {emp.EmpId}\nName : {emp.Name}\nReporting Manager : {emp.ReportingManager}\n" +
            $"Joining Date : {emp.DoJ}\nYears Of Experience : {emp.YoE}\nBasic Salary : {emp.BasicSalary}\n" +
            $"HRA : {emp.HRA}\nDA : {emp.DA}\nPF : {emp.PF}\n");
                netSalary = payrollEmployeeObj.CalNetSalary(emp);
                Console.WriteLine("Total Salary\n............");
                Console.WriteLine(netSalary);
                Console.WriteLine("............\n");
            }            
        }

        public void GetPayrollEmployeeDetails()
        {
            Console.WriteLine("Enter Payroll Employee Details");
            Console.WriteLine("...................................");
            Console.WriteLine("Enter Employee Name");
            string name = Console.ReadLine();
            Console.WriteLine("Enter RM name");
            string rm = Console.ReadLine();
            Console.WriteLine("Enter Joined date(YYYY-MM-DD)");
            DateTime doj = Convert.ToDateTime(Console.ReadLine());
            Console.WriteLine("Enter Experience in years");
            double exp = Convert.ToDouble(Console.ReadLine());
            Console.WriteLine("Enter basic salary");
            double basicSal = Convert.ToDouble(Console.ReadLine());
            Console.WriteLine("Enter HRA");
            double hra = Convert.ToDouble(Console.ReadLine());
            Console.WriteLine("Enter DA");
            double da = Convert.ToDouble(Console.ReadLine());
            Console.WriteLine("Enter PF Amount");
            double pf = Convert.ToDouble(Console.ReadLine());

            payrollEmployees.Add(new PayrollEmployee(name, rm, doj, exp, basicSal, hra, da, pf));

        }

        public void TotalEmployees()
        {
            int totalCount = payrollEmployees.Count + contractEmployees.Count;
            Console.WriteLine($"\nTotal number of Employees is : {totalCount}\n");
        }
    }
}
