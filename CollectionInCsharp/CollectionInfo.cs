using System;
using System.Collections.Generic;
using System.Linq; 
namespace MvcEmployeCrud.CollectionInCsharp
{
    class Program
    {
        static void Main(string[] args)
        {
            var employeelist = Employee.GetEmployees();

            foreach (var item in employeelist)
            {
                Console.WriteLine("ID : " + item.ID + "\t First Name :" + item.FirstName + "\t Last Name:" + item.LastName + "\t Salary :" + item.Salary);
            }
            Console.WriteLine("\n Salary greater than 70k ");
            var highSalariedEmp = employeelist.Where(x => x.Salary > 70000);

            foreach (var item in highSalariedEmp)
            {
                Console.WriteLine("ID : " + item.ID + "\t First Name :" + item.FirstName + "\t Last Name:" + item.LastName + "\t Salary :" + item.Salary);
            }


            Console.WriteLine("\n name has p  ");
            var nameHasP = employeelist.Where(x => x.FirstName.Contains("P"));

            foreach (var item in nameHasP)
            {
                Console.WriteLine("ID : " + item.ID + "\t First Name :" + item.FirstName + "\t Last Name:" + item.LastName + "\t Salary :" + item.Salary);
            }


            Console.WriteLine("\n name and salary p  ");
            var nameHasPandhighsalary = employeelist.Where(x => x.FirstName.Contains("P") && x.Salary > 60000);

            foreach (var item in nameHasPandhighsalary)
            {
                Console.WriteLine("ID : " + item.ID + "\t First Name :" + item.FirstName + "\t Last Name:" + item.LastName + "\t Salary :" + item.Salary);
            }


            Console.WriteLine("\n name and salary low and name has s  ");
            var nameHasSandLowsalary = employeelist.Where(x => x.FirstName.StartsWith("S") || x.Salary >= 90000);

            foreach (var item in nameHasSandLowsalary)
            {
                Console.WriteLine("ID : " + item.ID + "\t First Name :" + item.FirstName + "\t Last Name:" + item.LastName + "\t Salary :" + item.Salary);
            }


            Console.WriteLine("\n Select custom ");
            var selectEmp = employeelist.Select(x => new
            {
                Name = x.FirstName + " " + x.LastName,
                Salary = x.Salary
            });
            foreach (var item in selectEmp)
            {
                Console.WriteLine("Name :" + item.Name + "\t Salary :" + item.Salary);
            }


            Console.WriteLine("\n uniqure records ");
            var uniqueEmp = employeelist.Select(x => new { x.ID, x.FirstName, x.LastName, x.Salary }).Distinct();

            foreach (var item in uniqueEmp)
            {
                Console.WriteLine("ID : " + item.ID + "\t First Name :" + item.FirstName + "\t Last Name:" + item.LastName + "\t Salary :" + item.Salary);
            }
            Console.ReadKey();
        }
    }
    public class Employee
    {
        public int ID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Salary { get; set; }
        public static List<Employee> GetEmployees()
        {
            List<Employee> employees = new List<Employee>
            {
                new Employee {ID = 101, FirstName = "Preety", LastName = "Tiwary", Salary = 60000 },
                new Employee {ID = 102, FirstName = "Priyanka", LastName = "Dewangan", Salary = 70000 },
                new Employee {ID = 103, FirstName = "Hina", LastName = "Sharma", Salary = 80000 },
                new Employee {ID = 104, FirstName = "Anurag", LastName = "Mohanty", Salary = 90000 },
                new Employee {ID = 105, FirstName = "Sambit", LastName = "Satapathy", Salary = 100000 },
                new Employee {ID = 106, FirstName = "Sushanta", LastName = "Jena", Salary = 160000 },
                  new Employee {ID = 101, FirstName = "Preety", LastName = "Tiwary", Salary = 60000 },
                new Employee {ID = 102, FirstName = "Priyanka", LastName = "Dewangan", Salary = 70000 },
                new Employee {ID = 103, FirstName = "Hina", LastName = "Sharma", Salary = 80000 }
            };
            return employees;
        }
    }
}