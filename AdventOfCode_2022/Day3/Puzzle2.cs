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
            prioritySum += CalculateItemValue(badgeItem);
        }

        return prioritySum.ToString();
    }

    private static char GetCommonItem(string rucksack1, string rucksack2, string rucksack3)
    {
        var items = new Dictionary<char, int>();

        rucksack1.ToHashSet().ToList().ForEach(item => _ = items.ContainsKey(item) ? items[item]++ : items[item] = 1);
        rucksack2.ToHashSet().ToList().ForEach(item => _ = items.ContainsKey(item) ? items[item]++ : items[item] = 1);
        rucksack3.ToHashSet().ToList().ForEach(item => _ = items.ContainsKey(item) ? items[item]++ : items[item] = 1);

        return items
            .Where(i => i.Value == 3)
            .First()
            .Key;
    }

    private static int CalculateItemValue(char duplicateItem)
    {
        // Lowercase letter
        if ('a' <= duplicateItem && duplicateItem <= 'z')
        {
            return duplicateItem - 'a' + 1;
        }

        // Uppercase letter
        else
        {
            return duplicateItem - 'A' + 27;
        }
    }
}
