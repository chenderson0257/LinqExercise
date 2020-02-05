using System;
using System.Collections.Generic;
using System.Linq;

namespace LinqExercise
{
    class Program
    {
        //Static array of integers
        private static int[] numbers = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 0 };

        static void Main(string[] args)
        {
            /*
             * 
             * Complete every task using Method OR Query syntax. 
             * You may find that Method syntax is easier to use since it is most like C#
             * Every one of these can be completed using Linq and then printing with a foreach loop.
             * Push to your github when completed!
             * 
             */

            //Print the Sum and Average of numbers
            Console.WriteLine(numbers.Average());
            Console.WriteLine(numbers.Sum());

            //Order numbers in ascending order and decsending order. Print each to console.
            var order = numbers.OrderBy(num => num);
            foreach(var num in order)
            {
                Console.WriteLine(num);
            }
            var orderDescending = numbers.OrderByDescending(num => num);
            foreach(var num in orderDescending)
            {
                Console.WriteLine(num);
            }

            //Print to the console only the numbers greater than 6
            var greaterThan = numbers.Where(num => num > 6 );
            foreach(var i in greaterThan)
            {
                Console.WriteLine(i);
            }

            //Order numbers in any order (acsending or desc) but only print 4 of them **foreach loop only!**
            var newOrder = numbers.OrderByDescending(num => num);
            var order3 = newOrder.Where(num => num > 5);

            foreach(var i in order3)
            {
                Console.WriteLine(i);

            }

            //Change the value at index 4 to your age, then print the numbers in decsending order
            numbers.SetValue(32, 4);
            var firstFour = orderDescending.Take(4); //foreach(var num in orderDescending.Take(4))
            foreach(var num in firstFour)
            {
                Console.WriteLine(num);
            }

            // List of employees ***Do not remove this***
            var employees = CreateEmployees();

            //Print all the employees' FullName properties to the console only if their FirstName starts with a C OR an S.
            //Order this in acesnding order by FirstName
            var worker = employees.Where(name => name.FirstName.ToLower()[0] == 'c' || name.FirstName.ToLower().StartsWith('s')) .OrderBy(name => name.FirstName);
            foreach(var i in worker)
            {
                Console.WriteLine(i.FullName);
            }

            //Print all the employees' FullName and Age who are over the age 26 to the console.
            //Order this by Age first and then by FirstName in the same result.
            var workers = employees.Where(num => num.Age > 26).OrderByDescending(num => num.Age).ThenBy(num => num.FirstName);
            foreach(var i in workers)
            {
                Console.WriteLine(i.FirstName);
            }
            //Print the Sum and then the Average of the employees' YearsOfExperience
            //if their YOE is less than or equal to 10 AND Age is greater than 35
            var orderYoe = employees.Where(num => num.YearsOfExperience <= 10 && num.Age >35);
            Console.WriteLine($"total yoe: {orderYoe.Sum(numbers => numbers.YearsOfExperience)}");
            Console.WriteLine($"avg yoe: {orderYoe.Average(numbers => numbers.YearsOfExperience)}");


            //Add an employee to the end of the list without using employees.Add()
            employees = employees.Append(new Employee("John", "Smith", 48, 17)).ToList();

            
            Console.WriteLine();

            Console.ReadLine();
        }

        #region CreateEmployeesMethod
        private static List<Employee> CreateEmployees()
        {
            List<Employee> employees = new List<Employee>();
            employees.Add(new Employee("Cruz", "Sanchez", 25, 10));
            employees.Add(new Employee("Steven", "Bustamento", 56, 5));
            employees.Add(new Employee("Micheal", "Doyle", 36, 8));
            employees.Add(new Employee("Daniel", "Walsh", 72, 22));
            employees.Add(new Employee("Jill", "Valentine", 32, 43));
            employees.Add(new Employee("Yusuke", "Urameshi", 14, 1));
            employees.Add(new Employee("Big", "Boss", 23, 14));
            employees.Add(new Employee("Solid", "Snake", 18, 3));
            employees.Add(new Employee("Chris", "Redfield", 44, 7));
            employees.Add(new Employee("Faye", "Valentine", 32, 10));

            return employees;
        }
        #endregion
    }
}
