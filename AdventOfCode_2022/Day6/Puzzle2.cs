namespace AdventOfCode_2022.Day6;

internal class Puzzle2 : IPuzzle
{
    public static string PuzzleSolution()
    {
        string signal = InputReader.ReadInputResourceAsStringList(Inputs.Day6).First();
        int startOfMessageIndex = Common.GetFirstDistinctCharactersIndex(signal, 14);

        return startOfMessageIndex.ToString();
    }
}
