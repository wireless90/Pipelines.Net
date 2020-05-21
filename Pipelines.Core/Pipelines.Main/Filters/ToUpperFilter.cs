using Pipelines.Core.Common.Interfaces;
using System;

namespace Pipelines.Main.Filters
{
    public class ToUpperFilter : AbstractFilter<String, String>
    {
        public override string Process(string input)
        {
            return input.ToUpper();
        }
    }
}
