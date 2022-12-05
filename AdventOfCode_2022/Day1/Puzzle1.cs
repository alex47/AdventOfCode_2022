namespace AdventOfCode_2022.Day1;

internal class Puzzle1 : IPuzzle
{
    public static string PuzzleSolution()
    {
        var calories = InputReader.ReadInputResourceAsStringListIncludedEmptyRows(Inputs.Day1);

        int maxCaloriesSum = 0;
        int currentCaloriesSum = 0;

        for (int i = 0; i < calories.Count; i++)
        {
            if (string.IsNullOrEmpty(calories[i]))
            {
                maxCaloriesSum = Math.Max(maxCaloriesSum, currentCaloriesSum);
                currentCaloriesSum = 0;
            }
            else
            {
                currentCaloriesSum += int.Parse(calories[i]);
            }
        }

        return maxCaloriesSum.ToString();
    }
}
