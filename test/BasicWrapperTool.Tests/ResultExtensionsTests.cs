namespace BasicWrapperTool.Tests
{
    using System;
    using Xunit;

    public class ResultExtensionsTests
    {
        [Fact]
        public void FromMaybe_WithMaybeWithValueAndResultWithValueSuccess_ResultWithValueSuccess()
        {
            // Arrange
            var maybe = new Maybe<string>("3");
            var result = Result<int>.Success(3);

            // Act
            Result<int> actual = maybe.FromMaybe("input cannot be null", () => result);

            // Assert
            Assert.NotNull(actual);
            Assert.True(actual.IsSuccess);
            Assert.False(actual.IsFail);
            Assert.Equal(3, actual.Value);
        }

        [Fact]
        public void Select_WithFunctionSource_ReturnResultSuccess()
        {
            // Arrange
            Result<string> result = Result<string>.Success("test");
            Result<int> result2 = Result<int>.Success(123);
            Func<string, int> func = x => result2.Value;

            // Act
            Result<int> actual = result.Select(func);

            // Assert
            Assert.NotNull(actual);
            Assert.IsType<Result<int>>(actual);
            Assert.True(actual.IsSuccess);
            Assert.False(actual.IsFail);
        }

        [Fact]
        public void SelectMany_WithFunctionResultSource_ReturnResultSuccess()
        {
            // Arrange
            Result<string> result = Result<string>.Success("test");
            Result<int> result2 = Result<int>.Success(123);
            Func<string, Result<int>> func = x => result2;

            // Act
            Result<int> actual = result.SelectMany(func);

            // Assert
            Assert.NotNull(actual);
            Assert.IsType<Result<int>>(actual);
            Assert.True(actual.IsSuccess);
            Assert.False(actual.IsFail);
        }

        [Fact]
        public void ToResult_ResultFailWithMessages_ResultFailWithoutValue()
        {
            // Arrange
            Result<int> result = Result<int>.Fail("test");

            // Act
            Result actual = result.ToResult();

            // Assert
            Assert.NotNull(actual);
            Assert.Equal(result.IsFail, actual.IsFail);
            Assert.Equal(result.IsSuccess, actual.IsSuccess);
            Assert.Equal(result.Messages, actual.Messages);
        }

        [Fact]
        public void ToResult_ResultSuccessWithInteger_ResultSuccessWithoutValue()
        {
            // Arrange
            Result<int> result = Result<int>.Success(1);

            // Act
            Result actual = result.ToResult();

            // Assert
            Assert.NotNull(actual);
            Assert.Equal(result.IsFail, actual.IsFail);
            Assert.Equal(result.IsSuccess, actual.IsSuccess);
            Assert.Equal(result.Messages, actual.Messages);
        }

        [Fact]
        public void Try_WithFunctionOutResult_ResultFailWithMessage()
        {
            // Arrange
            Func<int> func = () => Convert.ToInt32("test");

            // Act
            Result<int> actual = func.Try();

            // Assert
            Assert.NotNull(actual);
            Assert.True(actual.IsFail);
            Assert.False(actual.IsSuccess);
            Assert.Equal(default(int), actual.Value);
            Assert.NotEqual(string.Empty, actual.Message);
        }

        [Fact]
        public void Try_WithFunctionOutResult_ResultSuccess()
        {
            // Arrange
            Func<int> func = () => 1;

            // Act
            Result<int> actual = func.Try();

            // Assert
            Assert.NotNull(actual);
            Assert.True(actual.IsSuccess);
            Assert.False(actual.IsFail);
            Assert.Equal(1, actual.Value);
        }
    }
}