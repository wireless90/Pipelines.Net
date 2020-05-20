namespace Pipelines.Core.Common.Interfaces
{
    public interface IPipeline<Input, Output>
    {
        Output Execute(Input input);

        IPipeline<Input, Output> Register<FIn, FOut>(IFilter<FIn, FOut> filter);
    }
}
