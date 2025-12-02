namespace Day2;

public class Test1Tests
{
    [Fact]
    public void TestSample()
    {
        Program.Test1(Helper.GetFileContents(FileType.Test1Sample)).ShouldBe(Program.Test1SampleResult);
    }

    [Theory]
    [InlineData("11", true)]
    [InlineData("115", false)]
    [InlineData("1010", true)]
    [InlineData("1188511885", true)]
    [InlineData("222222", true)]
    [InlineData("446446", true)]
    [InlineData("38593859", true)]
    public void TestStep1(string input, bool result)
    {
        Program.IsMatch(long.Parse(input))
         .ShouldBe(result);
        // arrange
        // act
        // assert
    }

    [Theory]
    [InlineData(11, 22, new long[] { 11, 22 })]
    [InlineData(95, 115, new long[] { 99 })]
    [InlineData(998, 1012, new long[] { 1010 })]
    [InlineData(1188511880, 1188511890, new long[] { 1188511885 })]
    [InlineData(222220, 222224, new long[] { 222222 })]
    [InlineData(1698522, 1698528, new long[] { })]
    [InlineData(446443, 446449, new long[] { 446446 })]
    [InlineData(38593856, 38593862, new long[] { 38593859 })]
    public void TestStep2(long start, long end, long[] result)
    {
        Program.GetValidInRange(start, end)
         .ShouldBe(result);
    }
}
