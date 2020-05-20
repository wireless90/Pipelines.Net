namespace Pipelines.Core.Common.Interfaces
{
    public interface IFilter<Input, Output> : IBaseFilter
    {
        Output Execute(Input input);
    }
}
