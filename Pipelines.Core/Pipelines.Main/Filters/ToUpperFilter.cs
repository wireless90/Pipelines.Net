using Pipelines.Core.Common.Interfaces;
using System;
using System.Threading;

namespace Pipelines.Main.Filters
{
    public class ToUpperFilter : AbstractFilter<String, String>
    {
        public override string Process(string input)
        {
            Thread.Sleep(100);

            return input.ToUpper();
        }
    }
}
