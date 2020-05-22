using Pipelines.Core.Common.Interfaces;
using Pipelines.Core.Common.Interfaces.Parallel;
using Pipelines.Main.Filters;
using Pipelines.Main.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Pipelines.Main
{
    class Program
    {
        static void Main(string[] args)
        {
            int numberOfEmployesToCreate = 1000;
            List<Employee> employees = new List<Employee>();

            //IPipeline<String, String> employeePipeline = new EmployeePipeline()
            //    .Register(new IntToAlphaFilter())
            //    .Register(new ToUpperFilter());

            //Employee employee = new Employee();
            //for (int i = 0; i < numberOfEmployesToCreate; i++)
            //{
            //    employee = new Employee();
            //    employee.Name = employee.GetHashCode().ToString();
            //    employee.Name = employeePipeline.Execute(employee.Name);
            //    employees.Add(employee);
            //}

            IParallelPipeline<String, String> parallelPipeline = new EmployeeParallelPipeline()
                .Register<string, string, string>(new IntToAlphaParallelFilter())
                .Register<string, string, string>(new ToUpperParallelFilter())
                .CompleteRegisteration<string>();


            Employee employee = new Employee();
            for (int i = 0; i < numberOfEmployesToCreate; i++)
            {
                employee = new Employee();
                employee.Name = employee.GetHashCode().ToString();
                parallelPipeline.Process<String>(employee.Name);
            }
            
            parallelPipeline.CompleteProcessing<string, string>().Wait();

            Console.WriteLine(parallelPipeline.Sink.ToList()[0]);
            Console.ReadLine();
        }
    }
}
