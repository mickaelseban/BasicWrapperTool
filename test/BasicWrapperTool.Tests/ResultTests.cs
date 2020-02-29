namespace BasicWrapperTool.Tests
{
    using Xunit;

    public class ResultTests
    {
        [Theory]
        [ClassData(typeof(ResultTestCtorDataClass))]
        public void Ctor_WithParameters_CorrectState(string errorMessage,
            bool success,
            bool isSuccess,
            bool isFail,
            string expectedErrorMessage)
        {
            // Act
            var actual = new Result(success, errorMessage);

            // Assert
            Assert.NotNull(actual);
            Assert.Equal(isFail, actual.IsFail);
            Assert.Equal(isSuccess, actual.IsSuccess);
            Assert.Equal(expectedErrorMessage, actual.ErrorMessage);
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

        private sealed class ResultTestCtorDataClass : TheoryDataClass
        {
            public ResultTestCtorDataClass()
            {
                this.AddRow("test", false, false, true, "test");
                this.AddRow(null, true, true, false, string.Empty);
            }
        }
    }
}
