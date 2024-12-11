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

        public Employee(string name, string RM)
        {
            EmpId = _EmpIdIndex++;
            Name = name;
            ReportingManager = RM;
        }

        public abstract void DisplayEmployeeDetails();

    }
    public class ContractEmployee : Employee
    {
        public ContractEmployee(string name, string RM,int duration, double charges) : base(name, RM)
        {
            Name = name;
            ReportingManager = RM;
            ContractDurationInMonths = duration;
            Charges = charges;
        }

        public int ContractDurationInMonths { get; set; }
        public double Charges { get; set; }

        public override void DisplayEmployeeDetails()
        {
            Console.WriteLine("Contract Employee Details\n-------------------");
            Console.WriteLine($"ContractID : {EmpId}\nName : {Name}\nReporting Manager : {ReportingManager}\n" +
                $"ContractDuration : {ContractDurationInMonths}(months)\nCharges : {Charges}");
        }
    }
    public class PayrollEmployee : Employee
    {
        public DateTime DoJ { get; set; }
        public double YoE { get; set; }
        public double BasicSalary { get; set; }
        public double HRA { get; set; }
        public double DA { get; set; }
        public double PF { get; set; }

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

        public double CalNetSalary()
        {
            /*
            if exp > 10 years , DA = 10% of basic, HRA = 8.5 % of basic , PF = 6200
            if exp > 7 years and less than 10 years , DA = 7% of basic, HRA = 6.5 % of basic , PF = 4100
            if exp > 5 years and less than 7 years, DA = 4.1% of basic, HRA = 3.8 % of basic , PF = 1800
            if exp < 5 years , DA = 1.9% of basic, HRA = 2.0 % of basic , PF = 1200
            */

            if(YoE < 5)
            {
                DA = (1.9 / 100) * BasicSalary;
                HRA = (2 / 100) * BasicSalary;
                PF = 1200;
            }
            else if(YoE > 5 && YoE < 7)
            {
                DA = (4.1 / 100) * BasicSalary;
                HRA = (3.8 / 100) * BasicSalary;
                PF = 1800;
            }
            else if(YoE > 7 && YoE < 10)
            {
                DA = (7 / 100) * BasicSalary;
                HRA = (86.5 / 100) * BasicSalary;
                PF = 4100;
            }
            else if(YoE > 10)
            {
                DA = (10 / 100) * BasicSalary;
                HRA = (8.5 / 100) * BasicSalary;
                PF = 6200;
            }

            double grossSalary = BasicSalary + DA + HRA + PF;
            double netSalary = grossSalary - PF;

            return netSalary;
        }

        public override void DisplayEmployeeDetails()
        {
            double netSalary = CalNetSalary();
            Console.WriteLine("Payroll Employee Details\n----------------------------");
            Console.WriteLine($"EmployeeID : {EmpId}\nName : {Name}\nReporting Manager : {ReportingManager}\n" +
                $"Joining Date : {DoJ}\nYears Of Experience : {YoE}\nBasic Salary : {BasicSalary}" +
                $"HRA : {HRA}\nDA : {DA}\nPF : {PF}\n");
            Console.WriteLine("Total Salary\n............");
            Console.WriteLine(netSalary);
        }
    }

    public class EmployeeManager
    {
        List<PayrollEmployee> payrollEmployees;
        List<ContractEmployee> contractEmployees = new List<ContractEmployee>();

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

    }
}
