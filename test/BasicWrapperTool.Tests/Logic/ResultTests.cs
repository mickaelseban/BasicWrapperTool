namespace BasicWrapperTool.Tests.Logic
{
    using BasicWrapperTool.Logic;
    using System.Collections.Generic;
    using System.Linq;
    using Xunit;

    public class ResultTests
    {
        [Theory]
        [ClassData(typeof(ResultTestCtorDataClass))]
        public void Ctor_WithParameters_CorrectState(List<string> messages,
            bool success,
            bool isSuccess,
            bool isFail,
            List<string> expectedMessages)
        {
            // Act
            var actual = new Result(success, messages);

            // Assert
            Assert.NotNull(actual);
            Assert.Equal(isFail, actual.IsFail);
            Assert.Equal(isSuccess, actual.IsSuccess);
            Assert.Equal(expectedMessages, actual.Messages);
        }

        [Fact]
        public void FromFail_WithParameters_ResultFromFail()
        {
            // Act
            var messages = new[] { "test" }.ToList();

            var actual = Result.FromFail(messages);

            // Assert
            Assert.NotNull(actual);
            Assert.Equal(messages, actual.Messages);
            Assert.False(actual.IsSuccess);
            Assert.True(actual.IsFail);
        }

        [Fact]
        public void FromSuccess_WithParameters_ResultFromSuccess()
        {
            var expectedMessages = new List<string>();
            // Act
            var actual = Result.FromSuccess();

            // Assert
            Assert.NotNull(actual);
            Assert.Equal(expectedMessages.AsReadOnly(), actual.Messages);
            Assert.True(actual.IsSuccess);
            Assert.False(actual.IsFail);
        }

        private class ResultTestCtorDataClass : TheoryDataClass
        {
            public ResultTestCtorDataClass()
            {
                this.AddRow(new[] { "test" }.ToList(), false, false, true, new[] { "test" }.ToList());
                this.AddRow(null, true, true, false, new List<string>());
            }
        }
    }
}
