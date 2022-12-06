namespace AdventOfCode_2022.Day3;

internal class Puzzle2 : IPuzzle
{
    public static string PuzzleSolution()
    {
        var rucksacks = InputReader.ReadInputResourceAsStringList(Inputs.Day3);
        int prioritySum = 0;

        for (int i = 0; i < rucksacks.Count; i += 3)
        {
            char badgeItem = GetCommonItem(rucksacks[i], rucksacks[i + 1], rucksacks[i + 2]);
            prioritySum += Common.CalculateItemValue(badgeItem);
        }

        return prioritySum.ToString();
    }

    private static char GetCommonItem(string rucksack1, string rucksack2, string rucksack3)
    {
        var items = new Dictionary<char, int>();

        rucksack1.Distinct().ToList().ForEach(item => _ = items.ContainsKey(item) ? items[item]++ : items[item] = 1);
        rucksack2.Distinct().ToList().ForEach(item => _ = items.ContainsKey(item) ? items[item]++ : items[item] = 1);
        rucksack3.Distinct().ToList().ForEach(item => _ = items.ContainsKey(item) ? items[item]++ : items[item] = 1);

        return items
            .Where(i => i.Value == 3)
            .First()
            .Key;
    }
}
