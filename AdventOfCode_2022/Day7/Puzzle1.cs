namespace AdventOfCode_2022.Day7;

internal class Puzzle1 : IPuzzle
{
    public static string PuzzleSolution()
    {
        var commandsAndOutputs = InputReader.ReadInputResourceAsStringList(Inputs.Day7);
        
        var rootDirectory = Common.BuildFileSystem(commandsAndOutputs);
        Common.CalculateDirectorySizes(rootDirectory);
        
        int sumOfTotalDirectorySizes = GetSumOfTotalDirectorySizes_WhereLessThan100K(rootDirectory);

        return sumOfTotalDirectorySizes.ToString();
    }

    public static int GetSumOfTotalDirectorySizes_WhereLessThan100K(Common.Directory directory)
    {
        int subDirectoriesTotalSize = directory.SubDirectories.Sum(GetSumOfTotalDirectorySizes_WhereLessThan100K);
        return directory.Size <= 100000 ? directory.Size + subDirectoriesTotalSize : subDirectoriesTotalSize;
    }
}
