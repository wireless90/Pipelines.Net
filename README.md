# Pipelines.Net
Pipeline Library for .Net Core

## Creating a Synchronous Pipeline Example

```cs
IPipeline<String, String> employeePipeline = new EmployeePipeline()
                .Register(new IntToAlphaFilter())
                .Register(new ToUpperFilter());
```

##Usage
```cs
employeePipeline.Execute(employee.Name);
```


## Creating a Parallel Pipeline Example

```cs
IParallelPipeline<String, String> parallelPipeline = new EmployeeParallelPipeline()
               .Register<string, string, string>(new IntToAlphaParallelFilter())
               .Register<string, string, string>(new ToUpperParallelFilter())
               .CompleteRegisteration<string>();
```

##Usage
```cs
parallelPipeline.Process<String>(employee.Name);
await parallelPipeline.CompleteProcessing<string, string>();
```
