using System;
using System.Data.SqlClient;

using Ninject;
using System.Reflection;

namespace SimpleQuery
{
    public class Startup
    {
        private const string ConnectionString = @"Server=(localdb)\MSSQLLocalDB; " + "Database=Company; Integrated Security=true";
        private static Random randomIdGenerator = new Random();

        public static void Main()
        {
            // var kernel = new StandardKernel();
            // kernel.Load(Assembly.GetExecutingAssembly());
            // var currentQueries = kernel.Get<DbQueries>();
            // var databaseConnection = kernel.Get<SqlConnection>();

            var databaseConnection = new SqlConnection(ConnectionString);
            IWriter writer = new ConsoleWriterProvider();
            var currentQueries = new DbQueries(databaseConnection, writer);

            Console.WriteLine("Problem 1 - Get number of employees in department");
            currentQueries.GetEmployeesByDepartment(
            new SqlCommand(Commands.GetNumbersOfEmployeesInFinanceDepartmentCommand, databaseConnection),
            ConnectionString);

            Console.WriteLine("Problem 2 - Add employee in database");
            currentQueries.AddEmployeeToDb(
                new SqlCommand(Commands.AddEmployeeCommand, databaseConnection),
                "Vesko",
                "Goranov",
                1111,
                12,
                1,
                ConnectionString);

            Console.WriteLine("Problem 3 - Get all employees and make name UPPERCASE.");
            currentQueries.GetEmployeesNames(
                new SqlCommand(Commands.GetEmployeesNamesCommand, databaseConnection),
                ConnectionString);

            Console.WriteLine("Problem 4 - Get all employees full name and salary.");
            currentQueries.GetEmployeesByFirstNameLastNameAndSalary(
                new SqlCommand(Commands.GetEmployeesNamesAndSalaryCommand, databaseConnection),
                ConnectionString);

            Console.WriteLine("Problem 5 - Get all departments in Company database.");
            currentQueries.GetCountDepartments(
                new SqlCommand(Commands.GetDepartmentsCommand, databaseConnection),
                ConnectionString);

            Console.WriteLine("Problem 6 - Get average salary in current department.");
            currentQueries.GetAverageSalaryFromDepartment(
                new SqlCommand(Commands.GetAverageSalaryInEveryDepartmentCommand, databaseConnection),
                ConnectionString);

            // Note that in every run of this command you must clear the Table EmployeesProjects due to constraints of non duplicate values.
            Console.WriteLine("Problem 7 - Insert projects by employee id.");
            for (int i = 1; i <= 4; i++)
            {
                int projectId = i;
                int employeeId = i + 10;
                DateTime startDate = new DateTime(2016, 10, 21);
                DateTime endDate = startDate.AddYears(randomIdGenerator.Next(1, 6));

                currentQueries.InsertProjectsByEmployeeId(
                    new SqlCommand(Commands.InsertProjectsByEmployeeIdCommand, databaseConnection),
                    employeeId,
                    projectId,
                    startDate,
                    endDate,
                    ConnectionString);
            }

            Console.WriteLine("Problem 8 - Get all employees projects.");
            currentQueries.GetEmployeesProjectsSchedule(
                new SqlCommand(Commands.GetEmployeeProjectScheduleCommand, databaseConnection),
                ConnectionString);
        }
    }
}
