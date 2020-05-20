using System;

namespace Pipelines.Core.Common.Interfaces
{
    public abstract class AbstractFilter<Input, Output> : IFilter<Input, Output>
    {
        public virtual Output Execute(Input input)
        {
            return Process(input);
        }


        public virtual object Execute(object input)
        {
            return this.Execute((Input)input);
        }

        public abstract Output Process(Input input);
    }
}
