namespace AdventOfCode_2022.Day9;

internal class Puzzle2 : IPuzzle
{
    public static string PuzzleSolution()
    {
        var headMovements = InputReader.ReadInputResourceAsStringList(Inputs.Day9);
        int numberOfUniquePointsVisitedByTail = Common.CalculateNumberOfUniquePointsVisitedByTail(headMovements, 10);

        return numberOfUniquePointsVisitedByTail.ToString();
    }
}
