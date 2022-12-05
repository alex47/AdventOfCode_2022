namespace AdventOfCode_2022.Day4;

internal class Puzzle2 : IPuzzle
{
    public static string PuzzleSolution()
    {
        var sectionPairs = InputReader.ReadInputResourceAsStringList(Inputs.Day4);
        int overlapCount = 0;

        for (int i = 0; i < sectionPairs.Count; i++)
        {
            if (DoesOneRangeOverlapOther(sectionPairs[i]))
            {
                overlapCount++;
            }
        }

        return overlapCount.ToString();
    }

    private static bool DoesOneRangeOverlapOther(string sectionPair)
    {
        var sectionRanges = sectionPair.Split(',');

        var sectionRange1 = sectionRanges[0].Split('-');
        var sectionRange2 = sectionRanges[1].Split('-');

        int sectionRange1Start = int.Parse(sectionRange1[0]);
        int sectionRange1End = int.Parse(sectionRange1[1]);

        int sectionRange2Start = int.Parse(sectionRange2[0]);
        int sectionRange2End = int.Parse(sectionRange2[1]);

        bool doesRange1OverlapRange2 = sectionRange1Start <= sectionRange2Start && sectionRange2Start <= sectionRange1End;
        bool doesRange2OverlapRange1 = sectionRange2Start <= sectionRange1Start && sectionRange1Start <= sectionRange2End;

        return doesRange1OverlapRange2 || doesRange2OverlapRange1;
    }
}
