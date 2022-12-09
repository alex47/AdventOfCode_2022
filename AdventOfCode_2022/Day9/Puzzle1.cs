namespace AdventOfCode_2022.Day9;

internal class Puzzle1 : IPuzzle
{
    public static string PuzzleSolution()
    {
        var headMovements = InputReader.ReadInputResourceAsStringList(Inputs.Day9);
        int numberOfUniquePointsVisitedByTail = Common.CalculateNumberOfUniquePointsVisitedByTail(headMovements, 2);

        return numberOfUniquePointsVisitedByTail.ToString();
    }
}
