namespace BasicWrapperTool.Tests
{
    using Xunit;

    public class ResultWithValueTests
    {
        [Fact]
        public void Fail_WithParameters_ResultFail()
        {
            // Assert
            const string failMessage = "test";
            const string expectedFailMessage = "test";

            // Act
            var actual = Result<string>.Fail(failMessage);

            // Assert
            Assert.Equal(default(string), actual.Value);
            Assert.Equal(expectedFailMessage, actual.Message);
            Assert.False(actual.IsSuccess);
            Assert.True(actual.IsFail);
        }

        [Fact]
        public void Success_WithParameters_ResultSuccess()
        {
            // Arrange
            const string value = "value test";
            var expectedFailMessage = string.Empty;
            const string expectedValue = "value test";

            // Act
            var actual = Result<string>.Success(value);

            // Assert
            Assert.Equal(expectedValue, actual.Value);
            Assert.Equal(expectedFailMessage, actual.Message);
            Assert.True(actual.IsSuccess);
            Assert.False(actual.IsFail);
        }
    }
}
