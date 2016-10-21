using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleQuery
{
    public class Startup
    {
        private const string ConnectionString = @"Server=(localdb)\MSSQLLocalDB; " + "Database=Company; Integrated Security=true";

        public static void Main()
        {
            SqlConnection databaseConnection = new SqlConnection(ConnectionString);
            IWriter writerProvider = new ConsoleWriterProvider();

            DbQueries currentQueries = new DbQueries(databaseConnection, writerProvider);

            Console.WriteLine("Problem 1 - Get number of employees in department");
            currentQueries.GetEmployeesByDepartment(
            new SqlCommand(@"SELECT COUNT(*) FROM dbo.Employees [e] JOIN dbo.Departments [d] ON e.DepartmentId=d.Id WHERE d.Name='Finance'", databaseConnection), ConnectionString);

            Console.WriteLine("Problem 2 - Add employee in database");
            currentQueries.AddEmployeeToDb(
                new SqlCommand(@"INSERT INTO EMPLOYEES(FirstName, LastName, YearlySalary, ManagerId, DepartmentId) VALUES(@firstName, @lastName, @salary, @managerId, @departmentId)", databaseConnection),
                "Vesko",
                "Goranov",
                1111,
                12,
                1,
                ConnectionString);

            Console.WriteLine("Problem 3 - Get all employees and make name UPPERCASE.");
            currentQueries.GetEmployeesNames(new SqlCommand("SELECT FirstName, LastName FROM Employees", databaseConnection), ConnectionString);

            Console.WriteLine("Problem 4 - Get all employees full name and salary.");
            currentQueries.GetEmployeesByFirstNameLastNameAndSalary(
                new SqlCommand(
                    @"SELECT FirstName, LastName, YearlySalary, DepartmentId
                      FROM Employees", databaseConnection),
                ConnectionString);

            Console.WriteLine("Problem 5 - Get all departments in Company database");
            currentQueries.GetCountDepartments(
                new SqlCommand(
                    "SELECT COUNT(*) FROM Departments", databaseConnection), ConnectionString);
        }
    }
}
