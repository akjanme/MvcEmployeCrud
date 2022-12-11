using System;
using System.Linq;

namespace ConsoleApp1
{
    public class LinqQueries
    {
        public static void LambdaQueryExample()
        {
            var employeelist = Employee.GetEmployees();
            //where salary greater than 90000

            var salaryList = from e in employeelist
                             where e.Salary > 90000
                             select e;

            foreach (var item in salaryList)
            {
                Console.WriteLine("ID : " + item.ID + "\t First Name :" + item.FirstName + "\t Last Name:" + item.LastName + "\t Salary :" + item.Salary);
            }
        }
    }
}
