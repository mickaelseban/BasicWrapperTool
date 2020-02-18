namespace BasicWrapperTool.Tests.Logic
{
    using BasicWrapperTool.Logic;
    using Xunit;

    public class MaybeTests
    {
        [Fact]
        public void Ctor_Default_CorrectState()
        {
            // Arrange & Act
            var actual = new Maybe<string>();

            // Assert
            Assert.NotNull(actual);
            Assert.Null(actual.Value);
            Assert.True(actual.HasNoValue);
            Assert.False(actual.HasValue);
        }

        [Fact]
        public void Ctor_WithString_CorrectState()
        {
            // Arrange & Act
            const string maybeContent = "test";
            var actual = new Maybe<string>(maybeContent);

            // Assert
            Assert.NotNull(actual);
            Assert.NotNull(actual.Value);
            Assert.False(actual.HasNoValue);
            Assert.True(actual.HasValue);
        }
    }
}
