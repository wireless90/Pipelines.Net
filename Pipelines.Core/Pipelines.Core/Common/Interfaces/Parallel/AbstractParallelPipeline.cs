using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using System.Threading.Tasks.Dataflow;

namespace Pipelines.Core.Common.Interfaces.Parallel
{
    public abstract class AbstractParallelPipeline<Input, Output> : IParallelPipeline<Input, Output>
    {
        private List<IBaseFilter> _filters;

        public AbstractParallelPipeline()
        {
            _filters = new List<IBaseFilter>();
            Sink = new ConcurrentBag<Output>();
            SinkBlock = new ActionBlock<Output>(x => Sink.Add(x));
        }

        public  ConcurrentBag<Output> Sink { get; set; }
        public ActionBlock<Output> SinkBlock { get; set; }

        public async Task CompleteProcessing<FirstOutput, LastInput>()
        {
            ((IParallelBaseFilter<Input, FirstOutput>)_filters.First())
                .TransformBlock.Complete();

            await SinkBlock.Completion;
        }

        public virtual IParallelPipeline<Input, Output> CompleteRegisteration<PreviousInput>()
        {
            AbstractParallelFilter<PreviousInput, Output> lastFilter = (AbstractParallelFilter<PreviousInput, Output>)_filters.Last();
            lastFilter.TransformBlock.LinkTo(SinkBlock, new DataflowLinkOptions() { PropagateCompletion = true });

            return this;
        }

        public virtual IParallelPipeline<Input, Output> Process<FirstOutput>(Input input)
        {
            ((IParallelBaseFilter<Input, FirstOutput>)_filters.First())
                .TransformBlock.Post(input); 

            return this;
        }

        public virtual IParallelPipeline<Input, Output> Register<FIn, FOut, PreviousInput>(AbstractParallelFilter<FIn, FOut> filter)
        {

            if (_filters.Count == 0)
            {
                _filters.Add(filter);
                return this;
            }
            else
            {
                AbstractParallelFilter<PreviousInput, FIn> lastFilter = (AbstractParallelFilter<PreviousInput, FIn>)_filters.Last();
                lastFilter.TransformBlock.LinkTo(filter.TransformBlock, new DataflowLinkOptions() { PropagateCompletion = true });
                _filters.Add(filter);
            }
            return this;
        }
    }
}
