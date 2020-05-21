using Pipelines.Core.Common.Interfaces;
using Pipelines.Main.Filters;
using Pipelines.Main.Models;
using System;
using System.Collections.Generic;

namespace Pipelines.Main
{
    class Program
    {
        static void Main(string[] args)
        {
            int numberOfEmployesToCreate = 9;
            List<Employee> employees = new List<Employee>();
            IPipeline<String, String> employeePipeline = new EmployeePipeline()
                .Register(new IntToAlphaFilter())
                .Register(new ToUpperFilter());

            Employee employee = new Employee();
            for (int i = 0; i < numberOfEmployesToCreate; i++)
            {
                employee = new Employee();
                employee.Name = employee.GetHashCode().ToString();
                employee.Name = employeePipeline.Execute(employee.Name);
                employees.Add(employee);    
            }

            Console.WriteLine(employees[0].Name);
            Console.ReadLine();
        }
    }
}
