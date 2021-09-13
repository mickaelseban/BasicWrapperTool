using Xunit;

namespace BasicWrapperTool.Tests
{
    public class MaybeExtensionsTests
    {
        [Fact]
        public void ToMaybe_WithValueTypeString_ReturnsMaybeOfString()
        {
            // Arrange
            const string value = "3";

            // Act
            var actual = value.ToMaybe();

            // Assert
            Assert.NotNull(actual);
            Assert.True(actual.HasValue);
            Assert.False(actual.HasNoValue);
            Assert.Equal(value, actual.Value);
        }
    }
}