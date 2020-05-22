using System.Threading.Tasks.Dataflow;

namespace Pipelines.Core.Common.Interfaces.Parallel
{
    public interface IParallelBaseFilter<Input, Output> : IBaseFilter
    {
        TransformBlock<Input, Output> TransformBlock { get; set; }
    }
}
