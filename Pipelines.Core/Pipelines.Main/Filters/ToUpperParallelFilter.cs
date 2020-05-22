using Pipelines.Core.Common.Interfaces.Parallel;
using System.Threading;

namespace Pipelines.Main.Filters
{
    public class ToUpperParallelFilter : AbstractParallelFilter<string, string>
    {

        public override string Process(string input)
        {
            Thread.Sleep(100);
            return input.ToUpper();
        }
    }
}
