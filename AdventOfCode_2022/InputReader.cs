namespace AdventOfCode_2022;
internal class InputReader
{
    public static List<string> ReadInputResourceAsStringList(string inputResource)
    {
        return inputResource
            .Split("\r\n", StringSplitOptions.RemoveEmptyEntries)
            .ToList();
    }
    public static List<string> ReadInputResourceAsStringListIncludedEmptyRows(string inputResource)
    {
        return inputResource
            .Split("\r\n")
            .ToList();
    }

    public static List<int> ReadInputResourceAsIntList(string inputResource)
    {
        var inputAsStringList = ReadInputResourceAsStringList(inputResource);

        return inputAsStringList
            .Select(row => int.Parse(row))
            .ToList();
    }
}
