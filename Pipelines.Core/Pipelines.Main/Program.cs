using Pipelines.Core.Common.Interfaces;
using Pipelines.Core.Common.Interfaces.Parallel;
using Pipelines.Main.Filters;
using Pipelines.Main.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace Pipelines.Main
{
    class Program
    {
        static TimeSpan TimeAction(Action blockingAction)
        {
            Stopwatch stopwatch = Stopwatch.StartNew();
            blockingAction();
            stopwatch.Stop();
            return stopwatch.Elapsed;
        }

        static void SyncPipelineTimingTest(int numberOfEmployesToCreate)
        {
            IPipeline<String, String> employeePipeline = new EmployeePipeline()
                .Register(new IntToAlphaFilter())
                .Register(new ToUpperFilter());

            Employee employee = new Employee();
            for (int i = 0; i < numberOfEmployesToCreate; i++)
            {
                employee = new Employee();
                employee.Name = employee.GetHashCode().ToString();
                employee.Name = employeePipeline.Execute(employee.Name);
            }

        }
        static void ParallelPipelineTimingTest(int numberOfEmployesToCreate)
        {
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

        }
        static void Main(string[] args)
        {
            int numberOfEmployesToCreate = 200;

            Console.WriteLine(TimeAction(() => SyncPipelineTimingTest(numberOfEmployesToCreate)).TotalMilliseconds);

            Console.WriteLine(TimeAction(() => ParallelPipelineTimingTest(numberOfEmployesToCreate)).TotalMilliseconds);

            Console.ReadLine();
        }
    }
}
