namespace Pipelines.Core.Common.Interfaces
{

    /// <summary>
    /// Decompose a task that performs complex processing into a series of discrete elements that can be reused. 
    /// This pattern can improve performance, scalability, and reusability by allowing task elements that 
    /// perform the processing to be deployed and scaled independently.
    /// </summary>
    /// <typeparam name="InOutput"></typeparam>
    public interface IPipeline<InOutput> : IPipeline<InOutput, InOutput>
    {

    }

    /// <summary>
    /// Decompose a task that performs complex processing into a series of discrete elements that can be reused. 
    /// This pattern can improve performance, scalability, and reusability by allowing task elements that 
    /// perform the processing to be deployed and scaled independently.
    /// </summary>
    /// <typeparam name="Input"></typeparam>
    /// <typeparam name="Output"></typeparam>

    public interface IPipeline<Input, Output>
    {
        IPipeline<Input, Output> Register<FilterIn, FilterOut>(IFilter<FilterIn, FilterOut> filter);

        IPipeline<Input, Output> Register<FilterInOut>(IFilter<FilterInOut> filter);

        IPipeline<Input, Output> CreatePipeline();

        Output Process(Input input);

    }
}
