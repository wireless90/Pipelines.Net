# Pipelines.Net
A Simple Pipeline Library for .Net Core

# Pipes & Filters Pattern
Decompose a task that performs complex processing into a series of separate elements that can be reused. This can improve performance, scalability, and reusability by allowing task elements that perform the processing to be deployed and scaled independently.

# Code Explanation
A pipeline has an `Input` type and an `Output` type.
It is declared as `IPipeline<Input, Output>`.

A filter in a pipeline could contains a `Filter Input` type and a `Filter Output` type.
It is declared as `IFilter<FIn, FOut>`.

You can register multiple filters. 

Do note that the first filter's `FIn` should match the Pipeline's `Input`.
Do note that the last filter's `FOut` should match the Pipeline's `Output`.

## Creating a Synchronous Pipeline Example

```cs


IPipeline<Employee, String> employeePipeline = new EmployeePipeline()
                .Register<Employee, EmployeeName>(new IntToAlphaFilter())
                .Register<EmployeeName, String>(new ToUpperFilter());
```

## Usage
```cs
employeePipeline.Execute(employee);
```


## Creating a Parallel Pipeline Example

```cs
IParallelPipeline<String, String> parallelPipeline = new EmployeeParallelPipeline()
               .Register<string, string, string>(new IntToAlphaParallelFilter())
               .Register<string, string, string>(new ToUpperParallelFilter())
               .CompleteRegisteration<string>();
```

## Usage
```cs
parallelPipeline.Process<String>(employee.Name);
await parallelPipeline.CompleteProcessing<string, string>();
```
