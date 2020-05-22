using System.Collections.Concurrent;
using System.Threading.Tasks;
using System.Threading.Tasks.Dataflow;

namespace Pipelines.Core.Common.Interfaces.Parallel
{
    public interface IParallelPipeline<Input, Output>
    {
        IParallelPipeline<Input, Output> Register<FIn, FOut, PreviousInput>(AbstractParallelFilter<FIn, FOut> filter);


        IParallelPipeline<Input, Output> Process<FirstOutput>(Input input);

        Task CompleteProcessing<FirstOutput, LastInput>();

        IParallelPipeline<Input, Output> CompleteRegisteration<PreviousInput>();

        ConcurrentBag<Output> Sink { get; set; }

        ActionBlock<Output> SinkBlock { get; set; }
    }
}
