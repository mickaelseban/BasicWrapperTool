namespace BasicWrapperTool.Tests
{
    using Xunit;

    public class ResultTests
    {
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
    }
}
