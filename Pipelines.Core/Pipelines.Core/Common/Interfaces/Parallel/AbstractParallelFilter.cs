using System;
using System.Threading.Tasks.Dataflow;

namespace Pipelines.Core.Common.Interfaces.Parallel
{
    public abstract class AbstractParallelFilter<Input, Output> : IParallelFilter<Input, Output>
    {
        public AbstractParallelFilter()
        {
            TransformBlock = new TransformBlock<Input, Output>(new Func<Input, Output>(Execute), new ExecutionDataflowBlockOptions()
            {
                BoundedCapacity = DataflowBlockOptions.Unbounded,
                MaxDegreeOfParallelism = Environment.ProcessorCount

            });
        }
        

        public TransformBlock<Input, Output> TransformBlock { get; set; }


        public virtual object Execute(object input)
        {
            return this.Execute((Input)input);
        }
        
        public virtual Output Execute(Input input)
        {
            return Process(input);
        }

        public abstract Output Process(Input input);


    }
}
