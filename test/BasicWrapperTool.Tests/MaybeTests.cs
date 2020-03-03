namespace BasicWrapperTool.Tests
{
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

        [Fact]
        public void ExplicitOperator_WithValue_ReturnsMaybe()
        {
            // Arrange
            const string value = "test";

            // Act
            var actual = (Maybe<string>)value;

            // Assert
            Assert.NotNull(actual);
            Assert.IsType<Maybe<string>>(actual);
            Assert.Equal(value, actual.Value);
        }

        [Fact]
        public void ImplicitOperator_WithMaybe_ReturnsValue()
        {
            // Arrange
            const string value = "test";
            var maybe = new Maybe<string>(value);

            // Act
            string actual = maybe;

            // Assert
            Assert.NotNull(actual);
            Assert.IsType<string>(actual);
            Assert.Equal(value, value);
        }
    }
}
