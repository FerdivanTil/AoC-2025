namespace Template;

public class Test2Tests
{
    [Fact]
    public void TestSample()
    {
        Program.Test2(Helper.GetFileContents(FileType.Test2Sample)).ShouldBe(Program.Test2SampleResult);
    }

    [Theory]
    [InlineData("input", "result")]
    public void TestStep1(string input, string result)
    {
        // arrange
        // act
        // assert
        input.ShouldBe(result);
    }
}
