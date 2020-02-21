namespace BasicWrapperTool.Tests
{
    using System.Collections.Generic;
    using System.Linq;
    using Xunit;

    public class ResultWithValueTests
    {
        [Theory]
        [ClassData(typeof(ResultWithValueTestCtorDataClass))]
        public void CtorWithValue_WithParameters_CorrectState(string value,
            List<string> messages,
            bool success,
            bool isSuccess,
            bool isFail,
            bool hasMessages,
            bool hasNoMessages,
            List<string> expectedMessages,
            string expectedValue)
        {
            // Act
            var actual = new Result<string>(value, success, messages);

            // Assert
            Assert.NotNull(actual);
            Assert.Equal(isFail, actual.IsFail);
            Assert.Equal(isSuccess, actual.IsSuccess);
            Assert.Equal(hasMessages, actual.HasMessages);
            Assert.Equal(hasNoMessages, actual.HasNoMessages);
            Assert.Equal(expectedMessages, actual.Messages);
            Assert.Equal(expectedValue, value);
        }

        [Fact]
        public void FromFail_WithParameters_ResultFromFail()
        {
            // Assert
            var messages = new[] { "test" }.ToList();

            // Act
            var actual = Result<string>.FromFail(messages);

            // Assert
            Assert.NotNull(actual);
            Assert.Equal(messages, actual.Messages);
            Assert.False(actual.IsSuccess);
            Assert.True(actual.IsFail);
        }

        [Fact]
        public void FromSuccess_WithParameters_ResultFromSuccess()
        {
            // Arrange
            const string value = "value test";

            // Act
            var actual = Result<string>.FromSuccess(value);

            // Assert
            Assert.NotNull(actual);
            Assert.Equal((new List<string>()).AsReadOnly(), actual.Messages);
            Assert.True(actual.IsSuccess);
            Assert.False(actual.IsFail);
        }

        private sealed class ResultWithValueTestCtorDataClass : TheoryDataClass
        {
            public ResultWithValueTestCtorDataClass()
            {
                this.AddRow(default(string), new[] { "test" }.ToList(), false, false, true, true, false, new[] { "test" }.ToList(), default(string));
                this.AddRow("value test", null, true, true, false, false, true, new List<string>(), "value test");
            }
        }
    }
}
