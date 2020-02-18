namespace BasicWrapperTool.Examples
{
    using BasicWrapperTool.Logic;
    using System;

    public class Example
    {
        public Result<int> DoSomeOperation(Maybe<string> input)
        {
            return ResultBuilder<int, string>
                .Create(input, "input string cannot be null")
                .WithNonNullValue(() => Convert.ToInt32(input.Value))
                .WithMessage("Cannot convert input string into integer")
                .Build();
        }
    }
}
