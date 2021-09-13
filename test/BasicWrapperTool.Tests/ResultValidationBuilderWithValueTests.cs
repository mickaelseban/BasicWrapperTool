using System.Linq;
using Xunit;

namespace BasicWrapperTool.Tests
{
    public class ResultValidationBuilderWithValueTests
    {
        [Fact]
        public void Build_WithAllResultsFail_Fail()
        {
            // Act
            var sut = new ResultValidationBuilder();
            var stub = Result<string>.Fail("test");
            var stub2 = Result<string>.Fail("test2");
            var stub3 = Result<string>.Fail("test3");
            const string expectedValue = "expectedValue";

            // Arrange
            var actual = sut.AddResult(stub).AddResult(stub2).AddResult(stub3).Build(expectedValue);

            // Assert
            Assert.NotNull(actual);
            Assert.True(actual.IsFail);
            Assert.Equal(3, actual.Messages.Count());
        }

        [Fact]
        public void Build_WithAllResultsSuccess_Success()
        {
            // Act
            var sut = new ResultValidationBuilder();
            var stub = Result<string>.Success("test");
            var stub2 = Result<string>.Success("test2");
            const string expectedValue = "expectedValue";

            // Arrange
            var actual = sut.AddResult(stub).AddResult(stub2).Build(expectedValue);

            // Assert
            Assert.NotNull(actual);
            Assert.True(actual.IsSuccess);
            Assert.Empty(actual.Messages);
        }

        [Fact]
        public void Build_WithOneResultFail_Fail()
        {
            // Act
            var sut = new ResultValidationBuilder();
            var stub = Result<string>.Success("test");
            var stub2 = Result<string>.Success("test2");
            var stub3 = Result<string>.Fail("test3");
            const string expectedValue = "expectedValue";

            // Arrange
            var actual = sut.AddResult(stub).AddResult(stub2).AddResult(stub3).Build(expectedValue);

            // Assert
            Assert.NotNull(actual);
            Assert.True(actual.IsFail);
            Assert.Single(actual.Messages);
        }
    }
}