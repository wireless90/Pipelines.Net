using Pipelines.Core.Common.Interfaces;
using System;
using System.Text;

namespace Pipelines.Main.Filters
{
    public class IntToAlphaFilter : AbstractFilter<String, String>
    {
        private readonly StringBuilder _stringBuilder;

        public IntToAlphaFilter()
        {
            _stringBuilder = new StringBuilder();
        }
        public override string Process(string input)
        {
            _stringBuilder.Clear();
            foreach (char character in input)
            {
                switch(character)
                {
                    case '1':
                        _stringBuilder.Append("One");
                        break;

                    case '2':
                        _stringBuilder.Append("Two");
                        break;

                    case '3':
                        _stringBuilder.Append("Three");
                        break;

                    case '4':
                        _stringBuilder.Append("Four");
                        break;

                    case '5':
                        _stringBuilder.Append("Five");
                        break;

                    case '6':
                        _stringBuilder.Append("Six");
                        break;

                    case '7':
                        _stringBuilder.Append("Seven");
                        break;

                    case '8':
                        _stringBuilder.Append("Eight");
                        break;

                    case '9':
                        _stringBuilder.Append("Nine");
                        break;

                    case '0':
                        _stringBuilder.Append("Zero");
                        break;
                }
            }

            return _stringBuilder.ToString();
        }
    }
}
