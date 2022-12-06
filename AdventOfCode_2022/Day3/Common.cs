namespace AdventOfCode_2022.Day3;

internal class Common
{
    public static int CalculateItemValue(char duplicateItem)
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
