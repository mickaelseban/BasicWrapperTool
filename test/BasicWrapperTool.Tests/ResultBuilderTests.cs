namespace BasicWrapperTool.Tests
{
    using System.Linq;
    using Xunit;

    public class ResultBuilderTests
    {
        [Fact]
        public void Build_WithFunctionThatWillThrowAnException_ShouldResultFail()
        {
            // Arrange
            string stub = null;

            // Act
            var sut = new ResultBuilder()
                .Ensure(() => stub.Contains("a"), "fail message")
                .Build();

            // Assert
            Assert.True(sut.IsFail);
            Assert.Single(sut.Messages);
        }

        [Fact]
        public void Build_WithMessages_ShouldResultFail()
        {
            // Arrange Act
            var sut = new ResultBuilder()
                .Ensure(() => default(string) != null, "fail message")
                .Ensure(() => default(string) != null, "fail message 2")
                .Build();

            // Assert
            Assert.True(sut.IsFail);
            Assert.Equal(2, sut.Messages.Count());
        }

        [Fact]
        public void Build_WithoutMessages_ShouldResultSuccess()
        {
            // Arrange Act
            var sut = new ResultBuilder()
                .Ensure(() => default(string) == null, "fail message")
                .Build();

            // Assert
            Assert.True(sut.IsSuccess);
            Assert.Empty(sut.Messages);
        }

        [Fact]
        public void BuildTyped_WithMessages_ShouldResultFail()
        {
            // Arrange Act
            var sut = new ResultBuilder()
                .Ensure(() => default(string) != null, "fail message")
                .Ensure(() => default(string) != null, "fail message 2")
                .Build("value");

            // Assert
            Assert.True(sut.IsFail);
            Assert.Equal(2, sut.Messages.Count());
            Assert.Null(sut.Value);
        }

        [Fact]
        public void BuildTyped_WithoutMessages_ShouldResultSuccess()
        {
            // Arrange Act
            var sut = new ResultBuilder()
                .Ensure(() => default(string) == null, "fail message")
                .Build("value");

            // Assert
            Assert.True(sut.IsSuccess);
            Assert.Empty(sut.Messages);
            Assert.Equal("value", sut.Value);
        }

        [Fact]
        public void Ensure_ValidationFalse_ShouldAddMessage()
        {
            // Arrange Act
            var sut = new ResultBuilder()
                .Ensure(() => default(string) != null, "fail message")
                .Build("value");

            // Assert
            Assert.True(sut.IsFail);
            Assert.Single(sut.Messages);
        }

        [Fact]
        public void Ensure_ValidationTrue_ShouldNotAddMessage()
        {
            // Arrange Act
            var sut = new ResultBuilder()
                .Ensure(() => default(string) == null, "fail message")
                .Build("value");

            // Assert
            Assert.True(sut.IsSuccess);
            Assert.Empty(sut.Messages);
        }

        [Fact]
        public void EnsureNotNull_InputValidationNotNull_ShouldNotAddMessage()
        {
            // Arrange Act
            var sut = new ResultBuilder()
                .EnsureNotNull("", "fail message")
                .Build("value");

            // Assert
            Assert.True(sut.IsSuccess);
            Assert.Empty(sut.Messages);
        }

        [Fact]
        public void EnsureNotNull_InputValidationNull_ShouldAddMessage()
        {
            // Arrange Act
            var sut = new ResultBuilder()
                .EnsureNotNull(default(string), "fail message")
                .Build("value");

            // Assert
            Assert.True(sut.IsFail);
            Assert.Single(sut.Messages);
        }
    }
}
