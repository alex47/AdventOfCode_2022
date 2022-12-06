namespace AdventOfCode_2022.Day2;

internal class Puzzle1 : IPuzzle
{
    public static string PuzzleSolution()
    {
        var rounds = InputReader.ReadInputResourceAsStringList(Inputs.Day2);

        int totalScore = 0;

        foreach (var round in rounds)
        {
            totalScore += CalculateRoundScore(round);
        }

        return totalScore.ToString();
    }

    private static int CalculateRoundScore(string round)
    {
        return round switch
        {
            "A X" => 1 + 3, // Rock - Rock
            "A Y" => 2 + 6, // Rock - Paper
            "A Z" => 3 + 0, // Rock - Scissors
            "B X" => 1 + 0, // Paper - Rock
            "B Y" => 2 + 3, // Paper - Paper
            "B Z" => 3 + 6, // Paper - Scissors
            "C X" => 1 + 6, // Scissors - Rock
            "C Y" => 2 + 0, // Scissors - Paper
            "C Z" => 3 + 3, // Scissors - Scissors
            _ => 0,
        };
    }
}
