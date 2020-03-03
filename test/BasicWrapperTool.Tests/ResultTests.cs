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
            IResult<string> result = Result<string>.Success("test");
            IResult<int> result2 = Result<int>.Success(123);
            Func<string, IResult<int>> func = x => result2;

            // Act
            var actual = result.Bind(func);

            // Assert
            Assert.NotNull(actual);
            Assert.IsType<Result<int>>(actual);
            Assert.True(actual.IsSuccess);
            Assert.False(actual.IsFail);
        }

        [Fact]
        public void FromFail_WithParameters_ResultFromFail()
        {
            // Assert
            const string errorMessage = "test";

            // Act
            var actual = Result.Error(errorMessage);

            // Assert
            Assert.NotNull(actual);
            Assert.Equal(errorMessage, actual.ErrorMessage);
            Assert.False(actual.IsSuccess);
            Assert.True(actual.IsFail);
        }

        [Fact]
        public void FromSuccess_WithParameters_ResultFromSuccess()
        {
            // Act
            var actual = Result.Success();

            // Assert
            Assert.NotNull(actual);
            Assert.Equal(string.Empty, actual.ErrorMessage);
            Assert.True(actual.IsSuccess);
            Assert.False(actual.IsFail);
        }

        [Fact]
        public void Map_WithResult1AndResult2Success_ResultSuccess()
        {
            // Arrange
            IResult<string> result = Result<string>.Success("test");
            IResult<int> result2 = Result<int>.Success(123);
            Func<string, int> func = x => result2.Value;

            // Act
            var actual = result.Map(func);

            // Assert
            Assert.NotNull(actual);
            Assert.IsType<Result<int>>(actual);
            Assert.True(actual.IsSuccess);
            Assert.False(actual.IsFail);
        }
    }
}
