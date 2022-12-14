namespace AdventOfCode_2022.Day6;

internal class Common
{
    public static int GetFirstDistinctCharactersIndex(string text, int characterCount)
    {
        for (int i = 0; i < text.Length; i++)
        {
            string slice = text.Substring(i, characterCount);

            if (slice.Distinct().Count() == characterCount)
            {
                return (i + characterCount);
            }
        }

        throw new Exception("This should never happen");
    }
}
