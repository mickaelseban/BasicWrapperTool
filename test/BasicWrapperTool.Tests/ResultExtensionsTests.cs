using System;
using Xunit;

namespace BasicWrapperTool.Tests
{
    public class ResultExtensionsTests
    {
        [Fact]
        public void ConvertMaybe_WithMaybeWithValue_ShouldReturnResultSuccess()
        {
            // Arrange
            var maybe = new Maybe<string>("3");

            // Act
            var actual = maybe.ConvertToResult();

            // Assert
            Assert.NotNull(actual);
            Assert.True(actual.IsSuccess);
        }

        [Fact]
        public void ConvertMaybe_WithMaybeWithNoValue_ShouldReturnResultFail()
        {
            // Arrange
            var maybe = new Maybe<string>(default);

            // Act
            var actual = maybe.ConvertToResult();

            // Assert
            Assert.NotNull(actual);
            Assert.True(actual.IsFail);
        }

        [Fact]
        public void FromMaybe_WithMaybeWithValueAndResultWithValueSuccess_ResultWithValueSuccess()
        {
            // Arrange
            var maybe = new Maybe<string>("3");
            var result = Result<int>.Success(3);

            // Act
            var actual = maybe.FromMaybe("input cannot be null", () => result);

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
            var result = Result<string>.Success("test");
            var result2 = Result<int>.Success(123);
            Func<string, int> func = x => result2.Value;

            // Act
            var actual = result.Select(func);

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
            var result = Result<string>.Success("test");
            var result2 = Result<int>.Success(123);
            Func<string, Result<int>> func = x => result2;

            // Act
            var actual = result.SelectMany(func);

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
            var result = Result<int>.Fail("test");

            // Act
            var actual = result.ToResult();

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
            var result = Result<int>.Success(1);

            // Act
            var actual = result.ToResult();

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
            var actual = func.Try();

            // Assert
            Assert.NotNull(actual);
            Assert.True(actual.IsFail);
            Assert.False(actual.IsSuccess);
            Assert.Equal(default, actual.Value);
            Assert.NotEqual(string.Empty, actual.Message);
        }

        [Fact]
        public void Try_WithFunctionOutResult_ResultSuccess()
        {
            // Arrange
            Func<int> func = () => 1;

            // Act
            var actual = func.Try();

            // Assert
            Assert.NotNull(actual);
            Assert.True(actual.IsSuccess);
            Assert.False(actual.IsFail);
            Assert.Equal(1, actual.Value);
        }
    }
}