namespace AdventOfCode_2022.Day6;

internal class Puzzle1 : IPuzzle
{
    public static string PuzzleSolution()
    {
        string signal = InputReader.ReadInputResourceAsStringList(Inputs.Day6).First();
        int startOfPacketIndex = Common.GetFirstDistinctCharactersIndex(signal, 4);

        return startOfPacketIndex.ToString();
    }
}
