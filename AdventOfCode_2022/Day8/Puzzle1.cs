namespace AdventOfCode_2022.Day8;

internal class Puzzle1 : IPuzzle
{
    public static string PuzzleSolution()
    {
        var treeHeightmap = InputReader.ReadInputResourceAsStringList(Inputs.Day8);
        int visibleTreeCount = CalculateNumberOfVisibleTrees(treeHeightmap);

        return visibleTreeCount.ToString();
    }

    private static int CalculateNumberOfVisibleTrees(List<string> treeHeightmap)
    {
        int visibleTreeCount = 0;

        for (int rowIndex = 0; rowIndex < treeHeightmap.Count; rowIndex++)
        {
            for (int columnIndex = 0; columnIndex < treeHeightmap[0].Length; columnIndex++)
            {
                if (IsTreeVisibleFromAnyDirection(treeHeightmap, rowIndex, columnIndex))
                {
                    visibleTreeCount++;
                }
            }
        }

        return visibleTreeCount;
    }

    private static bool IsTreeVisibleFromAnyDirection(List<string> treeHeightmap, int rowIndex, int columnIndex)
    {
        return IsTreeVisibleFromWest(treeHeightmap, rowIndex, columnIndex) ||
            IsTreeVisibleFromEast(treeHeightmap, rowIndex, columnIndex) ||
            IsTreeVisibleFromNorth(treeHeightmap, rowIndex, columnIndex) ||
            IsTreeVisibleFromSouth(treeHeightmap, rowIndex, columnIndex);
    }

    private static bool IsTreeVisibleFromWest(List<string> treeHeightmap, int rowIndex, int columnIndex)
    {
        if (columnIndex == 0)
        {
            return true;
        }

        int treeHeight = Common.CharToInt(treeHeightmap[rowIndex][columnIndex]);

        for (int i = columnIndex - 1; 0 <= i; i--)
        {
            int otherTreeHeight = Common.CharToInt(treeHeightmap[rowIndex][i]);

            if (treeHeight <= otherTreeHeight)
            {
                return false;
            }
        }

        return true;
    }

    private static bool IsTreeVisibleFromEast(List<string> treeHeightmap, int rowIndex, int columnIndex)
    {
        if (columnIndex == treeHeightmap[0].Length)
        {
            return true;
        }

        int treeHeight = Common.CharToInt(treeHeightmap[rowIndex][columnIndex]);

        for (int i = columnIndex + 1; i < treeHeightmap[0].Length; i++)
        {
            int otherTreeHeight = Common.CharToInt(treeHeightmap[rowIndex][i]);

            if (treeHeight <= otherTreeHeight)
            {
                return false;
            }
        }

        return true;
    }

    private static bool IsTreeVisibleFromNorth(List<string> treeHeightmap, int rowIndex, int columnIndex)
    {
        if (rowIndex == 0)
        {
            return true;
        }

        int treeHeight = Common.CharToInt(treeHeightmap[rowIndex][columnIndex]);

        for (int i = rowIndex - 1; 0 <= i; i--)
        {
            int otherTreeHeight = Common.CharToInt(treeHeightmap[i][columnIndex]);

            if (treeHeight <= otherTreeHeight)
            {
                return false;
            }
        }

        return true;
    }

    private static bool IsTreeVisibleFromSouth(List<string> treeHeightmap, int rowIndex, int columnIndex)
    {
        if (rowIndex == treeHeightmap.Count)
        {
            return true;
        }

        int treeHeight = Common.CharToInt(treeHeightmap[rowIndex][columnIndex]);

        for (int i = rowIndex + 1; i < treeHeightmap.Count; i++)
        {
            int otherTreeHeight = Common.CharToInt(treeHeightmap[i][columnIndex]);

            if (treeHeight <= otherTreeHeight)
            {
                return false;
            }
        }

        return true;
    }
}
