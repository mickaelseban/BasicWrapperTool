namespace BasicWrapperTool.Tests
{
    using System;
    using Xunit;

    public class ResultTests
    {
        [Fact]
        public void Bind_WithResult1AndResult2Success_ResultSuccess()
        {
            // Arrange
            Result<string> result = Result<string>.Success("test");
            Result<int> result2 = Result<int>.Success(123);
            Func<string, Result<int>> func = x => result2;

            // Act
            Result<int> actual = result.Bind(func);

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
            Result<string> result = Result<string>.Success("test");

            // Act
            string actual = (string)result;

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
            Result actual = Result.Fail(failMessage);

            // Assert
            Assert.Equal(failMessage, actual.Message);
            Assert.False(actual.IsSuccess);
            Assert.True(actual.IsFail);
        }

        [Fact]
        public void FromSuccess_WithParameters_ResultFromSuccess()
        {
            // Act
            Result actual = Result.Success();

            // Assert
            Assert.Equal(string.Empty, actual.Message);
            Assert.True(actual.IsSuccess);
            Assert.False(actual.IsFail);
        }

        [Fact]
        public void Map_WithResult1AndResult2Success_ResultSuccess()
        {
            // Arrange
            Result<string> result = Result<string>.Success("test");
            Result<int> result2 = Result<int>.Success(123);
            Func<string, int> func = x => result2.Value;

            // Act
            Result<int> actual = result.Map(func);

            // Assert
            Assert.NotNull(actual);
            Assert.IsType<Result<int>>(actual);
            Assert.True(actual.IsSuccess);
            Assert.False(actual.IsFail);
        }
    }
}