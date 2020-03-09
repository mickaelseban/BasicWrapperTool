namespace BasicWrapperTool.Tests
{
    using System;
    using Xunit;

    public class ResultWithValueTests
    {
        [Fact]
        public void Error_WithParameters_ResultFail()
        {
            // Assert
            const string errorMessage = "test";
            const string expectedErrorMessage = "test";

            // Act
            var actual = Result<string>.Error(errorMessage);

            // Assert
            Assert.NotNull(actual);
            Assert.Equal(default(string), actual.Value);
            Assert.Equal(expectedErrorMessage, actual.ErrorMessage);
            Assert.False(actual.IsSuccess);
            Assert.True(actual.IsFail);
        }

        [Fact]
        public void ErrorFromException_WithException_ResultFail()
        {
            // Assert
            const string message = "test";
            var exception = new Exception(message);

            // Act
            var actual = Result<string>.ErrorFromException(exception);

            // Assert
            Assert.NotNull(actual);
            Assert.Equal(default(string), actual.Value);
            Assert.Equal(message, actual.ErrorMessage);
            Assert.False(actual.IsSuccess);
            Assert.True(actual.IsFail);
        }

        //Exception

        [Fact]
        public void Success_WithParameters_ResultSuccess()
        {
            // Arrange
            const string value = "value test";
            var expectedErrorMessage = string.Empty;
            const string expectedValue = "value test";

            // Act
            var actual = Result<string>.Success(value);

            // Assert
            Assert.NotNull(actual);
            Assert.Equal(expectedValue, actual.Value);
            Assert.Equal(expectedErrorMessage, actual.ErrorMessage);
            Assert.True(actual.IsSuccess);
            Assert.False(actual.IsFail);
        }
    }
}
