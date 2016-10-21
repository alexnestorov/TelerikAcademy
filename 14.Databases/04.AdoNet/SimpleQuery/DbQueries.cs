// <copyright file="DbQueries.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Reflection;

namespace SimpleQuery
{
    /// <summary>
    /// Represents simple queries from Company database in MSSQLServer.
    /// </summary>
    public class DbQueries
    {
        private SqlConnection databaseConnection;
        private IWriter writer;

        public DbQueries(SqlConnection dbConnection, IWriter writerProvider)
        {
            if (dbConnection == null)
            {
                throw new ArgumentNullException("Db connection is not initialised.");
            }

            if (writerProvider == null)
            {
                throw new ArgumentNullException("Db provider instance is not initialised.");
            }

            this.databaseConnection = dbConnection;
            this.writer = writerProvider;
        }

        public void GetEmployeesByDepartment(SqlCommand commandEmployeesInDepartment, string connection)
        {
            this.databaseConnection.ConnectionString = connection;
            this.databaseConnection.Open();

            using (this.databaseConnection)
            {
                int employeesCountByFinanceDepartment = (int)commandEmployeesInDepartment.ExecuteScalar();

                string result = string.Format("Employees in finance department: {0}", employeesCountByFinanceDepartment);
                this.writer.Provider(result);
            }

            this.databaseConnection.Close();
        }

        public void AddEmployeeToDb(
             SqlCommand commandInsertEmployee,
             string firstName,
             string lastName,
             decimal salary,
             int managerId,
             int departmentId,
             string connection)
        {
            this.databaseConnection.ConnectionString = connection;
            this.databaseConnection.Open();

            using (this.databaseConnection)
            {
                var parameters = MethodBase.GetCurrentMethod().GetParameters();

                commandInsertEmployee.Parameters.AddWithValue("@firstName", firstName);
                commandInsertEmployee.Parameters.AddWithValue("@lastName", lastName);
                commandInsertEmployee.Parameters.AddWithValue("@salary", salary);
                commandInsertEmployee.Parameters.AddWithValue("@managerId", managerId);
                commandInsertEmployee.Parameters.AddWithValue("@departmentId", departmentId);

                commandInsertEmployee.ExecuteNonQuery();
            }

            this.databaseConnection.Close();
        }

        public void GetEmployeesNames(SqlCommand commandExtractEmployeesNames, string connection)
        {
            this.databaseConnection.ConnectionString = connection;
            this.databaseConnection.Open();

            SqlDataReader reader = commandExtractEmployeesNames.ExecuteReader();

            using (reader)
            {
                while (reader.Read())
                {
                    string emplFirstName = (string)reader["FirstName"];
                    string emplLastName = (string)reader["LastName"];

                    emplFirstName = emplFirstName.ToUpper();
                    emplLastName = emplLastName.ToUpper();

                    this.writer.Provider(string.Format("{0} {1}", emplFirstName, emplLastName));
                }
            }

            this.databaseConnection.Close();
        }

        public void GetEmployeesByFirstNameLastNameAndSalary(SqlCommand commandExtractEmployeesWithSalary, string connection)
        {
            this.databaseConnection.ConnectionString = connection;
            this.databaseConnection.Open();

            using (this.databaseConnection)
            {
                SqlDataReader reader = commandExtractEmployeesWithSalary.ExecuteReader();
                var employees = new HashSet<string>();

                using (reader)
                {
                    while (reader.Read())
                    {
                        string firstName = (string)reader["FirstName"];
                        string lastName = (string)reader["LastName"];
                        string fullName = string.Format("{0} {1}", firstName, lastName);
                        decimal salary = (decimal)reader["YearlySalary"];
                        employees.Add(string.Format("Employee name: {0}, Employee salary: {1}", fullName, salary));
                    }
                }

                foreach (var empl in employees)
                {
                    this.writer.Provider(empl);
                }
            }

            this.databaseConnection.Close();
        }

        public void GetCountDepartments(SqlCommand commandDepartmentsCount, string connection)
        {
            this.databaseConnection.ConnectionString = connection;
            this.databaseConnection.Open();

            using (this.databaseConnection)
            {
                int departmentsCount = (int)commandDepartmentsCount.ExecuteScalar();

                this.writer.Provider(string.Format("Departments count: {0} ", departmentsCount));
            }

            this.databaseConnection.Close();
        }
    }
}
