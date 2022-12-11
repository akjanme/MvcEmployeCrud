using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConsoleApp1
{
    class LambdaExpression
    {
        public static void LambdaExpressionExample()
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

            Console.WriteLine("\n uniqure records ");
            var distinctData = employeelist.Select(x => new { x.ID, x.FirstName, x.LastName, x.Salary }).Distinct();
            var sum = distinctData.Sum(x => x.Salary);
            var average = distinctData.Average(x => x.Salary);
            var count = distinctData.Count();
            var minsalary = distinctData.Min(x => x.Salary);
            var maxsalary = distinctData.Max(x => x.Salary);


            Console.WriteLine("Sum is " + sum);
            Console.WriteLine("average is " + average); Console.WriteLine("count is " + count); Console.WriteLine("minsalary is " + minsalary); Console.WriteLine("maxsalary is " + maxsalary);

            Console.WriteLine("Element at " + distinctData.ElementAtOrDefault(10));

            Console.WriteLine("first at " + distinctData.First());
            Console.WriteLine("Single at " + distinctData.SingleOrDefault(x => x.Salary > 100000));

            Console.WriteLine("empty at " + distinctData.Where(x => x.Salary > 200000).DefaultIfEmpty());




            Console.WriteLine("\n GroupBy records ");
            var grouobysalar = employeelist.GroupBy(x => x.Salary);

            foreach (var item in grouobysalar)
            {
                Console.WriteLine("ID : " + item.Key);
            }

            Console.WriteLine("\n order by records asc");
            var orderbyrecd = employeelist.OrderBy(x => x.Salary);

            foreach (var item in orderbyrecd)
            {
                Console.WriteLine("ID : " + item.ID + "\t First Name :" + item.FirstName + "\t Last Name:" + item.LastName + "\t Salary :" + item.Salary);
            }


            Console.WriteLine("\n order by records ");
            var orderbyrecdes = employeelist.OrderByDescending(x => x.Salary);

            foreach (var item in orderbyrecdes)
            {
                Console.WriteLine("ID : " + item.ID + "\t First Name :" + item.FirstName + "\t Last Name:" + item.LastName + "\t Salary :" + item.Salary);
            }

            Console.WriteLine("\n order by then records ");
            var orderbythen = employeelist.OrderByDescending(x => x.Salary).ThenBy(x => x.FirstName).ThenBy(x => x.LastName);

            foreach (var item in orderbythen)
            {
                Console.WriteLine("ID : " + item.ID + "\t First Name :" + item.FirstName + "\t Last Name:" + item.LastName + "\t Salary :" + item.Salary);
            }
            var result = orderbythen.Any(x => x.FirstName == "Shri Shri 108 Shri Trilok Ji Maharaj ji");
            Console.WriteLine(result);

            var emp = new List<Employee>();
            emp.Add(new Employee { ID = 101, FirstName = "Preety", LastName = "Tiwary", Salary = 60000 });
            var exeptlist = employeelist.Except(emp);
            foreach (var item in exeptlist)
            {
                Console.WriteLine("ID : " + item.ID + "\t First Name :" + item.FirstName + "\t Last Name:" + item.LastName + "\t Salary :" + item.Salary);
            }

            Console.ReadKey();
        }
    }
}
