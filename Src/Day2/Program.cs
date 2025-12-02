using Businesslogic.Helpers;
using System.Text.RegularExpressions;

namespace Day2;

internal static partial class Program
{
    public static long Test1SampleResult = 1227775554;
    public static long Test2SampleResult = -1;

    static void Main()
    {
        switch (FileType.Test1)
        {
            case FileType.Test1Sample:
                Helper.WriteResult(Test1, FileType.Test1Sample, Test1SampleResult);
                break;
            case FileType.Test1:
                Helper.WriteResult(Test1, FileType.Test1);
                break;
            case FileType.Test2Sample:
                Helper.WriteResult(Test2, FileType.Test2Sample, Test2SampleResult);
                break;
            case FileType.Test2:
                Helper.WriteResult(Test2, FileType.Test2);
                break;
        }
    }

    internal static long Test1(List<string> input)
    {
        var items = ParseRanges(input[0]);
        var result = items
            .SelectMany(range => GetRange(range.start, range.end))
            .Where(i => i.ToString().Length % 2 == 0) // 835 ms - 556 ms saves 279 ms!
            .Where(IsMatch)
            .ToList();
        return result.Sum();
    }

    internal static long Test2(List<string> input)
    {
        throw new NotImplementedException();
        return 0;
    }

    public static List<(long start, long end)> ParseRanges(string line)
    {
        var parts = line.Split(',', StringSplitOptions.RemoveEmptyEntries);
        return [.. parts
            .Select(part => part.Split('-', StringSplitOptions.RemoveEmptyEntries))
            .Select(rangeParts => (start: long.Parse(rangeParts[0]), end: long.Parse(rangeParts[1])))];
    }
    public static List<long> GetRange(long start, long end)
    {
        return [.. EnumerableHelper.Range(start, end - start + 1)];
    }
    public static bool IsMatch(long input)
    {
        var regex = Program.regex();
        return regex.IsMatch(input.ToString());
    }

    [GeneratedRegex(@"^(\d+)\1$")]
    private static partial Regex regex();
}
