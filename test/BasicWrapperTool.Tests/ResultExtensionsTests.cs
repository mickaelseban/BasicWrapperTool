using System;
using Xunit;

namespace BasicWrapperTool.Tests
{
    public class ResultExtensionsTests
    {
        [Fact]
        public void Create_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            var input = "3".ToMaybe();

            // Act
            var actual = input
                .FromMaybe("input cannot be null",
                    () => ResultExtensions.Try<int>(
                        () => Convert.ToInt32(input))
               );

            // Assert
            Assert.NotNull(actual);
            Assert.True(actual.IsSuccess);
            Assert.False(actual.IsFail);
            Assert.Equal(3, actual.Value);
        }
    }
}
