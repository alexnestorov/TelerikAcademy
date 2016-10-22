/// <summary>
/// Contains SQL Commands, which are supposed to be executed.
/// </summary>
namespace SimpleQuery
{
    /// <summary>
    /// Defines simple SQL Commands.
    /// </summary>
    public static class Commands
    {
        // SQL Commands.
        public const string GetNumbersOfEmployeesInFinanceDepartmentCommand = @"SELECT COUNT(*) FROM dbo.Employees [e] JOIN dbo.Departments [d] ON e.DepartmentId=d.Id WHERE d.Name='Finance'";

        public const string AddEmployeeCommand = @"INSERT INTO EMPLOYEES(FirstName, LastName, YearlySalary, ManagerId, DepartmentId) VALUES(@firstName, @lastName, @salary, @managerId, @departmentId)";

        public const string GetEmployeesNamesCommand = "SELECT FirstName, LastName FROM Employees";

        public const string GetEmployeesNamesAndSalaryCommand = @"SELECT FirstName, LastName, YearlySalary, DepartmentId FROM Employees";

        public const string GetDepartmentsCommand = "SELECT COUNT(*) FROM Departments";

        public const string GetAverageSalaryInEveryDepartmentCommand = @"SELECT d.Name,ROUND(AVG(e.YearlySalary),2) AS [Average Salary], d.Id AS [Department ID] FROM dbo.Employees [e] JOIN dbo.Departments [d] ON e.DepartmentId=d.Id GROUP BY d.Name, d.Id";

        public const string InsertProjectsByEmployeeIdCommand = @"INSERT INTO EmployeesProjects (EmployeeId,ProjectId,StartDate,EndDate) VALUES (@employeeId, @projectId, @startDate, @endDate)";

        public const string GetEmployeeProjectScheduleCommand = @"SELECT e.FirstName+' ' +e.LastName AS [Employee Full Name], pro.Name AS [Project], p.StartDate, p.EndDate FROM EmployeesProjects AS [p] LEFT JOIN dbo.Employees e ON e.Id = p.EmployeeId LEFT JOIN dbo.Projects pro ON pro.Id = p.ProjectId";
    }
}
