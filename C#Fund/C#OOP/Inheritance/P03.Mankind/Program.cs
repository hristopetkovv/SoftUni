using System;

namespace P03.Mankind
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                string[] studentArgs = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);

                string studentFirstName = studentArgs[0];
                string studentLastName = studentArgs[1];
                string studentFacultyNumber = studentArgs[2];

                Student student = new Student(studentFirstName, studentLastName, studentFacultyNumber);

                string[] workerArgs = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);

                string workerFirstName = workerArgs[0];
                string workerLastName = workerArgs[1];
                double salary = double.Parse(workerArgs[2]);
                double workedHoursPerDay = double.Parse(workerArgs[3]);

                Worker worker = new Worker(workerFirstName, workerLastName, salary, workedHoursPerDay);

                Console.WriteLine(student);
                Console.WriteLine(worker);
            }
            catch (ArgumentException exception)
            {

                Console.WriteLine(exception.Message);
            }

        }
    }
}
