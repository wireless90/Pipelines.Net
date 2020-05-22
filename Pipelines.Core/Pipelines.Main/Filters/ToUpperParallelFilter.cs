using Pipelines.Core.Common.Interfaces.Parallel;

namespace Pipelines.Main.Filters
{
    public class ToUpperParallelFilter : AbstractParallelFilter<string, string>
    {

        public override string Process(string input)
        {
            return input.ToUpper();
        }
    }
}
