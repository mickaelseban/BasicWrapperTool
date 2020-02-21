namespace BasicWrapperTool.Tests
{
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
            bool hasMessages,
            bool hasNoMessages,
            List<string> expectedMessages)
        {
            // Act
            var actual = new Result(success, messages);

            // Assert
            Assert.NotNull(actual);
            Assert.Equal(isFail, actual.IsFail);
            Assert.Equal(isSuccess, actual.IsSuccess);
            Assert.Equal(hasMessages, actual.HasMessages);
            Assert.Equal(hasNoMessages, actual.HasNoMessages);
            Assert.Equal(expectedMessages, actual.Messages);
        }

        [Fact]
        public void FromFail_WithParameters_ResultFromFail()
        {
            // Assert
            var messages = new[] { "test" }.ToList();

            // Act
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
            // Act
            var actual = Result.FromSuccess();

            // Assert
            Assert.NotNull(actual);
            Assert.Equal((new List<string>()).AsReadOnly(), actual.Messages);
            Assert.True(actual.IsSuccess);
            Assert.False(actual.IsFail);
        }

        private sealed class ResultTestCtorDataClass : TheoryDataClass
        {
            public ResultTestCtorDataClass()
            {
                this.AddRow(new[] { "test" }.ToList(), false, false, true, true, false, new[] { "test" }.ToList());
                this.AddRow(null, true, true, false, false, true, new List<string>());
            }
        }
    }
}
