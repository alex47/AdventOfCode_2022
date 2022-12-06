namespace AdventOfCode_2022.Day4;

internal class Puzzle1 : IPuzzle
{
    public static string PuzzleSolution()
    {
        var sectionPairs = InputReader.ReadInputResourceAsStringList(Inputs.Day4);
        int fullyContainCount = 0;

        foreach (var sectionPair in sectionPairs)
        {
            if (DoesOneRangeFullyContainOther(sectionPair))
            {
                fullyContainCount++;
            }
        }

        return fullyContainCount.ToString();
    }

    private static bool DoesOneRangeFullyContainOther(string sectionPair)
    {
        var sectionRanges = sectionPair.Split(',');

        var sectionRange1 = sectionRanges[0].Split('-');
        var sectionRange2 = sectionRanges[1].Split('-');

        int sectionRange1Start = int.Parse(sectionRange1[0]);
        int sectionRange1End = int.Parse(sectionRange1[1]);

        int sectionRange2Start = int.Parse(sectionRange2[0]);
        int sectionRange2End = int.Parse(sectionRange2[1]);

        bool doesRange1FullyContainRange2 = sectionRange1Start <= sectionRange2Start && sectionRange2End <= sectionRange1End;
        bool doesRange2FullyContainRange1 = sectionRange2Start <= sectionRange1Start && sectionRange1End <= sectionRange2End;

        return doesRange1FullyContainRange2 || doesRange2FullyContainRange1;
    }
}
