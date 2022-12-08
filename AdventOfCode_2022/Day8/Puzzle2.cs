namespace AdventOfCode_2022.Day8;

internal class Puzzle2 : IPuzzle
{
    public static string PuzzleSolution()
    {
        var treeHeightmap = InputReader.ReadInputResourceAsStringList(Inputs.Day8);
        int visibleTreeCount = CalculateHighestScenicScore(treeHeightmap);

        return visibleTreeCount.ToString();
    }

    private static int CalculateHighestScenicScore(List<string> treeHeightmap)
    {
        int highestScenicScore = 0;

        int rowCount = treeHeightmap.Count;
        int columnCount = treeHeightmap[0].Length;

        for (int rowIndex = 1; rowIndex < rowCount - 1; rowIndex++)
        {
            for (int columnIndex = 1; columnIndex < columnCount - 1; columnIndex++)
            {
                highestScenicScore = Math.Max(highestScenicScore, CalculateScenicScore(treeHeightmap, rowIndex, columnIndex));
            }
        }

        return highestScenicScore;
    }

    private static int CalculateScenicScore(List<string> treeHeightmap, int rowIndex, int columnIndex)
    {
        int visibleTreeCountToWest = CalculateVisibleTreesToWest(treeHeightmap, rowIndex,columnIndex);
        int visibleTreeCountToEast = CalculateVisibleTreesToEast(treeHeightmap, rowIndex,columnIndex);
        int visibleTreeCountToNorth = CalculateVisibleTreesToNorth(treeHeightmap, rowIndex,columnIndex);
        int visibleTreeCountToSouth = CalculateVisibleTreesToSouth(treeHeightmap, rowIndex,columnIndex);

        return visibleTreeCountToWest * visibleTreeCountToEast * visibleTreeCountToNorth * visibleTreeCountToSouth;
    }

    private static int CalculateVisibleTreesToWest(List<string> treeHeightmap, int rowIndex, int columnIndex)
    {
        if (columnIndex == 0)
        {
            return 0;
        }

        int visibleTreeCount = 0;

        int treeHeight = Common.CharToInt(treeHeightmap[rowIndex][columnIndex]);

        for (int i = columnIndex - 1; 0 <= i; i--)
        {
            visibleTreeCount++;
            int otherTreeHeight = Common.CharToInt(treeHeightmap[rowIndex][i]);

            if (treeHeight <= otherTreeHeight)
            {
                break;
            }
        }

        return visibleTreeCount;
    }

    private static int CalculateVisibleTreesToEast(List<string> treeHeightmap, int rowIndex, int columnIndex)
    {
        if (columnIndex == treeHeightmap[0].Length - 1)
        {
            return 0;
        }

        int visibleTreeCount = 0;

        int treeHeight = Common.CharToInt(treeHeightmap[rowIndex][columnIndex]);

        for (int i = columnIndex + 1; i < treeHeightmap[0].Length; i++)
        {
            visibleTreeCount++;
            int otherTreeHeight = Common.CharToInt(treeHeightmap[rowIndex][i]);

            if (treeHeight <= otherTreeHeight)
            {
                break;
            }
        }

        return visibleTreeCount;
    }

    private static int CalculateVisibleTreesToNorth(List<string> treeHeightmap, int rowIndex, int columnIndex)
    {
        if (rowIndex == 0)
        {
            return 0;
        }

        int visibleTreeCount = 0;

        int treeHeight = Common.CharToInt(treeHeightmap[rowIndex][columnIndex]);

        for (int i = rowIndex - 1; 0 <= i; i--)
        {
            visibleTreeCount++;
            int otherTreeHeight = Common.CharToInt(treeHeightmap[i][columnIndex]);

            if (treeHeight <= otherTreeHeight)
            {
                break;
            }
        }

        return visibleTreeCount;
    }

    private static int CalculateVisibleTreesToSouth(List<string> treeHeightmap, int rowIndex, int columnIndex)
    {
        if (rowIndex == treeHeightmap.Count - 1)
        {
            return 0;
        }

        int visibleTreeCount = 0;

        int treeHeight = Common.CharToInt(treeHeightmap[rowIndex][columnIndex]);

        for (int i = rowIndex + 1; i < treeHeightmap.Count; i++)
        {
            visibleTreeCount++;
            int otherTreeHeight = Common.CharToInt(treeHeightmap[i][columnIndex]);

            if (treeHeight <= otherTreeHeight)
            {
                break;
            }
        }

        return visibleTreeCount;
    }
}
