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

            //Print the Sum and Average of numbers
            Console.WriteLine("Sum: " + numbers.Sum());
            Console.WriteLine("Average: " + numbers.Average());

            //Order numbers in ascending order and decsending order. Print each to console.
            var numbersAscending = numbers.OrderBy(x => x);
            var numbersDecending = numbers.OrderByDescending(x => x);

            Console.Write("Numbers ascending: ");
            foreach (var num in numbersAscending)
            {
                Console.Write(num + " ");
            }

            Console.Write("\nNumbers descending: ");
            foreach (var num in numbersDecending)
            {
                Console.Write(num + " ");
            }

            //Print to the console only the numbers greater than 6
            var greaterThanSix = numbers.Where(x => x > 6);
            Console.Write("\nGreater than six: ");
            foreach (var num in greaterThanSix)
            {
                Console.Write(num + " ");
            }

            //Order numbers in any order (acsending or desc) but only print 4 of them **foreach loop only!**
            var onlyFour = numbersAscending.Take(4);
            Console.Write("\nFirst four numbers only: ");
            foreach (var num in onlyFour)
            {
                Console.Write(num + " ");
            }

            //Change the value at index 4 to your age, then print the numbers in decsending order
            numbers[4] = 33;
            var ageDescending = numbers.OrderByDescending(x => x);
            Console.Write("\nAge Replacement, Descending: ");
            foreach (var num in ageDescending)
            {
                Console.Write(num + " ");
            }

            // List of employees ***Do not remove this***
            var employees = CreateEmployees();

            //Print all the employees' FullName properties to the console only if their FirstName starts with a C OR an S.
            //Order this in acesnding order by FirstName.
            Console.WriteLine();
            Console.WriteLine("\nEmployees by name:");
            var specialEmployee = employees.Where(x => x.FullName[0] == 'C' || x.FullName[0] == 'S').OrderBy(x => x.FirstName);
            foreach (var employee in specialEmployee)
            {
                Console.WriteLine(employee.FullName);
            }


            //Print all the employees' FullName and Age who are over the age 26 to the console.
            //Order this by Age first and then by FirstName in the same result.
            var over26 = employees.Where(x => x.Age > 26).OrderBy(x => x.Age).OrderBy(x => x.FirstName);
            Console.WriteLine("\nEmployees, by age and name:");
            foreach (var employee in over26)
            {
                Console.WriteLine(employee.FullName + "\t\t" + employee.Age);
            }

            //Print the Sum and then the Average of the employees' YearsOfExperience
            //if their YOE is less than or equal to 10 AND Age is greater than 35
            var experienceList = employees.Where(x => x.YearsOfExperience <= 10 && x.Age > 35);
            Console.WriteLine("Sum of Years of Experience: " + experienceList.Sum(x => x.YearsOfExperience));
            Console.WriteLine($"Average of Years of Experience: {experienceList.Average(x => x.YearsOfExperience):F2}");

            //Add an employee to the end of the list without using employees.Add()
            Console.WriteLine();
            var newEmployees = employees.Append(new Employee("Cloud", "Strife", 27, 10));
            foreach (var employee in newEmployees)
            {
                Console.WriteLine(employee.FullName);
            }
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
