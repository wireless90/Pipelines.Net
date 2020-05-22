namespace Pipelines.Core.Common.Interfaces.Parallel
{
    public interface IParallelFilter<Input, Output> : IParallelBaseFilter<Input, Output>
    {
        Output Execute(Input input);
    }
}
