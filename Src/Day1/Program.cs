using System.Diagnostics;

namespace Day1;

internal static partial class Program
{
    public static int Test1SampleResult = 3;
    public static int Test2SampleResult = -1;

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

    internal static int Test1(List<string> input)
    {
        var data = ParseInput(input);
        var current = 50;
        var result = 0;
        foreach(var item in data)
        {
            current += item.Direction == Direction.Left ? -item.Amount : item.Amount;
            current %= 100;
            if (current < 0)
            {
                current += 100;
            }
            if (current == 0)
            {
                result++;
            }
        }
        return result;
    }

    internal static int Test2(List<string> input)
    {
        throw new NotImplementedException();
        return 0;
    }
    internal static List<Rotation> ParseInput(List<string> input)
    {
        var regex = RotationRegex();
        return [.. input
            .Select(i => regex.Match(i))
            .Where(m => m.Success)
            .Select(m => new Rotation
            {
                Direction = m.Groups["Direction"].Value == "L" ? Direction.Left : Direction.Right,
                Amount = int.Parse(m.Groups["Amount"].Value)
            })];
    }

    [DebuggerDisplay("{Direction} {Amount}")]
    internal class Rotation
    {
        public Direction Direction { get; set; }
        public int Amount { get; set; }
    }
    internal enum Direction
    {
        Left,
        Right
    }

    [System.Text.RegularExpressions.GeneratedRegex(@"(?<Direction>L|R)(?<Amount>\d+)")]
    private static partial System.Text.RegularExpressions.Regex RotationRegex();
}
