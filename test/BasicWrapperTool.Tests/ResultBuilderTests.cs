using System;
using Xunit;

namespace BasicWrapperTool.Tests
{
    public class ResultBuilderTests
    {
        [Fact]
        public void Create_StateUnderTest_ExpectedBehavior()
        {
            var input = new Maybe<string>("3");

            var actual = ResultBuilder<int, string>
                .Create(input, "input string cannot be null")
                .WithNonNullValue(() => Convert.ToInt32(input))
                .WithMessage("Cannot convert input string into integer")
                .Build();

            Assert.NotNull(actual);
        }
    }
}
