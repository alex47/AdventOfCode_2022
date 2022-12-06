namespace AdventOfCode_2022.Day3;

internal class Puzzle1 : IPuzzle
{
    public static string PuzzleSolution()
    {
        var rucksacks = InputReader.ReadInputResourceAsStringList(Inputs.Day3);
        int prioritySum = 0;

        foreach (var rucksack in rucksacks)
        {
            char duplicateItem = GetDuplicateItem(rucksack);
            prioritySum += CalculateItemValue(duplicateItem);
        }
        
        return prioritySum.ToString();
    }

    private static char GetDuplicateItem(string rucksack)
    {
        int compartmentLength = rucksack.Length / 2;

        var compartment1 = rucksack[..compartmentLength];
        var compartment2 = rucksack[compartmentLength..];

        foreach (var item in compartment1)
        {
            if(compartment2.Contains(item))
            {
                return item;
            }
        }

        throw new Exception("This should never happen.");
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
