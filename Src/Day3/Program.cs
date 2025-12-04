namespace Day3;

internal static class Program
{
    public static int Test1SampleResult = 357;
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
        return input.Select(GetLargestJoltage).Sum();
    }

    internal static int Test2(List<string> input)
    {
        throw new NotImplementedException();
        return 0;
    }

    public static int GetLargestJoltage(string input)
    {
        var joltages = input
            .AsEnumerable()
            .Select(x => int.Parse(x.ToString()))
            .ToList();
        var max = 0;
        foreach (var index in Enumerable.Range(0, joltages.Count))
        {
            var first = joltages[index];
            foreach(var secondIndex in Enumerable.Range(index +1 , joltages.Count - index -1))
            {
                //Console.WriteLine($"Getting {index},{secondIndex}");
                var second = joltages[secondIndex];
                var joltage = first * 10 + second;
                if (joltage > max)
                {
                    max = joltage;
                }
            }
        }
        return max;
    }
}
