namespace Pipelines.Core.Common.Interfaces
{
    /// <summary>
    /// A filter for a pipeline. Allows for processing on the input and creating an output
    /// </summary>
    /// <typeparam name="Input">Input of the filter</typeparam>
    /// <typeparam name="Output">Output of the filter</typeparam>
    public interface IFilter<Input, Output>
    {
        Output Execute(Input input);
    }

    /// <summary>
    /// A filter for a pipeline. Allows for processing on the input and creating a same typed output
    /// </summary>
    /// <typeparam name="InOutput">Input and Output of the filter</typeparam>
    public interface IFilter<InOutput>
    {
        InOutput Execute(InOutput input);
    }
}
