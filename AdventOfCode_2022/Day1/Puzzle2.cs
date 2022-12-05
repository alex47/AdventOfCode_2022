namespace AdventOfCode_2022.Day1;
internal class Puzzle2 : IPuzzle
{
    public static string PuzzleSolution()
    {
        var calories = InputReader.ReadInputResourceAsStringListIncludedEmptyRows(Inputs.Day1);

        var maxCaloriesSums = new List<int>(3) { 0, 0, 0 };
        int currentCaloriesSum = 0;

        for (int i = 0; i < calories.Count; i++)
        {
            if (string.IsNullOrEmpty(calories[i]))
            {
                maxCaloriesSums.Add(currentCaloriesSum);

                maxCaloriesSums = maxCaloriesSums
                    .OrderDescending()
                    .Take(3)
                    .ToList();

                currentCaloriesSum = 0;
            }
            else
            {
                currentCaloriesSum += int.Parse(calories[i]);
            }
        }

        return maxCaloriesSums
            .Sum()
            .ToString();
    }
}
