using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nortthwind.Migrations
{
    public class SeedData
    {
        private Random random = new Random();

        public SeedData()
        {
            this.Employees = GetEmployees();
        }

        public IEnumerable<Employee> Employees { get; set; }

        public IEnumerable<Employee> GetEmployees()
        {
            var employees = new List<Employee>();
            var firstNames = new string[] { "Alexander", "Georgi", "Stanislav", "Elena", "Violeta", "Krasimir", "Valeria" };
            var families = new string[] { "Alexandrov", "Georgiev", "Stanislavski", "Ivanova", "Parvanova", "Krasimirov", "Stoykov" };
            var titles = new string[] { "First Title", "Second Title", "Third Title", "НАРОЧНО БАЗАТА Е ПРАЗНА" };
            var region = new string[] { "Sofia", "Plovdiv", "Varna", "Burgas", "ЛЮЛИН" };
            var countries = new string[] { "Bulgaria", "USA", "Great Britain", "Japan", "Canada" };

            for (int i = 0; i < 15; i++)
            {
                employees.Add(new Employee()
                {
                    FirstName = firstNames[i % 7],
                    LastName = families[i % 7],
                    EmployeeID = i + 1,
                    Title = titles[random.Next(0, 4)],
                    Region = region[random.Next(0, 4)],
                    Country = countries[random.Next(0, 4)],
                    BirthDate = new DateTime(2017, 01, i+1),
                });
            }

            return employees;
        }
    }
}
