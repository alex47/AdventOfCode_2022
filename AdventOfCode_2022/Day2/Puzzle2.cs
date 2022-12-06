namespace AdventOfCode_2022.Day2;

internal class Puzzle2 : IPuzzle
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
            "A X" => 3 + 0, // Rock - Lose (Scissors)
            "A Y" => 1 + 3, // Rock - Draw (Rock)
            "A Z" => 2 + 6, // Rock - Win (Paper)
            "B X" => 1 + 0, // Paper - Lose (Rock)
            "B Y" => 2 + 3, // Paper - Draw (Paper)
            "B Z" => 3 + 6, // Paper - Win (Scissors)
            "C X" => 2 + 0, // Scissors - Lose (Paper)
            "C Y" => 3 + 3, // Scissors - Draw (Scissors)
            "C Z" => 1 + 6, // Scissors - Win (Rock)
            _ => 0,
        };
    }
}
