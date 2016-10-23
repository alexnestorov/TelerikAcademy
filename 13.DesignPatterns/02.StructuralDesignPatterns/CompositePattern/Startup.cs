using System;
using System.Collections.Generic;
using System.Reflection;

using CompositePattern.Contracts;
using CompositePattern.Models;
using Ninject;

namespace CompositePattern
{
    public class Startup
    {
        public static void Main()
        {
            var kernel = new StandardKernel();
            kernel.Load(Assembly.GetExecutingAssembly());

            var financialWorkers = kernel.Get<ICollection<IEmployee>>();
            var accountantWorkers = kernel.Get<ICollection<IEmployee>>();
            var headWorkers = kernel.Get<ICollection<IEmployee>>();

            var worker = new Worker("Junior accountant Vasil Vasilev", 15);
            var financialManager = new Manager("Manager Finance department Krasimir Georgiev", 22, financialWorkers);
            var accountantManager = new Manager("Manager Accountant department Ivelina Pencheva", 19, accountantWorkers);
            var headDepartmentManager = new Manager("Angelina Stoyneva", 33, headWorkers);
            var secondWorker = new Worker("Junior payroll Sevdalina Hristova", 6);

            //create relationships between employees.
            accountantManager.AddSubordinate(worker);
            financialManager.AddSubordinate(accountantManager);
            headDepartmentManager.AddSubordinate(financialManager);
            headDepartmentManager.AddSubordinate(secondWorker);


            // View all completed tasks for Head department.
            Console.WriteLine("HEAD DEPARTMENT EMPLOYEES");
            var headTasks = (headDepartmentManager as IEmployee).WorkResponsibilities();
            Console.WriteLine(headTasks);

            Console.WriteLine(new string('-', 75));

            // View all completed tasks from accounting department.
            Console.WriteLine("FINANCIAL DEPARTMENT EMPLOYEES");
            var financialTasks = (financialManager as IEmployee).WorkResponsibilities();
            Console.WriteLine(financialTasks);

            Console.WriteLine(new string('-', 75));

            // View all completed tasks from accounting department.
            Console.WriteLine("ACCOUNTING DEPARTMENT EMPLOYEES");
            var accTasks = (accountantManager as IEmployee).WorkResponsibilities();
            Console.WriteLine(accTasks);

            Console.WriteLine(new string('-', 75));

            // View workers completed tasks.
            Console.WriteLine(worker.WorkResponsibilities());
            Console.WriteLine(new string('-', 75));
            Console.WriteLine(secondWorker.WorkResponsibilities());
        }
    }
}