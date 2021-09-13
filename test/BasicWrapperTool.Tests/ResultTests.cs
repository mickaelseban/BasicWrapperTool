using System;
using Xunit;

namespace BasicWrapperTool.Tests
{
    public class ResultTests
    {
        [Fact]
        public void Bind_WithResult1AndResult2Success_ResultSuccess()
        {
            // Arrange
            var result = Result<string>.Success("test");
            var result2 = Result<int>.Success(123);
            Func<string, Result<int>> func = x => result2;

            // Act
            var actual = result.Bind(func);

            // Assert
            Assert.NotNull(actual);
            Assert.IsType<Result<int>>(actual);
            Assert.True(actual.IsSuccess);
            Assert.False(actual.IsFail);
        }

        [Fact]
        public void ExplicitOperator_WithResult_ReturnsValue()
        {
            // Arrange
            const string value = "test";
            var result = Result<string>.Success("test");

            // Act
            var actual = (string)result;

            // Assert
            Assert.NotNull(actual);
            Assert.IsType<string>(actual);
            Assert.Equal(value, value);
        }

        [Fact]
        public void FromFail_WithParameters_ResultFromFail()
        {
            // Assert
            const string failMessage = "test";

            // Act
            var actual = Result.Fail(failMessage);

            // Assert
            Assert.Equal(failMessage, actual.Message);
            Assert.False(actual.IsSuccess);
            Assert.True(actual.IsFail);
        }

        [Fact]
        public void FromSuccess_WithParameters_ResultFromSuccess()
        {
            // Act
            var actual = Result.Success();

            // Assert
            Assert.Equal(string.Empty, actual.Message);
            Assert.True(actual.IsSuccess);
            Assert.False(actual.IsFail);
        }

        [Fact]
        public void Map_WithResult1AndResult2Success_ResultSuccess()
        {
            // Arrange
            var result = Result<string>.Success("test");
            var result2 = Result<int>.Success(123);
            Func<string, int> func = x => result2.Value;

            // Act
            var actual = result.Map(func);

            // Assert
            Assert.NotNull(actual);
            Assert.IsType<Result<int>>(actual);
            Assert.True(actual.IsSuccess);
            Assert.False(actual.IsFail);
        }

        [Fact]
        public void HasMessages_WithMessage_True()
        {
            // Assert
            const string message = "test";

            // Act
            var actual = Result.Fail(message);

            // Assert
            Assert.True(actual.HasMessages);
        }


        [Fact]
        public void HasMessages_WithoutMessage_False()
        {
            // Act
            var actual = Result.Fail();

            // Assert
            Assert.False(actual.HasMessages);
        }
    }
}