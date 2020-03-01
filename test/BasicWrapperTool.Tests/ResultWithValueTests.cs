namespace BasicWrapperTool.Tests
{
    using Xunit;

    public class ResultWithValueTests
    {
        [Fact]
        public void FromFail_WithParameters_ResultFromFail()
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
        public void FromSuccess_WithParameters_ResultFromSuccess()
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
