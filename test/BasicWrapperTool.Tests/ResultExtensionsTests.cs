namespace BasicWrapperTool.Tests
{
    using Moq;
    using System;
    using Xunit;

    public class ResultExtensionsTests
    {
        [Fact]
        public void FromMaybe_WithMaybeWithValueAndResultWithValueSuccess_ResultWithValueSuccess()
        {
            // Arrange
            Mock<IMaybe<string>> maybeMock = new Mock<IMaybe<string>>();
            maybeMock.Setup(m => m.Value).Returns("3");
            maybeMock.Setup(m => m.HasValue).Returns(true);
            maybeMock.Setup(m => m.HasNoValue).Returns(false);

            Mock<IResult<int>> resultMock = new Mock<IResult<int>>();
            resultMock.Setup(m => m.Value).Returns(3);
            resultMock.Setup(m => m.IsSuccess).Returns(true);
            resultMock.Setup(m => m.IsFail).Returns(false);

            // Act
            IResult<int> actual = maybeMock.Object.FromMaybe("input cannot be null", () => resultMock.Object);

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
            IResult<int> actual = result.Select(func);

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
            Func<string, IResult<int>> func = x => result2;

            // Act
            IResult<int> actual = result.SelectMany(func);

            // Assert
            Assert.NotNull(actual);
            Assert.IsType<Result<int>>(actual);
            Assert.True(actual.IsSuccess);
            Assert.False(actual.IsFail);
        }

        [Fact]
        public void ToResult_ResultFailWithMessages_IResultFailWithoutValue()
        {
            // Arrange
            IResult<int> result = Result<int>.Fail("test");

            // Act
            IResult actual = result.ToResult();

            // Assert
            Assert.NotNull(actual);
            Assert.Equal(result.IsFail, actual.IsFail);
            Assert.Equal(result.IsSuccess, actual.IsSuccess);
            Assert.Equal(result.Messages, actual.Messages);
        }

        [Fact]
        public void ToResult_ResultSuccessWithInteger_IResultSuccessWithoutValue()
        {
            // Arrange
            IResult<int> result = Result<int>.Success(1);

            // Act
            IResult actual = result.ToResult();

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
            IResult<int> actual = func.Try();

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
            IResult<int> actual = func.Try();

            // Assert
            Assert.NotNull(actual);
            Assert.True(actual.IsSuccess);
            Assert.False(actual.IsFail);
            Assert.Equal(1, actual.Value);
        }
    }
}
