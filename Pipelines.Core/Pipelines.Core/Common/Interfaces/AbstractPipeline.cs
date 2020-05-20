using System.Collections.Generic;

namespace Pipelines.Core.Common.Interfaces
{
    public abstract class AbstractPipeline<Input, Output> : IPipeline<Input, Output>
    {
        private List<IBaseFilter> _filters;

        public AbstractPipeline()
        {
            _filters = new List<IBaseFilter>();
        }

        public virtual Output Execute(Input input)
        {
            object objInput = input;

            foreach (var filter in _filters)
            {
                objInput = filter.Execute(objInput);
            }

            return (Output)objInput;
        }

        public abstract IPipeline<Input, Output> Register<FIn, FOut>(IFilter<FIn, FOut> filter);
    }
}
