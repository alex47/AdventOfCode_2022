namespace AdventOfCode_2022.Day1;

internal class Puzzle1 : IPuzzle
{
    public static string PuzzleSolution()
    {
        var calories = InputReader.ReadInputResourceAsStringListIncludedEmptyRows(Inputs.Day1);

        int maxCaloriesSum = 0;
        int currentCaloriesSum = 0;

        foreach (var calory in calories)
        {
            if (string.IsNullOrEmpty(calory))
            {
                maxCaloriesSum = Math.Max(maxCaloriesSum, currentCaloriesSum);
                currentCaloriesSum = 0;
            }
            else
            {
                currentCaloriesSum += int.Parse(calory);
            }
        }

        return maxCaloriesSum.ToString();
    }
}
