namespace BasicWrapperTool.Tests
{
    using Moq;
    using Xunit;

    public class ResultExtensionsTests
    {
        [Fact]
        public void FromMaybe_WithMaybeWithValueAndResultWithValueSuccess_ResultWithValueSuccess()
        {
            // Arrange
            var maybeMock = new Mock<IMaybe<string>>();
            maybeMock.Setup(m => m.Value).Returns("3");
            maybeMock.Setup(m => m.HasValue).Returns(true);
            maybeMock.Setup(m => m.HasNoValue).Returns(false);

            var resultMock = new Mock<IResult<int>>();
            resultMock.Setup(m => m.Value).Returns(3);
            resultMock.Setup(m => m.IsSuccess).Returns(true);
            resultMock.Setup(m => m.IsFail).Returns(false);

            // Act
            var actual = maybeMock.Object.FromMaybe("input cannot be null", () => resultMock.Object);

            // Assert
            Assert.NotNull(actual);
            Assert.True(actual.IsSuccess);
            Assert.False(actual.IsFail);
            Assert.Equal(3, actual.Value);
        }
    }
}
