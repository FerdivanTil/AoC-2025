

namespace Day3;

public class Test1Tests
{
    [Fact]
    public void TestSample()
    {
        Program.Test1(Helper.GetFileContents(FileType.Test1Sample)).ShouldBe(Program.Test1SampleResult);
    }

    [Theory]
    [InlineData("987654321111111", 98)]
    [InlineData("811111111111119", 89)]
    [InlineData("234234234234278", 78)]
    [InlineData("818181911112111", 92)]
    public void TestStep1(string input, int result)
    {
        Program
            .GetLargestJoltage(input)
            .ShouldBe(result);
        // arrange
        // act
        // assert
    }
}
